namespace ChuDe3.StudentManagerNoAI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing) components?.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            grpStudent = new GroupBox();
            lblStudentId = new Label();
            txtStudentId = new TextBox();
            lblGender = new Label();
            rdoMale = new RadioButton();
            rdoFemale = new RadioButton();
            lblLastMiddleName = new Label();
            txtLastMiddleName = new TextBox();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblBirthDate = new Label();
            dtpBirthDate = new DateTimePicker();
            lblClass = new Label();
            cboClass = new ComboBox();
            lblIdentityNumber = new Label();
            txtIdentityNumber = new TextBox();
            lblPhoneNumber = new Label();
            txtPhoneNumber = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblSubjects = new Label();
            clbSubjects = new CheckedListBox();
            btnClear = new Button();
            btnSearch = new Button();
            btnShowAll = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnExit = new Button();
            lblList = new Label();
            lblCurrentFile = new Label();
            dataGridView1 = new DataGridView();
            Selected = new DataGridViewCheckBoxColumn();
            StudentID = new DataGridViewTextBoxColumn();
            LastMiddleName = new DataGridViewTextBoxColumn();
            FirstName = new DataGridViewTextBoxColumn();
            BirthDate = new DataGridViewTextBoxColumn();
            GenderText = new DataGridViewTextBoxColumn();
            ClassName = new DataGridViewTextBoxColumn();
            IdentityNumber = new DataGridViewTextBoxColumn();
            PhoneNumber = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            SubjectsText = new DataGridViewTextBoxColumn();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newFileToolStripMenuItem = new ToolStripMenuItem();
            loadFileToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            studentsContextMenuStrip = new ContextMenuStrip(components);
            deleteStudentsToolStripMenuItem = new ToolStripMenuItem();
            subjectsContextMenuStrip = new ContextMenuStrip(components);
            addSubjectToolStripMenuItem = new ToolStripMenuItem();
            removeSubjectToolStripMenuItem = new ToolStripMenuItem();
            grpStudent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            studentsContextMenuStrip.SuspendLayout();
            subjectsContextMenuStrip.SuspendLayout();
            SuspendLayout();
            //
            // grpStudent
            //
            grpStudent.Controls.Add(lblStudentId);
            grpStudent.Controls.Add(txtStudentId);
            grpStudent.Controls.Add(lblGender);
            grpStudent.Controls.Add(rdoMale);
            grpStudent.Controls.Add(rdoFemale);
            grpStudent.Controls.Add(lblLastMiddleName);
            grpStudent.Controls.Add(txtLastMiddleName);
            grpStudent.Controls.Add(lblFirstName);
            grpStudent.Controls.Add(txtFirstName);
            grpStudent.Controls.Add(lblBirthDate);
            grpStudent.Controls.Add(dtpBirthDate);
            grpStudent.Controls.Add(lblClass);
            grpStudent.Controls.Add(cboClass);
            grpStudent.Controls.Add(lblIdentityNumber);
            grpStudent.Controls.Add(txtIdentityNumber);
            grpStudent.Controls.Add(lblPhoneNumber);
            grpStudent.Controls.Add(txtPhoneNumber);
            grpStudent.Controls.Add(lblAddress);
            grpStudent.Controls.Add(txtAddress);
            grpStudent.Controls.Add(lblSubjects);
            grpStudent.Controls.Add(clbSubjects);
            grpStudent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpStudent.Location = new Point(12, 35);
            grpStudent.Name = "grpStudent";
            grpStudent.Size = new Size(980, 300);
            grpStudent.TabIndex = 0;
            grpStudent.TabStop = false;
            grpStudent.Text = "Thông tin sinh viên";
            //
            // lblStudentId
            //
            lblStudentId.Location = new Point(16, 28);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(120, 23);
            lblStudentId.TabIndex = 0;
            lblStudentId.Text = "MSSV:";
            lblStudentId.TextAlign = ContentAlignment.MiddleLeft;
            //
            // txtStudentId
            //
            txtStudentId.Location = new Point(140, 27);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(285, 23);
            txtStudentId.TabIndex = 1;
            //
            // lblGender
            //
            lblGender.Location = new Point(450, 28);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(110, 23);
            lblGender.TabIndex = 2;
            lblGender.Text = "Giới tính:";
            lblGender.TextAlign = ContentAlignment.MiddleLeft;
            //
            // rdoMale
            //
            rdoMale.Location = new Point(570, 27);
            rdoMale.Name = "rdoMale";
            rdoMale.Size = new Size(75, 24);
            rdoMale.TabIndex = 3;
            rdoMale.Text = "Nam";
            //
            // rdoFemale
            //
            rdoFemale.Location = new Point(655, 27);
            rdoFemale.Name = "rdoFemale";
            rdoFemale.Size = new Size(75, 24);
            rdoFemale.TabIndex = 4;
            rdoFemale.Text = "Nữ";
            //
            // lblLastMiddleName
            //
            lblLastMiddleName.Location = new Point(16, 63);
            lblLastMiddleName.Name = "lblLastMiddleName";
            lblLastMiddleName.Size = new Size(120, 23);
            lblLastMiddleName.TabIndex = 5;
            lblLastMiddleName.Text = "Họ và tên lót:";
            lblLastMiddleName.TextAlign = ContentAlignment.MiddleLeft;
            //
            // txtLastMiddleName
            //
            txtLastMiddleName.Location = new Point(140, 62);
            txtLastMiddleName.Name = "txtLastMiddleName";
            txtLastMiddleName.Size = new Size(285, 23);
            txtLastMiddleName.TabIndex = 6;
            //
            // lblFirstName
            //
            lblFirstName.Location = new Point(450, 63);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(110, 23);
            lblFirstName.TabIndex = 7;
            lblFirstName.Text = "Tên:";
            lblFirstName.TextAlign = ContentAlignment.MiddleLeft;
            //
            // txtFirstName
            //
            txtFirstName.Location = new Point(570, 62);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(365, 23);
            txtFirstName.TabIndex = 8;
            //
            // lblBirthDate
            //
            lblBirthDate.Location = new Point(16, 98);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(120, 23);
            lblBirthDate.TabIndex = 9;
            lblBirthDate.Text = "Ngày sinh:";
            lblBirthDate.TextAlign = ContentAlignment.MiddleLeft;
            //
            // dtpBirthDate
            //
            dtpBirthDate.Location = new Point(140, 97);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(285, 23);
            dtpBirthDate.TabIndex = 10;
            dtpBirthDate.CustomFormat = "dd/MM/yyyy";
            dtpBirthDate.Format = DateTimePickerFormat.Custom;
            //
            // lblClass
            //
            lblClass.Location = new Point(450, 98);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(110, 23);
            lblClass.TabIndex = 11;
            lblClass.Text = "Lớp:";
            lblClass.TextAlign = ContentAlignment.MiddleLeft;
            //
            // cboClass
            //
            cboClass.Location = new Point(570, 97);
            cboClass.Name = "cboClass";
            cboClass.Size = new Size(365, 23);
            cboClass.TabIndex = 12;
            cboClass.FormattingEnabled = true;
            cboClass.Items.AddRange(new object[] { "CTK46", "CTK47", "CTK48", "CTK49", "CTK50" });
            //
            // lblIdentityNumber
            //
            lblIdentityNumber.Location = new Point(16, 133);
            lblIdentityNumber.Name = "lblIdentityNumber";
            lblIdentityNumber.Size = new Size(120, 23);
            lblIdentityNumber.TabIndex = 13;
            lblIdentityNumber.Text = "Số CMND:";
            lblIdentityNumber.TextAlign = ContentAlignment.MiddleLeft;
            //
            // txtIdentityNumber
            //
            txtIdentityNumber.Location = new Point(140, 132);
            txtIdentityNumber.Name = "txtIdentityNumber";
            txtIdentityNumber.Size = new Size(285, 23);
            txtIdentityNumber.TabIndex = 14;
            //
            // lblPhoneNumber
            //
            lblPhoneNumber.Location = new Point(450, 133);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(110, 23);
            lblPhoneNumber.TabIndex = 15;
            lblPhoneNumber.Text = "Số điện thoại:";
            lblPhoneNumber.TextAlign = ContentAlignment.MiddleLeft;
            //
            // txtPhoneNumber
            //
            txtPhoneNumber.Location = new Point(570, 132);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(365, 23);
            txtPhoneNumber.TabIndex = 16;
            //
            // lblAddress
            //
            lblAddress.Location = new Point(16, 168);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(120, 23);
            lblAddress.TabIndex = 17;
            lblAddress.Text = "Địa chỉ liên lạc:";
            lblAddress.TextAlign = ContentAlignment.MiddleLeft;
            //
            // txtAddress
            //
            txtAddress.Location = new Point(140, 167);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(795, 23);
            txtAddress.TabIndex = 18;
            //
            // lblSubjects
            //
            lblSubjects.Location = new Point(16, 206);
            lblSubjects.Name = "lblSubjects";
            lblSubjects.Size = new Size(120, 23);
            lblSubjects.TabIndex = 19;
            lblSubjects.Text = "Môn học đăng ký:";
            lblSubjects.TextAlign = ContentAlignment.MiddleLeft;
            //
            // clbSubjects
            //
            clbSubjects.Location = new Point(140, 202);
            clbSubjects.Name = "clbSubjects";
            clbSubjects.Size = new Size(795, 92);
            clbSubjects.TabIndex = 20;
            clbSubjects.CheckOnClick = true;
            clbSubjects.IntegralHeight = false;
            clbSubjects.MultiColumn = true;
            clbSubjects.ColumnWidth = 385;
            clbSubjects.ContextMenuStrip = subjectsContextMenuStrip;
            clbSubjects.Items.AddRange(new object[] { "Mạng máy tính", "Hệ điều hành", "Lập trình CSDL", "Lập trình mạng", "Đồ án cơ sở", "Phương pháp NCKH", "Lập trình trên thiết bị di động", "An toàn và bảo mật hệ thống" });
            clbSubjects.MouseDown += clbSubjects_MouseDown;
            //
            // btnClear
            //
            btnClear.Location = new Point(12, 347);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(110, 28);
            btnClear.TabIndex = 21;
            btnClear.Text = "Nhập lại";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            //
            // btnSearch
            //
            btnSearch.Location = new Point(132, 347);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(110, 28);
            btnSearch.TabIndex = 22;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            //
            // btnShowAll
            //
            btnShowAll.Location = new Point(252, 347);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(110, 28);
            btnShowAll.TabIndex = 23;
            btnShowAll.Text = "Tất cả sinh viên";
            btnShowAll.UseVisualStyleBackColor = true;
            btnShowAll.Click += btnShowAll_Click;
            //
            // btnAdd
            //
            btnAdd.Location = new Point(482, 347);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 28);
            btnAdd.TabIndex = 24;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            //
            // btnUpdate
            //
            btnUpdate.Location = new Point(602, 347);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(110, 28);
            btnUpdate.TabIndex = 25;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            //
            // btnExit
            //
            btnExit.Location = new Point(882, 347);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(110, 28);
            btnExit.TabIndex = 26;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            //
            // lblList
            //
            lblList.Location = new Point(12, 385);
            lblList.Name = "lblList";
            lblList.Size = new Size(260, 23);
            lblList.Text = "Danh sách sinh viên";
            //
            // dataGridView1
            //
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ContextMenuStrip = studentsContextMenuStrip;
            dataGridView1.Location = new Point(12, 412);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(980, 290);
            dataGridView1.TabIndex = 27;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Selected, StudentID, LastMiddleName, FirstName, BirthDate, GenderText, ClassName, IdentityNumber, PhoneNumber, Address, SubjectsText });
            dataGridView1.CurrentCellChanged += dataGridView1_CurrentCellChanged;
            dataGridView1.CellMouseDown += dataGridView1_CellMouseDown;
            dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
            //
            // Selected
            //
            Selected.HeaderText = "Chọn";
            Selected.Name = "Selected";
            Selected.Width = 45;
            Selected.ReadOnly = false;
            Selected.SortMode = DataGridViewColumnSortMode.NotSortable;
            //
            // StudentID
            //
            StudentID.DataPropertyName = "StudentID";
            StudentID.HeaderText = "MSSV";
            StudentID.Name = "StudentID";
            StudentID.Width = 85;
            StudentID.ReadOnly = true;
            //
            // LastMiddleName
            //
            LastMiddleName.DataPropertyName = "LastMiddleName";
            LastMiddleName.HeaderText = "Họ và tên lót";
            LastMiddleName.Name = "LastMiddleName";
            LastMiddleName.Width = 135;
            LastMiddleName.ReadOnly = true;
            //
            // FirstName
            //
            FirstName.DataPropertyName = "FirstName";
            FirstName.HeaderText = "Tên";
            FirstName.Name = "FirstName";
            FirstName.Width = 80;
            FirstName.ReadOnly = true;
            //
            // BirthDate
            //
            BirthDate.DataPropertyName = "BirthDate";
            BirthDate.HeaderText = "Ngày sinh";
            BirthDate.Name = "BirthDate";
            BirthDate.Width = 100;
            BirthDate.ReadOnly = true;
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            BirthDate.DefaultCellStyle = dataGridViewCellStyle1;
            //
            // GenderText
            //
            GenderText.DataPropertyName = "GenderText";
            GenderText.HeaderText = "Giới tính";
            GenderText.Name = "GenderText";
            GenderText.Width = 70;
            GenderText.ReadOnly = true;
            //
            // ClassName
            //
            ClassName.DataPropertyName = "ClassName";
            ClassName.HeaderText = "Lớp";
            ClassName.Name = "ClassName";
            ClassName.Width = 80;
            ClassName.ReadOnly = true;
            //
            // IdentityNumber
            //
            IdentityNumber.DataPropertyName = "IdentityNumber";
            IdentityNumber.HeaderText = "Số CMND";
            IdentityNumber.Name = "IdentityNumber";
            IdentityNumber.Width = 105;
            IdentityNumber.ReadOnly = true;
            //
            // PhoneNumber
            //
            PhoneNumber.DataPropertyName = "PhoneNumber";
            PhoneNumber.HeaderText = "Số điện thoại";
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.Width = 110;
            PhoneNumber.ReadOnly = true;
            //
            // Address
            //
            Address.DataPropertyName = "Address";
            Address.HeaderText = "Địa chỉ liên lạc";
            Address.Name = "Address";
            Address.Width = 200;
            Address.ReadOnly = true;
            //
            // SubjectsText
            //
            SubjectsText.DataPropertyName = "SubjectsText";
            SubjectsText.HeaderText = "Môn đăng ký";
            SubjectsText.Name = "SubjectsText";
            SubjectsText.Width = 240;
            SubjectsText.ReadOnly = true;
            //
            // lblCurrentFile
            //
            lblCurrentFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblCurrentFile.AutoEllipsis = true;
            lblCurrentFile.Location = new Point(12, 709);
            lblCurrentFile.Name = "lblCurrentFile";
            lblCurrentFile.Size = new Size(980, 25);
            //
            // menuStrip1
            //
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1004, 24);
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newFileToolStripMenuItem, loadFileToolStripMenuItem, saveAsToolStripMenuItem });
            //
            // fileToolStripMenuItem
            //
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Text = "Tập tin";
            //
            // newFileToolStripMenuItem
            //
            newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            newFileToolStripMenuItem.Text = "Tập tin mới...";
            newFileToolStripMenuItem.Click += newFileToolStripMenuItem_Click;
            //
            // loadFileToolStripMenuItem
            //
            loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            loadFileToolStripMenuItem.Text = "Mở tập tin...";
            loadFileToolStripMenuItem.Click += loadFileToolStripMenuItem_Click;
            //
            // saveAsToolStripMenuItem
            //
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Text = "Lưu thành...";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            //
            // deleteStudentsToolStripMenuItem
            //
            deleteStudentsToolStripMenuItem.Name = "deleteStudentsToolStripMenuItem";
            deleteStudentsToolStripMenuItem.Text = "Xóa sinh viên đã chọn";
            deleteStudentsToolStripMenuItem.Click += deleteStudentsToolStripMenuItem_Click;
            //
            // addSubjectToolStripMenuItem
            //
            addSubjectToolStripMenuItem.Name = "addSubjectToolStripMenuItem";
            addSubjectToolStripMenuItem.Text = "Thêm môn...";
            addSubjectToolStripMenuItem.Click += addSubjectToolStripMenuItem_Click;
            //
            // removeSubjectToolStripMenuItem
            //
            removeSubjectToolStripMenuItem.Name = "removeSubjectToolStripMenuItem";
            removeSubjectToolStripMenuItem.Text = "Xóa môn khỏi danh mục";
            removeSubjectToolStripMenuItem.Click += removeSubjectToolStripMenuItem_Click;
            studentsContextMenuStrip.Items.AddRange(new ToolStripItem[] { deleteStudentsToolStripMenuItem });
            subjectsContextMenuStrip.Items.AddRange(new ToolStripItem[] { addSubjectToolStripMenuItem, removeSubjectToolStripMenuItem });
            studentsContextMenuStrip.Name = "studentsContextMenuStrip";
            subjectsContextMenuStrip.Name = "subjectsContextMenuStrip";
            openFileDialog1.Filter = "Tập tin sinh viên (*.json;*.txt;*.xml)|*.json;*.txt;*.xml|JSON (*.json)|*.json|TXT (*.txt)|*.txt|XML (*.xml)|*.xml";
            openFileDialog1.Title = "Mở danh sách sinh viên";
            saveFileDialog1.Filter = "JSON (*.json)|*.json|TXT (*.txt)|*.txt|XML (*.xml)|*.xml";
            saveFileDialog1.DefaultExt = "json";
            saveFileDialog1.Title = "Lưu danh sách sinh viên";
            //
            // MainForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1004, 741);
            Controls.Add(grpStudent);
            Controls.Add(btnClear);
            Controls.Add(btnSearch);
            Controls.Add(btnShowAll);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnExit);
            Controls.Add(lblList);
            Controls.Add(dataGridView1);
            Controls.Add(lblCurrentFile);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1020, 780);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý sinh viên";
            Load += MainForm_Load;
            FormClosing += MainForm_FormClosing;
            grpStudent.ResumeLayout(false);
            grpStudent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            studentsContextMenuStrip.ResumeLayout(false);
            subjectsContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpStudent = null!;
        private Label lblStudentId = null!;
        private TextBox txtStudentId = null!;
        private Label lblGender = null!;
        private RadioButton rdoMale = null!;
        private RadioButton rdoFemale = null!;
        private Label lblLastMiddleName = null!;
        private TextBox txtLastMiddleName = null!;
        private Label lblFirstName = null!;
        private TextBox txtFirstName = null!;
        private Label lblBirthDate = null!;
        private DateTimePicker dtpBirthDate = null!;
        private Label lblClass = null!;
        private ComboBox cboClass = null!;
        private Label lblIdentityNumber = null!;
        private TextBox txtIdentityNumber = null!;
        private Label lblPhoneNumber = null!;
        private TextBox txtPhoneNumber = null!;
        private Label lblAddress = null!;
        private TextBox txtAddress = null!;
        private Label lblSubjects = null!;
        private CheckedListBox clbSubjects = null!;
        private Button btnClear = null!;
        private Button btnSearch = null!;
        private Button btnShowAll = null!;
        private Button btnAdd = null!;
        private Button btnUpdate = null!;
        private Button btnExit = null!;
        private Label lblList = null!;
        private Label lblCurrentFile = null!;
        private DataGridView dataGridView1 = null!;
        private DataGridViewCheckBoxColumn Selected = null!;
        private DataGridViewTextBoxColumn StudentID = null!;
        private DataGridViewTextBoxColumn LastMiddleName = null!;
        private DataGridViewTextBoxColumn FirstName = null!;
        private DataGridViewTextBoxColumn BirthDate = null!;
        private DataGridViewTextBoxColumn GenderText = null!;
        private DataGridViewTextBoxColumn ClassName = null!;
        private DataGridViewTextBoxColumn IdentityNumber = null!;
        private DataGridViewTextBoxColumn PhoneNumber = null!;
        private DataGridViewTextBoxColumn Address = null!;
        private DataGridViewTextBoxColumn SubjectsText = null!;
        private MenuStrip menuStrip1 = null!;
        private ToolStripMenuItem fileToolStripMenuItem = null!;
        private ToolStripMenuItem newFileToolStripMenuItem = null!;
        private ToolStripMenuItem loadFileToolStripMenuItem = null!;
        private ToolStripMenuItem saveAsToolStripMenuItem = null!;
        private OpenFileDialog openFileDialog1 = null!;
        private SaveFileDialog saveFileDialog1 = null!;
        private ContextMenuStrip studentsContextMenuStrip = null!;
        private ToolStripMenuItem deleteStudentsToolStripMenuItem = null!;
        private ContextMenuStrip subjectsContextMenuStrip = null!;
        private ToolStripMenuItem addSubjectToolStripMenuItem = null!;
        private ToolStripMenuItem removeSubjectToolStripMenuItem = null!;
    }
}
