using MediatR;
using PetShop.Procedimento.EmailProviderMok;
using PetShop.Servicos.Domain.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PetShop.Servicos.Application.EventHandlers
{
    class EnviarEmail_ProcedimentoAgendadoEventHandler : INotificationHandler<ProcedimentoAgendadoEvent>
    {
        private readonly IEmailProvider _email;

        public EnviarEmail_ProcedimentoAgendadoEventHandler(IEmailProvider email)
        {
            _email = email;
        }

        public async Task Handle(ProcedimentoAgendadoEvent notification, CancellationToken cancellationToken)
        {
            var email = notification.Procedimento.Solicitante.Email.EnderecoCompleto;
            var nomeCleinte = notification.Procedimento.Solicitante.Nome;
            var servico = notification.Procedimento.TipoProcedimento.Descricao;
            var dataAgendamento = notification.Procedimento.Data;
            var htmlMensagem = $"Prezado(a), {nomeCleinte}.<br/> Seu agendamento para o servico {servico}," +
                $"foi realizado com sucesso.<br/>Compareça em nossa loja em {dataAgendamento}.<br/>" +
                $"Atenciosamente,<br/>";
            await _email.Send(email, htmlMensagem);
        }
    }
}
