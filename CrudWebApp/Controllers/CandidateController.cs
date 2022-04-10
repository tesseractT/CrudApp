using CrudWebApp.Data;
using CrudWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                TempData["success"] = "Candidate added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }


        //GET

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CandidatesLiFromDb = _db.CandidateInfo.Find(id);
            //var CandidatesLiFromFirst = _db.CandidateInfo.FirstOrDefault(u=>u.Id==id);
            //var CandidatesLiFromSingle = _db.CandidateInfo.SingleOrDefault(u=>u.Id==id);

            if (CandidatesLiFromDb == null)
            {
                return NotFound();
            }
            return View(CandidatesLiFromDb);
        }
        //POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CandidatesLi obj)
        {
            if (ModelState.IsValid)
            {
                _db.CandidateInfo.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Candidate updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //GET

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CandidatesLiFromDb = _db.CandidateInfo.Find(id);
            //var CandidatesLiFromFirst = _db.CandidateInfo.FirstOrDefault(u=>u.Id==id);
            //var CandidatesLiFromSingle = _db.CandidateInfo.SingleOrDefault(u=>u.Id==id);

            if (CandidatesLiFromDb == null)
            {
                return NotFound();
            }
            return View(CandidatesLiFromDb);
        }
        //POST

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.CandidateInfo.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            
                _db.CandidateInfo.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Candidate deleted successfully";
            return RedirectToAction("Index");
            
            

        }
        
    }

}
