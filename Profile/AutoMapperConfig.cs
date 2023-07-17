using AutoMapper;
using TaskBoardAPI.DTOs;
using TaskBoardAPI.Models;

namespace TaskBoardAPI.Profile
{
    public static class AutoMapperConfig
    {
        public static IMapper Configure()
        {
            var configuracao = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Colaborador, ColaboradorDto>()
                    .ForMember(x => x.Id, o => o.MapFrom(y => y.Id))
                    .ForMember(x => x.Nome, o => o.MapFrom(y => y.Nome))
                    .ForMember(x => x.Telefone, o => o.MapFrom(y => y.Telefone))
                    .ForMember(x => x.CargoId, o => o.MapFrom(y => y.CargoId))
                    .ForMember(x => x.Situacao, o => o.MapFrom(y => y.Situacao))
                    .ForMember(x => x.Linkedin, o => o.MapFrom(y => y.Linkedin));

                cfg.CreateMap<Cargo, CargoDto>()
                    .ForMember(x => x.Id, o => o.MapFrom(y => y.Id))
                    .ForMember(x => x.Nome, o => o.MapFrom(y => y.Nome))
                    .ForMember(x => x.Descricao, o => o.MapFrom(y => y.Descricao))
                    .ForMember(x => x.Situacao, o => o.MapFrom(y => y.Situacao));

                cfg.CreateMap<Card, CardDto>()
                    .ForMember(x => x.Id, o => o.MapFrom(y => y.Id))
                    .ForMember(x => x.Nome, o => o.MapFrom(y => y.Nome))
                    .ForMember(x => x.Posicao, o => o.MapFrom(y => y.Posicao))
                    .ForMember(x => x.Cor, o => o.MapFrom(y => y.Cor));

                cfg.CreateMap<Tarefa, TarefaDto>()
                    .ForMember(x => x.Id, o => o.MapFrom(y => y.Id))
                    .ForMember(x => x.Nome, o => o.MapFrom(y => y.Nome))
                    .ForMember(x => x.CardId, o => o.MapFrom(y => y.CardId))
                    .ForMember(x => x.ResponsavelId, o => o.MapFrom(y => y.ResponsavelId))
                    .ForMember(x => x.Card, o => o.MapFrom(y => y.Card));
            });

            return configuracao.CreateMapper();
        }
    }
}
