namespace ResshaDataBaseTools
{
    partial class ConnectionDataBaseForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelHostName = new System.Windows.Forms.Label();
            this.labelDatabaseName = new System.Windows.Forms.Label();
            this.labelConnectionType = new System.Windows.Forms.Label();
            this.labelLoginUserName = new System.Windows.Forms.Label();
            this.comboBoxHostName = new System.Windows.Forms.ComboBox();
            this.comboBoxDatabaseName = new System.Windows.Forms.ComboBox();
            this.textBoxLoginUserName = new System.Windows.Forms.TextBox();
            this.radioButtonWindowsConnection = new System.Windows.Forms.RadioButton();
            this.radioButtonSQLConnection = new System.Windows.Forms.RadioButton();
            this.buttonConnection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelHostName
            // 
            this.labelHostName.AutoSize = true;
            this.labelHostName.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelHostName.Location = new System.Drawing.Point(5, 11);
            this.labelHostName.Name = "labelHostName";
            this.labelHostName.Size = new System.Drawing.Size(87, 12);
            this.labelHostName.TabIndex = 0;
            this.labelHostName.Text = "接続先ホスト名";
            // 
            // labelDatabaseName
            // 
            this.labelDatabaseName.AutoSize = true;
            this.labelDatabaseName.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDatabaseName.Location = new System.Drawing.Point(4, 38);
            this.labelDatabaseName.Name = "labelDatabaseName";
            this.labelDatabaseName.Size = new System.Drawing.Size(75, 12);
            this.labelDatabaseName.TabIndex = 1;
            this.labelDatabaseName.Text = "接続先DB名";
            // 
            // labelConnectionType
            // 
            this.labelConnectionType.AutoSize = true;
            this.labelConnectionType.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelConnectionType.Location = new System.Drawing.Point(4, 67);
            this.labelConnectionType.Name = "labelConnectionType";
            this.labelConnectionType.Size = new System.Drawing.Size(57, 12);
            this.labelConnectionType.TabIndex = 2;
            this.labelConnectionType.Text = "接続方式";
            // 
            // labelLoginUserName
            // 
            this.labelLoginUserName.AutoSize = true;
            this.labelLoginUserName.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelLoginUserName.Location = new System.Drawing.Point(4, 91);
            this.labelLoginUserName.Name = "labelLoginUserName";
            this.labelLoginUserName.Size = new System.Drawing.Size(91, 12);
            this.labelLoginUserName.TabIndex = 3;
            this.labelLoginUserName.Text = "ログインユーザ名";
            // 
            // comboBoxHostName
            // 
            this.comboBoxHostName.FormattingEnabled = true;
            this.comboBoxHostName.Location = new System.Drawing.Point(109, 8);
            this.comboBoxHostName.Name = "comboBoxHostName";
            this.comboBoxHostName.Size = new System.Drawing.Size(236, 20);
            this.comboBoxHostName.TabIndex = 1;
            // 
            // comboBoxDatabaseName
            // 
            this.comboBoxDatabaseName.FormattingEnabled = true;
            this.comboBoxDatabaseName.Location = new System.Drawing.Point(109, 38);
            this.comboBoxDatabaseName.Name = "comboBoxDatabaseName";
            this.comboBoxDatabaseName.Size = new System.Drawing.Size(236, 20);
            this.comboBoxDatabaseName.TabIndex = 2;
            // 
            // textBoxLoginUserName
            // 
            this.textBoxLoginUserName.Enabled = false;
            this.textBoxLoginUserName.Location = new System.Drawing.Point(109, 91);
            this.textBoxLoginUserName.Name = "textBoxLoginUserName";
            this.textBoxLoginUserName.Size = new System.Drawing.Size(236, 19);
            this.textBoxLoginUserName.TabIndex = 5;
            // 
            // radioButtonWindowsConnection
            // 
            this.radioButtonWindowsConnection.AutoSize = true;
            this.radioButtonWindowsConnection.Location = new System.Drawing.Point(109, 65);
            this.radioButtonWindowsConnection.Name = "radioButtonWindowsConnection";
            this.radioButtonWindowsConnection.Size = new System.Drawing.Size(91, 16);
            this.radioButtonWindowsConnection.TabIndex = 3;
            this.radioButtonWindowsConnection.TabStop = true;
            this.radioButtonWindowsConnection.Text = "Windows認証";
            this.radioButtonWindowsConnection.UseVisualStyleBackColor = true;
            this.radioButtonWindowsConnection.CheckedChanged += new System.EventHandler(this.ChangeCheckedRadioButton);
            // 
            // radioButtonSQLConnection
            // 
            this.radioButtonSQLConnection.AutoSize = true;
            this.radioButtonSQLConnection.Location = new System.Drawing.Point(240, 65);
            this.radioButtonSQLConnection.Name = "radioButtonSQLConnection";
            this.radioButtonSQLConnection.Size = new System.Drawing.Size(105, 16);
            this.radioButtonSQLConnection.TabIndex = 4;
            this.radioButtonSQLConnection.TabStop = true;
            this.radioButtonSQLConnection.Text = "SQL Server認証";
            this.radioButtonSQLConnection.UseVisualStyleBackColor = true;
            // 
            // buttonConnection
            // 
            this.buttonConnection.Location = new System.Drawing.Point(7, 115);
            this.buttonConnection.Name = "buttonConnection";
            this.buttonConnection.Size = new System.Drawing.Size(338, 23);
            this.buttonConnection.TabIndex = 6;
            this.buttonConnection.Text = "接続";
            this.buttonConnection.UseVisualStyleBackColor = true;
            this.buttonConnection.Click += new System.EventHandler(this.ClickConnectionButton);
            // 
            // ConnectionDataBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 146);
            this.Controls.Add(this.buttonConnection);
            this.Controls.Add(this.radioButtonSQLConnection);
            this.Controls.Add(this.radioButtonWindowsConnection);
            this.Controls.Add(this.textBoxLoginUserName);
            this.Controls.Add(this.comboBoxDatabaseName);
            this.Controls.Add(this.comboBoxHostName);
            this.Controls.Add(this.labelLoginUserName);
            this.Controls.Add(this.labelConnectionType);
            this.Controls.Add(this.labelDatabaseName);
            this.Controls.Add(this.labelHostName);
            this.Name = "ConnectionDataBaseForm";
            this.Text = "接続先DB選択";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHostName;
        private System.Windows.Forms.Label labelDatabaseName;
        private System.Windows.Forms.Label labelConnectionType;
        private System.Windows.Forms.Label labelLoginUserName;
        private System.Windows.Forms.ComboBox comboBoxHostName;
        private System.Windows.Forms.ComboBox comboBoxDatabaseName;
        private System.Windows.Forms.TextBox textBoxLoginUserName;
        private System.Windows.Forms.RadioButton radioButtonWindowsConnection;
        private System.Windows.Forms.RadioButton radioButtonSQLConnection;
        private System.Windows.Forms.Button buttonConnection;
    }
}

