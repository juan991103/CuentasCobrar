namespace CuentasCobrar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Clientes
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Identificador { get; set; }

        [StringLength(30)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{7})[-. ]?([0-9]{1})$", ErrorMessage = "Cedula no valida")]
        [DisplayFormat(DataFormatString = "{0:###-#######-#}", ApplyFormatInEditMode = false)]
        public string Cedula { get; set; }

        [Column(TypeName = "numeric")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:RD$#,##}", ApplyFormatInEditMode = false)]
        public decimal? Limite_credito { get; set; }

        [StringLength(10)]
        public string Estado { get; set; }
    }
}
