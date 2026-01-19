using Microsoft.Extensions.DependencyInjection;

namespace FastMath
{
    public partial class App : Application
    {
        public App(IServiceProvider service)
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}