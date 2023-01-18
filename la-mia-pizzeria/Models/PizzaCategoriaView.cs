namespace la_mia_pizzeria.Models
{
    public class PizzaCategoriaView
    {
        //la pizza vuota che il mio form dovrà compilare
        public Pizza Pizza { get; set; }

        //Questa lista di categorie servirà per la select
        public List<Categoria>? Categorie { get; set; }
    }
}
