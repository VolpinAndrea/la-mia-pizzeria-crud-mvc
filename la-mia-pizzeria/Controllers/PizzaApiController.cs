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
        public IActionResult Get()
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                List<Pizza> pizze = db.Pizze.Include(pizza => pizza.Id).ToList<Pizza>();

                return Ok(pizze);
            }
        }
    }
}
