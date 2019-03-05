using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TestSystemASP.DbModels
{
    public class Answer
    {
        public int Id { get; set; }

        public string Email { get; set; }
        
        public int OptionId { get; set; }

        [JsonIgnore]
        public Option Option { get; set; }
    }
}