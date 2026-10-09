using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChuDe3.StudentManager
{
    internal static class SelfTest
    {
        public static void Run()
        {
            var directory = Path.Combine(Path.GetTempPath(), "ChuDe3StudentManagerSelfTest-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(directory);
            try
            {
                var manager = new StudentManagerService();
                var first = Create("2410001", "Nguyễn Văn", "An", "24CT1", 2024);
                var second = Create("2410002", "Trần Thị", "Bình", "24CT1", 2024);
                manager.Add(first);
                manager.Add(second);
                Expect(manager.Students.Count == 2, "Thêm sinh viên thất bại.");
                Expect(StudentManagerService.Validate(Create("2510001", "Lê", "Cường", "25CT1", 2024)).Count > 0, "Sai năm nhập học chưa bị phát hiện.");
                Expect(StudentManagerService.Validate(Create("2499001", "Lê", "Cường", "25CT1", 2024)).Count > 0, "MSSV không có BB=10 chưa bị phát hiện.");
                var duplicateRejected = false;
                try { manager.Add(first); } catch (InvalidOperationException) { duplicateRejected = true; }
                Expect(duplicateRejected, "MSSV trùng chưa bị chặn.");

                second.FirstName = "Bình An";
                manager.Update("2410002", second);
                var andResult = manager.Search(new StudentSearchCriteria { Name = "binh", ClassName = "24ct", Combination = SearchCombination.All });
                Expect(andResult.Count == 1, "Tìm kiếm AND/không dấu thất bại.");
                var orResult = manager.Search(new StudentSearchCriteria { StudentId = "khong-co", Name = "nguyen", Combination = SearchCombination.Any });
                Expect(orResult.Count == 1, "Tìm kiếm OR thất bại.");

                foreach (var extension in new[] { ".txt", ".xml", ".json" })
                {
                    var path = Path.Combine(directory, "students" + extension);
                    var repository = StudentRepositoryFactory.FromPath(path);
                    repository.Save(path, manager.Students);
                    var loaded = repository.Load(path);
                    var reloaded = new StudentManagerService();
                    reloaded.ReplaceAll(loaded);
                    Expect(reloaded.Students.Count == 2 && reloaded.Students[0].Subjects.Count > 0, "Round-trip " + extension + " thất bại.");
                }

                File.WriteAllText(Path.Combine(directory, "bad.txt"), "bad|record");
                try { new TextStudentRepository().Load(Path.Combine(directory, "bad.txt")); throw new InvalidOperationException("Tệp TXT hỏng chưa báo lỗi."); } catch (InvalidOperationException) { }
                manager.Delete(new[] { "2410001", "2410002" });
                Expect(manager.Students.Count == 0, "Xóa nhiều sinh viên thất bại.");
            }
            finally
            {
                if (Directory.Exists(directory)) Directory.Delete(directory, true);
            }
        }

        private static Student Create(string id, string middle, string first, string className, int year)
        {
            return new Student { StudentId = id, LastNameAndMiddleName = middle, FirstName = first, BirthDate = new DateTime(2004, 1, 1), Gender = Gender.Male, ClassName = className, EnrollmentYear = year, IdentityNumber = "123456789", PhoneNumber = "0901234567", Address = "TP. Hồ Chí Minh", Subjects = new List<string> { "Mạng máy tính" } };
        }

        private static void Expect(bool condition, string message)
        {
            if (!condition) throw new InvalidOperationException(message);
        }
    }
}
