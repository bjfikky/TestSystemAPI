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
            
            // TODO: Check if the user has already answered i.e - edit and answer rather than save a new one
            
            _context.Answers.Add(answer);

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