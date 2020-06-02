using MediatR;
using PetShop.Servicos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Servicos.Domain.Event
{
    public class ProcedimentoAgendadoEvent : INotification
    {

        public Procedimento Procedimento { get; }
        
        public ProcedimentoAgendadoEvent(Procedimento procedimento)
        {
            this.Procedimento = procedimento;
        }
    }
}
