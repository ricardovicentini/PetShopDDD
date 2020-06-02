using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Servicos.Application.ViewModels
{
    public class ProcedimentoViewModel
    {
        public Guid Id { get; set; }
        public Guid ProfissionalID { get; set; }
        public int CategoriaID { get; set; }
        public string Descricao { get; set; }
        public Guid SolicitanteID { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public IEnumerable<string> Solicitacoes { get;  set; }
        public int SituacaoID { get;  set; }

    }
}
