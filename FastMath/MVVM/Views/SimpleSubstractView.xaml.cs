using FastMath.MVVM.ViewModels;

namespace FastMath.MVVM.Views;

public partial class SimpleSubstractView : ContentPage
{
	public SimpleSubstractView(SimpleSubstractionViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}