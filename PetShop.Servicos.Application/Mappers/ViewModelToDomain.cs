using AutoMapper;
using PetShop.Cadastros.Application.ViewModels;
using PetShop.Cadastros.Domain.Entities;
using PetShop.Cadastros.Domain.Enumerations;
using PetShop.Cadastros.Domain.ValueObjects;
using PetShop.SharedKernel.Base.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Servicos.Application.Mappers
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            CreateMap<FuncionarioViewModel, Funcionario>()
                .ForPath(dst => dst.Nome.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForPath(dst => dst.Nome.Sobrenome, opt => opt.MapFrom(src => src.Sobrenome))
                //.ForPath(dst => dst.Id, opt => opt.Ignore())
                .ConstructUsing(vm =>
                    new Funcionario(
                            new NomePessoa(vm.Nome, vm.Sobrenome),
                            vm.CPF
                    )
                );

            CreateMap<ClienteViewModel, Cliente>()
                //.ForPath(dst => dst.Id, opt => opt.Ignore())
                .ForPath(dst => dst.Nome.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForPath(dst => dst.Nome.Sobrenome, opt => opt.MapFrom(src => src.SobreNome))
                .ForPath(dst => dst.Telefone.DDD, opt => opt.MapFrom(src => src.DDD))
                .ForPath(dst => dst.Telefone.TipoTelefone.Value, opt => opt.MapFrom(src => src.TipoTelefone))
                .ForPath(dst => dst.Telefone.Numero, opt => opt.MapFrom(src => src.NumeroTelefone))
                .ForPath(dst => dst.Email.EnderecoCompleto, opt => opt.MapFrom(src => src.Email))
                .ConstructUsing(vm =>
                    new Cliente(
                        new NomePessoa(vm.Nome, vm.SobreNome),
                        vm.CPF,
                        new Telefone(vm.DDD, Enumeration.Get<EnumTipoTelefone>(vm.TipoTelefone), vm.NumeroTelefone),
                        new Email(vm.Email)
                    )
                );

        }
    }
}
