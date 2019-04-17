namespace PrototipoVendas.Infra.Data.Mapeamentos
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PrototipoVendas.Dominio.Entidades;

    internal class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(k => k.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(u => u.Nome).HasMaxLength(250).IsRequired();
            builder.Property(u => u.Descricao).HasMaxLength(500).IsRequired();
            builder.Property(u => u.Preco).IsRequired();
            builder.Property(u => u.Foto).IsRequired();
        }
    }
}
