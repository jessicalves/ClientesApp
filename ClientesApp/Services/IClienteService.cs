
using ClientesApp.Models;
using System.Collections.ObjectModel;

namespace ClientesApp.Services
{
    public interface IClienteService
    {
        Task<ObservableCollection<ClienteModel>> GetClientesAsync();
        Task<ClienteModel> GetClienteAsync(Guid id);
        Task AddClienteAsync(ClienteModel cliente);
        Task UpdateClienteAsync(ClienteModel cliente);
        Task DeleteClienteAsync(Guid id);
    }
}
