namespace TF_Program2017
{
    partial class Form1
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.系统命令ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.调车计划ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.g1_EnterV = new System.Windows.Forms.Label();
            this.g1_OutV = new System.Windows.Forms.Label();
            this.系统还原ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统命令ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1014, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 系统命令ToolStripMenuItem
            // 
            this.系统命令ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.调车计划ToolStripMenuItem,
            this.系统还原ToolStripMenuItem});
            this.系统命令ToolStripMenuItem.Name = "系统命令ToolStripMenuItem";
            this.系统命令ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.系统命令ToolStripMenuItem.Text = "系统命令";
            // 
            // 调车计划ToolStripMenuItem
            // 
            this.调车计划ToolStripMenuItem.Name = "调车计划ToolStripMenuItem";
            this.调车计划ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.调车计划ToolStripMenuItem.Text = "勾计划";
            this.调车计划ToolStripMenuItem.Click += new System.EventHandler(this.调车计划ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(520, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // g1_EnterV
            // 
            this.g1_EnterV.AutoSize = true;
            this.g1_EnterV.Location = new System.Drawing.Point(473, 222);
            this.g1_EnterV.Name = "g1_EnterV";
            this.g1_EnterV.Size = new System.Drawing.Size(41, 12);
            this.g1_EnterV.TabIndex = 10;
            this.g1_EnterV.Text = "label2";
            // 
            // g1_OutV
            // 
            this.g1_OutV.AutoSize = true;
            this.g1_OutV.Location = new System.Drawing.Point(552, 223);
            this.g1_OutV.Name = "g1_OutV";
            this.g1_OutV.Size = new System.Drawing.Size(41, 12);
            this.g1_OutV.TabIndex = 11;
            this.g1_OutV.Text = "label2";
            // 
            // 系统还原ToolStripMenuItem
            // 
            this.系统还原ToolStripMenuItem.Name = "系统还原ToolStripMenuItem";
            this.系统还原ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.系统还原ToolStripMenuItem.Text = "系统还原";
            this.系统还原ToolStripMenuItem.Click += new System.EventHandler(this.系统还原ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 662);
            this.Controls.Add(this.g1_OutV);
            this.Controls.Add(this.g1_EnterV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "一条执行进路";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 系统命令ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 调车计划ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label g1_EnterV;
        private System.Windows.Forms.Label g1_OutV;
        private System.Windows.Forms.ToolStripMenuItem 系统还原ToolStripMenuItem;
    }
}

