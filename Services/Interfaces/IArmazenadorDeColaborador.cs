using TaskBoardAPI.DTOs;

namespace TaskBoardAPI.Services.Interfaces
{
    public interface IArmazenadorDeColaborador
    {
        Task<ColaboradorDto> Armazenar(ColaboradorDto dto);
    }
}
