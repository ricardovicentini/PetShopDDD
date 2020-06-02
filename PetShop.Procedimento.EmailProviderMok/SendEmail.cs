using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PetShop.Procedimento.EmailProviderMok
{
    public class SendEmail : IEmailProvider
    {
        public async Task Send(string email, string message)
        {
            Debug.WriteLine($"[EmailProvider] email was sent to {email} with message {message}");
        }
    }
}
