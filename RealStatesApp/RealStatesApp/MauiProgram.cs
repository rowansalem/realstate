using Microsoft.Extensions.Logging;
using RealStatesApp.Pages.Addresses;
using RealStatesApp.Pages.Employees;
using RealStatesApp.Services;
using RealStatesApp.Services.Address;
using RealStatesApp.Services.Address.Contracts;
using RealStatesApp.Services.Employee;
using RealStatesApp.Services.Employee.Contracts;
using RealStatesApp.Services.SalesOffice;
using RealStatesApp.Services.SalesOffice.Contracts;
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
            // Services
            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddSingleton<IRealEstateService, RealEstateService>();
            builder.Services.AddTransient<IEmployeesService, EmployeesService>();
            builder.Services.AddSingleton<ISalesOfficeService, SalesOfficeService>();
            builder.Services.AddSingleton<IAddressService, AddressService>();

            // ViewModels
            builder.Services.AddTransient<PropertiesViewModel>();
            builder.Services.AddTransient<EmployeesViewModel>();
            builder.Services.AddTransient<EmployeesViewModel>();
            builder.Services.AddTransient<OfficesViewModel>();
            builder.Services.AddTransient<EmployeesListViewModel>();
            builder.Services.AddTransient<AddEditEmployeeViewModel>();
            builder.Services.AddTransient<AddressListViewModel>();
            builder.Services.AddTransient<AddEditAddressViewModel>();

            // Pages
            builder.Services.AddSingleton<PropertiesPage>();
            builder.Services.AddSingleton<EmployeesPage>();
            builder.Services.AddSingleton<OfficesPage>();
            builder.Services.AddSingleton<EmployeesListPage>();
            builder.Services.AddSingleton<AddEditEmployeePage>();
            builder.Services.AddSingleton<AddressesListPage>();
            builder.Services.AddSingleton<AddEditAddressPage>();

            // Routing
            Routing.RegisterRoute(nameof(EmployeesPage), typeof(EmployeesPage));
            Routing.RegisterRoute(nameof(PropertiesPage), typeof(PropertiesPage));
            Routing.RegisterRoute(nameof(OfficesPage), typeof(OfficesPage));
            Routing.RegisterRoute(nameof(EmployeesListPage), typeof(EmployeesListPage));
            Routing.RegisterRoute(nameof(AddEditEmployeePage), typeof(AddEditEmployeePage));
            Routing.RegisterRoute(nameof(AddressesListPage), typeof(AddressesListPage));
            Routing.RegisterRoute(nameof(AddEditAddressPage), typeof(AddEditAddressPage));
            
            // Add the configuration
            var configuration = new AppSettings
            {
                BaseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7074" : "https://localhost:44338"
            };

            builder.Services.AddSingleton(configuration);

            


            return builder.Build();
        }
    }
}
