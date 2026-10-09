namespace ChuDe3.StudentManagerNoAI
{
    partial class SubjectForm
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
            lblSubjectName = new Label();
            txtSubjectName = new TextBox();
            btnAdd = new Button();
            btnCancel = new Button();
            SuspendLayout();
            //
            // lblSubjectName
            //
            lblSubjectName.Location = new Point(16, 23);
            lblSubjectName.Name = "lblSubjectName";
            lblSubjectName.Size = new Size(80, 23);
            lblSubjectName.Text = "Tên môn:";
            //
            // txtSubjectName
            //
            txtSubjectName.Location = new Point(100, 20);
            txtSubjectName.Name = "txtSubjectName";
            txtSubjectName.Size = new Size(285, 23);
            txtSubjectName.TabIndex = 0;
            //
            // btnAdd
            //
            btnAdd.Location = new Point(165, 70);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(105, 28);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            //
            // btnCancel
            //
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(280, 70);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(105, 28);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            //
            // SubjectForm
            //
            AcceptButton = btnAdd;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(406, 119);
            Controls.Add(lblSubjectName);
            Controls.Add(txtSubjectName);
            Controls.Add(btnAdd);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SubjectForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm môn học";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSubjectName = null!;
        private TextBox txtSubjectName = null!;
        private Button btnAdd = null!;
        private Button btnCancel = null!;
    }
}

