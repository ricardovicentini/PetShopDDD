using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Cadastros.Application.ViewModels
{
    public class FuncionarioViewModel
    {
        public Guid ID { get; set; }
        public string Nome { get;  set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
    }
}
