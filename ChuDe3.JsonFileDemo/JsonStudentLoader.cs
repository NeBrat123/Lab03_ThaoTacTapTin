using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ChuDe3.JsonFileDemo
{
    public static class JsonStudentLoader
    {
        public static List<StudentInfo> Load(string path)
        {
            var root = JObject.Parse(File.ReadAllText(path));
            var result = new List<StudentInfo>();
            foreach (var item in root["sinhvien"] ?? new JArray())
            {
                result.Add(new StudentInfo
                {
                    MSSV = (string)item["MSSV"],
                    Hoten = (string)item["hoten"],
                    Tuoi = (int?)item["tuoi"] ?? 0,
                    Diem = (double?)item["diem"] ?? 0,
                    TonGiao = (bool?)item["tongiao"] ?? false
                });
            }
            return result;
        }
    }
}
