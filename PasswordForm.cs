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
    public partial class PasswordForm : Form
    {
        // ログインパスワード
        public string _Password;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PasswordForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// OKボタン押下時発生イベント
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント情報</param>
        private void Password(object sender, EventArgs e)
        {
            // パスワード設定
            _Password = textBoxPassword.Text;

            // パスワード入力専用画面閉じる
            this.Close();
        }
    }
}
