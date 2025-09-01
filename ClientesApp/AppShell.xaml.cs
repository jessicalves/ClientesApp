using ClientesApp.Views;

namespace ClientesApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ClienteDetailPage), typeof(ClienteDetailPage));
        }
    }
}
