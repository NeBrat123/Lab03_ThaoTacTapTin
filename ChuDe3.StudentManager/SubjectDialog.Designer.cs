namespace ChuDe3.StudentManager
{
    partial class SubjectDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label _label;
        private System.Windows.Forms.TextBox _textBox;
        private System.Windows.Forms.Button _ok;
        private System.Windows.Forms.Button _cancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this._label = new System.Windows.Forms.Label();
            this._textBox = new System.Windows.Forms.TextBox();
            this._ok = new System.Windows.Forms.Button();
            this._cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _label
            // 
            this._label.Location = new System.Drawing.Point(12, 15);
            this._label.Name = "_label";
            this._label.Size = new System.Drawing.Size(87, 23);
            this._label.TabIndex = 0;
            this._label.Text = "Tên môn học:";
            this._label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _textBox
            // 
            this._textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBox.Location = new System.Drawing.Point(105, 16);
            this._textBox.Name = "_textBox";
            this._textBox.Size = new System.Drawing.Size(253, 23);
            this._textBox.TabIndex = 0;
            // 
            // _ok
            // 
            this._ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._ok.Location = new System.Drawing.Point(195, 60);
            this._ok.Name = "_ok";
            this._ok.Size = new System.Drawing.Size(80, 30);
            this._ok.TabIndex = 1;
            this._ok.Text = "Thêm";
            this._ok.UseVisualStyleBackColor = true;
            this._ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // _cancel
            // 
            this._cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancel.Location = new System.Drawing.Point(281, 60);
            this._cancel.Name = "_cancel";
            this._cancel.Size = new System.Drawing.Size(80, 30);
            this._cancel.TabIndex = 2;
            this._cancel.Text = "Hủy";
            this._cancel.UseVisualStyleBackColor = true;
            // 
            // SubjectDialog
            // 
            this.AcceptButton = this._ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancel;
            this.ClientSize = new System.Drawing.Size(370, 125);
            this.Controls.Add(this._label);
            this.Controls.Add(this._textBox);
            this.Controls.Add(this._ok);
            this.Controls.Add(this._cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubjectDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm môn học";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}


