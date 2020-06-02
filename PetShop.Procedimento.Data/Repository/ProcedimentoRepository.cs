using Microsoft.EntityFrameworkCore;
using PetShop.Procedimento.Data.Context;
using PetShop.Procedimento.Data.DataModels;
using PetShop.SharedKernel.Base.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Procedimento.Data.Repository
{
    public class ProcedimentoRepository : Repository<ProcedimentoDataModel>
    {
        private readonly ProcedimentoDBContext _dbContext;
        public ProcedimentoRepository(ProcedimentoDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override IUnitOfWork UnityOfWork => _dbContext;
    }
}
