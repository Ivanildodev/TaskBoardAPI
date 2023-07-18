using Microsoft.EntityFrameworkCore;
using TaskBoardAPI.Data.Repositories.Interfaces;
using TaskBoardAPI.Models;

namespace TaskBoardAPI.Data.Repositories
{
    public class TarefaRepositorio : RepositorioBase<Tarefa>, ITarefaRepositorio
    {
        private readonly DbSet<Tarefa> _dbSet;

        public TarefaRepositorio(Contexto contexto) : base(contexto)
        {
            _dbSet = contexto.Set<Tarefa>();
        }

        public async Task<IEnumerable<Tarefa>> ObterComCardEResponsavelAsync()
        {
            var resultado = await _dbSet
                                    .Include(t => t.Card)
                                    .Include(t => t.Responsavel)
                                    .ToListAsync();

            return resultado;
        }

        public async Task<Tarefa> ObterComCardEResponsavelPorIdAsync(int id)
        {
            var resultado = await _dbSet.Include(c => c.Card).Include(c => c.Responsavel).FirstOrDefaultAsync(c => c.Id == id);

            return resultado;
        }
    }
}
