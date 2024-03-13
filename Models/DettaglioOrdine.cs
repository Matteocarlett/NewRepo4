namespace Pizzeria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DettaglioOrdine")]
    public partial class DettaglioOrdine
    {
        public int Id { get; set; }

        public int IdOrdini { get; set; }

        public int IdProdotti { get; set; }

        public int Quantità { get; set; }

        public virtual Ordini Ordini { get; set; }

        public virtual Prodotti Prodotti { get; set; }
    }
}
