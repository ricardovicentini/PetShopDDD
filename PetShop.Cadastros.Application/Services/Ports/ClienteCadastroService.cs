using AutoMapper;
using PetShop.Cadastros.Application.Services.Adapters;
using PetShop.Cadastros.Application.ViewModels;
using PetShop.Cadastros.Data.Repository;
using PetShop.Cadastros.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Cadastros.Application.Services.Ports
{
    public class ClienteCadastroService : IClienteCadastroServices
    {
        private readonly ClienteRepository _repository;
        private readonly IMapper _mapper;

        public ClienteCadastroService(ClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClienteViewModel> Adicionar(ClienteViewModel cliente)
        {
            var entity = _mapper.Map<Cliente>(cliente);
            var dm = _mapper.Map<Data.Models.Cliente>(entity);
            await _repository.Adicionar(dm);
            await _repository.UnityOfWork.Commit();
            return _mapper.Map<ClienteViewModel>(dm);
        }

        public async Task<ClienteViewModel> Cliente(Guid id)
        {
            var dbcliente = await _repository.Todos(x => x.ID == id);
            return _mapper.Map<ClienteViewModel>(dbcliente.SingleOrDefault());
        }

        public async Task<IEnumerable<ClienteViewModel>> ListarClientes()
        {
            var clientes = await _repository.Todos(noTracking: true);
            return _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);
        }

        public void Remover(Guid idCliente)
        {
            var entidade = _repository.Todos(x => x.ID == idCliente).Result.SingleOrDefault();
            var dm = _mapper.Map<Data.Models.Cliente>(entidade);
            _repository.Remover(dm);
            _repository.UnityOfWork.Commit();
        }
    }
}
