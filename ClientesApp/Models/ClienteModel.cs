using CommunityToolkit.Mvvm.ComponentModel;
using System.Xml.Linq;

namespace ClientesApp.Models
{
    public partial class ClienteModel : ObservableObject
    {
        [ObservableProperty]
        private Guid _id;

        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private string _lastname = string.Empty;

        [ObservableProperty]
        private int _age;

        [ObservableProperty]
        private AddressModel _address = new AddressModel();

        public string FullName => $"{Name} {Lastname}";
    }
}
