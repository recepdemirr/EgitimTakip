using EgitimTakip.Data;
using EgitimTakip.Models;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakipWeb.Controllers
{
    public class TrainingSubjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly ApplicationDbContext _context;

        public TrainingSubjectController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult GetAll ()
        {
            var result = _context.TrainingSubjects.ToList();
            return Json(new {data = result});
        }
        [HttpPost]
        public IActionResult Add(TrainingSubject trainingSubject)
        {
            _context.TrainingSubjects.Add(trainingSubject);
            _context.SaveChanges();
            return Ok(trainingSubject);
        }
        public IActionResult Delete (int id)
        {
            //SOFT DELETE
            TrainingSubject trainingSubjects = _context.TrainingSubjects.Find(id);
            trainingSubjects.IsDeleted = true;
            _context.SaveChanges();
            return Ok(trainingSubjects);
        }
        [HttpPost]
        public IActionResult Update (TrainingSubject trainingSubject)
        {

            _context.TrainingSubjects.Update(trainingSubject);
            _context.SaveChanges();
            return Ok(trainingSubject);
        }

    }
}
