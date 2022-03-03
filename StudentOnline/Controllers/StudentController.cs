using Microsoft.AspNetCore.Mvc;
using StudentOnline.Data;
using StudentOnline.Models;

namespace StudentOnline.Controllers
{
    public class StudentController : Controller
    {
        private readonly DatabaseDbContext _db;
        public StudentController(DatabaseDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string SearchText = "")
        {
            List<Student> objList;
            if (SearchText != "" && SearchText !=null)
            {
                objList = _db.students.Where(p => p.Student_Name.Contains(SearchText)).ToList();
            }
            if(SearchText != "" && SearchText != null)
            {
                objList = _db.students.Where(p => p.Student_Department.Contains(SearchText)).ToList();
            }
            else
            objList = _db.students.ToList();
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.students.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? student_Id)
        {
            if (student_Id == null || student_Id == 0)
            {
                return NotFound();
            }
            var studentDb = _db.students.Find(student_Id);
            if (studentDb == null)
            {
                return NotFound();
            }
            return View(studentDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.students.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var studentDb = _db.students.Find(id);
            if (studentDb == null)
            {
                return NotFound();
            }
            return View(studentDb);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.students.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
