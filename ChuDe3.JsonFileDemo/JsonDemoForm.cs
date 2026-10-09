using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ChuDe3.JsonFileDemo
{
    public partial class JsonDemoForm : Form
    {
        private readonly string _path;

        public JsonDemoForm()
            : this(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "students.json"))
        {
        }

        public JsonDemoForm(string path)
        {
            _path = path;
            InitializeComponent();
        }

        private void ReadJson_Click(object sender, EventArgs e)
        {
            try
            {
                var students = JsonStudentLoader.Load(_path);
                var message = new StringBuilder();
                for (var i = 0; i < students.Count; i++)
                {
                    var student = students[i];
                    message.AppendFormat("Sinh viên {0}: MSSV {1}, họ tên: {2}, điểm TB: {3}\r\n", i + 1, student.MSSV, student.Hoten, student.Diem);
                }

                _output.Text = message.ToString();
                MessageBox.Show(_output.Text, "Kết quả đọc JSON", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Không thể đọc JSON", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
