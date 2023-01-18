using la_mia_pizzeria.Database;
using la_mia_pizzeria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace la_mia_pizzeria.Controllers
{
    public class PizzaController : Controller
    {
       
        [HttpGet]
        public IActionResult Create()
        {
            using (PizzeriaContext db = new())
            {
                List<Categoria> listaCategorie = db.Categorie.ToList<Categoria>();

                PizzaCategoriaView modelForView = new();
                modelForView.Pizza = new();

                modelForView.Categorie = listaCategorie;
                return View("Create", modelForView);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaCategoriaView formData)
        {
            if (!ModelState.IsValid)
            {
                using (PizzeriaContext db = new PizzeriaContext())
                {
                    List<Categoria> listaCategorie = db.Categorie.ToList<Categoria>();

                    formData.Categorie = listaCategorie;
                }


                return View("Create", formData);
            }

            using (PizzeriaContext db = new PizzeriaContext())
            {
                db.Pizze.Add(formData.Pizza);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Details(int id)
        {
            using PizzeriaContext db = new PizzeriaContext();
            var PizzaTrovata = db.Pizze.Where(x => x.Id == id).Include(PizzaTrovata => PizzaTrovata.Categoria).FirstOrDefault();
            if (PizzaTrovata != null)
            {
                return View(PizzaTrovata);
            }

            return NotFound("Ia pizza con l'id cercato non esiste!");

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            using PizzeriaContext db = new();
            var pizzaUpdate = db.Pizze.Where(x => x.Id == id).FirstOrDefault();
            if (pizzaUpdate == null)
            {
                return NotFound("Pizza non presente");
            }
            else
            {
                List<Categoria> CategoriaFromDb = db.Categorie.ToList();
                PizzaCategoriaView ModelForView = new();
                ModelForView.Pizza = pizzaUpdate;
                ModelForView.Categorie = CategoriaFromDb;
                return View("Update", ModelForView);
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(PizzaCategoriaView formdata)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", formdata);
            }
            using PizzeriaContext db = new PizzeriaContext();
            Pizza? ModificaPizza = db.Pizze.Where(x => x.Id == formdata.Pizza.Id).FirstOrDefault();
            if (ModificaPizza != null)
            {
                ModificaPizza.Nome = formdata.Pizza.Nome;
                ModificaPizza.Prezzo = formdata.Pizza.Prezzo;
                ModificaPizza.Descrizione = formdata.Pizza.Descrizione;
                ModificaPizza.Immagine = formdata.Pizza.Immagine;
                ModificaPizza.CategoriaId = formdata.Pizza.CategoriaId;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza pizzaDaEliminare = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaDaEliminare != null)
                {
                    db.Pizze.Remove(pizzaDaEliminare);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return NotFound("Ia pizza da eliminare non è stata trovata!");
                }
            }
        }
    }

    
}
