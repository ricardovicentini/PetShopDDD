using PetShop.SharedKernel.Base.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Cadastros.Data.Models
{
    public class Cliente : ITableModel
    {
        public Guid ID { get; set; }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string DDD { get; set; }
        public int TipoTelefone { get; set; }
        public string NumeroTelefone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
    }
}
