using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.SharedKernel.Base.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
