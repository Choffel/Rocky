using Microsoft.AspNetCore.Mvc;
using RockyTwo.Data;
using RockyTwo.Models;
using Microsoft.EntityFrameworkCore;

namespace RockyTwo.Controllers
{
    public class ProductController: Controller
    {
        private readonly ApplicationDbContext _Db;

        public ProductController(ApplicationDbContext db)
        {
            _Db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Product> objlist = _Db.Products.ToList(); 

            foreach (var obj in objlist)
            {
                obj.Category = _Db.Category.FirstOrDefault(x => x.Id == obj.CategoryId);
            }

          
            return View(objlist);
        }


       
        public IActionResult UpSert(int? id)
        {
            Product product = new Product();

            if (id == null) 
            {
                return View(product);
            }
            else
            {
                product  = _Db.Products.Find(id);
            }
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
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
            
            if (id is null || id == 0)
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
            if (obj == null)
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
