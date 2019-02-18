using System;
using System.ComponentModel.DataAnnotations;

namespace TestSystemASP.UiModels
{
    public class QuestionViewModel
    {
        [Required]
        [Display(Name ="Question")]
        public string QuestionText { get; set; }
    }
}
