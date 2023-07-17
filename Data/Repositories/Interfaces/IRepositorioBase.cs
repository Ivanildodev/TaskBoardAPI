using TaskBoardAPI.Models;

namespace TaskBoardAPI.Data.Repositories.Interfaces
{
    public interface IRepositorioBase<TEntity>
    {
        Task<TEntity> AdicionarAsync(TEntity objeto);
        Task<TEntity?> AtualizarAsync(int id, TEntity entity);
        Task<TEntity?> ObterPorIdAsync(int id);
        Task<TEntity[]> ObterAsync();
        Task<bool> DeleteAsync(int id);
    }
}
