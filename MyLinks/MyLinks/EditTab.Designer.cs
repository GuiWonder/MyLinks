namespace MyLinks
{
    partial class EditTab
    {/// <summary>
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
            this.checkBoxBG = new System.Windows.Forms.CheckBox();
            this.textBoxImg = new System.Windows.Forms.TextBox();
            this.checkBoxTiled = new System.Windows.Forms.CheckBox();
            this.linkLabelBKImage = new System.Windows.Forms.LinkLabel();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonList = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxBG
            // 
            this.checkBoxBG.AutoSize = true;
            this.checkBoxBG.Location = new System.Drawing.Point(11, 53);
            this.checkBoxBG.Name = "checkBoxBG";
            this.checkBoxBG.Size = new System.Drawing.Size(96, 16);
            this.checkBoxBG.TabIndex = 0;
            this.checkBoxBG.Text = "使用背景图片";
            this.checkBoxBG.UseVisualStyleBackColor = true;
            this.checkBoxBG.CheckedChanged += new System.EventHandler(this.CheckBoxBG_CheckedChanged);
            // 
            // textBoxImg
            // 
            this.textBoxImg.AllowDrop = true;
            this.textBoxImg.Location = new System.Drawing.Point(36, 75);
            this.textBoxImg.Multiline = true;
            this.textBoxImg.Name = "textBoxImg";
            this.textBoxImg.Size = new System.Drawing.Size(342, 43);
            this.textBoxImg.TabIndex = 1;
            this.textBoxImg.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBoxImg_DragDrop);
            this.textBoxImg.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBoxImg_DragEnter);
            this.textBoxImg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxImg_KeyPress);
            // 
            // checkBoxTiled
            // 
            this.checkBoxTiled.AutoSize = true;
            this.checkBoxTiled.Location = new System.Drawing.Point(36, 125);
            this.checkBoxTiled.Name = "checkBoxTiled";
            this.checkBoxTiled.Size = new System.Drawing.Size(96, 16);
            this.checkBoxTiled.TabIndex = 2;
            this.checkBoxTiled.Text = "背景图片平铺";
            this.checkBoxTiled.UseVisualStyleBackColor = true;
            this.checkBoxTiled.CheckedChanged += new System.EventHandler(this.CheckBoxTiled_CheckedChanged);
            // 
            // linkLabelBKImage
            // 
            this.linkLabelBKImage.AutoSize = true;
            this.linkLabelBKImage.Location = new System.Drawing.Point(384, 78);
            this.linkLabelBKImage.Name = "linkLabelBKImage";
            this.linkLabelBKImage.Size = new System.Drawing.Size(29, 12);
            this.linkLabelBKImage.TabIndex = 3;
            this.linkLabelBKImage.TabStop = true;
            this.linkLabelBKImage.Text = "浏览";
            this.linkLabelBKImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelBKImage_LinkClicked);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(78, 12);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(300, 21);
            this.textBoxTitle.TabIndex = 9;
            this.textBoxTitle.TextChanged += new System.EventHandler(this.TextBoxTitle_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "本栏标题";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "列表";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "文字颜色";
            // 
            // buttonList
            // 
            this.buttonList.Location = new System.Drawing.Point(70, 213);
            this.buttonList.Name = "buttonList";
            this.buttonList.Size = new System.Drawing.Size(75, 23);
            this.buttonList.TabIndex = 23;
            this.buttonList.Text = "内容";
            this.buttonList.UseVisualStyleBackColor = true;
            this.buttonList.Click += new System.EventHandler(this.ButtonList_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(70, 161);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // EditTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 286);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.linkLabelBKImage);
            this.Controls.Add(this.checkBoxTiled);
            this.Controls.Add(this.textBoxImg);
            this.Controls.Add(this.checkBoxBG);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditTab";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改栏";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxBG;
        private System.Windows.Forms.TextBox textBoxImg;
        private System.Windows.Forms.CheckBox checkBoxTiled;
        private System.Windows.Forms.LinkLabel linkLabelBKImage;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonList;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
