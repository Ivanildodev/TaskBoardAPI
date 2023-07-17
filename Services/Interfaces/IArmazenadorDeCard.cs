using TaskBoardAPI.DTOs;

namespace TaskBoardAPI.Services.Interfaces
{
    public interface IArmazenadorDeCard
    {
        Task<CardDto> Armazenar(CardDto dto);
    }
}
