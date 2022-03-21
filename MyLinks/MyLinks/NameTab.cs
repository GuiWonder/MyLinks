using System;
using System.Windows.Forms;

namespace MyLinks
{
    public partial class NameTab : Form
    {
        public string name;
        public NameTab(string n)
        {
            InitializeComponent();
            buttonOK.Click += ButtonOK_Click;
            buttonCancel.Click += ButtonCancel_Click; ;
            if (!string.IsNullOrEmpty(n))
            {
                textBox1.Text = n;
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e) => Close();

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(s))
            {
                MessageBox.Show(this, "名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            name = s;
            DialogResult = DialogResult.OK;
        }
    }
}
