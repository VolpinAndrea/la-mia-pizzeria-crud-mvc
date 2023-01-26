using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using la_mia_pizzeria.Database;
using la_mia_pizzeria.Models;

namespace la_mia_pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaApiController : ControllerBase
    {
        [HttpGet]

        public IActionResult Get(string? search)
        {
            using PizzeriaContext db = new PizzeriaContext();
            List<Pizza> listaPizze = new List<Pizza>();
            if (search == null || search == "")
            {
                listaPizze = db.Pizze.ToList();
                return Ok(listaPizze);
            }
            else
            {
                search = search.ToLower();
                listaPizze = db.Pizze.Where(pizzaScelta => pizzaScelta.Nome.ToLower().Contains(search)).ToList();
                return Ok(listaPizze);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (PizzeriaContext context = new PizzeriaContext())
            {
                Pizza pizza = context.Pizze.Where(pizza => pizza.Id == id).Include(pizza => pizza.Categoria).FirstOrDefault();

                if (pizza == null)
                {
                    return NotFound();
                }

                return Ok(pizza);
            }
        }
    }
}
}
