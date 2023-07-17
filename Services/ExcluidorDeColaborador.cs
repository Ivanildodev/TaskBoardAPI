using TaskBoardAPI.Data.Repositories.Interfaces;
using TaskBoardAPI.Services.Interfaces;

namespace TaskBoardAPI.Services
{
    public class ExcluidorDeColaborador : IExcluidorDeColaborador
    {
        private readonly IColaboradorRepositorio _colaboradorRepositorio;

        public ExcluidorDeColaborador(IColaboradorRepositorio colaboradorRepositorio)
        {
            _colaboradorRepositorio = colaboradorRepositorio;
        }

        public async Task Excluir(int id)
        {
            var colaborador = await _colaboradorRepositorio.ObterPorIdAsync(id);

            if(colaborador != null)
                await _colaboradorRepositorio.DeleteAsync(id);
        }
    }
}
