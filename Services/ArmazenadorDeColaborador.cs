using AutoMapper;
using TaskBoardAPI.Data.Repositories.Interfaces;
using TaskBoardAPI.DTOs;
using TaskBoardAPI.Models;
using TaskBoardAPI.Services.Interfaces;

namespace TaskBoardAPI.Services
{
    public class ArmazenadorDeColaborador : IArmazenadorDeColaborador
    {
        private readonly IColaboradorRepositorio _colaboradorRepositorio;
        private readonly IMapper _mapper;

        public ArmazenadorDeColaborador(
            IColaboradorRepositorio colaboradorRepositorio,
            IMapper mapper)
        {
            _colaboradorRepositorio = colaboradorRepositorio;
            _mapper = mapper;
        }

        public async Task<ColaboradorDto> Armazenar(ColaboradorDto dto)
        {
            if (dto.Id == 0)
            {
                var colaborador = new Colaborador(dto.Id, dto.Nome, dto.Telefone, dto.CargoId, dto.Situacao, dto.Linkedin);
               
                await _colaboradorRepositorio.AdicionarAsync(colaborador);

                dto = _mapper.Map<ColaboradorDto>(colaborador);
            }
            else
            {
                var colaborador = await _colaboradorRepositorio.ObterPorIdAsync(dto.Id);

                if (colaborador != null)
                {
                    AtualizarColaborador(colaborador, dto);

                    await _colaboradorRepositorio.AtualizarAsync(colaborador.Id, colaborador);

                    dto = _mapper.Map<ColaboradorDto>(colaborador);
                }
            }
        
            return dto;
        }

        private static void AtualizarColaborador(Colaborador colaborador, ColaboradorDto dto)
        {
            colaborador.Nome = dto.Nome;
            colaborador.Telefone = dto.Telefone;
            colaborador.CargoId = dto.CargoId;
            colaborador.Situacao = dto.Situacao;
            colaborador.Linkedin = dto.Linkedin;
        }
    }
}
