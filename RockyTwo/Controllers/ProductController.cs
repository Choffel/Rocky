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
            IEnumerable<Product> objlist = _Db.Products.ToList(); //Get all products

            foreach (var obj in objlist)
            {
                obj.Category = _Db.Category.FirstOrDefault(x => x.Id == obj.CategoryId);
            }

          
            return View(objlist);
        }


        //GET - UpSert
        public IActionResult UpSert(int? id)
        {
            Product product = new Product();

            if (id == null) // перебрасываем на новый продукт
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

        //GET - Edit
        public IActionResult Edit(int? id)
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


        //GET - Delete
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


        //Post - Delete
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
