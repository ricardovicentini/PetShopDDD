using Microsoft.EntityFrameworkCore;
using PetShop.Procedimento.Data.DataModels;
using PetShop.SharedKernel.Base.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Procedimento.Data.Context
{
    public class ProcedimentoDBContext : DbContext, IUnitOfWork
    {
        public DbSet<ProcedimentoDataModel> Procedimentos { get; set; }

        public ProcedimentoDBContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
