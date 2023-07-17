using AutoMapper;
using TaskBoardAPI.Data.Repositories.Interfaces;
using TaskBoardAPI.DTOs;
using TaskBoardAPI.Models;
using TaskBoardAPI.Services.Interfaces;

namespace TaskBoardAPI.Services
{
    public class ArmazenadorDeTarefa : IArmazenadorDeTarefa
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;
        private readonly IMapper _mapper;

        public ArmazenadorDeTarefa(
            ITarefaRepositorio tarefaRepositorio,
            IMapper mapper)
        {
            _tarefaRepositorio = tarefaRepositorio;
            _mapper = mapper;
        }

        public async Task<TarefaDto> Armazenar(TarefaDto dto)
        {
            if (dto.Id == 0)
            {
                var card = new Card(dto.Card.Nome, dto.Card.Posicao, dto.Card.Cor);
                var tarefa = new Tarefa(dto.Nome, dto.ResponsavelId, card);

                await _tarefaRepositorio.AdicionarAsync(tarefa);

                dto = _mapper.Map<TarefaDto>(tarefa);
            }
            else
            {
                var tarefa = await _tarefaRepositorio.ObterPorIdAsync(dto.Id);

                if (tarefa != null)
                {
                    AtualizarTarefa(tarefa, dto);

                    await _tarefaRepositorio.AtualizarAsync(tarefa.Id, tarefa);

                    dto = _mapper.Map<TarefaDto>(tarefa);
                }
            }

            return dto;
        }

        private static void AtualizarTarefa(Tarefa tarefa, TarefaDto dto)
        {
            tarefa.Nome = dto.Nome;
            tarefa.CardId = dto.CardId;
            tarefa.ResponsavelId = dto.ResponsavelId;
        }
    }
}
