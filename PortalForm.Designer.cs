namespace ResshaDataBaseTools
{
    partial class PortalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageInitialisation = new System.Windows.Forms.TabPage();
            this.buttonInitialisation = new System.Windows.Forms.Button();
            this.labelInitialisation = new System.Windows.Forms.Label();
            this.tabPageUpdate = new System.Windows.Forms.TabPage();
            this.textBoxChienTime = new System.Windows.Forms.TextBox();
            this.labelChienTime = new System.Windows.Forms.Label();
            this.textBoxAllUpdate = new System.Windows.Forms.TextBox();
            this.labelAllUpdate = new System.Windows.Forms.Label();
            this.buttonAllUpdate = new System.Windows.Forms.Button();
            this.dataGridViewResshaList = new System.Windows.Forms.DataGridView();
            this.ColumnResshaNo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnJouge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEigyoShubetsuShuhensei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSokoJotai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnShihatsuEki = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnShuchakuEki = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnShihatsuTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnShuchakuTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEigyoShubetsuJuhensei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEigyoShubetsuJuhensei2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKeisoRessha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTokushuRessha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelTargetDate = new System.Windows.Forms.Label();
            this.dateTimePickerTargetDate = new System.Windows.Forms.DateTimePicker();
            this.buttonTargetDate = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageInitialisation.SuspendLayout();
            this.tabPageUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResshaList)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageInitialisation);
            this.tabControl1.Controls.Add(this.tabPageUpdate);
            this.tabControl1.Location = new System.Drawing.Point(1, 9);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(799, 441);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.Visible = false;
            // 
            // tabPageInitialisation
            // 
            this.tabPageInitialisation.Controls.Add(this.buttonInitialisation);
            this.tabPageInitialisation.Controls.Add(this.labelInitialisation);
            this.tabPageInitialisation.Location = new System.Drawing.Point(4, 22);
            this.tabPageInitialisation.Name = "tabPageInitialisation";
            this.tabPageInitialisation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInitialisation.Size = new System.Drawing.Size(791, 415);
            this.tabPageInitialisation.TabIndex = 0;
            this.tabPageInitialisation.Text = "実績初期化";
            this.tabPageInitialisation.UseVisualStyleBackColor = true;
            // 
            // buttonInitialisation
            // 
            this.buttonInitialisation.Location = new System.Drawing.Point(11, 36);
            this.buttonInitialisation.Name = "buttonInitialisation";
            this.buttonInitialisation.Size = new System.Drawing.Size(173, 65);
            this.buttonInitialisation.TabIndex = 1;
            this.buttonInitialisation.Text = "初期化";
            this.buttonInitialisation.UseVisualStyleBackColor = true;
            this.buttonInitialisation.Click += new System.EventHandler(this.ClickInitializationButton);
            // 
            // labelInitialisation
            // 
            this.labelInitialisation.AutoSize = true;
            this.labelInitialisation.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelInitialisation.Location = new System.Drawing.Point(8, 7);
            this.labelInitialisation.Name = "labelInitialisation";
            this.labelInitialisation.Size = new System.Drawing.Size(176, 16);
            this.labelInitialisation.TabIndex = 0;
            this.labelInitialisation.Text = "初期化対象日付：未設定";
            // 
            // tabPageUpdate
            // 
            this.tabPageUpdate.Controls.Add(this.textBoxChienTime);
            this.tabPageUpdate.Controls.Add(this.labelChienTime);
            this.tabPageUpdate.Controls.Add(this.textBoxAllUpdate);
            this.tabPageUpdate.Controls.Add(this.labelAllUpdate);
            this.tabPageUpdate.Controls.Add(this.buttonAllUpdate);
            this.tabPageUpdate.Controls.Add(this.dataGridViewResshaList);
            this.tabPageUpdate.Location = new System.Drawing.Point(4, 22);
            this.tabPageUpdate.Name = "tabPageUpdate";
            this.tabPageUpdate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUpdate.Size = new System.Drawing.Size(791, 415);
            this.tabPageUpdate.TabIndex = 1;
            this.tabPageUpdate.Text = "実績更新";
            this.tabPageUpdate.UseVisualStyleBackColor = true;
            // 
            // textBoxChienTime
            // 
            this.textBoxChienTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxChienTime.Location = new System.Drawing.Point(585, 5);
            this.textBoxChienTime.Name = "textBoxChienTime";
            this.textBoxChienTime.Size = new System.Drawing.Size(109, 19);
            this.textBoxChienTime.TabIndex = 6;
            this.textBoxChienTime.Text = "00:00";
            // 
            // labelChienTime
            // 
            this.labelChienTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelChienTime.AutoSize = true;
            this.labelChienTime.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelChienTime.Location = new System.Drawing.Point(514, 8);
            this.labelChienTime.Name = "labelChienTime";
            this.labelChienTime.Size = new System.Drawing.Size(67, 14);
            this.labelChienTime.TabIndex = 5;
            this.labelChienTime.Text = "遅延時間";
            // 
            // textBoxAllUpdate
            // 
            this.textBoxAllUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAllUpdate.Location = new System.Drawing.Point(399, 5);
            this.textBoxAllUpdate.Name = "textBoxAllUpdate";
            this.textBoxAllUpdate.Size = new System.Drawing.Size(109, 19);
            this.textBoxAllUpdate.TabIndex = 4;
            this.textBoxAllUpdate.Text = "00:00:00";
            // 
            // labelAllUpdate
            // 
            this.labelAllUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAllUpdate.AutoSize = true;
            this.labelAllUpdate.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelAllUpdate.Location = new System.Drawing.Point(328, 8);
            this.labelAllUpdate.Name = "labelAllUpdate";
            this.labelAllUpdate.Size = new System.Drawing.Size(67, 14);
            this.labelAllUpdate.TabIndex = 3;
            this.labelAllUpdate.Text = "更新時間";
            // 
            // buttonAllUpdate
            // 
            this.buttonAllUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAllUpdate.Location = new System.Drawing.Point(697, 3);
            this.buttonAllUpdate.Name = "buttonAllUpdate";
            this.buttonAllUpdate.Size = new System.Drawing.Size(94, 23);
            this.buttonAllUpdate.TabIndex = 2;
            this.buttonAllUpdate.Text = "一括更新";
            this.buttonAllUpdate.UseVisualStyleBackColor = true;
            // 
            // dataGridViewResshaList
            // 
            this.dataGridViewResshaList.AllowUserToAddRows = false;
            this.dataGridViewResshaList.AllowUserToDeleteRows = false;
            this.dataGridViewResshaList.AllowUserToOrderColumns = true;
            this.dataGridViewResshaList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewResshaList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResshaList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnResshaNo,
            this.ColumnJouge,
            this.ColumnEigyoShubetsuShuhensei,
            this.ColumnSokoJotai,
            this.ColumnShihatsuEki,
            this.ColumnShuchakuEki,
            this.ColumnShihatsuTime,
            this.ColumnShuchakuTime,
            this.ColumnEigyoShubetsuJuhensei,
            this.ColumnEigyoShubetsuJuhensei2,
            this.ColumnKeisoRessha,
            this.ColumnTokushuRessha});
            this.dataGridViewResshaList.Location = new System.Drawing.Point(3, 28);
            this.dataGridViewResshaList.Name = "dataGridViewResshaList";
            this.dataGridViewResshaList.ReadOnly = true;
            this.dataGridViewResshaList.RowTemplate.Height = 21;
            this.dataGridViewResshaList.Size = new System.Drawing.Size(785, 384);
            this.dataGridViewResshaList.TabIndex = 0;
            // 
            // ColumnResshaNo
            // 
            this.ColumnResshaNo.HeaderText = "列車番号";
            this.ColumnResshaNo.Name = "ColumnResshaNo";
            this.ColumnResshaNo.ReadOnly = true;
            // 
            // ColumnJouge
            // 
            this.ColumnJouge.HeaderText = "上下";
            this.ColumnJouge.Name = "ColumnJouge";
            this.ColumnJouge.ReadOnly = true;
            // 
            // ColumnEigyoShubetsuShuhensei
            // 
            this.ColumnEigyoShubetsuShuhensei.HeaderText = "愛称名(主)";
            this.ColumnEigyoShubetsuShuhensei.Name = "ColumnEigyoShubetsuShuhensei";
            this.ColumnEigyoShubetsuShuhensei.ReadOnly = true;
            // 
            // ColumnSokoJotai
            // 
            this.ColumnSokoJotai.HeaderText = "走行状態";
            this.ColumnSokoJotai.Name = "ColumnSokoJotai";
            this.ColumnSokoJotai.ReadOnly = true;
            // 
            // ColumnShihatsuEki
            // 
            this.ColumnShihatsuEki.HeaderText = "始発駅";
            this.ColumnShihatsuEki.Name = "ColumnShihatsuEki";
            this.ColumnShihatsuEki.ReadOnly = true;
            // 
            // ColumnShuchakuEki
            // 
            this.ColumnShuchakuEki.HeaderText = "終着駅";
            this.ColumnShuchakuEki.Name = "ColumnShuchakuEki";
            this.ColumnShuchakuEki.ReadOnly = true;
            // 
            // ColumnShihatsuTime
            // 
            this.ColumnShihatsuTime.HeaderText = "始発時刻";
            this.ColumnShihatsuTime.Name = "ColumnShihatsuTime";
            this.ColumnShihatsuTime.ReadOnly = true;
            // 
            // ColumnShuchakuTime
            // 
            this.ColumnShuchakuTime.HeaderText = "終着時刻";
            this.ColumnShuchakuTime.Name = "ColumnShuchakuTime";
            this.ColumnShuchakuTime.ReadOnly = true;
            // 
            // ColumnEigyoShubetsuJuhensei
            // 
            this.ColumnEigyoShubetsuJuhensei.HeaderText = "愛称名(従)";
            this.ColumnEigyoShubetsuJuhensei.Name = "ColumnEigyoShubetsuJuhensei";
            this.ColumnEigyoShubetsuJuhensei.ReadOnly = true;
            // 
            // ColumnEigyoShubetsuJuhensei2
            // 
            this.ColumnEigyoShubetsuJuhensei2.HeaderText = "愛称名(従2)";
            this.ColumnEigyoShubetsuJuhensei2.Name = "ColumnEigyoShubetsuJuhensei2";
            this.ColumnEigyoShubetsuJuhensei2.ReadOnly = true;
            // 
            // ColumnKeisoRessha
            // 
            this.ColumnKeisoRessha.HeaderText = "継送列車";
            this.ColumnKeisoRessha.Name = "ColumnKeisoRessha";
            this.ColumnKeisoRessha.ReadOnly = true;
            // 
            // ColumnTokushuRessha
            // 
            this.ColumnTokushuRessha.HeaderText = "特殊列車";
            this.ColumnTokushuRessha.Name = "ColumnTokushuRessha";
            this.ColumnTokushuRessha.ReadOnly = true;
            // 
            // labelTargetDate
            // 
            this.labelTargetDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTargetDate.AutoSize = true;
            this.labelTargetDate.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelTargetDate.Location = new System.Drawing.Point(519, 10);
            this.labelTargetDate.Name = "labelTargetDate";
            this.labelTargetDate.Size = new System.Drawing.Size(67, 14);
            this.labelTargetDate.TabIndex = 1;
            this.labelTargetDate.Text = "日付選択";
            // 
            // dateTimePickerTargetDate
            // 
            this.dateTimePickerTargetDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePickerTargetDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTargetDate.Location = new System.Drawing.Point(590, 8);
            this.dateTimePickerTargetDate.Name = "dateTimePickerTargetDate";
            this.dateTimePickerTargetDate.Size = new System.Drawing.Size(109, 19);
            this.dateTimePickerTargetDate.TabIndex = 0;
            // 
            // buttonTargetDate
            // 
            this.buttonTargetDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTargetDate.Location = new System.Drawing.Point(702, 6);
            this.buttonTargetDate.Name = "buttonTargetDate";
            this.buttonTargetDate.Size = new System.Drawing.Size(94, 23);
            this.buttonTargetDate.TabIndex = 1;
            this.buttonTargetDate.Text = "日付設定";
            this.buttonTargetDate.UseVisualStyleBackColor = true;
            this.buttonTargetDate.Click += new System.EventHandler(this.ClickSettingDateButton);
            // 
            // PortalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonTargetDate);
            this.Controls.Add(this.dateTimePickerTargetDate);
            this.Controls.Add(this.labelTargetDate);
            this.Controls.Add(this.tabControl1);
            this.Name = "PortalForm";
            this.Text = "対象日付：未設定";
            this.tabControl1.ResumeLayout(false);
            this.tabPageInitialisation.ResumeLayout(false);
            this.tabPageInitialisation.PerformLayout();
            this.tabPageUpdate.ResumeLayout(false);
            this.tabPageUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResshaList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageInitialisation;
        private System.Windows.Forms.TabPage tabPageUpdate;
        private System.Windows.Forms.DataGridView dataGridViewResshaList;
        private System.Windows.Forms.Label labelTargetDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerTargetDate;
        private System.Windows.Forms.Button buttonTargetDate;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnResshaNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnJouge;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEigyoShubetsuShuhensei;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSokoJotai;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnShihatsuEki;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnShuchakuEki;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnShihatsuTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnShuchakuTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEigyoShubetsuJuhensei;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEigyoShubetsuJuhensei2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKeisoRessha;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTokushuRessha;
        private System.Windows.Forms.Label labelInitialisation;
        private System.Windows.Forms.Button buttonInitialisation;
        private System.Windows.Forms.Button buttonAllUpdate;
        private System.Windows.Forms.Label labelAllUpdate;
        private System.Windows.Forms.TextBox textBoxAllUpdate;
        private System.Windows.Forms.TextBox textBoxChienTime;
        private System.Windows.Forms.Label labelChienTime;
    }
}