using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PushUpApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();

            BindingContext = new ProfileViewModel();
		}
	}
}