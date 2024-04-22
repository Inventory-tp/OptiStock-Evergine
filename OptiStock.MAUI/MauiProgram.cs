using OptiStock.MAUI.Evergine;
using OptiStock.MAUI.Views;
using OptiStock.MAUI.ViewsModels;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using OptiStock.MAUI.Services;
using OptiStock.MAUI.Models;
using OptiStock.MAUI.Database;
using OptiStock.MAUI.Services.Authentication;
using OptiStock.MAUI.State.Authenticators;
using Microsoft.Extensions.Logging;
using OptiStock.MAUI.State.Accounts;

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
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitCore()
                .RegisterDbContext()
                .RegisterServices()
                .RegisterViewModels()
                .RegisterViews()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Logging.AddDebug();

            return builder.Build();
        }

        //Method registering our DatabaseContext in services collection
        public static MauiAppBuilder RegisterDbContext(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddDbContext<OptiStockDbContext>();

            return mauiAppBuilder;
        }

        //Method registering our different services in services collection
        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<OptiStockDbContextFactory>();
            mauiAppBuilder.Services.AddSingleton<IDataRepository<AccountModel>, AccountDataService>();
            mauiAppBuilder.Services.AddSingleton<IAccountRepository, AccountDataService>();
            mauiAppBuilder.Services.AddSingleton<IAuthenticationRepository, AuthenticationService>();
            mauiAppBuilder.Services.AddSingleton<IDataRepository<DomainObject>, GenericDataService<DomainObject>>();

            return mauiAppBuilder;
        }

        //Method registering our different states manager in services collection
        public static MauiAppBuilder RegisterStates(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<IAccountStore, AccountStore>();
            mauiAppBuilder.Services.AddSingleton<IAuthenticator, Authenticator>();

            return mauiAppBuilder;
        }

        //Method registering our different views model in services collection
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<LoginPageViewModel>();
            mauiAppBuilder.Services.AddTransient<HomePageViewModel>();
            mauiAppBuilder.Services.AddTransient<ManageUsersViewModel>();
            mauiAppBuilder.Services.AddTransient<NewUserPageViewModel>();

            return mauiAppBuilder;
        }

        //Method registering our different views in services collection
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<HomePage>();
            mauiAppBuilder.Services.AddSingleton<LoginPage>();
            mauiAppBuilder.Services.AddSingleton<ManageUsersPage>();
            mauiAppBuilder.Services.AddSingleton<ManageProductsPage>();
            mauiAppBuilder.Services.AddSingleton<NewUserPage>();
            mauiAppBuilder.Services.AddSingleton<NewProductPage>();

            return mauiAppBuilder;
        }
    }
}