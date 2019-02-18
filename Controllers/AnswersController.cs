using Microsoft.AspNetCore.Mvc;
using TestSystemASP.Data;
using TestSystemASP.DbModels;

namespace TestSystemASP.Controllers
{
    public class AnswersController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public AnswersController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET
        [HttpPost]
        [Route("/api/answers")]
        public IActionResult Post([FromBody]Answer answer)
        {
            if (!ModelState.IsValid) return BadRequest();
            
            _context.Answers.Add(answer);

            _context.SaveChanges();

            return Ok("Added");

        }
    }
}