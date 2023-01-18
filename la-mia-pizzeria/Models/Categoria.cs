namespace la_mia_pizzeria.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public List<Pizza> Pizze { get; set; }

        public Categoria() { }
    }
}
