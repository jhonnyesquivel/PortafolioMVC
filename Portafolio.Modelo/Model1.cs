namespace Portafolio.Modelo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=PortafolioContext")
        {
        }

        public virtual DbSet<Experiencia> Experiencias { get; set; }
        public virtual DbSet<Habilidad> Habilidads { get; set; }
        public virtual DbSet<TablaDato> TablaDatoes { get; set; }
        public virtual DbSet<Testimonio> Testimonios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Experiencias)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.Usuario_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Habilidads)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.Usuario_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Testimonios)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.Usuario_id)
                .WillCascadeOnDelete(false);
        }
    }
}
