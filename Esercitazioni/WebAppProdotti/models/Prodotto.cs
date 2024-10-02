using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
    public class Prodotto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Il campo Nome è obbligatorio.")]
        public string Nome { get; set; }
        public decimal Prezzo { get; set; }

        [StringLength(50, MinimumLength =3, ErrorMessage = "Il nome deve essere compreso tra 3 e 50 caratteri.")]
        public string Dettaglio { get; set; }

        public string Immagine{ get; set; }
        public int Quantita { get; set; }
        public string Categoria { get; set; }
        public List<string> Categorie { get; set;}
    }

