using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ChuDe3.StudentManager
{
    public partial class MainForm : Form
    {
        private readonly StudentManagerService _service = new StudentManagerService();
        private string _currentPath;
        private string _selectedOriginalId;
        private List<Student> _displayedStudents = new List<Student>();
        private bool _populating;

        public MainForm()
        {
            InitializeComponent();
            _birthDate.MaxDate = DateTime.Today;
            _enrollmentYear.Maximum = DateTime.Today.Year;
            _enrollmentYear.Value = DateTime.Today.Year;
            UpdateButtonState();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            var last = SettingsStore.LoadLastPath();
            var sample = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "students.txt");
            LoadStudents(File.Exists(last) ? last : sample, !File.Exists(last));
        }

        private void OpenFileMenuItem_Click(object sender, EventArgs e) { OpenFile(); }
        private void SaveMenuItem_Click(object sender, EventArgs e) { SaveCurrent(); }
        private void SaveAsMenuItem_Click(object sender, EventArgs e) { SaveAs(); }
        private void Exit_Click(object sender, EventArgs e) { Close(); }

        private void InputChanged(object sender, EventArgs e)
        {
            if (!_populating) UpdateButtonState();
        }

        private void Subjects_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!_populating && IsHandleCreated) BeginInvoke(new Action(UpdateButtonState));
        }

        private void LoadStudents(string path, bool isFallback)
        {
            try
            {
                var students = StudentRepositoryFactory.FromPath(path).Load(path);
                _service.ReplaceAll(students);
                _currentPath = path;
                SettingsStore.SaveLastPath(path);
                RefreshList(_service.Students);
                _status.Text = "Đã tải " + _service.Students.Count + " sinh viên từ: " + path;
            }
            catch (Exception ex)
            {
                if (!isFallback)
                {
                    MessageBox.Show("Không thể tải tệp đã chọn. Danh sách hiện tại vẫn được giữ nguyên.\r\n\r\n" + ex.Message, "Lỗi mở tệp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Không thể tải dữ liệu mẫu: " + ex.Message, "Lỗi khởi động", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenFile()
        {
            using (var dialog = new OpenFileDialog { Filter = "Tệp sinh viên (*.txt;*.xml;*.json)|*.txt;*.xml;*.json|TXT (*.txt)|*.txt|XML (*.xml)|*.xml|JSON (*.json)|*.json" })
            {
                if (dialog.ShowDialog(this) == DialogResult.OK) LoadStudents(dialog.FileName, false);
            }
        }

        private void SaveCurrent()
        {
            if (string.IsNullOrWhiteSpace(_currentPath)) { SaveAs(); return; }
            try { Persist(); MessageBox.Show("Đã lưu dữ liệu.", "Lưu tệp", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Không thể lưu", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void SaveAs()
        {
            using (var dialog = new SaveFileDialog { Filter = "TXT (*.txt)|*.txt|XML (*.xml)|*.xml|JSON (*.json)|*.json", FileName = Path.GetFileName(_currentPath ?? "students.txt") })
            {
                if (dialog.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    StudentRepositoryFactory.FromPath(dialog.FileName).Save(dialog.FileName, _service.Students);
                    _currentPath = dialog.FileName;
                    SettingsStore.SaveLastPath(_currentPath);
                    _status.Text = "Đã lưu " + _service.Students.Count + " sinh viên vào: " + _currentPath;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Không thể lưu", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Student student;
            if (!TryGetStudent(out student)) return;
            try
            {
                _service.Add(student); Persist(); RefreshList(_service.Students); SelectStudent(student.StudentId);
                _status.Text = "Đã thêm sinh viên " + student.StudentId + ".";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Không thể thêm", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_selectedOriginalId))
            {
                MessageBox.Show("Hãy chọn sinh viên cần cập nhật trong danh sách.", "Chưa chọn sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Student student;
            if (!TryGetStudent(out student)) return;
            try
            {
                _service.Update(_selectedOriginalId, student); Persist(); RefreshList(_service.Students); SelectStudent(student.StudentId);
                _status.Text = "Đã cập nhật sinh viên " + student.StudentId + ".";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Không thể cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void DeleteStudents_Click(object sender, EventArgs e)
        {
            var ids = _listView.Items.Cast<ListViewItem>().Where(item => item.Checked).Select(item => (string)item.Tag).ToList();
            if (ids.Count == 0 && _listView.SelectedItems.Count > 0) ids.Add((string)_listView.SelectedItems[0].Tag);
            if (ids.Count == 0)
            {
                MessageBox.Show("Hãy đánh dấu hoặc chọn ít nhất một sinh viên.", "Chưa chọn sinh viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Xóa " + ids.Count + " sinh viên đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try { _service.Delete(ids); Persist(); ClearForm(); RefreshList(_service.Students); _status.Text = "Đã xóa " + ids.Count + " sinh viên."; }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            using (var dialog = new SearchForm())
            {
                if (dialog.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    var found = _service.Search(dialog.Criteria);
                    RefreshList(found);
                    _status.Text = "Tìm thấy " + found.Count + " sinh viên. Nhấp Tệp > Mở hoặc tìm lại để xem toàn bộ danh sách.";
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Không thể tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }
        }

        private void AddSubject_Click(object sender, EventArgs e)
        {
            using (var dialog = new SubjectDialog())
            {
                if (dialog.ShowDialog(this) != DialogResult.OK) return;
                var exists = _subjects.Items.Cast<object>().Any(item => string.Equals(item.ToString(), dialog.SubjectName, StringComparison.OrdinalIgnoreCase));
                if (exists)
                {
                    MessageBox.Show("Môn học này đã có trong danh sách.", "Trùng môn học", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _subjects.Items.Add(dialog.SubjectName, true);
                UpdateButtonState();
            }
        }

        private void DeleteSubject_Click(object sender, EventArgs e)
        {
            if (_subjects.SelectedIndex < 0)
            {
                MessageBox.Show("Hãy chọn môn học cần xóa.", "Chưa chọn môn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _subjects.Items.RemoveAt(_subjects.SelectedIndex);
            UpdateButtonState();
        }

        private bool TryGetStudent(out Student student)
        {
            student = new Student
            {
                StudentId = _txtId.Text.Trim(),
                LastNameAndMiddleName = _txtMiddleName.Text.Trim(),
                FirstName = _txtFirstName.Text.Trim(),
                BirthDate = _birthDate.Value.Date,
                Gender = _female.Checked ? Gender.Female : Gender.Male,
                ClassName = _className.Text.Trim(),
                EnrollmentYear = (int)_enrollmentYear.Value,
                IdentityNumber = _txtIdentity.Text,
                PhoneNumber = _txtPhone.Text,
                Address = _txtAddress.Text.Trim(),
                Subjects = _subjects.CheckedItems.Cast<object>().Select(item => item.ToString()).ToList()
            };
            var validation = StudentManagerService.Validate(student);
            _errors.Clear();
            if (!_male.Checked && !_female.Checked) validation.Add("Hãy chọn giới tính.");
            if (validation.Count == 0) return true;
            _errors.SetError(_txtId, validation[0]);
            MessageBox.Show(string.Join(Environment.NewLine, validation.Select(message => "• " + message)), "Thông tin chưa hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void RefreshList(IReadOnlyList<Student> students)
        {
            _displayedStudents = students.Select(s => s.Clone()).ToList();
            _populating = true;
            _listView.BeginUpdate();
            _listView.Items.Clear();
            foreach (var student in _displayedStudents)
            {
                var item = new ListViewItem(student.StudentId) { Tag = student.StudentId };
                item.SubItems.Add(student.LastNameAndMiddleName);
                item.SubItems.Add(student.FirstName);
                item.SubItems.Add(student.BirthDate.ToString("dd/MM/yyyy"));
                item.SubItems.Add(student.ClassName);
                item.SubItems.Add(student.EnrollmentYear.ToString());
                item.SubItems.Add(student.IdentityNumber);
                item.SubItems.Add(student.PhoneNumber);
                item.SubItems.Add(student.Address);
                _listView.Items.Add(item);
            }
            _listView.EndUpdate();
            _populating = false;
            UpdateButtonState();
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_populating || _listView.SelectedItems.Count != 1) return;
            var id = (string)_listView.SelectedItems[0].Tag;
            var student = _service.Students.FirstOrDefault(s => string.Equals(s.StudentId, id, StringComparison.OrdinalIgnoreCase));
            if (student == null) return;
            PopulateForm(student);
            _selectedOriginalId = student.StudentId;
            UpdateButtonState();
        }

        private void PopulateForm(Student student)
        {
            _populating = true;
            _txtId.Text = student.StudentId;
            _txtMiddleName.Text = student.LastNameAndMiddleName;
            _txtFirstName.Text = student.FirstName;
            _birthDate.Value = student.BirthDate;
            _male.Checked = student.Gender == Gender.Male;
            _female.Checked = student.Gender == Gender.Female;
            _className.Text = student.ClassName;
            _enrollmentYear.Value = Math.Max(_enrollmentYear.Minimum, Math.Min(_enrollmentYear.Maximum, student.EnrollmentYear));
            _txtIdentity.Text = student.IdentityNumber;
            _txtPhone.Text = student.PhoneNumber;
            _txtAddress.Text = student.Address;
            foreach (var subject in student.Subjects.Where(subject => !_subjects.Items.Cast<object>().Any(item => string.Equals(item.ToString(), subject, StringComparison.OrdinalIgnoreCase)))) _subjects.Items.Add(subject);
            for (var i = 0; i < _subjects.Items.Count; i++) _subjects.SetItemChecked(i, student.Subjects.Any(subject => string.Equals(subject, _subjects.Items[i].ToString(), StringComparison.OrdinalIgnoreCase)));
            _populating = false;
        }

        private void SelectStudent(string studentId)
        {
            foreach (ListViewItem item in _listView.Items)
            {
                if (!string.Equals((string)item.Tag, studentId, StringComparison.OrdinalIgnoreCase)) continue;
                item.Selected = true;
                item.Focused = true;
                item.EnsureVisible();
                break;
            }
        }

        private void ClearForm()
        {
            _populating = true;
            _txtId.Clear(); _txtMiddleName.Clear(); _txtFirstName.Clear(); _txtIdentity.Clear(); _txtPhone.Clear(); _txtAddress.Clear();
            _className.SelectedIndex = -1;
            _birthDate.Value = new DateTime(2004, 1, 1);
            _male.Checked = false;
            _female.Checked = false;
            _enrollmentYear.Value = DateTime.Today.Year;
            for (var i = 0; i < _subjects.Items.Count; i++) _subjects.SetItemChecked(i, false);
            _selectedOriginalId = null;
            _populating = false;
            UpdateButtonState();
        }

        private void Persist()
        {
            if (string.IsNullOrWhiteSpace(_currentPath)) throw new InvalidOperationException("Chưa có tệp dữ liệu để lưu.");
            StudentRepositoryFactory.FromPath(_currentPath).Save(_currentPath, _service.Students);
            SettingsStore.SaveLastPath(_currentPath);
        }

        private void UpdateButtonState()
        {
            var basic = !string.IsNullOrWhiteSpace(_txtId.Text) && !string.IsNullOrWhiteSpace(_txtMiddleName.Text) && !string.IsNullOrWhiteSpace(_txtFirstName.Text) && (_male.Checked || _female.Checked) && !string.IsNullOrWhiteSpace(_className.Text) && _txtIdentity.Text.Length == 9 && _txtPhone.Text.Length == 10 && !string.IsNullOrWhiteSpace(_txtAddress.Text) && _subjects.CheckedItems.Count > 0;
            _add.Enabled = basic;
            _update.Enabled = basic && !string.IsNullOrWhiteSpace(_selectedOriginalId);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) e.Cancel = true;
        }

        private void _subjects_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _inputTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void _genderPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
