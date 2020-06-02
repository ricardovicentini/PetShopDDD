using AutoMapper;
using MediatR;
using PetShop.Cadastros.Application.Services.Adapters;
using PetShop.Cadastros.Domain.Entities;
using PetShop.Cadastros.Domain.Enumerations;
using PetShop.Cadastros.Domain.ValueObjects;
using PetShop.Procedimento.Data.DataModels;
using PetShop.Procedimento.Data.Repository;
using PetShop.Servicos.Application.Services.Adapters;
using PetShop.Servicos.Application.ViewModels;
using PetShop.Servicos.Domain.Entities;
using PetShop.Servicos.Domain.Enumerations;
using PetShop.Servicos.Domain.Event;
using PetShop.Servicos.Domain.ValueObjects;
using PetShop.SharedKernel.Base.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Servicos.Application.Services.Ports
{
    public class ProcedimentoServices : IProcedimentoService
    {
        readonly ProcedimentoRepository _repository;
        readonly IMapper _mapper;
        readonly IFuncionarioCadastroServices _funcionarioServices;
        readonly IClienteCadastroServices _clienteServices;
        readonly IMediator _mediator;

        private async Task<Domain.Entities.Procedimento> CriarProcedimento(ProcedimentoViewModel model)
        {
            var funcionario = await _funcionarioServices.Funcionario(model.ProfissionalID);
            var cliente = await _clienteServices.Cliente(model.SolicitanteID);

            
            return new Domain.Entities.Procedimento(
                _mapper.Map<Funcionario>(funcionario),
                new TipoProcedimentoVO(model.Descricao, Enumeration.Get<EnumCategoria>(model.CategoriaID)),
                _mapper.Map<Cliente>(cliente)
                , model.Valor, model.Solicitacoes);
        }

        private async Task<Domain.Entities.Procedimento> Mapear(ProcedimentoDataModel procedimentoBD)
        {
            var funcionario = await _funcionarioServices.Funcionario(procedimentoBD.ProfissionalID);
            var cliente = await _clienteServices.Cliente(procedimentoBD.SolicitanteID);

            return new Domain.Entities.Procedimento(
                   _mapper.Map<Funcionario>(funcionario),
                    new TipoProcedimentoVO(procedimentoBD.Descricao,
                        Enumeration.Get<EnumCategoria>(procedimentoBD.CategoriaID)
                    ),
                    _mapper.Map<Cliente>(cliente),
                    procedimentoBD.Valor,
                    procedimentoBD.Solicitacoes.Split(',')
                );
        }

        public ProcedimentoServices(ProcedimentoRepository repository, IMapper mapper, 
            IFuncionarioCadastroServices funcionarioServices, IClienteCadastroServices clienteServices,
            IMediator mediator)
        {
            _repository = repository;
            _mapper = mapper;
            _funcionarioServices = funcionarioServices;
            _clienteServices = clienteServices;
            _mediator = mediator;
        }

        public async Task<ProcedimentoViewModel> Adicionar(ProcedimentoViewModel model)
        {

            var procedimento = await CriarProcedimento(model);
            var dbProcedimento = _mapper.Map<ProcedimentoDataModel>(procedimento);
            await _repository.Adicionar(dbProcedimento);
            await _repository.UnityOfWork.Commit();
            return _mapper.Map<ProcedimentoViewModel>(dbProcedimento);
        }

        public async Task Agendar(Guid id, DateTime dataAgendamento)
        {
            var procedimentoBD = _repository.Todos(x => x.ID == id).Result.Single();

            var procedimento = await Mapear(procedimentoBD);

            procedimento.Agendar(dataAgendamento);

            procedimentoBD.Data = dataAgendamento;
            _repository.Atualizar(procedimentoBD);
            await _repository.UnityOfWork.Commit();
            await _mediator.Publish(new ProcedimentoAgendadoEvent(procedimento));

            
            

            

                

        }

        public Task Cancelar(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProcedimentoViewModel>> Todos()
        {
            var procedimentos = await _repository.Todos();
            return _mapper.Map<IEnumerable<ProcedimentoViewModel>>(procedimentos);
        }

        public async Task<ProcedimentoViewModel> Procedimento(Guid id)
        {
            var procedimentoBD = await _repository.Todos(x => x.ID == id);
            return _mapper.Map<ProcedimentoViewModel>(procedimentoBD.Single());
        }
    }
}
