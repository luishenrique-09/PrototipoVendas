namespace PrototipoVendas.Infra.Data.Contexto
{
    using Microsoft.EntityFrameworkCore;
    using PrototipoVendas.Dominio.Entidades;
    using PrototipoVendas.Infra.Data.Mapeamentos;
    using System.Linq;

    public class VendasContexto : DbContext
    {
        public VendasContexto(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
        
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
