using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoardAPI.Models;

namespace TaskBoardAPI.Data.Mappings
{
    public class CargoMapping : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.ToTable(nameof(Cargo));

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Nome).IsRequired().HasMaxLength(100);
            builder.Property(o => o.Descricao).IsRequired().HasMaxLength(100);
            builder.Property(o => o.Situacao).IsRequired();
        }
    }
}
