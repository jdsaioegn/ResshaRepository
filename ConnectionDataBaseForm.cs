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
    /// =======================================================================
    /// クラス名 ： ConnectionDataBaseForm
    /// <summary>
    /// 指定先データベース接続画面
    /// </summary>
    /// <remarks>
    /// □ユーザが指定したデータベースへの接続を行う画面である。
    /// □本画面には以下のメソッドが存在する。
    ///     □ConnectionDataBaseForm
    ///         □コンポーネント初期化処理
    ///     □GetSettingXML
    ///         □設定ファイル読み込み
    ///     □Click_btnCon
    ///         □「接続」ボタンを押下イベント
    ///     □SaveSettingFile
    ///         □設定ファイル指定要素更新
    ///     □SaveHiddenSettingFile
    ///         □隠し設定ファイル更新
    /// </remarks>
    /// <history>
    /// =======================================================================
    /// 更新履歴
    /// 項番　　　更新日付　　担当者　　更新内容
    /// 0001　　　2020/03/01  鶴　見    新規作成     
    /// =======================================================================
    /// </history>
    public partial class ConnectionDataBaseForm : Form
    {
        #region グローバル変数
        /// <summary>トレースロガー</summary>
        private readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>ログインパスワード</summary>
        private string password = "";
        /// <summary>設定オブジェクト</summary>
        SettingFile setting;

        #endregion

        #region FORM初期化
        /// =======================================================================
        /// コンストラクタ名 ： ConnectionDataBaseForm
        /// <summary>
        /// コンポーネント初期化処理
        /// </summary>
        /// <remarks>
        /// □指定先データベース接続画面のコントロールを初期化する。
        /// </remarks>
        /// <history>
        /// =======================================================================
        /// 更新履歴
        /// 項番　　　更新日付　　担当者　　更新内容
        /// 0001　　　2020/03/01  鶴　見    新規作成     
        /// =======================================================================
        /// </history>
        public ConnectionDataBaseForm()
        {
            InitializeComponent();

            // 設定ファイル読込
            setting = new SettingFile();

            // 接続方式に"Windows"が設定されている場合
            if (setting.ConnectionType == "Windows")
            {
                // 接続方式初期選択を「Windows認証」に設定
                radioButtonWindowsConnection.Checked = true;
            }
            // 接続方式に"SQL"が設定されている場合
            else if (setting.ConnectionType == "SQL")
            {
                // 接続方式初期選択を「SQL Server認証」に設定
                radioButtonSQLConnection.Checked = true;
            }
            // 接続方式に上記以外が設定されている場合
            else
            {

            }

            // ログインユーザ記憶機能がONである場合
            if (setting.PreservationUserFlg == "ON")
            {
                // 隠し設定ファイル読込
                HiddenSettingFile _setting = new HiddenSettingFile();
                // ログインユーザ名設定
                textBoxLoginUserName.Text = _setting.LastUserName;
                // ログインパスワード設定
                password = _setting.LastUserPassword;
            }
            // ログインユーザ記憶機能がOFFである場合
            else if (setting.PreservationUserFlg == "OFF")
            {
                // 隠し設定ファイルを初期化
                SaveHiddenSettingFile("", "");
            }
            // ログインユーザ記憶機能に上記以外が設定されている場合
            else
            {

            }

            // 接続先ホスト名一覧設定
            comboBoxHostName.DataSource = setting.HostNameMaster;
            // 接続先データベース名一覧設定
            comboBoxDatabaseName.DataSource = setting.DatabaseNameMaster;
        }

        #endregion

        #region イベント

        #region 接続方式切替時発生イベント
        /// =======================================================================
        /// メソッド名 ： ChangeRadioBtn
        /// <summary>
        /// 接続方式切替時発生イベント
        /// </summary>
        /// <remarks>
        /// □接続方式「Windows認証」が選択された場合ログインユーザ入力項目を活性化
        /// </remarks>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <history>
        /// =======================================================================
        /// 更新履歴
        /// 項番　　　更新日付　　担当者　　更新内容
        /// 0001　　　2020/03/01  鶴　見    新規作成     
        /// =======================================================================
        /// </history>
        private void ChangeCheckedRadioButton(object sender, EventArgs e)
        {
            // イベント発生元オブジェクトをラジオボタン型へキャスト
            RadioButton radio = (RadioButton)sender;

            // Windows認証が選択された場合
            if (radio.Checked == true)
            {
                // ログインユーザ名入力項目を非活性化
                textBoxLoginUserName.Enabled = false;
            }
            // SQL認証が選択された場合
            else
            {
                // ログインユーザ名入力項目を活性化
                textBoxLoginUserName.Enabled = true;
            }
        }

        #endregion

        #region 接続ボタン押下
        /// =======================================================================
        /// メソッド名 ： ClickConnectionButton
        /// <summary>
        /// 「接続」ボタン押下時発生イベント
        /// </summary>
        /// <remarks>
        /// □接続方式の「Windows認証」が選択されている場合
        ///     □ 接続情報を用いてWindows認証を試行する。
        /// □接続方式の「SQL Server認証」が選択されている場合
        ///     □ ログインユーザ記憶機能がOFFである場合
        ///         □ パスワードの入力専用画面を表示する。
        ///         □ パスワードの入力結果を取得する。
        ///     □ 接続情報を用いてSQL Server認証を試行する。
        /// □接続が失敗した場合
        ///     □ 接続失敗のメッセージを表示し再度接続情報の入力を促す。
        /// □接続が成功した場合
        ///     □ ログインユーザ記憶機能がONである場合
        ///         □ 隠し設定ファイルを今回ログイン情報で更新する。
        ///     □ 試験用統合DB編集ツールのポータル画面に遷移する。
        /// </remarks>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <history>
        /// =======================================================================
        /// 更新履歴
        /// 項番　　　更新日付　　担当者　　更新内容
        /// 0001　　　2020/03/01  鶴　見    新規作成     
        /// =======================================================================
        /// </history>
        private void ClickConnectionButton(object sender, EventArgs e)
        {
            // DB接続用文字列設定用
            string cmd;

            // 接続方式の「Windows認証」が選択されている場合
            if (radioButtonWindowsConnection.Checked == true)
            {
                // DB接続用文字列設定（Windows認証用）
                cmd = string.Format(DatabaseConnectionCommandTemplate.CONNECTION_WINDOWS_AUTHENTICATION, comboBoxHostName.Text, comboBoxDatabaseName.Text);
            }
            // 接続方式の「SQL Server認証」が選択されている場合
            else
            {
                // パスワードが設定されていない場合（ログインユーザ記憶機能がOFFである場合）
                if (string.IsNullOrEmpty(password))
                {
                    // パスワード入力専用画面の生成
                    PasswordForm passForm = new PasswordForm();
                    // パスワード入力専用画面表示
                    passForm.ShowDialog();
                    // 接続用パスワード設定
                    password = passForm.password;
                }

                // DB接続用文字列設定（SQL Server認証用）
                cmd = string.Format(DatabaseConnectionCommandTemplate.CONNECTION_SQL_AUTHENTICATION, comboBoxHostName.Text, comboBoxDatabaseName.Text, textBoxLoginUserName.Text, password);
            }

            // 上記設定接続文字列を用いた指定先統合DBへの接続確認が失敗した場合
            if (new DbContext().TryConnection(cmd) == false)
            {
                // パスワード初期化
                password = "";
                // ユーザ通知
                MessageBox.Show("", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // 処理終了
                return;
            }
            // 上記設定接続文字列を用いたして先統合DBへの接続確認が成功した場合
            else
            {
                // 今回の接続方式が「Windows認証」であった場合
                if (radioButtonWindowsConnection.Checked == true)
                {
                    // 設定ファイルの接続方式値を"Windows"で更新
                    SaveSettingFile("ConnectionType", "Windows");
                }
                // 今回の接続方式が「SQL Server認証」であった場合
                else
                {
                    // 設定ファイルの接続方式値を"SQL"で更新
                    SaveSettingFile("ConnectionType", "SQL");
                }

                // 隠し設定ファイルを今回のログイン情報で更新
                SaveHiddenSettingFile(textBoxLoginUserName.Text, password);
            }

            // 各機能共通画面生成
            PortalForm portalForm = new PortalForm();

            // 本画面非表示（本画面を閉じたいが親ウィンドウであるため非表示化で対応）
            this.Visible = false;

            // 各機能共通画面表示
            portalForm.ShowDialog();

            // 本画面を閉じる
            this.Close();
        }
        #endregion

        #endregion

        #region メソッド

        #region 設定ファイル指定要素更新
        /// =======================================================================
        /// メソッド名 ： SaveSettingFile
        /// <summary>
        /// 設定ファイル指定要素更新
        /// </summary>
        /// <remarks>
        /// □引数で取得した要素に対して指定値による更新を行う。
        /// </remarks>
        /// <param name="node">更新対象要素</param>
        /// <param name="value">更新値</param>
        /// <history>
        /// =======================================================================
        /// 更新履歴
        /// 項番　　　更新日付　　担当者　　更新内容
        /// 0001　　　2020/03/01  鶴　見    新規作成     
        /// =======================================================================
        /// </history>
        private void SaveSettingFile(string node, string value)
        {
            // 設定ファイルパス指定
            XElement xml = XElement.Load(@".\Config.xml");

            // Config要素配下全取得
            foreach (XElement nodes in from item in xml.Elements("Config") select item)
            {
                // 指定要素の設定値を更新
                nodes.Element(node).Value = value;

                // 設定ファイル保存
                xml.Save(@".\Config.xml");
            }
        }

        #endregion

        #region 隠し設定ファイル更新
        /// =======================================================================
        /// メソッド名 ： SaveHiddenSettingFile
        /// <summary>
        /// 隠し設定ファイル更新
        /// </summary>
        /// <remarks>
        /// □引数で取得した文字列を用いて隠し設定ファイルを更新する。
        /// </remarks>
        /// <param name="setuser">設定ユーザ名</param>
        /// <param name="setpass">設定パスワード</param>
        /// <history>
        /// =======================================================================
        /// 更新履歴
        /// 項番　　　更新日付　　担当者　　更新内容
        /// 0001　　　2020/03/01  鶴　見    新規作成     
        /// =======================================================================
        /// </history>
        private void SaveHiddenSettingFile(string setuser, string setpass)
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
                _node.Element("LastUser").Value = setuser;
                // Password要素をパスワードで更新
                _node.Element("Password").Value = setpass;
                // 更新を反映・保存
                _xml.Save(@".\_Config.xml");
            }

            // 設定ファイル（隠しファイル）へ読取専用属性を付与
            _fileinfo.Attributes |= FileAttributes.ReadOnly;
            // 設定ファイル（隠しファイル）へ隠しファイル属性を付与
            _fileinfo.Attributes |= FileAttributes.Hidden;
        }

        #endregion
         
        #endregion

        #region 設定ファイルオブジェクト
        // =======================================================================
        /// クラス名 ： SettingFile
        /// <summary>
        /// 設定ファイル管理用オブジェクト
        /// </summary>
        /// <remarks>
        /// 設定ファイルの設定内容を読み取るためのクラスである。
        /// □本クラスは設定ファイルの読み込みと値の取得を行う。
        /// □本クラスには以下のメソッドが存在する。
        ///     □SettingFile
        ///         □コンポーネント初期化処理
        /// </remarks>
        /// <history>
        /// =======================================================================
        /// 更新履歴
        /// 項番　　　更新日付　　担当者　　更新内容
        /// 0001　　　2020/03/01  鶴　見    新規作成     
        /// =======================================================================
        /// </history>
        class SettingFile
        {
            /// <summary>最終接続方式</summary>
            public string ConnectionType { get; set; }
            /// <summary>最終接続ユーザ入力省略機能フラグ</summary>
            public string PreservationUserFlg { get; set; }
            /// <summary>接続先ホスト名マスタ</summary>
            public List<string> HostNameMaster { get; set; }
            /// <summary>接続先DB名マスタ</summary>
            public List<string> DatabaseNameMaster { get; set; }

            /// =======================================================================
            /// コンストラクタ名 ： SettingFile
            /// <summary>
            /// コンポーネント初期化処理
            /// </summary>
            /// <remarks>
            /// □設定ファイルの設定内容を取得する。
            /// </remarks>
            /// <history>
            /// =======================================================================
            /// 更新履歴
            /// 項番　　　更新日付　　担当者　　更新内容
            /// 0001　　　2020/03/01  鶴　見    新規作成     
            /// =======================================================================
            /// </history>
            public SettingFile()
            {
                // 外部設定ファイルパス指定
                XElement xml = XElement.Load(@".\Config.xml");

                // 設定値の解析
                foreach (XElement node in from item in xml.Elements("Config") select item)
                {
                    // 接続方式読取
                    ConnectionType = node.Element("ConnectionType").Value;
                    // 最終接続ユーザ入力省略機能フラグ読取
                    PreservationUserFlg = node.Element("PreservationUserFlg").Value;
                    // 接続先ホスト名マスタ読取
                    IEnumerable<XElement> hostnode = from item in node.Elements("HostMast") select item;
                    HostNameMaster = hostnode.Elements("Value").Select(p => p.Value).ToList();
                    // 接続先DB名マスタ読取
                    IEnumerable<XElement> databasenode = from item in node.Elements("DataBaseMast") select item;
                    DatabaseNameMaster = databasenode.Elements("Value").Select(p => p.Value).ToList();
                }
            }
        }

        #endregion

        #region 隠し設定ファイルオブジェクト
        /// =======================================================================
        /// クラス名 ： HiddenSettingFile
        /// <summary>
        /// 隠し設定ファイル管理用オブジェクト
        /// </summary>
        /// <remarks>
        /// 隠し設定ファイルの設定内容を読み取るためのクラスである。
        /// □本クラスは隠し設定ファイルの読み込みと値の取得を行う。
        /// □本クラスには以下のメソッドが存在する。
        ///     □HiddenSettingFile
        ///         □コンポーネント初期化処理
        /// </remarks>
        /// <history>
        /// =======================================================================
        /// 更新履歴
        /// 項番　　　更新日付　　担当者　　更新内容
        /// 0001　　　2020/03/01  鶴　見    新規作成     
        /// =======================================================================
        /// </history>
        class HiddenSettingFile
        {
            /// <summary>最終ログインユーザ名</summary>
            public string LastUserName { get; set; }
            /// <summary>最終ログインユーザパスワード</summary>
            public string LastUserPassword { get; set; }

            /// =======================================================================
            /// コンストラクタ名 ： HiddenSettingFile
            /// <summary>
            /// コンポーネント初期化処理
            /// </summary>
            /// <remarks>
            /// □隠し設定ファイルの設定内容を取得する。
            /// </remarks>
            /// <history>
            /// =======================================================================
            /// 更新履歴
            /// 項番　　　更新日付　　担当者　　更新内容
            /// 0001　　　2020/03/01  鶴　見    新規作成     
            /// =======================================================================
            /// </history>
            public HiddenSettingFile()
            {
                // 隠し設定ファイルパス指定（実効ファイルとの相対パス指定）
                XElement xml = XElement.Load(@".\_Config.xml");

                // 設定値の解析
                foreach (XElement node in from item in xml.Elements("Config") select item)
                {
                    // 最終接続ユーザ
                    LastUserName = node.Element("LastUser").Value;
                    // 最終接続ユーザログイン用パスワード
                    LastUserPassword = node.Element("Password").Value;
                }
            }
        }

        #endregion
    }
}
