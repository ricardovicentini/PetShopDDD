using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetShop.Cadastros.Application.Services.Adapters;
using PetShop.Cadastros.Application.Services.Ports;
using PetShop.Cadastros.Application.ViewModels;
using PetShop.Cadastros.Data.Context;
using PetShop.Cadastros.Data.Repository;
using System.Linq;
using Xunit;


namespace IntegrationTests
{
    public class ClienteIntegrationTests
    {
        private ServiceProvider serviceProvider;
        private IClienteCadastroServices _clienteServices;
        private readonly ClienteViewModel clienteVM = new ClienteViewModel()
        { 
            Nome = "José",
            SobreNome = "da Silva",
            CPF = "123",
            DDD = "11",
            TipoTelefone  = 3,
            NumeroTelefone = "974142141",
            Email = "a@b.com"
        };

        public ClienteIntegrationTests()
        {
            serviceProvider = new ServiceCollection()
               .AddScoped<IClienteCadastroServices, ClienteCadastroService>()
               .AddScoped<ClienteRepository, ClienteRepository>()
               .AddDbContext<CadastrosDBContext>(opt => opt.UseInMemoryDatabase("teste"))
               .AddAutoMapper(typeof(FuncionarioService))
               .BuildServiceProvider();

            _clienteServices = serviceProvider.GetService<IClienteCadastroServices>();
        }

        
        private void Adicionar_Cliente()
        {
            _clienteServices.Adicionar(clienteVM);
        }

        [Fact(DisplayName = "Adicionar e verificar se cliente foi adicionado")]
        public async void Testar_Adicionar_Cliente()
        {
            Adicionar_Cliente();
            var clientes = await _clienteServices.ListarClientes();
            Assert.True(clientes.Any());
        }

        [Fact(DisplayName = "Removendo todos os clientes a tabela deve ficar vazia")]
        public async void Adicionar_Remover_Consultar()
        {
            Adicionar_Cliente();
            var clientes = await _clienteServices.ListarClientes();
            foreach (var c in clientes.ToList())
            {
                _clienteServices.Remover(c.ID);
            }
            clientes = await _clienteServices.ListarClientes();
            Assert.False(clientes.Any());
        }
    }
}
