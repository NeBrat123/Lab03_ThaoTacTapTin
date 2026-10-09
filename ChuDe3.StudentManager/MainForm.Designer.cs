namespace ChuDe3.StudentManager
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _fileMenu;
        private System.Windows.Forms.ToolStripMenuItem _openFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _saveAsMenuItem;
        private System.Windows.Forms.ToolStripSeparator _fileMenuSeparator;
        private System.Windows.Forms.ToolStripMenuItem _exitMenuItem;
        private System.Windows.Forms.GroupBox _inputGroup;
        private System.Windows.Forms.Label _idLabel;
        private System.Windows.Forms.Label _genderLabel;
        private System.Windows.Forms.Label _middleNameLabel;
        private System.Windows.Forms.Label _firstNameLabel;
        private System.Windows.Forms.Label _birthDateLabel;
        private System.Windows.Forms.Label _classLabel;
        private System.Windows.Forms.Label _identityLabel;
        private System.Windows.Forms.Label _enrollmentYearLabel;
        private System.Windows.Forms.Label _addressLabel;
        private System.Windows.Forms.Label _phoneLabel;
        private System.Windows.Forms.Label _subjectsLabel;
        private System.Windows.Forms.MaskedTextBox _txtId;
        private System.Windows.Forms.TextBox _txtMiddleName;
        private System.Windows.Forms.TextBox _txtFirstName;
        private System.Windows.Forms.DateTimePicker _birthDate;
        private System.Windows.Forms.ComboBox _className;
        private System.Windows.Forms.MaskedTextBox _txtIdentity;
        private System.Windows.Forms.NumericUpDown _enrollmentYear;
        private System.Windows.Forms.TextBox _txtAddress;
        private System.Windows.Forms.MaskedTextBox _txtPhone;
        private System.Windows.Forms.Panel _genderPanel;
        private System.Windows.Forms.RadioButton _male;
        private System.Windows.Forms.RadioButton _female;
        private System.Windows.Forms.CheckedListBox _subjects;
        private System.Windows.Forms.Button _search;
        private System.Windows.Forms.Button _add;
        private System.Windows.Forms.Button _update;
        private System.Windows.Forms.Button _exit;
        private System.Windows.Forms.ListView _listView;
        private System.Windows.Forms.ColumnHeader _studentIdColumn;
        private System.Windows.Forms.ColumnHeader _middleNameColumn;
        private System.Windows.Forms.ColumnHeader _firstNameColumn;
        private System.Windows.Forms.ColumnHeader _birthDateColumn;
        private System.Windows.Forms.ColumnHeader _classColumn;
        private System.Windows.Forms.ColumnHeader _enrollmentYearColumn;
        private System.Windows.Forms.ColumnHeader _identityColumn;
        private System.Windows.Forms.ColumnHeader _phoneColumn;
        private System.Windows.Forms.ColumnHeader _addressColumn;
        private System.Windows.Forms.Label _status;
        private System.Windows.Forms.ErrorProvider _errors;
        private System.Windows.Forms.ContextMenuStrip _subjectMenu;
        private System.Windows.Forms.ToolStripMenuItem _addSubjectMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _deleteSubjectMenuItem;
        private System.Windows.Forms.ContextMenuStrip _studentMenu;
        private System.Windows.Forms.ToolStripMenuItem _deleteStudentsMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._openFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._fileMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this._exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._inputGroup = new System.Windows.Forms.GroupBox();
            this._idLabel = new System.Windows.Forms.Label();
            this._txtId = new System.Windows.Forms.MaskedTextBox();
            this._genderLabel = new System.Windows.Forms.Label();
            this._genderPanel = new System.Windows.Forms.Panel();
            this._male = new System.Windows.Forms.RadioButton();
            this._female = new System.Windows.Forms.RadioButton();
            this._middleNameLabel = new System.Windows.Forms.Label();
            this._txtMiddleName = new System.Windows.Forms.TextBox();
            this._firstNameLabel = new System.Windows.Forms.Label();
            this._txtFirstName = new System.Windows.Forms.TextBox();
            this._birthDateLabel = new System.Windows.Forms.Label();
            this._birthDate = new System.Windows.Forms.DateTimePicker();
            this._classLabel = new System.Windows.Forms.Label();
            this._className = new System.Windows.Forms.ComboBox();
            this._identityLabel = new System.Windows.Forms.Label();
            this._txtIdentity = new System.Windows.Forms.MaskedTextBox();
            this._enrollmentYearLabel = new System.Windows.Forms.Label();
            this._enrollmentYear = new System.Windows.Forms.NumericUpDown();
            this._addressLabel = new System.Windows.Forms.Label();
            this._txtAddress = new System.Windows.Forms.TextBox();
            this._phoneLabel = new System.Windows.Forms.Label();
            this._txtPhone = new System.Windows.Forms.MaskedTextBox();
            this._subjectsLabel = new System.Windows.Forms.Label();
            this._subjects = new System.Windows.Forms.CheckedListBox();
            this._subjectMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._addSubjectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._deleteSubjectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._search = new System.Windows.Forms.Button();
            this._add = new System.Windows.Forms.Button();
            this._update = new System.Windows.Forms.Button();
            this._exit = new System.Windows.Forms.Button();
            this._listView = new System.Windows.Forms.ListView();
            this._studentIdColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._middleNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._firstNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._birthDateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._classColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._enrollmentYearColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._identityColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._phoneColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._addressColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._studentMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._deleteStudentsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._status = new System.Windows.Forms.Label();
            this._errors = new System.Windows.Forms.ErrorProvider(this.components);
            this._menuStrip.SuspendLayout();
            this._inputGroup.SuspendLayout();
            this._genderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._enrollmentYear)).BeginInit();
            this._subjectMenu.SuspendLayout();
            this._studentMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errors)).BeginInit();
            this.SuspendLayout();
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileMenu});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this._menuStrip.Size = new System.Drawing.Size(946, 24);
            this._menuStrip.TabIndex = 1;
            // 
            // _fileMenu
            // 
            this._fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openFileMenuItem,
            this._saveMenuItem,
            this._saveAsMenuItem,
            this._fileMenuSeparator,
            this._exitMenuItem});
            this._fileMenu.Name = "_fileMenu";
            this._fileMenu.Size = new System.Drawing.Size(39, 20);
            this._fileMenu.Text = "Tệp";
            // 
            // _openFileMenuItem
            // 
            this._openFileMenuItem.Name = "_openFileMenuItem";
            this._openFileMenuItem.Size = new System.Drawing.Size(160, 22);
            this._openFileMenuItem.Text = "Mở...";
            this._openFileMenuItem.Click += new System.EventHandler(this.OpenFileMenuItem_Click);
            // 
            // _saveMenuItem
            // 
            this._saveMenuItem.Name = "_saveMenuItem";
            this._saveMenuItem.Size = new System.Drawing.Size(160, 22);
            this._saveMenuItem.Text = "Lưu";
            this._saveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // _saveAsMenuItem
            // 
            this._saveAsMenuItem.Name = "_saveAsMenuItem";
            this._saveAsMenuItem.Size = new System.Drawing.Size(160, 22);
            this._saveAsMenuItem.Text = "Lưu dưới dạng...";
            this._saveAsMenuItem.Click += new System.EventHandler(this.SaveAsMenuItem_Click);
            // 
            // _fileMenuSeparator
            // 
            this._fileMenuSeparator.Name = "_fileMenuSeparator";
            this._fileMenuSeparator.Size = new System.Drawing.Size(157, 6);
            // 
            // _exitMenuItem
            // 
            this._exitMenuItem.Name = "_exitMenuItem";
            this._exitMenuItem.Size = new System.Drawing.Size(160, 22);
            this._exitMenuItem.Text = "Thoát";
            this._exitMenuItem.Click += new System.EventHandler(this.Exit_Click);
            // 
            // _inputGroup
            // 
            this._inputGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._inputGroup.Controls.Add(this._idLabel);
            this._inputGroup.Controls.Add(this._txtId);
            this._inputGroup.Controls.Add(this._genderLabel);
            this._inputGroup.Controls.Add(this._genderPanel);
            this._inputGroup.Controls.Add(this._middleNameLabel);
            this._inputGroup.Controls.Add(this._txtMiddleName);
            this._inputGroup.Controls.Add(this._firstNameLabel);
            this._inputGroup.Controls.Add(this._txtFirstName);
            this._inputGroup.Controls.Add(this._birthDateLabel);
            this._inputGroup.Controls.Add(this._birthDate);
            this._inputGroup.Controls.Add(this._classLabel);
            this._inputGroup.Controls.Add(this._className);
            this._inputGroup.Controls.Add(this._identityLabel);
            this._inputGroup.Controls.Add(this._txtIdentity);
            this._inputGroup.Controls.Add(this._enrollmentYearLabel);
            this._inputGroup.Controls.Add(this._enrollmentYear);
            this._inputGroup.Controls.Add(this._addressLabel);
            this._inputGroup.Controls.Add(this._txtAddress);
            this._inputGroup.Controls.Add(this._phoneLabel);
            this._inputGroup.Controls.Add(this._txtPhone);
            this._inputGroup.Controls.Add(this._subjectsLabel);
            this._inputGroup.Controls.Add(this._subjects);
            this._inputGroup.Location = new System.Drawing.Point(10, 30);
            this._inputGroup.Name = "_inputGroup";
            this._inputGroup.Padding = new System.Windows.Forms.Padding(9);
            this._inputGroup.Size = new System.Drawing.Size(926, 248);
            this._inputGroup.TabIndex = 0;
            this._inputGroup.TabStop = false;
            this._inputGroup.Text = "Thông tin sinh viên";
            // 
            // _idLabel
            // 
            this._idLabel.Location = new System.Drawing.Point(12, 22);
            this._idLabel.Name = "_idLabel";
            this._idLabel.Size = new System.Drawing.Size(84, 26);
            this._idLabel.TabIndex = 0;
            this._idLabel.Text = "MSSV:";
            this._idLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtId
            // 
            this._txtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtId.Location = new System.Drawing.Point(102, 25);
            this._txtId.Mask = "0000000";
            this._txtId.Name = "_txtId";
            this._txtId.Size = new System.Drawing.Size(358, 20);
            this._txtId.TabIndex = 1;
            this._txtId.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this._txtId.TextChanged += new System.EventHandler(this.InputChanged);
            // 
            // _genderLabel
            // 
            this._genderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._genderLabel.Location = new System.Drawing.Point(466, 22);
            this._genderLabel.Name = "_genderLabel";
            this._genderLabel.Size = new System.Drawing.Size(84, 26);
            this._genderLabel.TabIndex = 2;
            this._genderLabel.Text = "Giới tính:";
            this._genderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _genderPanel
            // 
            this._genderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._genderPanel.Controls.Add(this._male);
            this._genderPanel.Controls.Add(this._female);
            this._genderPanel.Location = new System.Drawing.Point(556, 25);
            this._genderPanel.Name = "_genderPanel";
            this._genderPanel.Size = new System.Drawing.Size(358, 20);
            this._genderPanel.TabIndex = 3;
            // 
            // _male
            // 
            this._male.AutoSize = true;
            this._male.Location = new System.Drawing.Point(3, 1);
            this._male.Name = "_male";
            this._male.Size = new System.Drawing.Size(47, 17);
            this._male.TabIndex = 0;
            this._male.Text = "Nam";
            this._male.CheckedChanged += new System.EventHandler(this.InputChanged);
            // 
            // _female
            // 
            this._female.AutoSize = true;
            this._female.Location = new System.Drawing.Point(56, 1);
            this._female.Name = "_female";
            this._female.Size = new System.Drawing.Size(39, 17);
            this._female.TabIndex = 1;
            this._female.Text = "Nữ";
            this._female.CheckedChanged += new System.EventHandler(this.InputChanged);
            // 
            // _middleNameLabel
            // 
            this._middleNameLabel.Location = new System.Drawing.Point(12, 48);
            this._middleNameLabel.Name = "_middleNameLabel";
            this._middleNameLabel.Size = new System.Drawing.Size(84, 26);
            this._middleNameLabel.TabIndex = 4;
            this._middleNameLabel.Text = "Họ và tên lót:";
            this._middleNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtMiddleName
            // 
            this._txtMiddleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtMiddleName.Location = new System.Drawing.Point(102, 51);
            this._txtMiddleName.Name = "_txtMiddleName";
            this._txtMiddleName.Size = new System.Drawing.Size(358, 20);
            this._txtMiddleName.TabIndex = 5;
            this._txtMiddleName.TextChanged += new System.EventHandler(this.InputChanged);
            // 
            // _firstNameLabel
            // 
            this._firstNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._firstNameLabel.Location = new System.Drawing.Point(466, 48);
            this._firstNameLabel.Name = "_firstNameLabel";
            this._firstNameLabel.Size = new System.Drawing.Size(84, 26);
            this._firstNameLabel.TabIndex = 6;
            this._firstNameLabel.Text = "Tên:";
            this._firstNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtFirstName
            // 
            this._txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtFirstName.Location = new System.Drawing.Point(556, 51);
            this._txtFirstName.Name = "_txtFirstName";
            this._txtFirstName.Size = new System.Drawing.Size(358, 20);
            this._txtFirstName.TabIndex = 7;
            this._txtFirstName.TextChanged += new System.EventHandler(this.InputChanged);
            // 
            // _birthDateLabel
            // 
            this._birthDateLabel.Location = new System.Drawing.Point(12, 74);
            this._birthDateLabel.Name = "_birthDateLabel";
            this._birthDateLabel.Size = new System.Drawing.Size(84, 26);
            this._birthDateLabel.TabIndex = 8;
            this._birthDateLabel.Text = "Ngày sinh:";
            this._birthDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _birthDate
            // 
            this._birthDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._birthDate.CustomFormat = "dd/MM/yyyy";
            this._birthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._birthDate.Location = new System.Drawing.Point(102, 77);
            this._birthDate.MaxDate = new System.DateTime(2026, 9, 19, 0, 0, 0, 0);
            this._birthDate.Name = "_birthDate";
            this._birthDate.Size = new System.Drawing.Size(358, 20);
            this._birthDate.TabIndex = 9;
            this._birthDate.Value = new System.DateTime(2004, 1, 1, 0, 0, 0, 0);
            this._birthDate.ValueChanged += new System.EventHandler(this.InputChanged);
            // 
            // _classLabel
            // 
            this._classLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._classLabel.Location = new System.Drawing.Point(466, 74);
            this._classLabel.Name = "_classLabel";
            this._classLabel.Size = new System.Drawing.Size(84, 26);
            this._classLabel.TabIndex = 10;
            this._classLabel.Text = "Lớp:";
            this._classLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _className
            // 
            this._className.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._className.Items.AddRange(new object[] {
            "CTK43",
            "CTK44",
            "CTK45",
            "CTK46"});
            this._className.Location = new System.Drawing.Point(556, 77);
            this._className.Name = "_className";
            this._className.Size = new System.Drawing.Size(358, 21);
            this._className.TabIndex = 11;
            this._className.TextChanged += new System.EventHandler(this.InputChanged);
            // 
            // _identityLabel
            // 
            this._identityLabel.Location = new System.Drawing.Point(12, 100);
            this._identityLabel.Name = "_identityLabel";
            this._identityLabel.Size = new System.Drawing.Size(84, 26);
            this._identityLabel.TabIndex = 12;
            this._identityLabel.Text = "Số CMND:";
            this._identityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtIdentity
            // 
            this._txtIdentity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtIdentity.Location = new System.Drawing.Point(102, 103);
            this._txtIdentity.Mask = "000000000";
            this._txtIdentity.Name = "_txtIdentity";
            this._txtIdentity.Size = new System.Drawing.Size(358, 20);
            this._txtIdentity.TabIndex = 13;
            this._txtIdentity.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this._txtIdentity.TextChanged += new System.EventHandler(this.InputChanged);
            // 
            // _enrollmentYearLabel
            // 
            this._enrollmentYearLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._enrollmentYearLabel.Location = new System.Drawing.Point(466, 100);
            this._enrollmentYearLabel.Name = "_enrollmentYearLabel";
            this._enrollmentYearLabel.Size = new System.Drawing.Size(84, 26);
            this._enrollmentYearLabel.TabIndex = 14;
            this._enrollmentYearLabel.Text = "Năm nhập học:";
            this._enrollmentYearLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _enrollmentYear
            // 
            this._enrollmentYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._enrollmentYear.Location = new System.Drawing.Point(556, 103);
            this._enrollmentYear.Maximum = new decimal(new int[] {
            2026,
            0,
            0,
            0});
            this._enrollmentYear.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this._enrollmentYear.Name = "_enrollmentYear";
            this._enrollmentYear.Size = new System.Drawing.Size(358, 20);
            this._enrollmentYear.TabIndex = 15;
            this._enrollmentYear.Value = new decimal(new int[] {
            2026,
            0,
            0,
            0});
            this._enrollmentYear.ValueChanged += new System.EventHandler(this.InputChanged);
            // 
            // _addressLabel
            // 
            this._addressLabel.Location = new System.Drawing.Point(12, 126);
            this._addressLabel.Name = "_addressLabel";
            this._addressLabel.Size = new System.Drawing.Size(84, 26);
            this._addressLabel.TabIndex = 16;
            this._addressLabel.Text = "Địa chỉ liên lạc:";
            this._addressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtAddress
            // 
            this._txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtAddress.Location = new System.Drawing.Point(102, 129);
            this._txtAddress.Name = "_txtAddress";
            this._txtAddress.Size = new System.Drawing.Size(358, 20);
            this._txtAddress.TabIndex = 17;
            this._txtAddress.TextChanged += new System.EventHandler(this.InputChanged);
            // 
            // _phoneLabel
            // 
            this._phoneLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._phoneLabel.Location = new System.Drawing.Point(466, 126);
            this._phoneLabel.Name = "_phoneLabel";
            this._phoneLabel.Size = new System.Drawing.Size(84, 26);
            this._phoneLabel.TabIndex = 18;
            this._phoneLabel.Text = "Số ĐT:";
            this._phoneLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtPhone
            // 
            this._txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtPhone.Location = new System.Drawing.Point(556, 129);
            this._txtPhone.Mask = "000-000-0000";
            this._txtPhone.Name = "_txtPhone";
            this._txtPhone.Size = new System.Drawing.Size(358, 20);
            this._txtPhone.TabIndex = 19;
            this._txtPhone.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this._txtPhone.TextChanged += new System.EventHandler(this.InputChanged);
            // 
            // _subjectsLabel
            // 
            this._subjectsLabel.Location = new System.Drawing.Point(12, 152);
            this._subjectsLabel.Name = "_subjectsLabel";
            this._subjectsLabel.Size = new System.Drawing.Size(84, 87);
            this._subjectsLabel.TabIndex = 20;
            this._subjectsLabel.Text = "Môn học đăng ký:";
            // 
            // _subjects
            // 
            this._subjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._subjects.CheckOnClick = true;
            this._subjects.ContextMenuStrip = this._subjectMenu;
            this._subjects.FormattingEnabled = true;
            this._subjects.Items.AddRange(new object[] {
            "Mạng máy tính",
            "Hệ điều hành",
            "Lập trình CSDL",
            "Lập trình mạng",
            "Đồ án cơ sở",
            "Phương pháp NCKH",
            "Lập trình trên thiết bị di động",
            "An toàn và bảo mật hệ thống"});
            this._subjects.Location = new System.Drawing.Point(102, 155);
            this._subjects.MultiColumn = true;
            this._subjects.Name = "_subjects";
            this._subjects.Size = new System.Drawing.Size(812, 79);
            this._subjects.TabIndex = 21;
            this._subjects.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.Subjects_ItemCheck);
            this._subjects.SelectedIndexChanged += new System.EventHandler(this._subjects_SelectedIndexChanged);
            // 
            // _subjectMenu
            // 
            this._subjectMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._addSubjectMenuItem,
            this._deleteSubjectMenuItem});
            this._subjectMenu.Name = "_subjectMenu";
            this._subjectMenu.Size = new System.Drawing.Size(183, 48);
            // 
            // _addSubjectMenuItem
            // 
            this._addSubjectMenuItem.Name = "_addSubjectMenuItem";
            this._addSubjectMenuItem.Size = new System.Drawing.Size(182, 22);
            this._addSubjectMenuItem.Text = "Thêm môn...";
            this._addSubjectMenuItem.Click += new System.EventHandler(this.AddSubject_Click);
            // 
            // _deleteSubjectMenuItem
            // 
            this._deleteSubjectMenuItem.Name = "_deleteSubjectMenuItem";
            this._deleteSubjectMenuItem.Size = new System.Drawing.Size(182, 22);
            this._deleteSubjectMenuItem.Text = "Xóa môn đang chọn";
            this._deleteSubjectMenuItem.Click += new System.EventHandler(this.DeleteSubject_Click);
            // 
            // _search
            // 
            this._search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._search.Location = new System.Drawing.Point(590, 284);
            this._search.Name = "_search";
            this._search.Size = new System.Drawing.Size(81, 24);
            this._search.TabIndex = 0;
            this._search.Text = "Tìm kiếm";
            this._search.Click += new System.EventHandler(this.Search_Click);
            // 
            // _add
            // 
            this._add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._add.Location = new System.Drawing.Point(677, 284);
            this._add.Name = "_add";
            this._add.Size = new System.Drawing.Size(81, 24);
            this._add.TabIndex = 1;
            this._add.Text = "Thêm mới";
            this._add.Click += new System.EventHandler(this.Add_Click);
            // 
            // _update
            // 
            this._update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._update.Location = new System.Drawing.Point(764, 284);
            this._update.Name = "_update";
            this._update.Size = new System.Drawing.Size(81, 24);
            this._update.TabIndex = 2;
            this._update.Text = "Cập nhật";
            this._update.Click += new System.EventHandler(this.Update_Click);
            // 
            // _exit
            // 
            this._exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._exit.Location = new System.Drawing.Point(851, 284);
            this._exit.Name = "_exit";
            this._exit.Size = new System.Drawing.Size(81, 24);
            this._exit.TabIndex = 3;
            this._exit.Text = "Thoát";
            this._exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // _listView
            // 
            this._listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._listView.CheckBoxes = true;
            this._listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._studentIdColumn,
            this._middleNameColumn,
            this._firstNameColumn,
            this._birthDateColumn,
            this._classColumn,
            this._enrollmentYearColumn,
            this._identityColumn,
            this._phoneColumn,
            this._addressColumn});
            this._listView.ContextMenuStrip = this._studentMenu;
            this._listView.FullRowSelect = true;
            this._listView.GridLines = true;
            this._listView.HideSelection = false;
            this._listView.Location = new System.Drawing.Point(10, 314);
            this._listView.Name = "_listView";
            this._listView.Size = new System.Drawing.Size(926, 276);
            this._listView.TabIndex = 2;
            this._listView.UseCompatibleStateImageBehavior = false;
            this._listView.View = System.Windows.Forms.View.Details;
            this._listView.SelectedIndexChanged += new System.EventHandler(this.ListView_SelectedIndexChanged);
            // 
            // _studentIdColumn
            // 
            this._studentIdColumn.Text = "MSSV";
            this._studentIdColumn.Width = 85;
            // 
            // _middleNameColumn
            // 
            this._middleNameColumn.Text = "Họ và tên lót";
            this._middleNameColumn.Width = 135;
            // 
            // _firstNameColumn
            // 
            this._firstNameColumn.Text = "Tên";
            this._firstNameColumn.Width = 90;
            // 
            // _birthDateColumn
            // 
            this._birthDateColumn.Text = "Ngày sinh";
            this._birthDateColumn.Width = 90;
            // 
            // _classColumn
            // 
            this._classColumn.Text = "Lớp";
            this._classColumn.Width = 80;
            // 
            // _enrollmentYearColumn
            // 
            this._enrollmentYearColumn.Text = "Năm nhập học";
            this._enrollmentYearColumn.Width = 100;
            // 
            // _identityColumn
            // 
            this._identityColumn.Text = "Số CMND";
            this._identityColumn.Width = 95;
            // 
            // _phoneColumn
            // 
            this._phoneColumn.Text = "Số điện thoại";
            this._phoneColumn.Width = 105;
            // 
            // _addressColumn
            // 
            this._addressColumn.Text = "Địa chỉ liên lạc";
            this._addressColumn.Width = 190;
            // 
            // _studentMenu
            // 
            this._studentMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._deleteStudentsMenuItem});
            this._studentMenu.Name = "_studentMenu";
            this._studentMenu.Size = new System.Drawing.Size(214, 26);
            // 
            // _deleteStudentsMenuItem
            // 
            this._deleteStudentsMenuItem.Name = "_deleteStudentsMenuItem";
            this._deleteStudentsMenuItem.Size = new System.Drawing.Size(213, 22);
            this._deleteStudentsMenuItem.Text = "Xóa sinh viên đã đánh dấu";
            this._deleteStudentsMenuItem.Click += new System.EventHandler(this.DeleteStudents_Click);
            // 
            // _status
            // 
            this._status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._status.Location = new System.Drawing.Point(10, 596);
            this._status.Name = "_status";
            this._status.Size = new System.Drawing.Size(926, 21);
            this._status.TabIndex = 3;
            this._status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _errors
            // 
            this._errors.ContainerControl = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 625);
            this.Controls.Add(this._search);
            this.Controls.Add(this._add);
            this.Controls.Add(this._update);
            this.Controls.Add(this._exit);
            this.Controls.Add(this._inputGroup);
            this.Controls.Add(this._listView);
            this.Controls.Add(this._status);
            this.Controls.Add(this._menuStrip);
            this.MainMenuStrip = this._menuStrip;
            this.MinimumSize = new System.Drawing.Size(962, 595);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập thông tin sinh viên";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this._inputGroup.ResumeLayout(false);
            this._inputGroup.PerformLayout();
            this._genderPanel.ResumeLayout(false);
            this._genderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._enrollmentYear)).EndInit();
            this._subjectMenu.ResumeLayout(false);
            this._studentMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._errors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}

