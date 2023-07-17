using AutoMapper;
using TaskBoardAPI.Data.Repositories.Interfaces;
using TaskBoardAPI.DTOs;
using TaskBoardAPI.Models;
using TaskBoardAPI.Services.Interfaces;

namespace TaskBoardAPI.Services
{
    public class ArmazenadorDeCard : IArmazenadorDeCard
    {
        private readonly ICardRepositorio _cardRepositorio;
        private readonly IMapper _mapper;

        public ArmazenadorDeCard(
            ICardRepositorio cardRepositorio,
            IMapper mapper)
        {
            _cardRepositorio = cardRepositorio;
            _mapper = mapper;
        }

        public async Task<CardDto> Armazenar(CardDto dto)
        {
            if (dto.Id == 0)
            {
                var card = new Card(dto.Nome, dto.Posicao, dto.Cor);

                await _cardRepositorio.AdicionarAsync(card);

                dto = _mapper.Map<CardDto>(card);
            }
            else
            {
                var card = await _cardRepositorio.ObterPorIdAsync(dto.Id);

                if (card != null)
                {
                    AtualizarCard(card, dto);

                    await _cardRepositorio.AtualizarAsync(card.Id, card);

                    dto = _mapper.Map<CardDto>(card);
                }
            }

            return dto;
        }

        private static void AtualizarCard(Card card, CardDto dto)
        {
            card.Nome = dto.Nome;
            card.Posicao = dto.Posicao;
            card.Cor = dto.Cor;
        }
    }
}
