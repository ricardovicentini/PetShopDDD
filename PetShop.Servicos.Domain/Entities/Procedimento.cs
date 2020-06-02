using FluentValidation;
using Microsoft.Extensions.Options;
using PetShop.Cadastros.Domain.Entities;
using PetShop.Servicos.Domain.Enumerations;
using PetShop.Servicos.Domain.Validators;
using PetShop.Servicos.Domain.ValueObjects;
using PetShop.SharedKernel.Base.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Servicos.Domain.Entities
{
    public class Procedimento : Entity
    {
        private readonly ProcedimentoValidator validator = new ProcedimentoValidator();
        public Funcionario  Profissional { get; private set; }
        public TipoProcedimentoVO  TipoProcedimento { get; private set; }
        public Cliente Solicitante { get; private set; }
        public DateTime Data { get; private set; }
        public decimal Valor { get; private set; }
        public IEnumerable<string> Solicitacoes { get; private set; }
        public EnumSituacaoProcedimento Situacao { get; private set; }

        public Procedimento(Funcionario profissional, TipoProcedimentoVO tipoProcedimento, Cliente solicitante, decimal valor, IEnumerable<string> solicitacoes)
        {
            Profissional = profissional;
            TipoProcedimento = tipoProcedimento;
            Solicitante = solicitante;
            Valor = valor;
            Solicitacoes = solicitacoes;
            Data = DateTime.Now;
            Situacao = EnumSituacaoProcedimento.Ativo;

            validator.ValidateAndThrow(this);
        }

        public void Agendar(DateTime data)
        {
            this.Data = data;
            AgendamentoValidator agendamentoValidator = new AgendamentoValidator();
            agendamentoValidator.ValidateAndThrow(this);
            

        }

        public void Cancelar()
        {
            this.Situacao = EnumSituacaoProcedimento.Cancelado;
        }
    }
}
