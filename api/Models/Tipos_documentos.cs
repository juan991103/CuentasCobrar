namespace api.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Tipos_documentos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipos_documentos()
        {
            Transacciones = new HashSet<Transacciones>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(30)]
        public string Identificador { get; set; }

        [Key]
        [StringLength(30)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(30)]
        public string Cuenta_contable { get; set; }

        [StringLength(10)]
        public string Estado { get; set; }

        public virtual Estado Estado1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transacciones> Transacciones { get; set; }
    }
}
