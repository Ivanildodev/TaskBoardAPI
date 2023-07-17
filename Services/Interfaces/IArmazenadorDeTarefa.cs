using TaskBoardAPI.DTOs;

namespace TaskBoardAPI.Services.Interfaces
{
    public interface IArmazenadorDeTarefa
    {
        Task<TarefaDto> Armazenar(TarefaDto dto);
    }
}
