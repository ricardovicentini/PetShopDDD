using Microsoft.EntityFrameworkCore;
using PetShop.Cadastros.Data.Context;
using PetShop.Cadastros.Data.Models;
using PetShop.SharedKernel.Base.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Cadastros.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>
    {
        private readonly CadastrosDBContext _dbContext;
        public ClienteRepository(CadastrosDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override IUnitOfWork UnityOfWork => _dbContext;
    }
}
