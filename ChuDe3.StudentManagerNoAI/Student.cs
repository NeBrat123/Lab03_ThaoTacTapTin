using Newtonsoft.Json;
using System.Text.RegularExpressions;
namespace ChuDe3.StudentManagerNoAI
{
    public class Student
    {
        [JsonProperty("StudentId", Required = Required.Always)]
        public required string StudentID {  
            get; 
            set {
                Validate(value, "MSSV", 7);
                field = value;
            } 
        }

        [JsonProperty("LastNameAndMiddleName", Required = Required.Always)]
        public required string LastMiddleName { get; set; }

        [JsonProperty("FirstName", Required = Required.Always)]
        public required string FirstName { get; set; }

        [JsonProperty("BirthDate", Required = Required.Always)]
        public required DateTime BirthDate { get; set; }

        [JsonProperty("Gender", Required = Required.Always)]
        public required int Gender { 
            get; 
            set {
                if (value == 1 || value == 0)
                    field = value;
                else
                    throw new ArgumentException("Giới tính không hợp lệ");
            } 
        }

        [JsonProperty("IdentityNumber", Required = Required.Always)]
        public required string IdentityNumber { 
            get; 
            set
            {
                Validate(value, "Số CMND", 9);
                field = value;
            } 
        }

        [JsonProperty("Address", Required = Required.Always)]
        public required string Address { get; set; }

        [JsonProperty("ClassName", Required = Required.Always)]
        public required string ClassName { get; set; }

        [JsonProperty("PhoneNumber", Required = Required.Always)]
        public required string PhoneNumber { 
            get; 
            set
            {
                Validate(value, "SDT", 10);
                field = value;
            } 
        }

        [JsonProperty("Subjects", Required = Required.Always)]
        public required List<string> Subjects { get; set; }

        [JsonIgnore]
        public string GenderText => Gender == 0 ? "Nam" : "Nữ";

        [JsonIgnore]
        public string SubjectsText => string.Join("; ", Subjects);

        public int GetEnrollmentYear()
        {
            var match = Regex.Match(ClassName ?? "", @"^CTK([0-9]{2})[A-Z]*$", RegexOptions.IgnoreCase);
            if (!match.Success)
                throw new ArgumentException("Lớp phải có dạng CTK46, CTK47 hoặc CTK46A.");
            int year = 1976 + int.Parse(match.Groups[1].Value);
            if (year > DateTime.Today.Year)
                throw new ArgumentException("Năm nhập học theo lớp không được lớn hơn năm hiện tại.");
            return year;
        }

        public void ValidateInformation()
        {
            Validate(StudentID, "MSSV", 7);
            Validate(IdentityNumber, "Số CMND", 9);
            Validate(PhoneNumber, "Số điện thoại", 10);
            if (string.IsNullOrWhiteSpace(LastMiddleName))
                throw new ArgumentException("Vui lòng nhập họ và tên lót.");
            if (string.IsNullOrWhiteSpace(FirstName))
                throw new ArgumentException("Vui lòng nhập tên sinh viên.");
            if (string.IsNullOrWhiteSpace(Address))
                throw new ArgumentException("Vui lòng nhập địa chỉ liên lạc.");
            if (BirthDate.Date < new DateTime(1753, 1, 1) || BirthDate.Date > DateTime.Today)
                throw new ArgumentException("Ngày sinh không hợp lệ.");
            if (Gender != 0 && Gender != 1)
                throw new ArgumentException("Vui lòng chọn giới tính.");
            if (Subjects == null || Subjects.Count == 0 || Subjects.Any(string.IsNullOrWhiteSpace))
                throw new ArgumentException("Vui lòng chọn ít nhất một môn đăng ký; tên môn không được để trống.");
            int year = GetEnrollmentYear();
            if (StudentID.Substring(0, 2) != (year % 100).ToString("00") || StudentID.Substring(2, 2) != "10")
                throw new ArgumentException($"MSSV phải có dạng {year % 100:00}10CCC theo lớp {ClassName}.");
        }

        private static void Validate(string? validateString, string validateField, int length)
        {
            if (string.IsNullOrEmpty(validateString) || validateString.Length != length)
                throw new ArgumentException(validateField + " phải có đúng " + length + " chữ số");
            if (validateString.Any(c => c < '0' || c > '9'))
                throw new ArgumentException(validateField + " chỉ được chứa chữ số từ 0 đến 9");
        }
    }
}
