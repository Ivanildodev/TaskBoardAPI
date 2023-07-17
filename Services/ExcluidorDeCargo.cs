using TaskBoardAPI.Data.Repositories.Interfaces;
using TaskBoardAPI.Services.Interfaces;

namespace TaskBoardAPI.Services
{
    public class ExcluidorDeCargo : IExcluidorDeCargo
    {
        private readonly ICargoRepositorio _cargoRepositorio;

        public ExcluidorDeCargo(ICargoRepositorio cargoRepositorio)
        {
            _cargoRepositorio = cargoRepositorio;
        }

        public async Task Excluir(int id)
        {
            var cargo = await _cargoRepositorio.ObterPorIdAsync(id);

            if(cargo != null)
                await _cargoRepositorio.DeleteAsync(id);
        }
    }
}
