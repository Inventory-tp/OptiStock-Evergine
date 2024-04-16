using OptiStock.MAUI.Evergine;
using Microsoft.Extensions.Logging;
using OptiStock.MAUI.Views;
using OptiStock.MAUI.ViewsModels;
using OptiStock.MAUI.Repositories;

namespace OptiStock.MAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            MauiAppBuilder builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiEvergine()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IProductRepository, ProductRepositoryImpl>();
            builder.Services.AddSingleton<IUserRepository, UserRepositoryImpl>();

            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<LoginPageViewModel>();

            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddTransient<HomePageViewModel>();

            builder.Services.AddSingleton<ManageUsersPage>();
            builder.Services.AddTransient<ManageUsersViewModel>();

            builder.Services.AddSingleton<NewUserPage>();
            builder.Services.AddTransient<NewUserPageViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
            #endif

            return builder.Build();
        }
    }
}