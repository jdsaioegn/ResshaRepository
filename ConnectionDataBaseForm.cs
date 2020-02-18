using ResshaDataBaseTools.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ResshaDataBaseTools
{
    /// <summary>
    /// 指定先データベース接続画面
    /// </summary>
    public partial class ConnectionDataBaseForm : Form
    {
        /// <summary>
        /// トレースロガー
        /// </summary>
        private readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 最終接続ユーザ自動ログイン機能フラグ
        /// </summary>
        private string _PreservationUserFlg = "";

        /// <summary>
        /// ログインパスワード
        /// </summary>
        private string _Password = "";

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConnectionDataBaseForm()
        {
            InitializeComponent();
        }

        #region 初期表示設定
        /// <summary>
        /// 画面起動時発生イベント
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void LoadForm(object sender, EventArgs e)
        {
            // 外部設定ファイル読み込み
            SettingFile xml = new SettingFile();

            // ConnectionType要素設定解析
            switch (xml.ConnectionType)
            {
                // "Windows"が設定されている場合
                case "Windows":
                    // Windows認証側のチェックボックスを初期表示でチェック済
                    radioButtonWindowsConnection.Checked = true;
                    // 抜け
                    break;

                // "SQL"が設定されている場合
                case "SQL":
                    // SQL Server認証側のチェックボックスを初期表示でチェック済
                    radioButtonSQLConnection.Checked = true;
                    // ログインユーザ入力項目を活性化
                    textBoxLoginUserName.Enabled = true;
                    // 抜け
                    break;

                // "(その他)"が設定されている場合
                default:
                    // エラーログ出力
                    _logger.Error("外部設定ファイル「要素：ConnectionType」設定値不備");
                    // 処理終了
                    return;
            }

            // 最終接続ユーザ自動ログイン機能フラグ更新
            _PreservationUserFlg = xml.PreservationUserFlg;

            // PreservationUserFlg要素設定値解析
            switch (_PreservationUserFlg)
            {
                // "ON"が設定されている場合
                case "ON":
                    // 隠し設定ファイル用インスタンス生成
                    HiddenSettingFile _xml = new HiddenSettingFile();
                    // 最終接続ユーザ名取得
                    textBoxLoginUserName.Text = _xml.LastUserName;
                    // 最終接続ユーザログインパスワード取得
                    _Password = _xml.LastUserPassword;
                    // 抜け
                    break;

                // "OFF"が設定されている場合
                case "OFF":
                    // 隠し設定ファイル設定内容初期化
                    SaveHiddenSettingFile("", "");
                    // 抜け
                    break;

                // "（その他）"が設定されている場合
                default:
                    // エラーログ出力
                    _logger.Error("外部設定ファイル「要素：PreservationUserFlg」設定値不備");
                    // 処理終了
                    return;
            }

            // 接続先ホスト名マスタ設定
            comboBoxHostName.DataSource = xml.HostNameMaster;

            // 接続先DB名マスタ設定
            comboBoxDatabaseName.DataSource = xml.DbNameMaster;
        }
        #endregion 初期表示設定

        #region 接続ボタン押下
        /// <summary>
        /// 接続ボタン押下時発生イベント
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void ClickConnectionButton(object sender, EventArgs e)
        {
            // DB接続用文字列設定用
            string cmd;

            // Windows認証による接続の場合
            if (radioButtonWindowsConnection.Checked == true)
            {
                // DB接続用文字列設定（Windows認証用）
                cmd = string.Format(DatabaseConnectionCommand.CONNECTION_WINDOWS_AUTHENTICATION, comboBoxHostName.Text, comboBoxDatabaseName.Text);
            }
            // SQL Server認証による接続の場合
            else
            {
                // パスワードが設定されていない場合（最終接続ユーザ自動ログイン機能フラグがOFFであるため）
                if (string.IsNullOrEmpty(_Password))
                {
                    // パスワード入力専用画面の生成
                    PasswordForm passForm = new PasswordForm();
                    // パスワード入力専用画面表示
                    passForm.ShowDialog();
                    // 接続用パスワード設定
                    _Password = passForm._Password;
                }

                // DB接続用文字列設定（SQL Server認証用）
                cmd = string.Format(DatabaseConnectionCommand.CONNECTION_SQL_AUTHENTICATION, comboBoxHostName.Text, comboBoxDatabaseName.Text, textBoxLoginUserName.Text, _Password);
            }

            // 指定再DB接続処理が失敗した場合
            if (new DbContext().TryConnection(cmd) == false)
            {
                // パスワード初期化
                _Password = "";
                // ユーザへ通知
                MessageBox.Show("", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // 処理終了
                return;
            }
        }
        #endregion

        #region 設定ファイル各機能

        /// <summary>
        /// 設定ファイル設定値読込
        /// </summary>
        class SettingFile
        {
            /// <summary>
            /// 最終接続方式
            /// </summary>
            public string ConnectionType { get; set; }

            /// <summary>
            /// 最終接続ユーザ入力省略機能フラグ
            /// </summary>
            public string PreservationUserFlg { get; set; }

            /// <summary>
            /// 接続先ホスト名マスタ
            /// </summary>
            public List<string> HostNameMaster { get; set; }

            /// <summary>
            /// 接続先DB名マスタ
            /// </summary>
            public List<string> DbNameMaster { get; set; }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            public SettingFile()
            {
                // 外部設定ファイルパス指定
                XElement xml = XElement.Load(@".\Config.xml");

                // 設定値の取得
                IEnumerable<XElement> config = from item in xml.Elements("Config") select item;

                // 設定値の解析
                foreach (XElement node in config)
                {
                    // 接続方式
                    ConnectionType = node.Element("ConnectionType").Value;

                    // 最終接続ユーザ入力省略機能フラグ
                    PreservationUserFlg = node.Element("PreservationUserFlg").Value;

                    // 接続先ホスト名マスタ
                    IEnumerable<XElement> hostnode = from item in node.Elements("HostMast") select item;
                    // 接続先ホスト名マスタにデータバインド
                    HostNameMaster = hostnode.Elements("Value").Select(p => p.Value).ToList();

                    // 接続先DB名マスタ
                    IEnumerable<XElement> databasenode = from item in node.Elements("DataBaseMast") select item;
                    // 接続先DB名マスタにデータバインド
                    DbNameMaster = databasenode.Elements("Value").Select(p => p.Value).ToList();
                }
            }
        }

        /// <summary>
        /// 隠し設定ファイル設定値読込
        /// </summary>
        class HiddenSettingFile
        {
            /// <summary>
            /// 最終ログインユーザ名
            /// </summary>
            public string LastUserName { get; set; }

            /// <summary>
            /// 最終ログインユーザパスワード
            /// </summary>
            public string LastUserPassword { get; set; }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            public HiddenSettingFile()
            {
                // 外部設定ファイルパス指定
                XElement xml = XElement.Load(@".\_Config.xml");

                // 設定値の取得
                IEnumerable<XElement> config = from item in xml.Elements("Config") select item;

                // 設定値の解析
                foreach (XElement node in config)
                {
                    // 最終接続ユーザ
                    LastUserName = node.Element("LastUser").Value;

                    // 最終接続ユーザログイン用パスワード
                    LastUserPassword = node.Element("Password").Value;
                }
            }
        }

        /// <summary>
        /// 隠し設定ファイル設定値更新
        /// </summary>
        /// <param name="setLastUser">ユーザ名</param>
        /// <param name="setPassword">パスワード</param>
        private void SaveHiddenSettingFile(string setLastUser, string setPassword)
        {
            // 設定ファイル（隠しファイル）の属性を一時的に変更するため取得
            FileInfo _fileinfo = new FileInfo(@".\_Config.xml");
            // 設定ファイル（隠しファイル）の隠しファイル属性を削除
            _fileinfo.Attributes &= ~FileAttributes.Hidden;
            // 設定ファイル（隠しファイル）の読取専用属性を削除
            _fileinfo.Attributes &= ~FileAttributes.ReadOnly;

            // 設定ファイル（隠しファイル）指定
            XElement _xml = XElement.Load(@".\_Config.xml");

            // 設定ファイル（隠しファイル）解析・書き込み
            foreach (XElement _node in from item in _xml.Elements("Config") select item)
            {
                // LastUser要素をユーザ名で更新
                _node.Element("LastUser").Value = setLastUser;
                // Password要素をパスワードで更新
                _node.Element("Password").Value = setPassword;
                // 更新を反映・保存
                _xml.Save(@".\_Config.xml");
            }

            // 設定ファイル（隠しファイル）へ読取専用属性を付与
            _fileinfo.Attributes |= FileAttributes.ReadOnly;
            // 設定ファイル（隠しファイル）へ隠しファイル属性を付与
            _fileinfo.Attributes |= FileAttributes.Hidden;
        }
        #endregion 設定ファイル各機能

        #region 汎用処理
        /// <summary>
        /// 接続方式切り替え時発生イベント（Windows認証選択側観点）
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void ChangeCheckedRadioButton(object sender, EventArgs e)
        {
            // イベント発生元オブジェクトを解析
            RadioButton radio = (RadioButton)sender;

            // Windows認証が選択された場合
            if (radio.Checked == true)
            {
                // ログインユーザ名入力項目を非活性化
                textBoxLoginUserName.Enabled = false;
            }
            // Windows認証以外が選択された場合
            else
            {
                // ログインユーザ名入力項目を活性化
                textBoxLoginUserName.Enabled = true;
            }
        }
        #endregion
    }
}
