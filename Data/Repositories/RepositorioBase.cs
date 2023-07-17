using Microsoft.EntityFrameworkCore;
using TaskBoardAPI.Data.Repositories.Interfaces;

namespace TaskBoardAPI.Data.Repositories
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class
    {
        private readonly Contexto _contexto;
        private readonly DbSet<TEntity> _dbSet;

        public RepositorioBase(Contexto contexto)
        {
            _contexto = contexto;
            _dbSet = contexto.Set<TEntity>();
        }

        public async Task<TEntity> AdicionarAsync(TEntity objeto)
        {
            await _dbSet.AddAsync(objeto);
            await _contexto.SaveChangesAsync();

            return objeto;
        }

        public async Task<TEntity?> AtualizarAsync(int id, TEntity objeto)
        {
            var entidadeExistente = await _dbSet.FindAsync(id);
            if (entidadeExistente != null)
            {
                _contexto.Entry(entidadeExistente).CurrentValues.SetValues(objeto);
                await _contexto.SaveChangesAsync();
            }

            return entidadeExistente;
        }

        public async Task<TEntity?> ObterPorIdAsync(int id)
        {
            var objeto = await _dbSet.FindAsync(id);

            return objeto;
        }

        public async Task<TEntity[]> ObterAsync()
        {
            var resultado = await _dbSet.ToArrayAsync();

            return resultado;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var objeto = await _dbSet.FindAsync(id);

            if (objeto != null)
            {
                _dbSet.Remove(objeto);
                await _contexto.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
