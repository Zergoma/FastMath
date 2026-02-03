using FastMath.Core.Factories;
using FastMath.Core.Helpers;
using FastMath.Core.Interfaces;
using FastMath.Core.Models.OperationsWorld.OperationParameters;
using FastMath.Core.Models.OperationsWorld.OperationParameters.Types;
using FastMath.Core.Models.UserConfiguration;
using FastMath.Helper;
using FastMath.MVVM.ViewModels;
using FastMath.MVVM.Views;
using FastMath.Serialization;
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

            builder.Services.AddTransient<UserSelectionView>();
            builder.Services.AddTransient<UserSelectionViewModel>();

            builder.Services.AddTransient<SimpleAdditionView>();
            builder.Services.AddTransient<SimpleAdditionViewModel>();

            builder.Services.AddTransient<MultiplyView>();
            builder.Services.AddTransient<SimpleMultiplyViewModel>();

            builder.Services.AddTransient<SimpleSubstractView>();
            builder.Services.AddTransient<SimpleSubstractionViewModel>();

            builder.Services.AddTransient<SimpleDivideView>();
            builder.Services.AddTransient<SimpleDivideViewModel>();

            builder.Services.AddTransient<GenerateSimpleOperationHelper>();


            builder.Services.AddSingleton<ICurrentUser, User>();
            builder.Services.AddSingleton<ICreate<OperationSettingParametersBase>, OriginParametersFactory>();


            builder.Services.AddKeyedTransient<IGetUserSetting, SettingHelper<AdditionSimpleParameters>>(SettingHelperKeys.Addition);
            builder.Services.AddKeyedTransient<IGetUserSetting, SettingHelper<DivideSimpleParameters>>(SettingHelperKeys.Division);
            builder.Services.AddKeyedTransient<IGetUserSetting, SettingHelper<MultiplySimpleParameters>>(SettingHelperKeys.Multiplication);
            builder.Services.AddKeyedTransient<IGetUserSetting, SettingHelper<SubstractSimpleParameters>>(SettingHelperKeys.Subtraction);


            builder.Services.AddKeyedSingleton<IGetOperation, AdditionService>(OperationServiceKeys.Addition);
            builder.Services.AddKeyedSingleton<IGetOperation, DivideService>(OperationServiceKeys.Division);
            builder.Services.AddKeyedSingleton<IGetOperation, MultiplicationService>(OperationServiceKeys.Multiplication);
            builder.Services.AddKeyedSingleton<IGetOperation, SubstractionService>(OperationServiceKeys.Subtraction);
            builder.Services.AddKeyedSingleton<IGetOperation, SubstractionServiceBiggestOnLeft>(SpecificOperationServiceKeys.BiggestOnLeft);


            builder.Services.AddKeyedSingleton<IDataLayer<UserSettingCollection>, ConfigsXmlDataLayer<UserSettingCollection>>(DataLayerKeys.xml);
            builder.Services.AddKeyedSingleton<IDataLayer<UserSettingCollection>, ConfigsJsonDataLayer<UserSettingCollection>>(DataLayerKeys.json);

            return builder.Build();
        }
    }
}
