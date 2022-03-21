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
            this.checkBoxNoReadLnk = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxBW = new System.Windows.Forms.TextBox();
            this.textBoxBH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxStateBar = new System.Windows.Forms.CheckBox();
            this.checkBoxFormIcon = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxTabLoac = new System.Windows.Forms.ComboBox();
            this.pictureBoxBack = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBack)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxHideStart
            // 
            this.checkBoxHideStart.AutoSize = true;
            this.checkBoxHideStart.Location = new System.Drawing.Point(14, 136);
            this.checkBoxHideStart.Name = "checkBoxHideStart";
            this.checkBoxHideStart.Size = new System.Drawing.Size(108, 16);
            this.checkBoxHideStart.TabIndex = 5;
            this.checkBoxHideStart.Text = "启动后隐藏窗口";
            this.checkBoxHideStart.UseVisualStyleBackColor = true;
            this.checkBoxHideStart.CheckedChanged += new System.EventHandler(this.CheckBoxHideStart_CheckedChanged);
            // 
            // checkBoxHideRun
            // 
            this.checkBoxHideRun.AutoSize = true;
            this.checkBoxHideRun.Location = new System.Drawing.Point(200, 136);
            this.checkBoxHideRun.Name = "checkBoxHideRun";
            this.checkBoxHideRun.Size = new System.Drawing.Size(132, 16);
            this.checkBoxHideRun.TabIndex = 6;
            this.checkBoxHideRun.Text = "运行项目后隐藏窗口";
            this.checkBoxHideRun.UseVisualStyleBackColor = true;
            this.checkBoxHideRun.CheckedChanged += new System.EventHandler(this.CheckBoxHideRun_CheckedChanged);
            // 
            // checkBoxTopmost
            // 
            this.checkBoxTopmost.AutoSize = true;
            this.checkBoxTopmost.Location = new System.Drawing.Point(200, 71);
            this.checkBoxTopmost.Name = "checkBoxTopmost";
            this.checkBoxTopmost.Size = new System.Drawing.Size(72, 16);
            this.checkBoxTopmost.TabIndex = 2;
            this.checkBoxTopmost.Text = "窗口置顶";
            this.checkBoxTopmost.UseVisualStyleBackColor = true;
            this.checkBoxTopmost.CheckedChanged += new System.EventHandler(this.CheckBoxTopmost_CheckedChanged);
            // 
            // checkBoxNotExit
            // 
            this.checkBoxNotExit.AutoSize = true;
            this.checkBoxNotExit.Location = new System.Drawing.Point(14, 172);
            this.checkBoxNotExit.Name = "checkBoxNotExit";
            this.checkBoxNotExit.Size = new System.Drawing.Size(168, 16);
            this.checkBoxNotExit.TabIndex = 7;
            this.checkBoxNotExit.Text = "点击关闭按钮进入后台运行";
            this.checkBoxNotExit.UseVisualStyleBackColor = true;
            this.checkBoxNotExit.CheckedChanged += new System.EventHandler(this.CheckBoxNotExit_CheckedChanged);
            // 
            // checkBoxAutoStart
            // 
            this.checkBoxAutoStart.AutoSize = true;
            this.checkBoxAutoStart.Location = new System.Drawing.Point(14, 71);
            this.checkBoxAutoStart.Name = "checkBoxAutoStart";
            this.checkBoxAutoStart.Size = new System.Drawing.Size(72, 16);
            this.checkBoxAutoStart.TabIndex = 1;
            this.checkBoxAutoStart.Text = "开机启动";
            this.checkBoxAutoStart.UseVisualStyleBackColor = true;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(39, 33);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(341, 21);
            this.textBoxTitle.TabIndex = 0;
            this.textBoxTitle.TextChanged += new System.EventHandler(this.TextBoxTitle_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "窗口标题";
            // 
            // checkBoxNoReadLnk
            // 
            this.checkBoxNoReadLnk.AutoSize = true;
            this.checkBoxNoReadLnk.Location = new System.Drawing.Point(200, 172);
            this.checkBoxNoReadLnk.Name = "checkBoxNoReadLnk";
            this.checkBoxNoReadLnk.Size = new System.Drawing.Size(180, 16);
            this.checkBoxNoReadLnk.TabIndex = 8;
            this.checkBoxNoReadLnk.Text = "不读取快捷方式指向的源文件";
            this.checkBoxNoReadLnk.UseVisualStyleBackColor = true;
            this.checkBoxNoReadLnk.CheckedChanged += new System.EventHandler(this.CheckBoxNoReadLnk_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "标签尺寸";
            // 
            // textBoxBW
            // 
            this.textBoxBW.Location = new System.Drawing.Point(236, 205);
            this.textBoxBW.Name = "textBoxBW";
            this.textBoxBW.Size = new System.Drawing.Size(60, 21);
            this.textBoxBW.TabIndex = 10;
            // 
            // textBoxBH
            // 
            this.textBoxBH.Location = new System.Drawing.Point(320, 205);
            this.textBoxBH.Name = "textBoxBH";
            this.textBoxBH.Size = new System.Drawing.Size(60, 21);
            this.textBoxBH.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "宽";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "高";
            // 
            // checkBoxStateBar
            // 
            this.checkBoxStateBar.AutoSize = true;
            this.checkBoxStateBar.Location = new System.Drawing.Point(14, 102);
            this.checkBoxStateBar.Name = "checkBoxStateBar";
            this.checkBoxStateBar.Size = new System.Drawing.Size(84, 16);
            this.checkBoxStateBar.TabIndex = 3;
            this.checkBoxStateBar.Text = "显示任务栏";
            this.checkBoxStateBar.UseVisualStyleBackColor = true;
            // 
            // checkBoxFormIcon
            // 
            this.checkBoxFormIcon.AutoSize = true;
            this.checkBoxFormIcon.Location = new System.Drawing.Point(200, 102);
            this.checkBoxFormIcon.Name = "checkBoxFormIcon";
            this.checkBoxFormIcon.Size = new System.Drawing.Size(96, 16);
            this.checkBoxFormIcon.TabIndex = 4;
            this.checkBoxFormIcon.Text = "显示窗口图标";
            this.checkBoxFormIcon.UseVisualStyleBackColor = true;
            this.checkBoxFormIcon.CheckedChanged += new System.EventHandler(this.CheckBoxFormIcon_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "标签位置";
            // 
            // comboBoxTabLoac
            // 
            this.comboBoxTabLoac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTabLoac.FormattingEnabled = true;
            this.comboBoxTabLoac.Items.AddRange(new object[] {
            "顶部",
            "底部",
            "左侧",
            "右侧"});
            this.comboBoxTabLoac.Location = new System.Drawing.Point(72, 205);
            this.comboBoxTabLoac.Name = "comboBoxTabLoac";
            this.comboBoxTabLoac.Size = new System.Drawing.Size(66, 20);
            this.comboBoxTabLoac.TabIndex = 9;
            this.comboBoxTabLoac.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTabLoac_SelectedIndexChanged);
            // 
            // pictureBoxBack
            // 
            this.pictureBoxBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBack.Location = new System.Drawing.Point(98, 242);
            this.pictureBoxBack.Name = "pictureBoxBack";
            this.pictureBoxBack.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxBack.TabIndex = 26;
            this.pictureBoxBack.TabStop = false;
            this.pictureBoxBack.Click += new System.EventHandler(this.PictureBoxBack_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "标签背景颜色";
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 296);
            this.Controls.Add(this.pictureBoxBack);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxTabLoac);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBoxFormIcon);
            this.Controls.Add(this.checkBoxStateBar);
            this.Controls.Add(this.textBoxBH);
            this.Controls.Add(this.textBoxBW);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBoxNoReadLnk);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBack)).EndInit();
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
        private System.Windows.Forms.CheckBox checkBoxNoReadLnk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxBW;
        private System.Windows.Forms.TextBox textBoxBH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxStateBar;
        private System.Windows.Forms.CheckBox checkBoxFormIcon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxTabLoac;
        private System.Windows.Forms.PictureBox pictureBoxBack;
        private System.Windows.Forms.Label label6;
    }
}
