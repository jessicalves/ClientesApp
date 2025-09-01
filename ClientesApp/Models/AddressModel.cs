using CommunityToolkit.Mvvm.ComponentModel;

namespace ClientesApp.Models
{
    public partial class AddressModel : ObservableObject
    {
        [ObservableProperty]
        private string _street = string.Empty;

        [ObservableProperty]
        private string _complement = string.Empty;

        [ObservableProperty]
        private string _city = string.Empty;

        [ObservableProperty]
        private string _state = string.Empty;

        [ObservableProperty]
        private string _zipCode = string.Empty;
    }
}
