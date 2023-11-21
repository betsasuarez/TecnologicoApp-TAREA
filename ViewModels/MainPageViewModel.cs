using CommunityToolkit.Maui.Alerts;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Input;
using TecnologicoApp.Models;
using TecnologicoApp.Views;
using System.Net.Mail;

namespace TecnologicoApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        #region "Properties"

        public UsuarioRegistro Usuario { get; set; }

        public ICommand LoginCommand { get; set; }

        #endregion

        public MainPageViewModel()
        {
            Usuario = new UsuarioRegistro();
            LoginCommand = new Command(LoginAsync);
        }

        #region "Logic"

        private async void LoginAsync()
        {
            if (!IsAValidEmail(Usuario.Email))
            {
                await Util.ShowToastAsync("Ingrese Email Válido");
                return;
            }

            if (!IsAValidPassword(Usuario.Password))
            {
                await Util.ShowToastAsync("Ingrese Contraseña Válida");
                return;
            }

            await Shell.Current.GoToAsync(nameof(WelcomePage));
        }

        private bool IsAValidPassword(string password)
        {
            throw new NotImplementedException();
        }

        private bool IsAValidEmail(string email)
        {
            try
            {
                string pattern = @"^(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)$";
                return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
    }
}