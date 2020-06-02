using PetShop.Servicos.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Servicos.Application.Services.Adapters
{
    public interface IProcedimentoService
    {
        Task<ProcedimentoViewModel> Adicionar(ProcedimentoViewModel model);
        Task<IEnumerable<ProcedimentoViewModel>> Todos();
        Task Agendar(Guid id, DateTime dataAgendamento);
        Task Cancelar(Guid id);
        Task<ProcedimentoViewModel> Procedimento(Guid id);
    }
}
