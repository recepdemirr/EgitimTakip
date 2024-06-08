using EgitimTakip.Data;
using EgitimTakip.Models;
using Microsoft.AspNetCore.Mvc;

namespace EgitimTakipWeb.Controllers
{
    public class UserTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            return Json(new { data = _context.UserTypes.Where(ut=>! ut.IsDeleted) });
        }
        [HttpPost]
        public IActionResult Add(AppUserType userType)
        {
            _context.UserTypes.Add(userType);
            _context.SaveChanges();
            return Ok(userType);
        }
        [HttpPost]
        public IActionResult Update (AppUserType userType)
        {
            _context.UserTypes.Update(userType);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var userType = _context.UserTypes.Find(id);
            userType.IsDeleted = true;
            _context.UserTypes.Update(userType);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IActionResult GetById(int id)
        {
            return Ok(_context.UserTypes.Find(id));
        }
    }
}
