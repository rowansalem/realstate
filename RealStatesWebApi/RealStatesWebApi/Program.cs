using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Repositories.Contracts;
using Repositories;
using Services;
using WebAPI;
using Data.Infrastructure;
using FluentValidation;
using Models.DTO;
using Models.Validators;
using Data.Infrastructure.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
//Add Cross Origins Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Real State API", Version = "v1" });
    c.EnableAnnotations(); 
});
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextPool<Data.DbEntities>(
                        options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

//builder.Services.AddScoped<IReportRepository, ReportRepository>();
//builder.Services.AddScoped<IReportService, ReportService>();
//builder.Services.AddScoped<ISalesOfficeRepository, SalesOfficeRepository>();
//builder.Services.AddScoped<ISalesOfficeService, SalesOfficeService>();
// Add DI configuration
ConfigureService.RegisterRepositories(builder.Services);
ConfigureService.RegisterServices(builder.Services);
ConfigureService.RegisterMappers(builder.Services);

builder.Services.AddScoped<IValidator<EmployeeDTO>, EmployeeDTOValidator>();
builder.Services.AddScoped<IValidator<OwnerDTO>, OwnerDTOValidator>();
builder.Services.AddScoped<IValidator<AddressDTO>, AddressDTOValidator>();
builder.Services.AddScoped<IValidator<PropertyDTO>, PropertyDTOValidator>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
