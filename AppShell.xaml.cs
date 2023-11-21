using TecnologicoApp.Models;
using TecnologicoApp.Views;

namespace TecnologicoApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(WelcomePage), typeof(WelcomePage));
        }
    }
}
