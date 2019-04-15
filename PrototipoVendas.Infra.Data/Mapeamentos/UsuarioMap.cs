namespace PrototipoVendas.Infra.Data.Mapeamentos
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PrototipoVendas.Dominio.Entidades;

    internal class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(k => k.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(u => u.Email).HasMaxLength(100).IsRequired();
            builder.Property(u => u.Senha).HasMaxLength(20).IsRequired();
            builder.Property(u => u.Nome).HasMaxLength(150).IsRequired();
        }
    }
}
