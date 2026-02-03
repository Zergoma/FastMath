using FastMath.MVVM.Views;

namespace FastMath
{
    public partial class App : Application
    {
        private readonly IServiceProvider service;

        public App(IServiceProvider service)
        {
            InitializeComponent();
            this.service = service;            
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(service.GetRequiredService<UserSelectionView>()));
        }
    }
}