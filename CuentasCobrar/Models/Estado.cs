namespace CuentasCobrar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Estado")]
    public partial class Estado
    {
        public int ID { get; set; }

        [Required]
        [StringLength(10)]
        public string Descripcion { get; set; }
    }
}
