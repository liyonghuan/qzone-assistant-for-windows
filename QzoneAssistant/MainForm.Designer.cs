namespace QzoneSpider
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAllDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemFileSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabelSavePath = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabelDownload = new System.Windows.Forms.ToolStripStatusLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFile,
            this.MenuItemFileSetting});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1103, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemFile
            // 
            this.MenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemAllDownload,
            this.MenuItemFileExit});
            this.MenuItemFile.Name = "MenuItemFile";
            this.MenuItemFile.Size = new System.Drawing.Size(96, 28);
            this.MenuItemFile.Text = "文件(&F）";
            // 
            // MenuItemAllDownload
            // 
            this.MenuItemAllDownload.Name = "MenuItemAllDownload";
            this.MenuItemAllDownload.Size = new System.Drawing.Size(270, 34);
            this.MenuItemAllDownload.Text = "全部下载(&A)";
            this.MenuItemAllDownload.Click += new System.EventHandler(this.MenuItemAllDownload_Click);
            // 
            // MenuItemFileExit
            // 
            this.MenuItemFileExit.Name = "MenuItemFileExit";
            this.MenuItemFileExit.Size = new System.Drawing.Size(270, 34);
            this.MenuItemFileExit.Text = "退出(&E)";
            this.MenuItemFileExit.Click += new System.EventHandler(this.MenuItemFileExit_Click);
            // 
            // MenuItemFileSetting
            // 
            this.MenuItemFileSetting.Name = "MenuItemFileSetting";
            this.MenuItemFileSetting.Size = new System.Drawing.Size(84, 28);
            this.MenuItemFileSetting.Text = "设置(&S)";
            this.MenuItemFileSetting.Click += new System.EventHandler(this.MenuItemFileSetting_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabelSavePath,
            this.StatusLabelDownload});
            this.statusStrip1.Location = new System.Drawing.Point(0, 612);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1103, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabelSavePath
            // 
            this.StatusLabelSavePath.Name = "StatusLabelSavePath";
            this.StatusLabelSavePath.Size = new System.Drawing.Size(0, 15);
            // 
            // StatusLabelDownload
            // 
            this.StatusLabelDownload.Name = "StatusLabelDownload";
            this.StatusLabelDownload.Size = new System.Drawing.Size(0, 15);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 36);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1103, 563);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemDownload});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(167, 34);
            // 
            // MenuItemDownload
            // 
            this.MenuItemDownload.Name = "MenuItemDownload";
            this.MenuItemDownload.Size = new System.Drawing.Size(166, 30);
            this.MenuItemDownload.Text = "下载相册&D";
            this.MenuItemDownload.Click += new System.EventHandler(this.MenuItemDownload_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1103, 634);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "QQ空间助手";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFileExit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFileSetting;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabelSavePath;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDownload;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabelDownload;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAllDownload;
    }
}

