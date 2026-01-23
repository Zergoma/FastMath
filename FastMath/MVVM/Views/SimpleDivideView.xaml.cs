using FastMath.MVVM.ViewModels;

namespace FastMath.MVVM.Views;

public partial class SimpleDivideView : ContentPage
{
	public SimpleDivideView(SimpleDivideViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}