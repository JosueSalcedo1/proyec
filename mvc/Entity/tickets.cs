namespace mvc.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tickets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tickets()
        {
            proyecto = new HashSet<proyecto>();
        }

        [Key]
        [Column("tickets")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int tickets1 { get; set; }

        public int? Incidencias { get; set; }

        public int? Requerimiento { get; set; }

        public int? Soporte { get; set; }

        public virtual precios precios { get; set; }

        public virtual precios precios1 { get; set; }

        public virtual precios precios2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<proyecto> proyecto { get; set; }
    }
}
