using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoardAPI.Models;

namespace TaskBoardAPI.Data.Mappings
{
    public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable(nameof(Tarefa));

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Nome).IsRequired().HasMaxLength(100);
            builder.Property(o => o.CardId).IsRequired();
            builder.Property(o => o.ResponsavelId).IsRequired();


            builder.HasOne(o => o.Card)
                    .WithMany()
                    .HasForeignKey(o => o.CardId);
            builder.HasOne(o => o.Responsavel)
                    .WithMany()
                    .HasForeignKey(o => o.ResponsavelId);
        }
    }
}
