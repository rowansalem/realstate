using Microsoft.Extensions.Logging;
using RealStatesApp.Pages.Addresses;
using RealStatesApp.Pages.Employees;
using RealStatesApp.Pages.Owners;
using RealStatesApp.Pages.Properties;
using RealStatesApp.Pages.SalesOffices;
using RealStatesApp.Services;
using RealStatesApp.Services.Address;
using RealStatesApp.Services.Address.Contracts;
using RealStatesApp.Services.Employee;
using RealStatesApp.Services.Employee.Contracts;
using RealStatesApp.Services.Owner;
using RealStatesApp.Services.Owner.Contracts;
using RealStatesApp.Services.Property;
using RealStatesApp.Services.Property.Contracts;
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
            builder.Services.AddSingleton<IAddressService, AddressService>();
            builder.Services.AddSingleton<IOwnersService, OwnersService>();
            builder.Services.AddSingleton<IPropertiesService, PropertiesService>();
            builder.Services.AddSingleton<ISalesOfficeService, SalesOfficeService>();

            // ViewModels
            builder.Services.AddTransient<PropertiesViewModel>();
            builder.Services.AddTransient<EmployeesViewModel>();
            builder.Services.AddTransient<EmployeesViewModel>();
            builder.Services.AddTransient<OfficesViewModel>();
            builder.Services.AddTransient<EmployeesListViewModel>();
            builder.Services.AddTransient<AddEditEmployeeViewModel>();
            builder.Services.AddTransient<AddressListViewModel>();
            builder.Services.AddTransient<AddEditAddressViewModel>();
            builder.Services.AddTransient<OwnersListViewModel>();
            builder.Services.AddTransient<AddEditOwnerViewModel>();
            builder.Services.AddTransient<PropertiesListViewModel>();
            builder.Services.AddTransient<AddEditPropertyViewModel>();
            builder.Services.AddTransient<SalesOfficesListViewModel>();
            builder.Services.AddTransient<AddEditSalesOfficeViewModel>();

            // Pages
            builder.Services.AddSingleton<PropertiesPage>();
            builder.Services.AddSingleton<EmployeesPage>();
            builder.Services.AddSingleton<OfficesPage>();
            builder.Services.AddSingleton<EmployeesListPage>();
            builder.Services.AddSingleton<AddEditEmployeePage>();
            builder.Services.AddSingleton<AddressesListPage>();
            builder.Services.AddSingleton<AddEditAddressPage>();
            builder.Services.AddSingleton<OwnersListPage>();
            builder.Services.AddSingleton<AddEditOwnerPage>();
            builder.Services.AddSingleton<PropertiesListPage>();
            builder.Services.AddSingleton<AddEditPropertyPage>();
            builder.Services.AddSingleton<SalesOfficesListPage>();
            builder.Services.AddSingleton<AddEditSalesOfficePage>();

            // Routing
            Routing.RegisterRoute(nameof(EmployeesPage), typeof(EmployeesPage));
            Routing.RegisterRoute(nameof(PropertiesPage), typeof(PropertiesPage));
            Routing.RegisterRoute(nameof(OfficesPage), typeof(OfficesPage));
            Routing.RegisterRoute(nameof(EmployeesListPage), typeof(EmployeesListPage));
            Routing.RegisterRoute(nameof(AddEditEmployeePage), typeof(AddEditEmployeePage));
            Routing.RegisterRoute(nameof(AddressesListPage), typeof(AddressesListPage));
            Routing.RegisterRoute(nameof(AddEditAddressPage), typeof(AddEditAddressPage));
            Routing.RegisterRoute(nameof(OwnersListPage), typeof(OwnersListPage));
            Routing.RegisterRoute(nameof(AddEditOwnerPage), typeof(AddEditOwnerPage));
            Routing.RegisterRoute(nameof(PropertiesListPage), typeof(PropertiesListPage));
            Routing.RegisterRoute(nameof(AddEditPropertyPage), typeof(AddEditPropertyPage));
            Routing.RegisterRoute(nameof(SalesOfficesListPage), typeof(SalesOfficesListPage));
            Routing.RegisterRoute(nameof(AddEditSalesOfficePage), typeof(AddEditSalesOfficePage));
            
            // Add the configuration
            var configuration = new AppSettings
            {
                BaseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:44338" : "https://localhost:44338"
            };

            builder.Services.AddSingleton(configuration);

            


            return builder.Build();
        }
    }
}
