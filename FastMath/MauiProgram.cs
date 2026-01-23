using FastMath.Core.Abstraction;
using FastMath.MVVM.ViewModels;
using FastMath.MVVM.Views;
using FastMath.Services;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;

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
            builder.UseSkiaSharp();

            builder.Services.AddTransient<SimpleAdditionView>();
            builder.Services.AddTransient<SimpleAdditionViewModel>();

            builder.Services.AddTransient<MultiplyView>();
            builder.Services.AddTransient<SimpleMultiplyViewModel>();

            builder.Services.AddTransient<SimpleSubstractView>();
            builder.Services.AddTransient<SimpleSubstractionViewModel>();

            builder.Services.AddTransient<SimpleDivideView>();
            builder.Services.AddTransient<SimpleDivideViewModel>();



            builder.Services.AddSingleton<AdditionService>();
            builder.Services.AddSingleton<DivideService>();
            builder.Services.AddSingleton<MultiplicationService>();
            builder.Services.AddSingleton<SubstractionService>();

            return builder.Build();
        }
    }
}
