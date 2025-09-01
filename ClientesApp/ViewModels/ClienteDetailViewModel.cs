using ClientesApp.Models;
using ClientesApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;

namespace ClientesApp.ViewModels
{

    [QueryProperty(nameof(ClienteJson), "cliente")]
    [QueryProperty(nameof(IsNew), "isNew")]
    public partial class ClienteDetailViewModel : ObservableObject
    {
        private readonly IClienteService _clienteService;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Title))]
        private ClienteModel _cliente;

        [ObservableProperty] private string _clienteJson;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Title))]
        private bool _isNew;
        
        [ObservableProperty] private string _nameError = string.Empty;
        [ObservableProperty]  private string _lastNameError = string.Empty;
        [ObservableProperty]  private string _ageError = string.Empty;
        [ObservableProperty]  private string _zipCodeError = string.Empty;
        [ObservableProperty]  private string _streetError = string.Empty;
        [ObservableProperty]  private string _cityError = string.Empty;
        [ObservableProperty]  private string _stateError = string.Empty;
        public string Title => IsNew ? "Novo Cliente" : "Editar Cliente";

        public ClienteDetailViewModel(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        partial void OnClienteJsonChanged(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                var decodedJson = Uri.UnescapeDataString(value);
                Cliente = JsonConvert.DeserializeObject<ClienteModel>(decodedJson) ?? new ClienteModel();
            }
        }
        partial void OnIsNewChanged(bool value)
        {
            IsNew = value;
        }

        [RelayCommand]
        private async Task Save()
        {
            if (!Validate())
            {
                await Shell.Current.DisplayAlert("Atenção!", "Preencha todos os campos obrigatórios", "OK");
                return;
            }

            if (IsNew)
            {
                await _clienteService.AddClienteAsync(Cliente);
            }
            else
            {
                await _clienteService.UpdateClienteAsync(Cliente);
            }

            await Shell.Current.GoToAsync("..");
        }

        private bool Validate()
        {
            NameError = LastNameError = AgeError = ZipCodeError = StreetError = CityError = StateError = string.Empty;

            bool aux = true;

            if (string.IsNullOrEmpty(Cliente.Name))
            {
                NameError = "* O campo nome é obrigatório";
                aux = false;
            }

            if (string.IsNullOrEmpty(Cliente.Lastname))
            {
                LastNameError = "* O campo sobrenome é obrigatório";
                aux = false;
            }

            if (Cliente.Age <= 0)
            {
                AgeError = "* O campo idade é obrigatório";
                aux = false;
            }

            if (string.IsNullOrEmpty(Cliente.Address.Street))
            {
                StreetError = "* O campo rua é obrigatório";
                aux = false;
            }

            if (string.IsNullOrEmpty(Cliente.Address.City))
            {
                CityError = "* O campo cidade é obrigatório";
                aux = false;
            }

            if (string.IsNullOrEmpty(Cliente.Address.State))
            {
                StateError = "* O campo estado é obrigatório";
                aux = false;
            }
            return aux;

        }

        [RelayCommand]
        private async Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}