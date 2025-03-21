using SimpleErp.ViewModels;
using SimpleErp.Data;

namespace SimpleErp.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel();
	}


}