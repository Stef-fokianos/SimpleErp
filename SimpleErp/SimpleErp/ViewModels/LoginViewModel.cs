using CommunityToolkit.Mvvm.ComponentModel;

namespace SimpleErp.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;
    }
}
