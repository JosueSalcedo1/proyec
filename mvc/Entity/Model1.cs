namespace mvc.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<clientes> clientes { get; set; }
        public virtual DbSet<precios> precios { get; set; }
        public virtual DbSet<proyecto> proyecto { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tickets> tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<clientes>()
                .Property(e => e.nombreCliente)
                .IsFixedLength();

            modelBuilder.Entity<clientes>()
                .HasMany(e => e.proyecto)
                .WithOptional(e => e.clientes)
                .HasForeignKey(e => e.cantidad);

            modelBuilder.Entity<precios>()
                .Property(e => e.valor_total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<precios>()
                .HasMany(e => e.tickets)
                .WithOptional(e => e.precios)
                .HasForeignKey(e => e.Soporte);

            modelBuilder.Entity<precios>()
                .HasMany(e => e.tickets1)
                .WithOptional(e => e.precios1)
                .HasForeignKey(e => e.Requerimiento);

            modelBuilder.Entity<precios>()
                .HasMany(e => e.tickets2)
                .WithOptional(e => e.precios2)
                .HasForeignKey(e => e.Incidencias);

            modelBuilder.Entity<proyecto>()
                .Property(e => e.nombreProyecto)
                .IsFixedLength();

            modelBuilder.Entity<tickets>()
                .HasMany(e => e.proyecto)
                .WithOptional(e => e.tickets)
                .HasForeignKey(e => e.cantidad);
        }
    }
}
