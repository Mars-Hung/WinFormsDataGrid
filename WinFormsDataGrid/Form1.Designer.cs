namespace WinFormsDataGrid
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            gvMain = new DataGridView();
            Column2 = new DataGridViewButtonColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            lblTimerGvMainDesc = new Label();
            timerMain = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            chkAutoUpdate = new CheckBox();
            lblThreadInfo = new Label();
            label1 = new Label();
            label2 = new Label();
            lblSecondThreadInfo = new Label();
            btnClearPainting = new Button();
            ((System.ComponentModel.ISupportInitialize)gvMain).BeginInit();
            SuspendLayout();
            // 
            // gvMain
            // 
            gvMain.AllowUserToAddRows = false;
            gvMain.AllowUserToDeleteRows = false;
            gvMain.AllowUserToResizeColumns = false;
            gvMain.AllowUserToResizeRows = false;
            gvMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gvMain.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft JhengHei UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gvMain.ColumnHeadersHeight = 34;
            gvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gvMain.Columns.AddRange(new DataGridViewColumn[] { Column2, Column3, Column1, Column5, Column4, Column6, Column7 });
            gvMain.Location = new Point(0, 156);
            gvMain.MultiSelect = false;
            gvMain.Name = "gvMain";
            gvMain.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Microsoft JhengHei UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            gvMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            gvMain.RowHeadersVisible = false;
            gvMain.RowHeadersWidth = 62;
            gvMain.ShowCellToolTips = false;
            gvMain.ShowEditingIcon = false;
            gvMain.Size = new Size(945, 394);
            gvMain.TabIndex = 0;
            gvMain.CellPainting += gvMain_CellPainting;
            // 
            // Column2
            // 
            Column2.HeaderText = "操作";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.DataPropertyName = "StockId";
            Column3.HeaderText = "代碼";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "Name";
            Column1.HeaderText = "名稱";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.DataPropertyName = "CurrentPrice";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            Column5.DefaultCellStyle = dataGridViewCellStyle2;
            Column5.HeaderText = "成交價";
            Column5.MinimumWidth = 8;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.DataPropertyName = "OpenPrice";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            Column4.DefaultCellStyle = dataGridViewCellStyle3;
            Column4.HeaderText = "開盤價";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column6
            // 
            Column6.DataPropertyName = "CVD";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            Column6.DefaultCellStyle = dataGridViewCellStyle4;
            Column6.HeaderText = "累計交易量";
            Column6.MinimumWidth = 8;
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // Column7
            // 
            Column7.DataPropertyName = "OpenCurrentDiff";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            Column7.DefaultCellStyle = dataGridViewCellStyle5;
            Column7.HeaderText = "漲跌";
            Column7.MinimumWidth = 8;
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            // 
            // lblTimerGvMainDesc
            // 
            lblTimerGvMainDesc.AutoSize = true;
            lblTimerGvMainDesc.Location = new Point(660, 89);
            lblTimerGvMainDesc.Name = "lblTimerGvMainDesc";
            lblTimerGvMainDesc.Size = new Size(86, 23);
            lblTimerGvMainDesc.TabIndex = 2;
            lblTimerGvMainDesc.Text = "更新倒數:";
            // 
            // timerMain
            // 
            timerMain.Enabled = true;
            timerMain.Tick += timerMain_Tick;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1433, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // chkAutoUpdate
            // 
            chkAutoUpdate.AutoSize = true;
            chkAutoUpdate.Checked = true;
            chkAutoUpdate.CheckState = CheckState.Checked;
            chkAutoUpdate.Location = new Point(511, 88);
            chkAutoUpdate.Name = "chkAutoUpdate";
            chkAutoUpdate.Size = new Size(148, 27);
            chkAutoUpdate.TabIndex = 4;
            chkAutoUpdate.Text = "定時更新股價:";
            chkAutoUpdate.UseVisualStyleBackColor = true;
            chkAutoUpdate.CheckedChanged += chkAutoUpdate_CheckedChanged;
            // 
            // lblThreadInfo
            // 
            lblThreadInfo.AutoSize = true;
            lblThreadInfo.Location = new Point(190, 37);
            lblThreadInfo.Name = "lblThreadInfo";
            lblThreadInfo.Size = new Size(123, 23);
            lblThreadInfo.TabIndex = 5;
            lblThreadInfo.Text = "lblThreadInfo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold);
            label1.Location = new Point(59, 37);
            label1.Name = "label1";
            label1.Size = new Size(125, 23);
            label1.TabIndex = 6;
            label1.Text = "Main Thread:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold);
            label2.Location = new Point(38, 88);
            label2.Name = "label2";
            label2.Size = new Size(146, 23);
            label2.TabIndex = 7;
            label2.Text = "Second Thread:";
            // 
            // lblSecondThreadInfo
            // 
            lblSecondThreadInfo.AutoSize = true;
            lblSecondThreadInfo.Location = new Point(190, 88);
            lblSecondThreadInfo.Name = "lblSecondThreadInfo";
            lblSecondThreadInfo.Size = new Size(185, 23);
            lblSecondThreadInfo.TabIndex = 8;
            lblSecondThreadInfo.Text = "lblSecondThreadInfo";
            // 
            // btnClearPainting
            // 
            btnClearPainting.Location = new Point(1270, 504);
            btnClearPainting.Name = "btnClearPainting";
            btnClearPainting.Size = new Size(151, 34);
            btnClearPainting.TabIndex = 9;
            btnClearPainting.Text = "Clear Drawing";
            btnClearPainting.UseVisualStyleBackColor = true;
            btnClearPainting.Click += btnClearPainting_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1433, 550);
            Controls.Add(btnClearPainting);
            Controls.Add(lblSecondThreadInfo);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblThreadInfo);
            Controls.Add(chkAutoUpdate);
            Controls.Add(lblTimerGvMainDesc);
            Controls.Add(gvMain);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Paint += Form1_Paint;
            MouseDown += Form1_MouseDown;
            MouseMove += Form1_MouseMove;
            MouseUp += Form1_MouseUp;
            ((System.ComponentModel.ISupportInitialize)gvMain).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gvMain;
        private Label lblTimerGvMainDesc;
        private System.Windows.Forms.Timer timerMain;
        private MenuStrip menuStrip1;
        private CheckBox chkAutoUpdate;
        private DataGridViewButtonColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private Label lblThreadInfo;
        private Label label1;
        private Label label2;
        private Label lblSecondThreadInfo;
        private Button btnClearPainting;
    }
}
