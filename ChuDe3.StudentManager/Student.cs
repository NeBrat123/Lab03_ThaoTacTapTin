using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ChuDe3.StudentManager
{
    public enum Gender { Male, Female }
    public enum SearchCombination { All, Any }

    public sealed class Student
    {
        public string StudentId { get; set; }
        public string LastNameAndMiddleName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string ClassName { get; set; }
        public int EnrollmentYear { get; set; }
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        [XmlArray("Subjects")]
        [XmlArrayItem("Subject")]
        public List<string> Subjects { get; set; } = new List<string>();

        [XmlIgnore]
        public string FullName => (LastNameAndMiddleName + " " + FirstName).Trim();

        public Student Clone()
        {
            return new Student
            {
                StudentId = StudentId,
                LastNameAndMiddleName = LastNameAndMiddleName,
                FirstName = FirstName,
                BirthDate = BirthDate,
                Gender = Gender,
                ClassName = ClassName,
                EnrollmentYear = EnrollmentYear,
                IdentityNumber = IdentityNumber,
                PhoneNumber = PhoneNumber,
                Address = Address,
                Subjects = new List<string>(Subjects ?? new List<string>())
            };
        }
    }

    public sealed class StudentSearchCriteria
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public SearchCombination Combination { get; set; }

        public bool HasCondition => !string.IsNullOrWhiteSpace(StudentId) || !string.IsNullOrWhiteSpace(Name) || !string.IsNullOrWhiteSpace(ClassName);
    }
}
