using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ChuDe3.StudentManager
{
    public sealed class StudentManagerService
    {
        private readonly List<Student> _students = new List<Student>();
        private static readonly Regex StudentIdPattern = new Regex("^\\d{2}10\\d{3}$", RegexOptions.Compiled);
        private static readonly Regex NineDigits = new Regex("^\\d{9}$", RegexOptions.Compiled);
        private static readonly Regex TenDigits = new Regex("^\\d{10}$", RegexOptions.Compiled);

        public IReadOnlyList<Student> Students => _students.Select(s => s.Clone()).ToList();

        public void ReplaceAll(IEnumerable<Student> students)
        {
            var copies = (students ?? Enumerable.Empty<Student>()).Select(s => s.Clone()).ToList();
            var ids = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var student in copies)
            {
                EnsureValid(student, null);
                if (!ids.Add(student.StudentId)) throw new InvalidOperationException("Tệp dữ liệu có MSSV trùng: " + student.StudentId);
            }
            _students.Clear();
            _students.AddRange(copies);
        }

        public void Add(Student student)
        {
            EnsureValid(student, null);
            if (_students.Any(s => SameId(s.StudentId, student.StudentId))) throw new InvalidOperationException("MSSV đã tồn tại.");
            _students.Add(student.Clone());
        }

        public void Update(string originalId, Student student)
        {
            EnsureValid(student, originalId);
            var index = _students.FindIndex(s => SameId(s.StudentId, originalId));
            if (index < 0) throw new InvalidOperationException("Không tìm thấy sinh viên cần cập nhật.");
            if (_students.Any(s => !SameId(s.StudentId, originalId) && SameId(s.StudentId, student.StudentId))) throw new InvalidOperationException("MSSV đã tồn tại.");
            _students[index] = student.Clone();
        }

        public void Delete(IEnumerable<string> studentIds)
        {
            var ids = new HashSet<string>(studentIds ?? Enumerable.Empty<string>(), StringComparer.OrdinalIgnoreCase);
            _students.RemoveAll(s => ids.Contains(s.StudentId));
        }

        public List<Student> Search(StudentSearchCriteria criteria)
        {
            if (criteria == null || !criteria.HasCondition) throw new InvalidOperationException("Hãy nhập ít nhất một điều kiện tìm kiếm.");
            return _students.Where(student => Matches(student, criteria)).Select(s => s.Clone()).ToList();
        }

        public static List<string> Validate(Student student)
        {
            var errors = new List<string>();
            if (student == null) return new List<string> { "Thông tin sinh viên không hợp lệ." };
            if (string.IsNullOrWhiteSpace(student.StudentId)) errors.Add("MSSV không được để trống.");
            else if (!StudentIdPattern.IsMatch(student.StudentId)) errors.Add("MSSV phải gồm 7 số theo dạng AABBCCC, với BB = 10.");
            else if (student.EnrollmentYear < 2000 || student.EnrollmentYear > DateTime.Today.Year) errors.Add("Năm nhập học không hợp lệ.");
            else if (student.StudentId.Substring(0, 2) != (student.EnrollmentYear % 100).ToString("00", CultureInfo.InvariantCulture)) errors.Add("Hai số đầu MSSV phải là hai số cuối của năm nhập học.");
            if (string.IsNullOrWhiteSpace(student.LastNameAndMiddleName)) errors.Add("Họ và tên lót không được để trống.");
            if (string.IsNullOrWhiteSpace(student.FirstName)) errors.Add("Tên không được để trống.");
            if (student.BirthDate.Date > DateTime.Today) errors.Add("Ngày sinh không được ở tương lai.");
            if (string.IsNullOrWhiteSpace(student.ClassName)) errors.Add("Lớp không được để trống.");
            if (!NineDigits.IsMatch(student.IdentityNumber ?? string.Empty)) errors.Add("Số CMND phải gồm đúng 9 chữ số.");
            if (!TenDigits.IsMatch(student.PhoneNumber ?? string.Empty)) errors.Add("Số điện thoại phải gồm đúng 10 chữ số.");
            if (string.IsNullOrWhiteSpace(student.Address)) errors.Add("Địa chỉ liên lạc không được để trống.");
            if (student.Subjects == null || student.Subjects.Count == 0) errors.Add("Hãy chọn ít nhất một môn đăng ký.");
            return errors;
        }

        private static void EnsureValid(Student student, string originalId)
        {
            var errors = Validate(student);
            if (errors.Count > 0) throw new InvalidOperationException(string.Join(Environment.NewLine, errors));
        }

        private static bool Matches(Student student, StudentSearchCriteria criteria)
        {
            var matches = new List<bool>();
            if (!string.IsNullOrWhiteSpace(criteria.StudentId)) matches.Add(string.Equals(student.StudentId, criteria.StudentId.Trim(), StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrWhiteSpace(criteria.Name)) matches.Add(ContainsIgnoringDiacritics(student.FullName, criteria.Name));
            if (!string.IsNullOrWhiteSpace(criteria.ClassName)) matches.Add(ContainsIgnoringDiacritics(student.ClassName, criteria.ClassName));
            return criteria.Combination == SearchCombination.All ? matches.All(m => m) : matches.Any(m => m);
        }

        private static bool SameId(string left, string right) => string.Equals(left, right, StringComparison.OrdinalIgnoreCase);

        public static bool ContainsIgnoringDiacritics(string value, string query)
        {
            return RemoveDiacritics(value ?? string.Empty).IndexOf(RemoveDiacritics(query ?? string.Empty), StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static string RemoveDiacritics(string value)
        {
            var normalized = value.Normalize(NormalizationForm.FormD);
            var builder = new StringBuilder();
            foreach (var ch in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark) builder.Append(ch == 'đ' ? 'd' : ch == 'Đ' ? 'D' : ch);
            }
            return builder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
