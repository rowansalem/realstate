using Microsoft.Extensions.Logging;
using RealStatesApp.Services;
using RealStatesApp.ViewModels;

namespace RealStatesApp
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
            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddSingleton<IRealEstateService, RealEstateService>();
            builder.Services.AddSingleton<IEmployeesService, EmployeesService>();

            builder.Services.AddTransient<PropertiesViewModel>();
            builder.Services.AddTransient<EmployeesViewModel>();
            builder.Services.AddTransient<OfficesViewModel>();

            builder.Services.AddSingleton<PropertiesPage>();
            builder.Services.AddSingleton<EmployeesPage>();
            builder.Services.AddSingleton<OfficesPage>();
            builder.Services.AddSingleton<EmployeesListPage>();

            Routing.RegisterRoute(nameof(EmployeesPage), typeof(EmployeesPage));
            Routing.RegisterRoute(nameof(PropertiesPage), typeof(PropertiesPage));
            Routing.RegisterRoute(nameof(OfficesPage), typeof(OfficesPage));
            Routing.RegisterRoute(nameof(EmployeesListPage), typeof(EmployeesListPage));

            return builder.Build();
        }
    }
}
