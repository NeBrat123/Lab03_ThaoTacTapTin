using System;
using System.Windows.Forms;

namespace ChuDe3.StudentManager
{
    public partial class SubjectDialog : Form
    {
        public string SubjectName
        {
            get { return _textBox.Text.Trim(); }
        }

        public SubjectDialog()
        {
            InitializeComponent();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SubjectName))
            {
                MessageBox.Show("Tên môn học không được để trống.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
            }
        }
    }
}
