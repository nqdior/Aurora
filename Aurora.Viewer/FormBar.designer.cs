namespace Aurora.Viewer
{
    partial class FormBar
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.formBarBase = new System.Windows.Forms.MenuStrip();
            this.closeBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.minBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.title = new System.Windows.Forms.ToolStripMenuItem();
            this.DBcombo = new System.Windows.Forms.ToolStripComboBox();
            this.SVCombo = new System.Windows.Forms.ToolStripComboBox();
            this.topMost = new System.Windows.Forms.ToolStripMenuItem();
            this.formBarBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // formBarBase
            // 
            this.formBarBase.BackColor = System.Drawing.Color.Transparent;
            this.formBarBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formBarBase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeBtn,
            this.minBtn,
            this.title,
            this.DBcombo,
            this.SVCombo,
            this.topMost});
            this.formBarBase.Location = new System.Drawing.Point(0, 0);
            this.formBarBase.Name = "formBarBase";
            this.formBarBase.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.formBarBase.Size = new System.Drawing.Size(526, 28);
            this.formBarBase.TabIndex = 2;
            this.formBarBase.Text = "menuStrip";
            this.formBarBase.DoubleClick += new System.EventHandler(this.title_Click);
            this.formBarBase.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormBar_MouseDown);
            // 
            // closeBtn
            // 
            this.closeBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(12, 22);
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // minBtn
            // 
            this.minBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.minBtn.Name = "minBtn";
            this.minBtn.Size = new System.Drawing.Size(12, 22);
            this.minBtn.Click += new System.EventHandler(this.minBtn_Click);
            // 
            // title
            // 
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Name = "title";
            this.title.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.title.Size = new System.Drawing.Size(96, 22);
            this.title.Text = "DataReseacher";
            this.title.Click += new System.EventHandler(this.title_Click);
            // 
            // DBcombo
            // 
            this.DBcombo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.DBcombo.BackColor = System.Drawing.Color.Black;
            this.DBcombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DBcombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DBcombo.Font = new System.Drawing.Font("游ゴシック Medium", 9F);
            this.DBcombo.ForeColor = System.Drawing.Color.White;
            this.DBcombo.Name = "DBcombo";
            this.DBcombo.Size = new System.Drawing.Size(121, 22);
            this.DBcombo.Visible = false;
            this.DBcombo.SelectedIndexChanged += new System.EventHandler(this.DBcombo_SelectedIndexChanged);
            // 
            // SVCombo
            // 
            this.SVCombo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SVCombo.BackColor = System.Drawing.Color.Black;
            this.SVCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SVCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SVCombo.Font = new System.Drawing.Font("游ゴシック Medium", 9F);
            this.SVCombo.ForeColor = System.Drawing.Color.White;
            this.SVCombo.Name = "SVCombo";
            this.SVCombo.Size = new System.Drawing.Size(121, 22);
            this.SVCombo.Visible = false;
            this.SVCombo.SelectedIndexChanged += new System.EventHandler(this.SVCombo_SelectedIndexChanged);
            // 
            // topMost
            // 
            this.topMost.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.topMost.Name = "topMost";
            this.topMost.Size = new System.Drawing.Size(12, 22);
            this.topMost.Click += new System.EventHandler(this.topMost_Click);
            // 
            // FormBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.formBarBase);
            this.Name = "FormBar";
            this.Size = new System.Drawing.Size(526, 28);
            this.Load += new System.EventHandler(this.FormBar_Load);
            this.formBarBase.ResumeLayout(false);
            this.formBarBase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip formBarBase;
        private System.Windows.Forms.ToolStripMenuItem closeBtn;
        private System.Windows.Forms.ToolStripMenuItem minBtn;
        public System.Windows.Forms.ToolStripComboBox DBcombo;
        public System.Windows.Forms.ToolStripComboBox SVCombo;
        public System.Windows.Forms.ToolStripMenuItem title;
        public System.Windows.Forms.ToolStripMenuItem topMost;
    }
}
