using PetShop.Cadastros.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Cadastros.Application.Services.Adapters
{
    public interface IClienteCadastroServices
    {
        Task<ClienteViewModel> Adicionar(ClienteViewModel funcionario);
        void Remover(Guid idCliente);
        Task<IEnumerable<ClienteViewModel>> ListarClientes();
        Task<ClienteViewModel> Cliente(Guid id);
    }
}
