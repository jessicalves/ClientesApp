using ClientesApp.Models;
using System.Collections.ObjectModel;

namespace ClientesApp.Services
{

    public class ClienteService : IClienteService
    {
        private readonly ObservableCollection<ClienteModel> _clientes = new();
        public Task<ObservableCollection<ClienteModel>> GetClientesAsync()
        {
            return Task.FromResult(_clientes);
        }

        public Task<ClienteModel> GetClienteAsync(Guid id) =>
            Task.FromResult(_clientes.FirstOrDefault(c => c.Id == id))!;

        public Task AddClienteAsync(ClienteModel cliente)
        {
            cliente.Id = Guid.NewGuid();
            _clientes.Add(cliente);
            return Task.CompletedTask;
        }

        public Task UpdateClienteAsync(ClienteModel cliente)
        {
            var existing = _clientes.FirstOrDefault(c => c.Id == cliente.Id);
            if (existing != null)
            {
                existing.Name = cliente.Name;
                existing.Lastname = cliente.Lastname;
                existing.Age = cliente.Age;
                existing.Address = cliente.Address;
            }
            return Task.CompletedTask;
        }

        public Task DeleteClienteAsync(Guid id)
        {
            var cliente = _clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                _clientes.Remove(cliente);
            }
            return Task.CompletedTask;
        }
    }
}
