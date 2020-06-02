using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PetShop.Cadastros.Data.Models;
using PetShop.SharedKernel.Base.Data;
using System;
using System.Threading.Tasks;

namespace PetShop.Cadastros.Data.Context
{
    public class CadastrosDBContext : DbContext, IUnitOfWork
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        

        public CadastrosDBContext(DbContextOptions<CadastrosDBContext> options) : base(options)
        {
         
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CadastrosDBContext).Assembly);
        }
    }
}
