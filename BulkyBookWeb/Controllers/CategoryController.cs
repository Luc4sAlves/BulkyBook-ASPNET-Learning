using BulkyBookWeb.Data;
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
            var objCategoryList = _db.Categories.ToList(); 
            return View();
        }
    }
}
