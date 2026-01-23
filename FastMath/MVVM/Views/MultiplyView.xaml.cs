using FastMath.MVVM.ViewModels;

namespace FastMath.MVVM.Views;

public partial class MultiplyView : ContentPage
{
	public MultiplyView(SimpleMultiplyViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}