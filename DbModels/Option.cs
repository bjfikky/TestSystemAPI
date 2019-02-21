using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestSystemASP.DbModels
{
    public class Option
    {
        public int Id { get; set; }

        public string Text { get; set; }

        [JsonIgnore]
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
