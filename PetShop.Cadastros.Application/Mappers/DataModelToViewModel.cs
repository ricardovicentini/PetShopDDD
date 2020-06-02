using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using PetShop.Cadastros.Application.ViewModels;
using PetShop.Cadastros.Data.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PetShop.Cadastros.Application.Mappers
{
    public class DataModelToViewModel : Profile
    {
        public DataModelToViewModel()
        {
            CreateMap<Funcionario, FuncionarioViewModel>();
            CreateMap<Cliente, ClienteViewModel>();
        }
    }
}
