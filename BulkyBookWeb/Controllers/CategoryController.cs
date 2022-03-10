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
    }
}
