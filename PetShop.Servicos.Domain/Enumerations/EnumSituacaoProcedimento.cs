using PetShop.SharedKernel.Base.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Servicos.Domain.Enumerations
{
    public class EnumSituacaoProcedimento : Enumeration
    {
        public static readonly EnumSituacaoProcedimento Ativo = new EnumSituacaoProcedimento(1, "Ativo");
        public static readonly EnumSituacaoProcedimento Cancelado = new EnumSituacaoProcedimento(2, "Cancelado");
        public EnumSituacaoProcedimento(int value, string name) : base(value, name)
        {
        }
    }
}
