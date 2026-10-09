namespace ChuDe3.StudentManagerNoAI
{
    public partial class MainForm : Form
    {
        private string _currentFilename = "";
        private string? _selectedStudentId;
        private bool _canSave;
        private bool _refreshing;
        private (string Id, string Name, string Class, bool All)? _search;
        private string _settingsFile = "";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            if (DesignMode) return;
            dtpBirthDate.MaxDate = DateTime.Today;
            _currentFilename = Path.Combine(AppContext.BaseDirectory, "Data", "students.json");
            bool remembered = false;
            try
            {
                if (_settingsFile.Length == 0)
                    _settingsFile = Path.Combine(Application.UserAppDataPath, "last-file.txt");
                if (File.Exists(_settingsFile))
                {
                    string path = File.ReadAllText(_settingsFile).Trim();
                    if (!string.IsNullOrEmpty(path))
                    {
                        _currentFilename = Path.GetFullPath(path);
                        remembered = true;
                    }
                }
                if (File.Exists(_currentFilename))
                    OpenStudentsFile(_currentFilename);
                else if (remembered)
                    throw new FileNotFoundException("Không tìm thấy tập tin mở gần nhất.", _currentFilename);
                else
                {
                    Singleton.SStudentsList = new List<Student>();
                    _canSave = true;
                    RefreshStudents();
                    ClearInput();
                }
            }
            catch (Exception ex)
            {
                _canSave = false;
                RefreshStudents();
                ClearInput();
                ShowError(ex);
                lblCurrentFile.Text = "Không tải được dữ liệu. Hãy mở tập tin hợp lệ hoặc chọn Tập tin mới.";
            }
        }

        private void OpenStudentsFile(string filename)
        {
            var students = Ultilities.LoadFile(filename);
            // Chỉ thay dữ liệu sau khi toàn bộ tập tin được đọc và kiểm tra thành công.
            Singleton.SStudentsList = students;
            _currentFilename = Path.GetFullPath(filename);
            _canSave = true;
            _search = null;
            RefreshStudents();
            ClearInput();
            RememberFile();
        }

        private void loadFileToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) != DialogResult.OK) return;
            try { OpenStudentsFile(openFileDialog1.FileName); }
            catch (Exception ex) { ShowError(ex); }
        }

        private void saveAsToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (!_canSave)
            {
                MessageBox.Show(this, "Hãy mở tập tin hợp lệ hoặc tạo tập tin mới trước khi lưu.", "Thông báo");
                return;
            }
            saveFileDialog1.FileName = Path.GetFileName(_currentFilename);
            saveFileDialog1.FilterIndex = Path.GetExtension(_currentFilename).ToLowerInvariant() switch
            {
                ".txt" => 2, ".xml" => 3, _ => 1
            };
            if (saveFileDialog1.ShowDialog(this) != DialogResult.OK) return;
            try
            {
                Ultilities.SaveFile(saveFileDialog1.FileName, Singleton.SStudentsList);
                _currentFilename = Path.GetFullPath(saveFileDialog1.FileName);
                RefreshStudents();
                RememberFile();
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void newFileToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            saveFileDialog1.FileName = "students.json";
            saveFileDialog1.FilterIndex = 1;
            if (saveFileDialog1.ShowDialog(this) != DialogResult.OK) return;
            try
            {
                var students = new List<Student>();
                Ultilities.SaveFile(saveFileDialog1.FileName, students);
                Singleton.SStudentsList = students;
                _currentFilename = Path.GetFullPath(saveFileDialog1.FileName);
                _canSave = true;
                _search = null;
                RefreshStudents();
                ClearInput();
                RememberFile();
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private Student ReadStudent()
        {
            var student = new Student
            {
                StudentID = txtStudentId.Text.Trim(),
                LastMiddleName = txtLastMiddleName.Text.Trim(),
                FirstName = txtFirstName.Text.Trim(),
                BirthDate = dtpBirthDate.Value.Date,
                Gender = rdoMale.Checked ? 0 : rdoFemale.Checked ? 1 : -1,
                ClassName = cboClass.Text.Trim().ToUpperInvariant(),
                IdentityNumber = txtIdentityNumber.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Subjects = clbSubjects.CheckedItems.Cast<string>().ToList()
            };
            student.ValidateInformation();
            return student;
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!EnsureCanSave()) return;
            try
            {
                var student = ReadStudent();
                if (Singleton.SStudentsList.Any(s => s.StudentID == student.StudentID))
                    throw new ArgumentException("MSSV đã tồn tại.");
                var students = Singleton.SStudentsList.Concat(new[] { student }).ToList();
                SaveStudents(students);
                _search = null;
                RefreshStudents(student.StudentID);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (!EnsureCanSave()) return;
            try
            {
                if (_selectedStudentId == null || !Singleton.SStudentsList.Any(s => s.StudentID == _selectedStudentId))
                    throw new ArgumentException("Vui lòng chọn sinh viên cần cập nhật.");
                var student = ReadStudent();
                if (Singleton.SStudentsList.Any(s => s.StudentID == student.StudentID && s.StudentID != _selectedStudentId))
                    throw new ArgumentException("MSSV đã tồn tại.");
                var students = Singleton.SStudentsList
                    .Select(s => s.StudentID == _selectedStudentId ? student : s).ToList();
                SaveStudents(students);
                _search = null;
                RefreshStudents(student.StudentID);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private void deleteStudentsToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (!EnsureCanSave()) return;
            dataGridView1.EndEdit();
            var ids = dataGridView1.Rows.Cast<DataGridViewRow>()
                .Where(row => Equals(row.Cells["Selected"].Value, true))
                .Select(row => row.DataBoundItem).OfType<Student>().Select(s => s.StudentID).ToHashSet();
            if (ids.Count == 0 && dataGridView1.CurrentRow?.DataBoundItem is Student current)
                ids.Add(current.StudentID);
            if (ids.Count == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn sinh viên cần xóa.", "Thông báo");
                return;
            }
            if (MessageBox.Show(this, $"Xóa {ids.Count} sinh viên đã chọn?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                var students = Singleton.SStudentsList.Where(s => !ids.Contains(s.StudentID)).ToList();
                SaveStudents(students);
                RefreshStudents();
                ClearInput();
            }
            catch (Exception ex) { ShowError(ex); }
        }

        private bool EnsureCanSave()
        {
            if (_canSave) return true;
            MessageBox.Show(this, "Hãy mở tập tin hợp lệ hoặc tạo tập tin mới trước khi thay đổi dữ liệu.", "Thông báo");
            return false;
        }

        private void SaveStudents(List<Student> students)
        {
            Ultilities.SaveFile(_currentFilename, students);
            Singleton.SStudentsList = students;
            RememberFile();
        }

        private void RememberFile()
        {
            try
            {
                if (_settingsFile.Length == 0)
                    _settingsFile = Path.Combine(Application.UserAppDataPath, "last-file.txt");
                Directory.CreateDirectory(Path.GetDirectoryName(_settingsFile)!);
                File.WriteAllText(_settingsFile, _currentFilename);
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                MessageBox.Show(this, "Dữ liệu đã mở/lưu thành công nhưng không nhớ được đường dẫn:\n" + ex.Message,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RefreshStudents(string? selectedId = null)
        {
            IEnumerable<Student> students = Singleton.SStudentsList;
            if (_search.HasValue)
            {
                var criteria = _search.Value;
                students = students.Where(s =>
                {
                    var matches = new List<bool>();
                    if (criteria.Id.Length > 0)
                        matches.Add(s.StudentID.Contains(criteria.Id, StringComparison.OrdinalIgnoreCase));
                    if (criteria.Name.Length > 0)
                        matches.Add(s.FirstName.Contains(criteria.Name, StringComparison.OrdinalIgnoreCase));
                    if (criteria.Class.Length > 0)
                        matches.Add(s.ClassName.Contains(criteria.Class, StringComparison.OrdinalIgnoreCase));
                    return criteria.All ? matches.All(m => m) : matches.Any(m => m);
                });
            }
            _refreshing = true;
            dataGridView1.DataSource = students.ToList();
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
            _refreshing = false;
            _selectedStudentId = null;
            foreach (var className in Singleton.SStudentsList.Select(s => s.ClassName).Distinct())
                if (!cboClass.Items.Contains(className)) cboClass.Items.Add(className);
            lblCurrentFile.Text = $"Tập tin: {_currentFilename}   |   {dataGridView1.Rows.Count}/{Singleton.SStudentsList.Count} sinh viên";
            if (selectedId != null)
            {
                var row = dataGridView1.Rows.Cast<DataGridViewRow>()
                    .FirstOrDefault(r => r.DataBoundItem is Student s && s.StudentID == selectedId);
                if (row != null)
                {
                    dataGridView1.CurrentCell = row.Cells["StudentID"];
                    row.Selected = true;
                }
            }
        }

        private void dataGridView1_CurrentCellChanged(object? sender, EventArgs e)
        {
            if (_refreshing || dataGridView1.CurrentRow?.DataBoundItem is not Student student) return;
            _selectedStudentId = student.StudentID;
            txtStudentId.Text = student.StudentID;
            txtLastMiddleName.Text = student.LastMiddleName;
            txtFirstName.Text = student.FirstName;
            dtpBirthDate.Value = student.BirthDate.Date;
            rdoMale.Checked = student.Gender == 0;
            rdoFemale.Checked = student.Gender == 1;
            cboClass.Text = student.ClassName;
            txtIdentityNumber.Text = student.IdentityNumber;
            txtPhoneNumber.Text = student.PhoneNumber;
            txtAddress.Text = student.Address;
            foreach (string subject in student.Subjects)
                if (!clbSubjects.Items.Contains(subject)) clbSubjects.Items.Add(subject);
            for (int i = 0; i < clbSubjects.Items.Count; i++)
                clbSubjects.SetItemChecked(i, student.Subjects.Contains((string)clbSubjects.Items[i]));
        }

        private void ClearInput()
        {
            _selectedStudentId = null;
            txtStudentId.Clear();
            txtLastMiddleName.Clear();
            txtFirstName.Clear();
            txtIdentityNumber.Clear();
            txtPhoneNumber.Clear();
            txtAddress.Clear();
            cboClass.SelectedIndex = -1;
            cboClass.Text = "";
            rdoMale.Checked = false;
            rdoFemale.Checked = false;
            dtpBirthDate.Value = DateTime.Today;
            for (int i = 0; i < clbSubjects.Items.Count; i++) clbSubjects.SetItemChecked(i, false);
            txtStudentId.Focus();
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;
            ClearInput();
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            using var form = new SearchForm();
            if (form.ShowDialog(this) != DialogResult.OK) return;
            _search = (form.StudentId, form.StudentName, form.ClassName, form.MatchAll);
            RefreshStudents();
            ClearInput();
        }

        private void btnShowAll_Click(object? sender, EventArgs e)
        {
            _search = null;
            RefreshStudents();
            ClearInput();
        }

        private void addSubjectToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            using var form = new SubjectForm();
            if (form.ShowDialog(this) != DialogResult.OK) return;
            if (clbSubjects.Items.Cast<string>().Any(s => string.Equals(s, form.SubjectName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(this, "Môn học đã có trong danh mục.", "Thông báo");
                return;
            }
            clbSubjects.Items.Add(form.SubjectName);
        }

        private void removeSubjectToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (clbSubjects.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Vui lòng chọn môn cần xóa khỏi danh mục.", "Thông báo");
                return;
            }
            clbSubjects.Items.RemoveAt(clbSubjects.SelectedIndex);
        }

        private void clbSubjects_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) clbSubjects.SelectedIndex = clbSubjects.IndexFromPoint(e.Location);
        }

        private void dataGridView1_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells["StudentID"];
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty && dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void btnExit_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (DesignMode) return;
            e.Cancel = MessageBox.Show(this, "Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes;
        }

        private void ShowError(Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Không thực hiện được",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}

