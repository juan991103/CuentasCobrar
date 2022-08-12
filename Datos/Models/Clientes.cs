namespace api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clientes()
        {
            Transacciones = new HashSet<Transacciones>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [StringLength(30)]
        public string Identificador { get; set; }

        [StringLength(30)]
        public string Nombre { get; set; }

        public int Cedula { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Limite_credito { get; set; }

        [StringLength(10)]
        public string Estado { get; set; }

        public virtual Estado Estado1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transacciones> Transacciones { get; set; }
    }
}
