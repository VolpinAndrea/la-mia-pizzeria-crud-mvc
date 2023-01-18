using la_mia_pizzeria.Database;
using la_mia_pizzeria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace la_mia_pizzeria.Controllers
{
    public class HomeController : Controller
    {
   
        //passo il model delle categorie DB
        public IActionResult Index()
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                List<Categoria> listacategorie = db.Categorie.Include(categoria => categoria.Pizze).ToList<Categoria>();

                return View("Index", listacategorie);
            }
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}