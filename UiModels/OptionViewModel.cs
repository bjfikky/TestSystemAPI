using System;
using System.ComponentModel.DataAnnotations;

namespace TestSystemASP.UiModels
{
    public class OptionViewModel
    {
        [Required]
        [Display(Name = "Option")]
        public string OptionText { get; set; }

        [Display(Name = "Right Answer?")]
        public bool IsCorrect { get; set; } = false;
    }
}
