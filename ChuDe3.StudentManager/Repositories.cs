using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ChuDe3.StudentManager
{
    public interface IStudentRepository
    {
        List<Student> Load(string path);
        void Save(string path, IEnumerable<Student> students);
    }

    public static class StudentRepositoryFactory
    {
        public static IStudentRepository FromPath(string path)
        {
            switch (Path.GetExtension(path ?? string.Empty).ToLowerInvariant())
            {
                case ".txt": return new TextStudentRepository();
                case ".xml": return new XmlStudentRepository();
                case ".json": return new JsonStudentRepository();
                default: throw new InvalidOperationException("Chỉ hỗ trợ tệp .txt, .xml hoặc .json.");
            }
        }
    }

    public sealed class TextStudentRepository : IStudentRepository
    {
        public List<Student> Load(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException("Không tìm thấy tệp dữ liệu.", path);
            var result = new List<Student>();
            var lineNumber = 0;
            foreach (var line in File.ReadAllLines(path, Encoding.UTF8))
            {
                lineNumber++;
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#")) continue;
                var fields = SplitEscaped(line, '|');
                if (fields.Count != 11) throw new InvalidOperationException("Dòng " + lineNumber + " của TXT không đủ 11 trường.");
                DateTime date;
                if (!DateTime.TryParseExact(fields[3], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date)) throw new InvalidOperationException("Ngày sinh ở dòng " + lineNumber + " không hợp lệ.");
                Gender gender;
                if (!Enum.TryParse(fields[4], true, out gender)) throw new InvalidOperationException("Giới tính ở dòng " + lineNumber + " không hợp lệ.");
                int year;
                if (!int.TryParse(fields[6], out year)) throw new InvalidOperationException("Năm nhập học ở dòng " + lineNumber + " không hợp lệ.");
                result.Add(new Student { StudentId = fields[0], LastNameAndMiddleName = fields[1], FirstName = fields[2], BirthDate = date, Gender = gender, ClassName = fields[5], EnrollmentYear = year, IdentityNumber = fields[7], PhoneNumber = fields[8], Address = fields[9], Subjects = SplitEscaped(fields[10], ';') });
            }
            return result;
        }

        public void Save(string path, IEnumerable<Student> students)
        {
            var lines = new List<string> { "# StudentManager TXT v1" };
            foreach (var s in students)
            {
                var fields = new[] { s.StudentId, s.LastNameAndMiddleName, s.FirstName, s.BirthDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), s.Gender.ToString(), s.ClassName, s.EnrollmentYear.ToString(CultureInfo.InvariantCulture), s.IdentityNumber, s.PhoneNumber, s.Address, string.Join(";", (s.Subjects ?? new List<string>()).Select(v => Escape(v, ';'))) };
                lines.Add(string.Join("|", fields.Select(v => Escape(v, '|'))));
            }
            AtomicFile.Write(path, string.Join(Environment.NewLine, lines), new UTF8Encoding(false));
        }

        private static string Escape(string value, char separator) => (value ?? string.Empty).Replace("\\", "\\\\").Replace("\r", "\\r").Replace("\n", "\\n").Replace(separator.ToString(), "\\" + separator);
        private static List<string> SplitEscaped(string value, char separator)
        {
            var result = new List<string>(); var current = new StringBuilder(); var escaped = false;
            foreach (var ch in value ?? string.Empty)
            {
                if (escaped) { current.Append(ch == 'r' ? '\r' : ch == 'n' ? '\n' : ch); escaped = false; }
                else if (ch == '\\') escaped = true;
                else if (ch == separator) { result.Add(current.ToString()); current.Clear(); }
                else current.Append(ch);
            }
            if (escaped) current.Append('\\');
            result.Add(current.ToString()); return result;
        }
    }

    [XmlRoot("Students")]
    public sealed class StudentDocument
    {
        [XmlElement("Student")]
        [JsonProperty("students")]
        public List<Student> Students { get; set; } = new List<Student>();
    }

    public sealed class XmlStudentRepository : IStudentRepository
    {
        public List<Student> Load(string path)
        {
            var serializer = new XmlSerializer(typeof(StudentDocument));
            using (var stream = File.OpenRead(path)) return ((StudentDocument)serializer.Deserialize(stream)).Students ?? new List<Student>();
        }
        public void Save(string path, IEnumerable<Student> students)
        {
            var serializer = new XmlSerializer(typeof(StudentDocument));
            AtomicFile.Write(path, stream => serializer.Serialize(stream, new StudentDocument { Students = students.Select(s => s.Clone()).ToList() }));
        }
    }

    public sealed class JsonStudentRepository : IStudentRepository
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings { Formatting = Formatting.Indented, DateFormatString = "yyyy-MM-dd" };
        public List<Student> Load(string path)
        {
            var document = JsonConvert.DeserializeObject<StudentDocument>(File.ReadAllText(path, Encoding.UTF8), Settings);
            return document?.Students ?? new List<Student>();
        }
        public void Save(string path, IEnumerable<Student> students)
        {
            AtomicFile.Write(path, JsonConvert.SerializeObject(new StudentDocument { Students = students.Select(s => s.Clone()).ToList() }, Settings), new UTF8Encoding(false));
        }
    }

    internal static class AtomicFile
    {
        public static void Write(string path, string content, Encoding encoding)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(path)));
            var temporary = path + ".tmp";
            File.WriteAllText(temporary, content, encoding);
            Replace(path, temporary);
        }
        public static void Write(string path, Action<Stream> write)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(path)));
            var temporary = path + ".tmp";
            using (var stream = File.Create(temporary)) write(stream);
            Replace(path, temporary);
        }
        private static void Replace(string path, string temporary)
        {
            if (File.Exists(path)) File.Delete(path);
            File.Move(temporary, path);
        }
    }

}
