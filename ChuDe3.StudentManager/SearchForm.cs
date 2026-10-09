using System;
using System.Windows.Forms;

namespace ChuDe3.StudentManager
{
    public partial class SearchForm : Form
    {
        public StudentSearchCriteria Criteria { get; private set; }

        public SearchForm()
        {
            InitializeComponent();
        }

        private void Find_Click(object sender, EventArgs e)
        {
            Criteria = new StudentSearchCriteria
            {
                StudentId = _txtId.Text.Trim(),
                Name = _txtName.Text.Trim(),
                ClassName = _txtClass.Text.Trim(),
                Combination = _cmbCombination.SelectedIndex == 0 ? SearchCombination.All : SearchCombination.Any
            };

            if (!Criteria.HasCondition)
            {
                MessageBox.Show("Hãy nhập ít nhất một điều kiện tìm kiếm.", "Thiếu điều kiện", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
            }
        }
    }
}
