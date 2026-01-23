using FastMath.Core.Abstraction;
using FastMath.MVVM.ViewModels;
using FastMath.MVVM.Views;
using FastMath.Services;
using Microsoft.Extensions.Logging;

namespace FastMath
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<SimpleAdditionView>();
            builder.Services.AddTransient<SimpleAdditionViewModel>();

            builder.Services.AddSingleton<AdditionService>();
            builder.Services.AddSingleton<DivideService>();
            builder.Services.AddSingleton<MultiplicationService>();
            builder.Services.AddSingleton<SoustractionService>();

            return builder.Build();
        }
    }
}
