using TaskBoardAPI.Models;

namespace TaskBoardAPI.Data.Repositories.Interfaces
{
    public interface ITarefaRepositorio : IRepositorioBase<Tarefa>
    {
        Task<IEnumerable<Tarefa>> ObterComCardEResponsavelAsync();
        Task<Tarefa> ObterComCardEResponsavelPorIdAsync(int id);
    }
}
