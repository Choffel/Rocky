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


        //GET
        public IActionResult Create()
        { 
            return View();
        }

        //POST - Получение
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj) // Получаем обьект который нужно добваить в бд
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
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _Db.Category.Find(id); // Поиск конкретного айди для изменения

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }


        //Post - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _Db.Update(obj); //Обновляем категорию при изменении
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
            var obj = _Db.Category.Find(id); // Поиск конкретного айди для изменения

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
            if(obj == null)
            {
               return NotFound();
            }  
                _Db.Remove(obj); //Обновляем категорию при изменении
                _Db.SaveChanges();
                return RedirectToAction("Index");
            
            return View(obj);
        }

    }
}
