namespace ChuDe3.StudentManagerNoAI
{
    partial class SearchForm
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
            lblStudentId = new Label();
            lblStudentName = new Label();
            lblClassName = new Label();
            txtStudentId = new TextBox();
            txtStudentName = new TextBox();
            txtClassName = new TextBox();
            rdoAll = new RadioButton();
            rdoAny = new RadioButton();
            btnSearch = new Button();
            btnCancel = new Button();
            SuspendLayout();
            //
            // lblStudentId
            //
            lblStudentId.Location = new Point(20, 22);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(90, 23);
            lblStudentId.Text = "MSSV:";
            //
            // txtStudentId
            //
            txtStudentId.Location = new Point(120, 20);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(270, 23);
            txtStudentId.TabIndex = 0;
            //
            // lblStudentName
            //
            lblStudentName.Location = new Point(20, 62);
            lblStudentName.Name = "lblStudentName";
            lblStudentName.Size = new Size(90, 23);
            lblStudentName.Text = "Tên:";
            //
            // txtStudentName
            //
            txtStudentName.Location = new Point(120, 60);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.Size = new Size(270, 23);
            txtStudentName.TabIndex = 1;
            //
            // lblClassName
            //
            lblClassName.Location = new Point(20, 102);
            lblClassName.Name = "lblClassName";
            lblClassName.Size = new Size(90, 23);
            lblClassName.Text = "Lớp:";
            //
            // txtClassName
            //
            txtClassName.Location = new Point(120, 100);
            txtClassName.Name = "txtClassName";
            txtClassName.Size = new Size(270, 23);
            txtClassName.TabIndex = 2;
            //
            // rdoAll
            //
            rdoAll.Checked = true;
            rdoAll.Location = new Point(20, 142);
            rdoAll.Name = "rdoAll";
            rdoAll.Size = new Size(180, 24);
            rdoAll.TabIndex = 3;
            rdoAll.TabStop = true;
            rdoAll.Text = "Tất cả điều kiện";
            //
            // rdoAny
            //
            rdoAny.Location = new Point(210, 142);
            rdoAny.Name = "rdoAny";
            rdoAny.Size = new Size(180, 24);
            rdoAny.TabIndex = 4;
            rdoAny.Text = "Bất kỳ điều kiện";
            //
            // btnSearch
            //
            btnSearch.Location = new Point(170, 190);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(105, 28);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            //
            // btnCancel
            //
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(285, 190);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(105, 28);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            //
            // SearchForm
            //
            AcceptButton = btnSearch;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(414, 241);
            Controls.Add(lblStudentId);
            Controls.Add(lblStudentName);
            Controls.Add(lblClassName);
            Controls.Add(txtStudentId);
            Controls.Add(txtStudentName);
            Controls.Add(txtClassName);
            Controls.Add(rdoAll);
            Controls.Add(rdoAny);
            Controls.Add(btnSearch);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SearchForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tìm kiếm sinh viên";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStudentId = null!;
        private Label lblStudentName = null!;
        private Label lblClassName = null!;
        private TextBox txtStudentId = null!;
        private TextBox txtStudentName = null!;
        private TextBox txtClassName = null!;
        private RadioButton rdoAll = null!;
        private RadioButton rdoAny = null!;
        private Button btnSearch = null!;
        private Button btnCancel = null!;
    }
}

