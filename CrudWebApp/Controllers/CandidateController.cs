using CrudWebApp.Data;
using CrudWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudWebApp.Controllers
{
    public class CandidateController : Controller
    {
        private readonly CrudDbContext _db;

        public CandidateController(CrudDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<CandidatesLi> objCandidateList = _db.CandidateInfo;
            return View(objCandidateList);
        }

        //GET

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }
        //POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CandidatesLi obj)
        {
            if(ModelState.IsValid)
            {
                _db.CandidateInfo.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }


    }
}
