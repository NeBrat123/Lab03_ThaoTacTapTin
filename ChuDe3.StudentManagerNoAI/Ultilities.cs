using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace ChuDe3.StudentManagerNoAI
{
    public static class Ultilities
    {
        public static List<Student> LoadJson(string filename)
        {
            var document = JsonConvert.DeserializeObject<StudentsList>(File.ReadAllText(filename, Encoding.UTF8));
            var students = document?.Students ?? throw new InvalidDataException("JSON phải có danh sách students.");
            ValidateStudents(students);
            return students;
        }

        public static List<Student> LoadXml(string filename)
        {
            using var reader = XmlReader.Create(filename, new XmlReaderSettings { DtdProcessing = DtdProcessing.Prohibit });
            var root = XDocument.Load(reader).Root;
            if (root == null || root.Name != "Students" || root.Elements().Any(e => e.Name != "Student"))
                throw new InvalidDataException("XML phải có cấu trúc Students/Student.");
            var students = root.Elements("Student").Select(e => new Student
            {
                StudentID = XmlValue(e, "StudentId"),
                LastMiddleName = XmlValue(e, "LastNameAndMiddleName"),
                FirstName = XmlValue(e, "FirstName"),
                BirthDate = XmlConvert.ToDateTime(XmlValue(e, "BirthDate"), XmlDateTimeSerializationMode.RoundtripKind),
                Gender = ParseGender(XmlValue(e, "Gender")),
                ClassName = XmlValue(e, "ClassName"),
                IdentityNumber = XmlValue(e, "IdentityNumber"),
                PhoneNumber = XmlValue(e, "PhoneNumber"),
                Address = XmlValue(e, "Address"),
                Subjects = (e.Element("Subjects") ?? throw new InvalidDataException("Thiếu danh sách môn học trong XML."))
                    .Elements("Subject").Select(s => s.Value).ToList()
            }).ToList();
            ValidateStudents(students);
            return students;
        }

        public static List<Student> LoadTxt(string filename)
        {
            var students = new List<Student>();
            int lineNumber = 0;
            foreach (string line in File.ReadAllLines(filename, Encoding.UTF8))
            {
                lineNumber++;
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith('#')) continue;
                try
                {
                    var fields = SplitEscaped(line, '|');
                    if (fields.Count != 11)
                        throw new InvalidDataException("Cần đúng 11 cột, ngăn cách bằng dấu |.");
                    var student = new Student
                    {
                        StudentID = fields[0], LastMiddleName = fields[1], FirstName = fields[2],
                        BirthDate = DateTime.ParseExact(fields[3], "yyyy-MM-dd", CultureInfo.InvariantCulture),
                        Gender = ParseGender(fields[4]), ClassName = fields[5], IdentityNumber = fields[7],
                        PhoneNumber = fields[8], Address = fields[9], Subjects = SplitEscaped(fields[10], ';')
                    };
                    if (!int.TryParse(fields[6], out int year) || year != student.GetEnrollmentYear())
                        throw new InvalidDataException("Năm nhập học không khớp với lớp.");
                    students.Add(student);
                }
                catch (Exception ex) when (ex is ArgumentException or FormatException or InvalidDataException)
                {
                    throw new InvalidDataException($"Dòng {lineNumber}: {ex.Message}", ex);
                }
            }
            ValidateStudents(students);
            return students;
        }

        public static List<Student> LoadFile(string filename)
        {
            return Path.GetExtension(filename).ToLowerInvariant() switch
            {
                ".json" => LoadJson(filename),
                ".xml" => LoadXml(filename),
                ".txt" => LoadTxt(filename),
                _ => throw new ArgumentException("Chỉ hỗ trợ tập tin TXT, XML hoặc JSON.")
            };
        }

        public static void SaveJson(string filename, List<Student> students)
        {
            ValidateStudents(students);
            var settings = new JsonSerializerSettings { Formatting = Newtonsoft.Json.Formatting.Indented, DateFormatString = "yyyy-MM-dd" };
            WriteFile(filename, JsonConvert.SerializeObject(new StudentsList { Students = students }, settings));
        }

        public static void SaveXml(string filename, List<Student> students)
        {
            ValidateStudents(students);
            var root = new XElement("Students", students.Select(s => new XElement("Student",
                new XElement("StudentId", s.StudentID),
                new XElement("LastNameAndMiddleName", s.LastMiddleName),
                new XElement("FirstName", s.FirstName),
                new XElement("BirthDate", s.BirthDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)),
                new XElement("Gender", s.Gender == 0 ? "Male" : "Female"),
                new XElement("ClassName", s.ClassName),
                new XElement("EnrollmentYear", s.GetEnrollmentYear()),
                new XElement("IdentityNumber", s.IdentityNumber),
                new XElement("PhoneNumber", s.PhoneNumber),
                new XElement("Address", s.Address),
                new XElement("Subjects", s.Subjects.Select(subject => new XElement("Subject", subject))))));
            WriteFile(filename, "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine + root);
        }

        public static void SaveTxt(string filename, List<Student> students)
        {
            ValidateStudents(students);
            var lines = new List<string> { "# StudentManager TXT v1" };
            foreach (var s in students)
            {
                string[] fields = { s.StudentID, s.LastMiddleName, s.FirstName,
                    s.BirthDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), s.Gender == 0 ? "Male" : "Female",
                    s.ClassName, s.GetEnrollmentYear().ToString(CultureInfo.InvariantCulture), s.IdentityNumber,
                    s.PhoneNumber, s.Address, string.Join(";", s.Subjects.Select(subject => Escape(subject, ';'))) };
                lines.Add(string.Join("|", fields.Select(value => Escape(value, '|'))));
            }
            WriteFile(filename, string.Join(Environment.NewLine, lines));
        }

        public static void SaveFile(string filename, List<Student> students)
        {
            switch (Path.GetExtension(filename).ToLowerInvariant())
            {
                case ".json": SaveJson(filename, students); break;
                case ".xml": SaveXml(filename, students); break;
                case ".txt": SaveTxt(filename, students); break;
                default: throw new ArgumentException("Chỉ hỗ trợ tập tin TXT, XML hoặc JSON.");
            }
        }

        private static void ValidateStudents(List<Student> students)
        {
            foreach (var student in students)
            {
                if (student == null) throw new InvalidDataException("Danh sách chứa sinh viên null.");
                try { student.ValidateInformation(); }
                catch (ArgumentException ex) { throw new InvalidDataException($"Sinh viên {student.StudentID}: {ex.Message}", ex); }
            }
            var duplicate = students.GroupBy(s => s.StudentID).FirstOrDefault(g => g.Count() > 1);
            if (duplicate != null) throw new InvalidDataException($"MSSV {duplicate.Key} bị trùng trong danh sách.");
        }

        private static string XmlValue(XElement student, string name)
        {
            return student.Element(name)?.Value ?? throw new InvalidDataException($"Thiếu trường {name} trong XML.");
        }

        private static int ParseGender(string value)
        {
            return value.ToLowerInvariant() switch
            {
                "0" or "male" => 0,
                "1" or "female" => 1,
                _ => throw new InvalidDataException("Giới tính phải là 0/1 hoặc Male/Female.")
            };
        }

        private static string Escape(string value, char separator)
        {
            return value.Replace("\\", "\\\\").Replace("\r", "\\r").Replace("\n", "\\n")
                .Replace(separator.ToString(), "\\" + separator);
        }

        private static List<string> SplitEscaped(string value, char separator)
        {
            var result = new List<string>();
            var current = new StringBuilder();
            bool escaped = false;
            foreach (char c in value)
            {
                if (escaped)
                {
                    current.Append(c == 'r' ? '\r' : c == 'n' ? '\n' : c);
                    escaped = false;
                }
                else if (c == '\\') escaped = true;
                else if (c == separator) { result.Add(current.ToString()); current.Clear(); }
                else current.Append(c);
            }
            if (escaped) throw new InvalidDataException("Ký tự escape ở cuối dòng không hợp lệ.");
            result.Add(current.ToString());
            return result;
        }

        // Ghi vào tập tin tạm cùng thư mục; chỉ thay tập tin gốc khi ghi xong.
        private static void WriteFile(string filename, string content)
        {
            string fullPath = Path.GetFullPath(filename);
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
            string temporary = fullPath + "." + Guid.NewGuid().ToString("N") + ".tmp";
            try
            {
                File.WriteAllText(temporary, content, new UTF8Encoding(false));
                if (File.Exists(fullPath)) File.Replace(temporary, fullPath, null);
                else File.Move(temporary, fullPath);
            }
            finally
            {
                if (File.Exists(temporary)) File.Delete(temporary);
            }
        }
    }
}

