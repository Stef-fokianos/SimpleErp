using SimpleErp.ViewModels;

namespace SimpleErp.Views;


public partial class SignupPage : ContentPage
{
	public SignupPage()
	{
		InitializeComponent();
        BindingContext = new SignupViewModel();
    }

}

