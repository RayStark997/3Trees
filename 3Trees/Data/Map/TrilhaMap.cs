using ThreeTrees.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ThreeTrees.Data.Map
{
    public class TrilhaMap : IEntityTypeConfiguration<TrilhaModel>
    {
        public void Configure(EntityTypeBuilder<TrilhaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Coordenada).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Descricao).HasMaxLength(255);
            builder.Property(x => x.Cidade).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CaminhoImagem).IsRequired().HasMaxLength(255);
        }
    }
}
