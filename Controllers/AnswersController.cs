using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestSystemASP.Data;
using TestSystemASP.DbModels;

namespace TestSystemASP.Controllers
{
    [EnableCors("vue")]
    public class AnswersController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public AnswersController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        
        
        [HttpPost]      
        [Route("/api/answers")]
        public IActionResult Post([FromBody]Answer answer)
        {
            if (!ModelState.IsValid) return BadRequest();
            
            // Get question related to answer id

            var option = _context.Options.Find(answer.OptionId);
            
            // TODO: Check if the user has already answered i.e - edit and answer rather than save a new one

            var previousAnswer = _context.Answers
                .FirstOrDefault(a => a.Email == answer.Email && a.Option.QuestionId == option.QuestionId);

            if (previousAnswer == null)
            {
                _context.Answers.Add(answer);
            }
            else
            {
                previousAnswer.Email = answer.Email;
                previousAnswer.OptionId = answer.OptionId;
            }
            
            

            _context.SaveChanges();

            return Ok("Added");
        }

        [HttpGet]
        [Route("/api/answers/{email}")]
        public IActionResult GetAnswers(string email)
        {
            var answers = _context.Answers.Where(a => a.Email == email).ToList();
            
            return Json(answers);
        }
        
    }
}