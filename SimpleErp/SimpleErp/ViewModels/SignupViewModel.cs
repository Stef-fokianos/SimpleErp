using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SimpleErp.Views;
using SimpleErp.Data;

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
    public IRelayCommand SignupCommand { get; set; }

    public  SignupViewModel()
	{

        NavigateToLoginCommand = new RelayCommand(NavigateToLoginPressed);
        SignupCommand = new RelayCommand(SignupPressed);
    }


    private async void NavigateToLoginPressed()
    {

        await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());

    }

    private async void SignupPressed()
    {
        Database db = new Database();
        await db.OpenDatabaseAsync();

        Person newUser = new Person
        {
            Email = _email,
            Password = _password,
            FirstName = _firstName,
            LastName = _lastName
        };

        await db.InsertAsync(newUser);

        await Application.Current.MainPage.DisplayAlert("Success", "Account created successfully!", "OK");

        await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
    }

}