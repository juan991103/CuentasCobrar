namespace CuentasCobrar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Transacciones
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Identificador_Transacción { get; set; }

        [Required]
        [StringLength(30)]
        public string Tipo_de_Movimiento { get; set; }

        [Required]
        [StringLength(30)]
        public string Tipo_Documento { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Número_de_Documento { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(30)]
        public string Identificador_Cliente { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Monto { get; set; }

        [StringLength(10)]
        public string Estado { get; set; }
    }
}
