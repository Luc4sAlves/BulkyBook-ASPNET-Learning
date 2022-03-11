using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //Pegando os elementos do database, passando pra uma lista e alocando em uma variavel
            //Podia retirar o .ToList quando mudei o var pra IEnumerable
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();

            //Passando essa var pra View, vamos recebê-la no index.cshtml como um @model
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj) 
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                //Colocando como name ali no primeiro argumento, ele mostra o erro no campo name no form
                //Colocando CustomError, ele mostra lá em cima, como foi definido no create html
                ModelState.AddModelError("name", "The name and display order can't be the same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id.Value == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id.Value);
            //Podia usar firstordefault ou singleordefault ao inves de find

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                //Colocando como name ali no primeiro argumento, ele mostra o erro no campo name no form
                //Colocando CustomError, ele mostra lá em cima, como foi definido no create html
                ModelState.AddModelError("name", "The name and display order can't be the same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }



}
