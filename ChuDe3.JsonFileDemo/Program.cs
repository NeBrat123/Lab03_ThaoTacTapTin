using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ChuDe3.JsonFileDemo
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "students.json");
            if (args.Contains("--self-test"))
            {
                var students = JsonStudentLoader.Load(path);
                if (students.Count != 2 || students[0].MSSV != "1245732") throw new InvalidOperationException("Dữ liệu JSON mẫu không đúng.");
                Console.WriteLine("JSON_DEMO_OK");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new JsonDemoForm(path));
        }
    }
}
