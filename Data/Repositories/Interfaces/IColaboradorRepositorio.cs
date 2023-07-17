using TaskBoardAPI.Models;

namespace TaskBoardAPI.Data.Repositories.Interfaces
{
    public interface IColaboradorRepositorio : IRepositorioBase<Colaborador>
    {
        Task<IEnumerable<Colaborador>> ObterComCargoAsync();
    }
}
