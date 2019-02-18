using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestSystemASP.Data;
using TestSystemASP.DbModels;
using TestSystemASP.UiModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestSystemASP.Controllers
{

    //[Authorize]
    public class QuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;


        public QuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: /Question/
        public IActionResult Index()
        {
            var questions = _context.Questions.Include(q => q.Options).ToList();

            return View(questions);
        }


        // GET: /Question/Create
        public IActionResult Create()
        {

            return View();
        }


        // POST: /Question/Create
        [HttpPost]
        public IActionResult Create(QuestionOptionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var question = new Question
            {
                QuestionText = model.QuestionViewModel.QuestionText
            };

            _context.Add(question);

            _context.SaveChanges();

            var insertedQuestionId = question.Id;



            foreach (var optionFromView in model.OptionViewModel)
            {
                var option = new Option
                {
                    Text = optionFromView.OptionText,
                    IsCorrect = optionFromView.IsCorrect,
                    QuestionId = insertedQuestionId
                };

                _context.Add(option);
                _context.SaveChanges();
            }

            TempData["success-msg"] = "Question Saved Successfully";

            ModelState.Clear();

            return RedirectToAction($"Create");
        }


        // GET: /api/questions
        [EnableCors("vue")]
        [Route("/api/questions")]
        public IActionResult GetQuestions()
        {
            var questions = _context.Questions.Include(q => q.Options).ToList();

            return Json(questions);
        }
    }
}
