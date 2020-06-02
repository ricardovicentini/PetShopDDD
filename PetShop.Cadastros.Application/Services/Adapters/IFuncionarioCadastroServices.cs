using PetShop.Cadastros.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Cadastros.Application.Services.Adapters
{
    public interface IFuncionarioCadastroServices
    {
        Task<FuncionarioViewModel> Adicionar(FuncionarioViewModel funcionario);
        void Remover(Guid idFuncionario);
        Task<IEnumerable<FuncionarioViewModel>> ListarFincionarios();
        Task<FuncionarioViewModel> Funcionario(Guid id);
    }
}
