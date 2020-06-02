using PetShop.SharedKernel.Base.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Cadastros.Domain.Enumerations
{
    public  class EnumTipoTelefone : Enumeration
    {
        public static readonly EnumTipoTelefone Residencial = new EnumTipoTelefone(1, "Residencial");
        public static readonly EnumTipoTelefone Comercial = new EnumTipoTelefone(2, "Comercial");
        public static readonly EnumTipoTelefone Celular = new EnumTipoTelefone(3, "Celular");

        public EnumTipoTelefone(int value, string name) : base(value, name)
        {
        }
    }
}
