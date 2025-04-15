using Microsoft.AspNetCore.Mvc;
using RockyTwo.Data;
using RockyTwo.Models;
using Microsoft.EntityFrameworkCore;

namespace RockyTwo.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _Db;

        public CategoryController(ApplicationDbContext db)
        {
            _Db = db;       
        }


        public IActionResult Index()
        {
            IEnumerable<Category> objlist = _Db.Category.ToList();

          
            return View(objlist);
        }


       
        public IActionResult Create()
        { 
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj) 
        {
            if (ModelState.IsValid)
            {
                _Db.Add(obj);
                _Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        
        public IActionResult Edit(int? id)
        {
            //проверка
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _Db.Category.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }


       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _Db.Update(obj); 
                _Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


       
        public IActionResult Delete(int? id)
        {
            //проверка
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _Db.Category.Find(id); 

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _Db.Category.Find(id);
            if(obj == null)
            {
               return NotFound();
            }  
                _Db.Remove(obj); 
                _Db.SaveChanges();
                return RedirectToAction("Index");
            
            return View(obj);
        }

    }
}
