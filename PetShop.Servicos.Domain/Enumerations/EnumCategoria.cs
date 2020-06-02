using PetShop.SharedKernel.Base.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Servicos.Domain.Enumerations
{
    public class EnumCategoria : Enumeration
    {
        public static readonly EnumCategoria Estetica = new EnumCategoria(1, "Estética");
        public static readonly EnumCategoria Saude = new EnumCategoria(2, "Saúde");
        public EnumCategoria(int value, string name) : base(value, name)
        {
        }
    }
}
