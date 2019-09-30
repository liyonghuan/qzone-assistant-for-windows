namespace QzoneSpider
{
    partial class SettingsForm
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
            this.labelUin = new System.Windows.Forms.Label();
            this.labelHostUin = new System.Windows.Forms.Label();
            this.textBoxUin = new System.Windows.Forms.TextBox();
            this.textBoxHostUin = new System.Windows.Forms.TextBox();
            this.labelCookie = new System.Windows.Forms.Label();
            this.textBoxCookie = new System.Windows.Forms.TextBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelUin
            // 
            this.labelUin.AutoSize = true;
            this.labelUin.Location = new System.Drawing.Point(30, 20);
            this.labelUin.Name = "labelUin";
            this.labelUin.Size = new System.Drawing.Size(71, 18);
            this.labelUin.TabIndex = 0;
            this.labelUin.Text = "QQ账号:";
            // 
            // labelHostUin
            // 
            this.labelHostUin.AutoSize = true;
            this.labelHostUin.Location = new System.Drawing.Point(12, 80);
            this.labelHostUin.Name = "labelHostUin";
            this.labelHostUin.Size = new System.Drawing.Size(89, 18);
            this.labelHostUin.TabIndex = 1;
            this.labelHostUin.Text = "查看账号:";
            // 
            // textBoxUin
            // 
            this.textBoxUin.Location = new System.Drawing.Point(107, 10);
            this.textBoxUin.Name = "textBoxUin";
            this.textBoxUin.Size = new System.Drawing.Size(343, 28);
            this.textBoxUin.TabIndex = 2;
            this.textBoxUin.Tag = "";
            // 
            // textBoxHostUin
            // 
            this.textBoxHostUin.Location = new System.Drawing.Point(107, 70);
            this.textBoxHostUin.Name = "textBoxHostUin";
            this.textBoxHostUin.Size = new System.Drawing.Size(343, 28);
            this.textBoxHostUin.TabIndex = 3;
            // 
            // labelCookie
            // 
            this.labelCookie.AutoSize = true;
            this.labelCookie.Location = new System.Drawing.Point(30, 129);
            this.labelCookie.Name = "labelCookie";
            this.labelCookie.Size = new System.Drawing.Size(71, 18);
            this.labelCookie.TabIndex = 4;
            this.labelCookie.Text = "Cookie:";
            // 
            // textBoxCookie
            // 
            this.textBoxCookie.Location = new System.Drawing.Point(107, 126);
            this.textBoxCookie.Multiline = true;
            this.textBoxCookie.Name = "textBoxCookie";
            this.textBoxCookie.Size = new System.Drawing.Size(343, 199);
            this.textBoxCookie.TabIndex = 5;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(218, 355);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(100, 35);
            this.buttonConfirm.TabIndex = 6;
            this.buttonConfirm.Text = "确定(&Y)";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(350, 355);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 35);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "取消(&N)";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 412);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.textBoxCookie);
            this.Controls.Add(this.labelCookie);
            this.Controls.Add(this.textBoxHostUin);
            this.Controls.Add(this.textBoxUin);
            this.Controls.Add(this.labelHostUin);
            this.Controls.Add(this.labelUin);
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUin;
        private System.Windows.Forms.Label labelHostUin;
        private System.Windows.Forms.TextBox textBoxUin;
        private System.Windows.Forms.TextBox textBoxHostUin;
        private System.Windows.Forms.Label labelCookie;
        private System.Windows.Forms.TextBox textBoxCookie;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
    }
}