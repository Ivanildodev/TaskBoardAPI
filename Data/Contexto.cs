using Microsoft.EntityFrameworkCore;
using TaskBoardAPI.Data.Mappings;

namespace TaskBoardAPI.Data
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ColaboradorMapping());
            modelBuilder.ApplyConfiguration(new CargoMapping());
            modelBuilder.ApplyConfiguration(new TarefaMapping());
            modelBuilder.ApplyConfiguration(new CardMapping());
        }
    }
}
