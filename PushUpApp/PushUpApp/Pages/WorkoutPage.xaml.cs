using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PushUpApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WorkoutPage : ContentPage
	{
		public WorkoutPage ()
		{
			InitializeComponent ();
            BindingContext = new WorkoutViewModel();
		}
	}
}