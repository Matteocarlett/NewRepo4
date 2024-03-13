namespace Pizzeria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ordini")]
    public partial class Ordini
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ordini()
        {
            DettaglioOrdine = new HashSet<DettaglioOrdine>();
        }

        public int Id { get; set; }

        public int IdUser { get; set; }

        public DateTime DataOra { get; set; }

        public bool StatoOrdine { get; set; }

        [Required]
        [StringLength(50)]
        public string NoteAggiuntive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DettaglioOrdine> DettaglioOrdine { get; set; }

        public virtual Users Users { get; set; }
    }
}
