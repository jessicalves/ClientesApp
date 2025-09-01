using ClientesApp.Models;
using ClientesApp.Services;
using ClientesApp.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace ClientesApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IClienteService _clienteService;
        [ObservableProperty] private ObservableCollection<ClienteModel> _clientes = [];

        public MainViewModel(IClienteService clienteService)
        {
            _clienteService = clienteService;
            LoadClientes();
        }

        private async void LoadClientes()
        {
            Clientes = await _clienteService.GetClientesAsync();
        }

        [RelayCommand]
        private async Task AddCliente()
        {
            var cliente = new ClienteModel();
            var clienteJson = JsonConvert.SerializeObject(cliente);
            var encodedJson = Uri.EscapeDataString(clienteJson);
            await Shell.Current.GoToAsync($"{nameof(ClienteDetailPage)}?cliente={encodedJson}&isNew=true");
        }

        [RelayCommand]
        private async Task EditCliente(ClienteModel? cliente)
        {
            if (cliente == null)
                return;

            var clienteJson = JsonConvert.SerializeObject(cliente);
            var encodedJson = Uri.EscapeDataString(clienteJson);
            await Shell.Current.GoToAsync($"{nameof(ClienteDetailPage)}?cliente={encodedJson}&isNew=false");
        }

        [RelayCommand]
        private async Task DeleteCliente(ClienteModel? cliente)
        {
            if (cliente == null)
                return;

            bool confirm = await Shell.Current.DisplayAlert(
                "Confirmar Exclusão",
                $"Deseja excluir o cliente {cliente.Name}?",
                "Sim", "Não");

            if (confirm)
            {
                await _clienteService.DeleteClienteAsync(cliente.Id);
                LoadClientes();
            }
        }

        [RelayCommand]
        private Task Refresh()
        {
            LoadClientes();
            return Task.CompletedTask;
        }

    }
}