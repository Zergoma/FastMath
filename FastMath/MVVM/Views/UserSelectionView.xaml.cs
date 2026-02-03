using FastMath.MVVM.ViewModels;

namespace FastMath.MVVM.Views;

public partial class UserSelectionView : ContentPage
{
	public UserSelectionView(UserSelectionViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if(BindingContext is UserSelectionViewModel vm)
        {
            // reset the collectionview's selected user
            // required because all is based on user changing 
            vm.SelectedUser = null;
        }
    }
}