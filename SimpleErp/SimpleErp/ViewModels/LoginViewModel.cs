using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SimpleErp.Views;
using SimpleErp.Data;

namespace SimpleErp.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        Database db = new Database();

        public IRelayCommand LoginCommand { get; set; }
        public IRelayCommand NavigateToSignupCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(OnLoginPressed);
            NavigateToSignupCommand = new RelayCommand(NavigateToSignupPressed);
            
        }

        private async void NavigateToSignupPressed()
        {

            await Application.Current.MainPage.Navigation.PushAsync(new SignupPage());

        }

        private async void OnLoginPressed()
        {
            Database db = new Database();
            await db.OpenDatabaseAsync();

            var person = await db.CheckPassword(_email, _password);

            if (person != null)
            {
                await Application.Current.MainPage.DisplayAlert("Success", "Login successful!", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Invalid email or password.", "OK");
            }

        }

        public bool IsValidEmail(string _email)
        {
            if (_email == null)
                //Make a warning message for null email 
                return false;
            else
                return new EmailAddressAttribute().IsValid(_email);

        }

        //public bool IsPasswordValid(string _password)
        //{
              
        //}

        //login debug 
        //
           //if (IsValidEmail(_email))
           // {
           //     Debug.WriteLine($"Email: {_email}, Password {_password}");
           // }
}
}
