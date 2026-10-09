namespace ChuDe3.StudentManagerNoAI
{
    public partial class SubjectForm : Form
    {
        public string SubjectName => txtSubjectName.Text.Trim();

        public SubjectForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SubjectName))
            {
                MessageBox.Show(this, "Vui lòng nhập tên môn học.", "Thông báo");
                txtSubjectName.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

