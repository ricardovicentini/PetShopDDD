using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Procedimento.EmailProviderMok
{
    public interface IEmailProvider
    {
        Task Send(string email, string message);
    }
}
