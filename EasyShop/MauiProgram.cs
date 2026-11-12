using Microsoft.Extensions.Logging;
using EasyShop.Data;
using EasyShop.Services;
using EasyShop.ViewModels;
using EasyShop.Views;

namespace EasyShop
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
            // Data
            builder.Services.AddSingleton<CustomerRepository>();
            builder.Services.AddSingleton<ProductRepository>();

            // Services
            builder.Services.AddSingleton<CustomerService>();
            builder.Services.AddSingleton<ProductService>();

            // ViewModels
            builder.Services.AddSingleton<CustomersViewModel>();
            builder.Services.AddSingleton<ProductsViewModel>();

            // Views
            builder.Services.AddSingleton<CustomersPage>();
            builder.Services.AddSingleton<ProductsPage>();
            return builder.Build();
        }
    }
}
