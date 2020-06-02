using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetShop.Cadastros.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Cadastros.Data.Mappings
{
    public class ClientMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable(name: "TAB_CLIENTE");
            
            builder.HasKey(k => k.ID);
            
            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.Sobrenome)
                .HasColumnName("SOBRENOME")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.DDD)
                .HasColumnName("DDD")
                .HasColumnType("varchar(3)")
                .IsRequired();

            builder.Property(p => p.TipoTelefone)
                .HasColumnName("TIPO_TELEFONE_ID")
                .IsRequired();

            builder.Property(p=> p.NumeroTelefone)
                .HasColumnName("NUMERO_TELEFONE")
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnName("EMAIL")
                .HasColumnType("varchar(255)")
                .IsRequired();

        }
    }
}
