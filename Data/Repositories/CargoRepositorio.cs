using TaskBoardAPI.Data.Repositories.Interfaces;
using TaskBoardAPI.Models;

namespace TaskBoardAPI.Data.Repositories
{
    public class CargoRepositorio : RepositorioBase<Cargo>, ICargoRepositorio
    {
        public CargoRepositorio(Contexto contexto) : base(contexto)
        {
        }
    }
}
