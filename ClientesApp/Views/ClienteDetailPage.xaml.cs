using ClientesApp.ViewModels;

namespace ClientesApp.Views;

public partial class ClienteDetailPage : ContentPage
{
    public ClienteDetailPage(ClienteDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}