namespace TF_Program2017
{
    partial class Order
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
            this.shiduan = new System.Windows.Forms.ComboBox();
            this.zhongduan = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Exe_Plan_Button = new System.Windows.Forms.Button();
            this.ParSet_Plan_Button = new System.Windows.Forms.Button();
            this.De_Plan_Button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // shiduan
            // 
            this.shiduan.FormattingEnabled = true;
            this.shiduan.Location = new System.Drawing.Point(28, 200);
            this.shiduan.Name = "shiduan";
            this.shiduan.Size = new System.Drawing.Size(69, 20);
            this.shiduan.TabIndex = 0;
            this.shiduan.Text = "始端";
            this.shiduan.TextChanged += new System.EventHandler(this.shiduan_TextChanged);
            // 
            // zhongduan
            // 
            this.zhongduan.FormattingEnabled = true;
            this.zhongduan.Location = new System.Drawing.Point(95, 200);
            this.zhongduan.Name = "zhongduan";
            this.zhongduan.Size = new System.Drawing.Size(67, 20);
            this.zhongduan.TabIndex = 1;
            this.zhongduan.Text = "终端";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(180, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "添加计划";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(28, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(86, 172);
            this.listBox1.TabIndex = 3;
            // 
            // Exe_Plan_Button
            // 
            this.Exe_Plan_Button.Location = new System.Drawing.Point(180, 13);
            this.Exe_Plan_Button.Name = "Exe_Plan_Button";
            this.Exe_Plan_Button.Size = new System.Drawing.Size(75, 23);
            this.Exe_Plan_Button.TabIndex = 4;
            this.Exe_Plan_Button.Text = "执行本记录";
            this.Exe_Plan_Button.UseVisualStyleBackColor = true;
            this.Exe_Plan_Button.Click += new System.EventHandler(this.button2_Click);
            // 
            // ParSet_Plan_Button
            // 
            this.ParSet_Plan_Button.Location = new System.Drawing.Point(181, 72);
            this.ParSet_Plan_Button.Name = "ParSet_Plan_Button";
            this.ParSet_Plan_Button.Size = new System.Drawing.Size(91, 23);
            this.ParSet_Plan_Button.TabIndex = 5;
            this.ParSet_Plan_Button.Text = "车辆参数设置";
            this.ParSet_Plan_Button.UseVisualStyleBackColor = true;
            // 
            // De_Plan_Button
            // 
            this.De_Plan_Button.Location = new System.Drawing.Point(180, 43);
            this.De_Plan_Button.Name = "De_Plan_Button";
            this.De_Plan_Button.Size = new System.Drawing.Size(75, 23);
            this.De_Plan_Button.TabIndex = 6;
            this.De_Plan_Button.Text = "删除计划";
            this.De_Plan_Button.UseVisualStyleBackColor = true;
            this.De_Plan_Button.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(180, 102);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "执行计划";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.De_Plan_Button);
            this.Controls.Add(this.ParSet_Plan_Button);
            this.Controls.Add(this.Exe_Plan_Button);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zhongduan);
            this.Controls.Add(this.shiduan);
            this.Name = "Order";
            this.Text = "Order";
            this.Load += new System.EventHandler(this.Order_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox shiduan;
        private System.Windows.Forms.ComboBox zhongduan;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Exe_Plan_Button;
        private System.Windows.Forms.Button ParSet_Plan_Button;
        private System.Windows.Forms.Button De_Plan_Button;
        private System.Windows.Forms.Button button2;
    }
}