using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResshaDataBaseTools
{
    /// =======================================================================
    /// クラス名 ： PasswordForm
    /// <summary>
    /// SQL Server認証時ログイン用パスワード入力専用画面
    /// </summary>
    /// <remarks>
    /// □SQL Server認証時ログイン用パスワード入力を行う画面である。
    /// □本クラスには以下のメソッドが存在する。
    ///     □Click_OkButton
    ///         □「OK」ボタン押下時発生イベント
    /// </remarks>
    /// <history>
    /// =======================================================================
    /// 更新履歴
    /// 項番　　　更新日付　　担当者　　更新内容
    /// 0001　　　2020/03/01  鶴　見    新規作成     
    /// =======================================================================
    /// </history>
    public partial class PasswordForm : Form
    {
        #region グローバル変数
        /// <summary>パスワード</summary>
        public string password;

        #endregion

        #region FORM初期化
        /// =======================================================================
        /// コンストラクタ名 ： PasswordForm
        /// <summary>
        /// コンポーネント初期化処理
        /// </summary>
        /// <remarks>
        /// □ログイン用パスワード入力専用画面のコントロールを初期化する。
        /// </remarks>
        /// <history>
        /// =======================================================================
        /// 更新履歴
        /// 項番　　　更新日付　　担当者　　更新内容
        /// 0001　　　2020/03/01  鶴　見    新規作成     
        /// =======================================================================
        /// </history>
        public PasswordForm()
        {
            InitializeComponent();
        }

        #endregion

        #region イベント

        #region 「OK」ボタン押下時発生イベント
        /// <summary>
        /// 「OK」ボタン押下時発生イベント
        /// </summary>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベント情報</param>
        private void Click_OkButton(object sender, EventArgs e)
        {
            // パスワード設定
            password = textBoxPassword.Text;
            // パスワード入力専用画面閉じる
            this.Close();
        }

        #endregion

        #endregion
    }
}
