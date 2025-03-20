using SimpleErp.ViewModels;

namespace SimpleErp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel();
	}


}