using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChuDe3.StudentManagerNoAI
{
    public class StudentsList
    {
        [JsonProperty("students", Required = Required.Always)]
        public required List<Student> Students { get; set; }
    }
}
