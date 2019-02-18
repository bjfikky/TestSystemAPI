using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestSystemASP.DbModels
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string QuestionText { get; set; }

        public ICollection<Option> Options { get; set; }
    }
}
