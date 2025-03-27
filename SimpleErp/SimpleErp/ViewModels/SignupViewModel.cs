using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SimpleErp.Views;
using SimpleErp.Data;
using System.Text.RegularExpressions;

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


        if (IsPasswordValid(Password) && FirstName!=null && LastName!=null)
        {
            await db.InsertAsync(newUser);

            await Application.Current.MainPage.DisplayAlert("Success", "Account created successfully!", "OK");

            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());

        }
        else if (FirstName == null || LastName == null) 
        {
            Application.Current.MainPage.DisplayAlert("Error", "First name and last name should not be empty", "OK");
        }


    }


    public bool IsPasswordValid(string password)
    {
        var hasNumber = new Regex(@"[0-9]+");
        var hasUpperChar = new Regex(@"[A-Z]+");
        var hasMinimum8Chars = new Regex(@".{8,}");

        if (!hasNumber.IsMatch(password))
        {
            //Does not contain a number
            Application.Current.MainPage.DisplayAlert("Error", "Password must contain a number", "OK");
            return false;
        }
        if (!hasUpperChar.IsMatch(password))
        {
            //Does not contain an upper character
            Application.Current.MainPage.DisplayAlert("Error", "Password must contain an upper character", "OK");
            return false;
        }
        if (!hasMinimum8Chars.IsMatch(password))
        {
            //Does not contain 8 characters
            Application.Current.MainPage.DisplayAlert("Error", "Password must contain at least 8 characters", "OK");
            return false;
        }

        if (hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password))
        {
            return true;
        }

        return false;
    }

}

