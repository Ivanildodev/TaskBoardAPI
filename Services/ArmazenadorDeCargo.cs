using AutoMapper;
using TaskBoardAPI.Data.Repositories.Interfaces;
using TaskBoardAPI.DTOs;
using TaskBoardAPI.Models;
using TaskBoardAPI.Services.Interfaces;

namespace TaskBoardAPI.Services
{
    public class ArmazenadorDeCargo : IArmazenadorDeCargo
    {
        private readonly ICargoRepositorio _cargoRepositorio;
        private readonly IMapper _mapper;

        public ArmazenadorDeCargo(
            ICargoRepositorio cargoRepositorio,
            IMapper mapper)
        {
            _cargoRepositorio = cargoRepositorio;
            _mapper = mapper;
        }

        public async Task<CargoDto> Armazenar(CargoDto dto)
        {
            if (dto.Id == 0)
            {
                var cargo = new Cargo(dto.Nome, dto.Descricao, dto.Situacao);

                await _cargoRepositorio.AdicionarAsync(cargo);

                dto = _mapper.Map<CargoDto>(cargo);
            }
            else
            {
                var cargo = await _cargoRepositorio.ObterPorIdAsync(dto.Id);

                if (cargo != null)
                {
                    AtualizarCargo(cargo, dto);

                    await _cargoRepositorio.AtualizarAsync(cargo.Id, cargo);

                    dto = _mapper.Map<CargoDto>(cargo);
                }
            }

            return dto;
        }

        private static void AtualizarCargo(Cargo cargo, CargoDto dto)
        {
            cargo.Nome = dto.Nome;
            cargo.Descricao = dto.Descricao;
            cargo.Situacao = dto.Situacao;
        }
    }
}
