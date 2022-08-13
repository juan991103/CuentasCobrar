namespace CuentasCobrar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Asientos_Contables
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Identificador_Asiento { get; set; }

        [Required]
        [StringLength(30)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(30)]
        public string Identificador_Cliente { get; set; }

        public int Cuenta { get; set; }

        [Required]
        [StringLength(30)]
        public string Tipo_de_Movimiento { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? Fecha_Asiento { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:RD$#,##}", ApplyFormatInEditMode = false)]
        public decimal? Monto_Asiento { get; set; }

        [StringLength(10)]
        public string Estado { get; set; }

        public int Id_registro { get; set; }
    }
}
