using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaskBoardAPI.Models;

namespace TaskBoardAPI.Data.Mappings
{
    public class ColaboradorMapping : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.ToTable(nameof(Colaborador));

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Nome).IsRequired().HasMaxLength(100);
            builder.Property(o => o.Telefone).IsRequired().HasMaxLength(11);
            builder.Property(o => o.CargoId).IsRequired();
            builder.Property(o => o.Situacao).IsRequired();
            builder.Property(o => o.Linkedin).IsRequired().HasMaxLength(100);

            builder.HasOne(o => o.Cargo)
                    .WithMany()
                    .HasForeignKey(o => o.CargoId);
        }
    }
}
