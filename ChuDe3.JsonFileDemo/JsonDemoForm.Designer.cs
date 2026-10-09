namespace ChuDe3.JsonFileDemo
{
    partial class JsonDemoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button _readJsonButton;
        private System.Windows.Forms.TextBox _output;

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
            this._readJsonButton = new System.Windows.Forms.Button();
            this._output = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _readJsonButton
            // 
            this._readJsonButton.Dock = System.Windows.Forms.DockStyle.Top;
            this._readJsonButton.Height = 45;
            this._readJsonButton.Name = "_readJsonButton";
            this._readJsonButton.TabIndex = 0;
            this._readJsonButton.Text = "Đọc file JSON";
            this._readJsonButton.UseVisualStyleBackColor = true;
            this._readJsonButton.Click += new System.EventHandler(this.ReadJson_Click);
            // 
            // _output
            // 
            this._output.Dock = System.Windows.Forms.DockStyle.Fill;
            this._output.Font = new System.Drawing.Font("Consolas", 10F);
            this._output.Multiline = true;
            this._output.Name = "_output";
            this._output.ReadOnly = true;
            this._output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._output.TabIndex = 1;
            // 
            // JsonDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 321);
            this.Controls.Add(this._output);
            this.Controls.Add(this._readJsonButton);
            this.Name = "JsonDemoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đọc file JSON";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
