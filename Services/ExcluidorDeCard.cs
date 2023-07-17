using TaskBoardAPI.Data.Repositories.Interfaces;
using TaskBoardAPI.Services.Interfaces;

namespace TaskBoardAPI.Services
{
    public class ExcluidorDeCard : IExcluidorDeCard
    {
        private readonly ICardRepositorio _cardRepositorio;

        public ExcluidorDeCard(ICardRepositorio cardRepositorio)
        {
            _cardRepositorio = cardRepositorio;
        }

        public async Task Excluir(int id)
        {
            var card = await _cardRepositorio.ObterPorIdAsync(id);

            if(card != null)
               await _cardRepositorio.DeleteAsync(id);
        }
    }
}
