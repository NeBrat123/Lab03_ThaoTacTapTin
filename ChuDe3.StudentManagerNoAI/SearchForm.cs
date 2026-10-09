namespace ChuDe3.StudentManagerNoAI
{
    public partial class SearchForm : Form
    {
        public string StudentId => txtStudentId.Text.Trim();
        public string StudentName => txtStudentName.Text.Trim();
        public string ClassName => txtClassName.Text.Trim();
        public bool MatchAll => rdoAll.Checked;

        public SearchForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            if (StudentId.Length == 0 && StudentName.Length == 0 && ClassName.Length == 0)
            {
                MessageBox.Show(this, "Vui lòng nhập ít nhất một điều kiện tìm kiếm.", "Thông báo");
                txtStudentId.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

