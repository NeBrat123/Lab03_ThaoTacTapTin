using System;
using System.Linq;
using System.Windows.Forms;

namespace ChuDe3.StudentManager
{
    internal static class Program
    {
        [STAThread]
        private static int Main(string[] args)
        {
            try
            {
                if (args.Contains("--self-test"))
                {
                    SelfTest.Run();
                    Console.WriteLine("STUDENT_MANAGER_SELF_TEST_OK");
                    return 0;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Lỗi chương trình", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }
        }
    }
}
