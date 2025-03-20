using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SimpleErp.Views;

namespace SimpleErp.ViewModels;

public partial class SignupViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _email;

    [ObservableProperty]
    private string _password;

    [ObservableProperty]
    private string _firstName;

    [ObservableProperty]
    private string _lastName;

    public IRelayCommand NavigateToLoginCommand { get; set; }

    public  SignupViewModel()
	{

        NavigateToLoginCommand = new RelayCommand(NavigateToLoginPressed);
    }


    private async void NavigateToLoginPressed()
    {

        await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());

    }

}