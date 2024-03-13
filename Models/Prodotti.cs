using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Models
{
    public class Prodotto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Prezzo { get; set; }

        [StringLength(500)]
        public string Ingredienti { get; set; }

        [StringLength(500)]
        public string Foto { get; set; }
    }
}