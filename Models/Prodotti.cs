namespace Pizzeria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prodotti")]
    public partial class Prodotti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prodotti()
        {
            DettaglioOrdine = new HashSet<DettaglioOrdine>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public decimal Prezzo { get; set; }

        [Required]
        [StringLength(500)]
        public string Ingredienti { get; set; }

        [StringLength(500)]
        public string Foto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DettaglioOrdine> DettaglioOrdine { get; set; }
    }
}
