namespace MyLinks
{
    partial class EditIco
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCanc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxParth = new System.Windows.Forms.TextBox();
            this.textBoxArg = new System.Windows.Forms.TextBox();
            this.checkBoxRunAs = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(55, 220);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "保存";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);
            // 
            // buttonCanc
            // 
            this.buttonCanc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCanc.Location = new System.Drawing.Point(262, 220);
            this.buttonCanc.Name = "buttonCanc";
            this.buttonCanc.Size = new System.Drawing.Size(75, 23);
            this.buttonCanc.TabIndex = 1;
            this.buttonCanc.Text = "取消";
            this.buttonCanc.UseVisualStyleBackColor = true;
            this.buttonCanc.Click += new System.EventHandler(this.ButtonCanc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "位置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "参数";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(55, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(325, 21);
            this.textBoxName.TabIndex = 5;
            // 
            // textBoxParth
            // 
            this.textBoxParth.Location = new System.Drawing.Point(55, 51);
            this.textBoxParth.Multiline = true;
            this.textBoxParth.Name = "textBoxParth";
            this.textBoxParth.Size = new System.Drawing.Size(325, 66);
            this.textBoxParth.TabIndex = 6;
            // 
            // textBoxArg
            // 
            this.textBoxArg.Location = new System.Drawing.Point(55, 136);
            this.textBoxArg.Name = "textBoxArg";
            this.textBoxArg.Size = new System.Drawing.Size(325, 21);
            this.textBoxArg.TabIndex = 7;
            // 
            // checkBoxRunAs
            // 
            this.checkBoxRunAs.AutoSize = true;
            this.checkBoxRunAs.Location = new System.Drawing.Point(15, 174);
            this.checkBoxRunAs.Name = "checkBoxRunAs";
            this.checkBoxRunAs.Size = new System.Drawing.Size(108, 16);
            this.checkBoxRunAs.TabIndex = 8;
            this.checkBoxRunAs.Text = "管理员方式运行";
            this.checkBoxRunAs.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(381, 54);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(29, 12);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "选择";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // EditIco
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCanc;
            this.ClientSize = new System.Drawing.Size(417, 270);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.checkBoxRunAs);
            this.Controls.Add(this.textBoxArg);
            this.Controls.Add(this.textBoxParth);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCanc);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditIco";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "编辑属性";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCanc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxParth;
        private System.Windows.Forms.TextBox textBoxArg;
        private System.Windows.Forms.CheckBox checkBoxRunAs;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
