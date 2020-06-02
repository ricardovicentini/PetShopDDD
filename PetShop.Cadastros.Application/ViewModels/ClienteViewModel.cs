using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Cadastros.Application.ViewModels
{
    public class ClienteViewModel
    {
        public Guid ID { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string CPF { get; set; }
        public string DDD { get; set; }
        public int TipoTelefone { get; set; }
        public string NumeroTelefone { get; set; }
        public string Email { get; set; }
    }
}
