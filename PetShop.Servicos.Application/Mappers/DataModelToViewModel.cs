using AutoMapper;
using PetShop.Procedimento.Data.DataModels;
using PetShop.Servicos.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace PetShop.Servicos.Application.Mappers
{
    public class DataModelToViewModel : Profile
    {
        public DataModelToViewModel()
        {
            CreateMap<ProcedimentoDataModel, ProcedimentoViewModel>()
                .ForMember(dst => dst.Solicitacoes,
                opt=> opt.MapFrom(src=> src.Solicitacoes.Split(',',StringSplitOptions.None).ToList()));
        }
    }
}
