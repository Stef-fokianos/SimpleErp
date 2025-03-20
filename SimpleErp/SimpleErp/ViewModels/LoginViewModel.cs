using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SimpleErp.Views;

namespace SimpleErp.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        public IRelayCommand LoginCommand { get; set; }
        public IRelayCommand NavigateToSignupCommand { get; set; }

        public LoginViewModel()
        {
            //LoginCommand = new RelayCommand(OnLoginPressed);
            NavigateToSignupCommand = new RelayCommand(NavigateToSignupPressed);
        }

       

        private async void NavigateToSignupPressed()
        {

            await Application.Current.MainPage.Navigation.PushAsync(new SignupPage());

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
        //      
        //}

        //login debug 
        //
           //if (IsValidEmail(_email))
           // {
           //     Debug.WriteLine($"Email: {_email}, Password {_password}");
           // }
}
}
