namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clientes
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Identificador { get; set; }

        [StringLength(30)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(30)]
        public string Cedula { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Limite_credito { get; set; }

        [StringLength(10)]
        public string Estado { get; set; }
    }
}
