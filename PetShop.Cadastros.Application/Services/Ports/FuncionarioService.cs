using AutoMapper;
using PetShop.Cadastros.Application.Services.Adapters;
using PetShop.Cadastros.Application.ViewModels;
using PetShop.Cadastros.Data.Models;
using PetShop.Cadastros.Data.Repository;
using PetShop.SharedKernel.Base.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Cadastros.Application.Services.Ports
{
    public class FuncionarioService : IFuncionarioCadastroServices
    {
        private readonly FuncionarioRepository _repository;
        private readonly IMapper _mapper;
        public FuncionarioService(FuncionarioRepository repository, IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<FuncionarioViewModel> Adicionar(FuncionarioViewModel funcionario)
        {
            //mapear a viewmodel para Entidade de Dominio (por que aqui será validada)
            var entidade = _mapper.Map<FuncionarioViewModel, Domain.Entities.Funcionario>(funcionario);

            //mapear da entdade de dominio para Entidade de persistencia
            var dataModel = _mapper.Map<Domain.Entities.Funcionario, Funcionario>(entidade);
            
            await _repository.Adicionar(dataModel);
            await _repository.UnityOfWork.Commit();
            return _mapper.Map<FuncionarioViewModel>(dataModel);
        }

        public async Task<FuncionarioViewModel> Funcionario(Guid id)
        {
            var dbFunc = await _repository.Todos(x => x.ID == id);
            return _mapper.Map<FuncionarioViewModel>(dbFunc.SingleOrDefault());
        }

        public async Task<IEnumerable<FuncionarioViewModel>> ListarFincionarios()
        {
            var funcs = await _repository.Todos();
            return _mapper.Map<IEnumerable<FuncionarioViewModel>>(funcs);

        }

        public void Remover(Guid idFuncionario)
        {
            var func = _repository.Todos(x => x.ID == idFuncionario).Result.SingleOrDefault();
            _repository.Remover(func);
            _repository.UnityOfWork.Commit();
        }
    }
}
