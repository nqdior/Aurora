namespace Aurora.Viewer
{
    partial class Form1
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
            this.formBar1 = new Aurora.Viewer.FormBar();
            this.SuspendLayout();
            // 
            // formBar1
            // 
            this.formBar1.BackColor = System.Drawing.Color.White;
            this.formBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.formBar1.ForeColor = System.Drawing.Color.White;
            this.formBar1.isController = false;
            this.formBar1.Location = new System.Drawing.Point(0, 0);
            this.formBar1.Name = "formBar1";
            this.formBar1.Size = new System.Drawing.Size(549, 28);
            this.formBar1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 284);
            this.Controls.Add(this.formBar1);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private FormBar formBar1;
    }
}