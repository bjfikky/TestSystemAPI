using System.ComponentModel.DataAnnotations;

namespace TestSystemASP.DbModels
{
    public class Answer
    {
        public int Id { get; set; }

        public string Email { get; set; }
        
        public int OptionId { get; set; }

        public Option Option { get; set; }
    }
}