namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tipos_documentos
    {
        public int ID { get; set; }

        [StringLength(30)]
        public string Identificador { get; set; }

        [Required]
        [StringLength(30)]
        public string Descripcion { get; set; }

        public decimal Cuenta_contable { get; set; }

        [StringLength(10)]
        public string Estado { get; set; }
    }
}
