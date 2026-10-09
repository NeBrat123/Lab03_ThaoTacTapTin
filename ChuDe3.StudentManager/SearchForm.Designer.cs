namespace ChuDe3.StudentManager
{
    partial class SearchForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox _txtId;
        private System.Windows.Forms.TextBox _txtName;
        private System.Windows.Forms.TextBox _txtClass;
        private System.Windows.Forms.ComboBox _cmbCombination;
        private System.Windows.Forms.Label _idLabel;
        private System.Windows.Forms.Label _nameLabel;
        private System.Windows.Forms.Label _classLabel;
        private System.Windows.Forms.Label _combinationLabel;
        private System.Windows.Forms.Button _find;
        private System.Windows.Forms.Button _cancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this._idLabel = new System.Windows.Forms.Label();
            this._txtId = new System.Windows.Forms.TextBox();
            this._nameLabel = new System.Windows.Forms.Label();
            this._txtName = new System.Windows.Forms.TextBox();
            this._classLabel = new System.Windows.Forms.Label();
            this._txtClass = new System.Windows.Forms.TextBox();
            this._combinationLabel = new System.Windows.Forms.Label();
            this._cmbCombination = new System.Windows.Forms.ComboBox();
            this._find = new System.Windows.Forms.Button();
            this._cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _idLabel
            // 
            this._idLabel.Location = new System.Drawing.Point(15, 15);
            this._idLabel.Name = "_idLabel";
            this._idLabel.Size = new System.Drawing.Size(101, 23);
            this._idLabel.TabIndex = 0;
            this._idLabel.Text = "MSSV:";
            this._idLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtId
            // 
            this._txtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtId.Location = new System.Drawing.Point(122, 16);
            this._txtId.Name = "_txtId";
            this._txtId.Size = new System.Drawing.Size(240, 20);
            this._txtId.TabIndex = 0;
            // 
            // _nameLabel
            // 
            this._nameLabel.Location = new System.Drawing.Point(15, 43);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(101, 23);
            this._nameLabel.TabIndex = 1;
            this._nameLabel.Text = "Tên:";
            this._nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtName
            // 
            this._txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtName.Location = new System.Drawing.Point(122, 44);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(240, 20);
            this._txtName.TabIndex = 1;
            // 
            // _classLabel
            // 
            this._classLabel.Location = new System.Drawing.Point(15, 71);
            this._classLabel.Name = "_classLabel";
            this._classLabel.Size = new System.Drawing.Size(101, 23);
            this._classLabel.TabIndex = 2;
            this._classLabel.Text = "Lớp:";
            this._classLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _txtClass
            // 
            this._txtClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtClass.Location = new System.Drawing.Point(122, 72);
            this._txtClass.Name = "_txtClass";
            this._txtClass.Size = new System.Drawing.Size(240, 20);
            this._txtClass.TabIndex = 2;
            // 
            // _combinationLabel
            // 
            this._combinationLabel.Location = new System.Drawing.Point(15, 99);
            this._combinationLabel.Name = "_combinationLabel";
            this._combinationLabel.Size = new System.Drawing.Size(101, 23);
            this._combinationLabel.TabIndex = 3;
            this._combinationLabel.Text = "Cách kết hợp:";
            this._combinationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _cmbCombination
            // 
            this._cmbCombination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._cmbCombination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbCombination.FormattingEnabled = true;
            this._cmbCombination.Items.AddRange(new object[] {
            "Khớp tất cả điều kiện (AND)",
            "Khớp bất kỳ điều kiện (OR)"});
            this._cmbCombination.Location = new System.Drawing.Point(122, 100);
            this._cmbCombination.Name = "_cmbCombination";
            this._cmbCombination.Size = new System.Drawing.Size(240, 21);
            this._cmbCombination.TabIndex = 3;
            // 
            // _find
            // 
            this._find.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._find.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._find.Location = new System.Drawing.Point(199, 140);
            this._find.Name = "_find";
            this._find.Size = new System.Drawing.Size(77, 30);
            this._find.TabIndex = 0;
            this._find.Text = "Tìm";
            this._find.UseVisualStyleBackColor = true;
            this._find.Click += new System.EventHandler(this.Find_Click);
            // 
            // _cancel
            // 
            this._cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancel.Location = new System.Drawing.Point(282, 140);
            this._cancel.Name = "_cancel";
            this._cancel.Size = new System.Drawing.Size(77, 30);
            this._cancel.TabIndex = 1;
            this._cancel.Text = "Hủy";
            this._cancel.UseVisualStyleBackColor = true;
            // 
            // SearchForm
            // 
            this.AcceptButton = this._find;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancel;
            this.ClientSize = new System.Drawing.Size(377, 191);
            this.Controls.Add(this._idLabel);
            this.Controls.Add(this._txtId);
            this.Controls.Add(this._nameLabel);
            this.Controls.Add(this._txtName);
            this.Controls.Add(this._classLabel);
            this.Controls.Add(this._txtClass);
            this.Controls.Add(this._combinationLabel);
            this.Controls.Add(this._cmbCombination);
            this.Controls.Add(this._find);
            this.Controls.Add(this._cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tìm kiếm sinh viên";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}



