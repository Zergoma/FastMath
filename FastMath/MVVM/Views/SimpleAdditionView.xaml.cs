using FastMath.MVVM.ViewModels;

namespace FastMath.MVVM.Views;

public partial class SimpleAdditionView : ContentPage
{
	public SimpleAdditionView(SimpleAdditionViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}