using Microsoft.EntityFrameworkCore;
using TaskBoardAPI.Data.Repositories.Interfaces;
using TaskBoardAPI.Models;

namespace TaskBoardAPI.Data.Repositories
{
    public class ColaboradorRepositorio : RepositorioBase<Colaborador>, IColaboradorRepositorio
    {
        private readonly DbSet<Colaborador> _dbSet;

        public ColaboradorRepositorio(Contexto contexto) : base(contexto)
        {
            _dbSet = contexto.Set<Colaborador>();
        }

        public async Task<IEnumerable<Colaborador>> ObterComCargoAsync()
        {
            var resultado = await _dbSet.Include(c => c.Cargo).ToListAsync();

            return resultado;
        }
    }
}
