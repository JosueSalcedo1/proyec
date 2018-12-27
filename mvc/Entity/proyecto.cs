namespace mvc.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("proyecto")]
    public partial class proyecto
    {
        [Key]
        [Column("proyecto")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int proyecto1 { get; set; }

        [StringLength(10)]
        public string nombreProyecto { get; set; }

        public int? cantidad { get; set; }

        public virtual clientes clientes { get; set; }

        public virtual tickets tickets { get; set; }
    }
}
