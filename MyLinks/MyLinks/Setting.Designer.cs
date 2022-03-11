namespace MyLinks
{
    partial class Setting
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
            this.checkBoxHideStart = new System.Windows.Forms.CheckBox();
            this.checkBoxHideRun = new System.Windows.Forms.CheckBox();
            this.checkBoxTopmost = new System.Windows.Forms.CheckBox();
            this.checkBoxNotExit = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoStart = new System.Windows.Forms.CheckBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxHideStart
            // 
            this.checkBoxHideStart.AutoSize = true;
            this.checkBoxHideStart.Location = new System.Drawing.Point(198, 91);
            this.checkBoxHideStart.Name = "checkBoxHideStart";
            this.checkBoxHideStart.Size = new System.Drawing.Size(108, 16);
            this.checkBoxHideStart.TabIndex = 4;
            this.checkBoxHideStart.Text = "启动后进入后台";
            this.checkBoxHideStart.UseVisualStyleBackColor = true;
            this.checkBoxHideStart.CheckedChanged += new System.EventHandler(this.CheckBoxHideStart_CheckedChanged);
            // 
            // checkBoxHideRun
            // 
            this.checkBoxHideRun.AutoSize = true;
            this.checkBoxHideRun.Location = new System.Drawing.Point(12, 131);
            this.checkBoxHideRun.Name = "checkBoxHideRun";
            this.checkBoxHideRun.Size = new System.Drawing.Size(132, 16);
            this.checkBoxHideRun.TabIndex = 5;
            this.checkBoxHideRun.Text = "运行项目后隐藏窗口";
            this.checkBoxHideRun.UseVisualStyleBackColor = true;
            this.checkBoxHideRun.CheckedChanged += new System.EventHandler(this.CheckBoxHideRun_CheckedChanged);
            // 
            // checkBoxTopmost
            // 
            this.checkBoxTopmost.AutoSize = true;
            this.checkBoxTopmost.Location = new System.Drawing.Point(198, 131);
            this.checkBoxTopmost.Name = "checkBoxTopmost";
            this.checkBoxTopmost.Size = new System.Drawing.Size(72, 16);
            this.checkBoxTopmost.TabIndex = 6;
            this.checkBoxTopmost.Text = "窗口置顶";
            this.checkBoxTopmost.UseVisualStyleBackColor = true;
            this.checkBoxTopmost.CheckedChanged += new System.EventHandler(this.CheckBoxTopmost_CheckedChanged);
            // 
            // checkBoxNotExit
            // 
            this.checkBoxNotExit.AutoSize = true;
            this.checkBoxNotExit.Location = new System.Drawing.Point(12, 175);
            this.checkBoxNotExit.Name = "checkBoxNotExit";
            this.checkBoxNotExit.Size = new System.Drawing.Size(144, 16);
            this.checkBoxNotExit.TabIndex = 7;
            this.checkBoxNotExit.Text = "点击关闭按钮进入后台";
            this.checkBoxNotExit.UseVisualStyleBackColor = true;
            this.checkBoxNotExit.CheckedChanged += new System.EventHandler(this.CheckBoxNotExit_CheckedChanged);
            // 
            // checkBoxAutoStart
            // 
            this.checkBoxAutoStart.AutoSize = true;
            this.checkBoxAutoStart.Location = new System.Drawing.Point(12, 91);
            this.checkBoxAutoStart.Name = "checkBoxAutoStart";
            this.checkBoxAutoStart.Size = new System.Drawing.Size(72, 16);
            this.checkBoxAutoStart.TabIndex = 8;
            this.checkBoxAutoStart.Text = "开机启动";
            this.checkBoxAutoStart.UseVisualStyleBackColor = true;
            this.checkBoxAutoStart.CheckedChanged += new System.EventHandler(this.CheckBoxAutoStart_CheckedChanged);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(37, 44);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(341, 21);
            this.textBoxTitle.TabIndex = 9;
            this.textBoxTitle.TextChanged += new System.EventHandler(this.TextBoxTitle_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "窗口标题";
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 267);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.checkBoxAutoStart);
            this.Controls.Add(this.checkBoxNotExit);
            this.Controls.Add(this.checkBoxTopmost);
            this.Controls.Add(this.checkBoxHideRun);
            this.Controls.Add(this.checkBoxHideStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Setting";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxHideStart;
        private System.Windows.Forms.CheckBox checkBoxHideRun;
        private System.Windows.Forms.CheckBox checkBoxTopmost;
        private System.Windows.Forms.CheckBox checkBoxNotExit;
        private System.Windows.Forms.CheckBox checkBoxAutoStart;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label label1;
    }
}