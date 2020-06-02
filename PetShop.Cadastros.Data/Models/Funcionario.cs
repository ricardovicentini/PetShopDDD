using PetShop.SharedKernel.Base.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PetShop.Cadastros.Data.Models
{
    [Table(name:"TAB_FUNCIONARIO")]
    public class Funcionario : ITableModel
    {
        [Key]
        public Guid ID { get; set; }

        [Column(name:"NOME_FUNCIONARIO",TypeName ="varchar(50)")]
        [Required]
        public string Nome { get; private set; }
        
        [Column(name: "SOBRENOME_FUNCIONARIO", TypeName = "varchar(50)")]
        [Required]
        public string SobreNome { get; set; }

        [Column(name: "CPF", TypeName = "varchar(13)")]
        [Required]
        public string CPF { get; private set; }
    }
}
