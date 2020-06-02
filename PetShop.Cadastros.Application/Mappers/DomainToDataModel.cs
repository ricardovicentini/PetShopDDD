using AutoMapper;
using PetShop.Cadastros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Cadastros.Application.Mappers
{
    public class DomainToDataModel : Profile
    {
        public DomainToDataModel()
        {
            CreateMap<Funcionario, Data.Models.Funcionario>()
                .ForPath(tgt => tgt.Nome, opt => opt.MapFrom(src => src.Nome.Nome))
                .ForPath(tgt => tgt.SobreNome, opt => opt.MapFrom(src => src.Nome.Sobrenome));

            CreateMap<Cliente, Data.Models.Cliente>()
                .ForPath(tgt => tgt.Nome, opt => opt.MapFrom(src => src.Nome.Nome))
                .ForPath(tgt => tgt.Sobrenome, opt => opt.MapFrom(src => src.Nome.Sobrenome))
                .ForPath(tgt => tgt.DDD, opt => opt.MapFrom(src => src.Telefone.DDD))
                .ForPath(tgt => tgt.TipoTelefone, opt => opt.MapFrom(src => src.Telefone.TipoTelefone.Value))
                .ForPath(tgt => tgt.NumeroTelefone, opt => opt.MapFrom(src => src.Telefone.Numero))
                .ForPath(tgt => tgt.Email, opt => opt.MapFrom(src => src.Email.EnderecoCompleto));
        }
    }
}
