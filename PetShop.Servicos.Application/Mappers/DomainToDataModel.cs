using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
using PetShop.Procedimento.Data.DataModels;

namespace PetShop.Servicos.Application.Mappers
{
    public class DomainToDataModel : Profile
    {
        public DomainToDataModel()
        {
            CreateMap<Domain.Entities.Procedimento, ProcedimentoDataModel>()
                .ForPath(dst => dst.ProfissionalID, opt => opt.MapFrom(src => src.Profissional.Id))
                .ForMember(dst => dst.CategoriaID, opt => opt.MapFrom(src => src.TipoProcedimento.Categoria.Value))
                .ForMember(dst => dst.Descricao, opt => opt.MapFrom(src => src.TipoProcedimento.Descricao))
                .ForMember(dst => dst.SolicitanteID, opt => opt.MapFrom(src => src.Solicitante.Id))
                .ForMember(dst => dst.Data, opt => opt.MapFrom(src => src.Data))
                .ForMember(dst => dst.Valor, opt => opt.MapFrom(src => src.Valor))
                .ForMember(dst => dst.Solicitacoes, opt => opt.MapFrom(src => string.Join(',', src.Solicitacoes)))
                .ForMember(dst => dst.SituacaoID, opt => opt.MapFrom(src => src.Situacao.Value))
                .ForMember(dst => dst.ID, opt=> opt.MapFrom(src=> src.Id));


        }
    }
}
