using la_mia_pizzeria.CustomValidation;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace la_mia_pizzeria.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        public string Nome { get; set; }
        public string? Descrizione { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [Url(ErrorMessage = "Hai inserito un link non valido")]
        [ImageUrlValidation] 
        public string Immagine { get; set; }

        [Required(ErrorMessage = "Questo campo è obbligatorio")]
        [PriceValidation]
        [StringLength(25)]
        public string Prezzo { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        public Pizza() 
        { 
        }

        public Pizza(string nome, string descrizione, string immagine, string prezzo)
        {

            Nome = Nome;
            Descrizione = descrizione;
            Immagine = Immagine;
            Prezzo = prezzo;
        }


    }
}
