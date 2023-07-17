using TaskBoardAPI.Data.Repositories.Interfaces;
using TaskBoardAPI.Models;

namespace TaskBoardAPI.Data.Repositories
{
    public class CardRepositorio : RepositorioBase<Card>, ICardRepositorio
    {
        public CardRepositorio(Contexto contexto) : base(contexto)
        {
        }
    }
}
