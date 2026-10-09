using System;
using System.IO;
using System.Text;

namespace ChuDe3.TextFileDemo
{
    internal static class Program
    {
        private static int Main(string[] args)
        {
            try
            {
                var dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
                Directory.CreateDirectory(dataDirectory);
                var path = Path.Combine(dataDirectory, "sample.txt");
                var lines = new[]
                {
                    "Chủ đề 3 - Thao tác tập tin",
                    "File.WriteAllLines ghi các dòng UTF-8.",
                    "File.ReadAllLines đọc lại dữ liệu đã lưu."
                };

                File.WriteAllLines(path, lines, new UTF8Encoding(false));
                var readLines = File.ReadAllLines(path, Encoding.UTF8);
                Console.WriteLine("Đã đọc lại tập tin: {0}", path);
                foreach (var line in readLines) Console.WriteLine(line);

                if (readLines.Length != lines.Length) throw new InvalidOperationException("Số dòng đọc lại không đúng.");
                if (Array.IndexOf(args, "--self-test") >= 0) Console.WriteLine("TEXT_DEMO_OK");
                return 0;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
                return 1;
            }
        }
    }
}
