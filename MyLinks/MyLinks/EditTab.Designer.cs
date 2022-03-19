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
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxFore = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBoxBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBack)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxBG
            // 
            this.checkBoxBG.AutoSize = true;
            this.checkBoxBG.Location = new System.Drawing.Point(12, 138);
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
            this.textBoxImg.Location = new System.Drawing.Point(46, 160);
            this.textBoxImg.Multiline = true;
            this.textBoxImg.Name = "textBoxImg";
            this.textBoxImg.Size = new System.Drawing.Size(333, 43);
            this.textBoxImg.TabIndex = 1;
            this.textBoxImg.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBoxImg_DragDrop);
            this.textBoxImg.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBoxImg_DragEnter);
            this.textBoxImg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxImg_KeyPress);
            // 
            // checkBoxTiled
            // 
            this.checkBoxTiled.AutoSize = true;
            this.checkBoxTiled.Location = new System.Drawing.Point(37, 210);
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
            this.linkLabelBKImage.Location = new System.Drawing.Point(385, 160);
            this.linkLabelBKImage.Name = "linkLabelBKImage";
            this.linkLabelBKImage.Size = new System.Drawing.Size(29, 12);
            this.linkLabelBKImage.TabIndex = 3;
            this.linkLabelBKImage.TabStop = true;
            this.linkLabelBKImage.Text = "浏览";
            this.linkLabelBKImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelBKImage_LinkClicked);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(45, 12);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(333, 21);
            this.textBoxTitle.TabIndex = 9;
            this.textBoxTitle.TextChanged += new System.EventHandler(this.TextBoxTitle_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "标题";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "文字颜色";
            // 
            // pictureBoxFore
            // 
            this.pictureBoxFore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxFore.Location = new System.Drawing.Point(71, 94);
            this.pictureBoxFore.Name = "pictureBoxFore";
            this.pictureBoxFore.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxFore.TabIndex = 24;
            this.pictureBoxFore.TabStop = false;
            this.pictureBoxFore.Click += new System.EventHandler(this.PictureBoxFore_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "背景颜色";
            // 
            // pictureBoxBack
            // 
            this.pictureBoxBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBack.Location = new System.Drawing.Point(71, 51);
            this.pictureBoxBack.Name = "pictureBoxBack";
            this.pictureBoxBack.Size = new System.Drawing.Size(25, 25);
            this.pictureBoxBack.TabIndex = 24;
            this.pictureBoxBack.TabStop = false;
            this.pictureBoxBack.Click += new System.EventHandler(this.PictureBoxBack_Click);
            // 
            // EditTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 271);
            this.Controls.Add(this.pictureBoxBack);
            this.Controls.Add(this.pictureBoxFore);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
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
            this.Text = "类别设置";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBack)).EndInit();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxFore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBoxBack;
    }
}
