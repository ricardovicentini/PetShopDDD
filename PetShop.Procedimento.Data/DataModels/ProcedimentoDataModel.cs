using PetShop.SharedKernel.Base.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetShop.Procedimento.Data.DataModels
{
    [Table(name:"TB_PROCEDIMENTO")]
    public class ProcedimentoDataModel : ITableModel
    {
        [Key]
        public Guid ID { get ; set ; }
        
        [Column(name:"PROFISSIONAL_ID")]
        [Required]
        public Guid ProfissionalID { get; set; }
        
        [Column(name: "Categoria_ID")]
        [Required]
        public int CategoriaID { get; set; }
        
        [Column(name: "DESCRICAO",TypeName ="varchar(50)")]
        [Required]
        public string Descricao { get; set; }
        
        [Column(name: "SOLICITANTE_ID")]
        [Required]
        public Guid SolicitanteID { get; set; }

        [Column(name: "DATA")]
        [Required]
        public DateTime Data { get; set; }
        
        [Column(name: "VALOR")]
        [Required]
        public decimal Valor { get; set; }

        [Column(name: "SOLICITACOES",TypeName ="varchar(255)")]
        [Required]
        public string Solicitacoes { get; set; }

        [Column(name: "SITUACAO_ID")]
        [Required]
        public int SituacaoID { get; private set; }
    }
}
