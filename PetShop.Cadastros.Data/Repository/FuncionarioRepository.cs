using Microsoft.EntityFrameworkCore;
using PetShop.Cadastros.Data.Context;
using PetShop.Cadastros.Data.Models;
using PetShop.SharedKernel.Base.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Cadastros.Data.Repository
{
    public class FuncionarioRepository : Repository<Funcionario>
    {
        private readonly CadastrosDBContext _dbCotnext;
        public FuncionarioRepository(CadastrosDBContext dbContext) : base(dbContext)
        {
            _dbCotnext = dbContext;
        }

        public override IUnitOfWork UnityOfWork => _dbCotnext;
    }
}
