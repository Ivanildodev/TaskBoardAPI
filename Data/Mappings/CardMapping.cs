using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoardAPI.Models;

namespace TaskBoardAPI.Data.Mappings
{
    public class CardMapping : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable(nameof(Card));

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Posicao).IsRequired().HasDefaultValue(0);
            builder.Property(c => c.Cor).IsRequired().HasMaxLength(100);
        }
    }
}
