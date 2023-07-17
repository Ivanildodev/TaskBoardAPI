using TaskBoardAPI.DTOs;

namespace TaskBoardAPI.Services.Interfaces
{
    public interface IArmazenadorDeCargo
    {
        Task<CargoDto> Armazenar(CargoDto dto);
    }
}
