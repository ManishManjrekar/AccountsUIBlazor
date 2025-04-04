using AccountApi.Application.Interfaces;
using AccountApi.Infrastructure.Repository;
using Accounts.Apis;
using AutoMapper;
using log4net;
using log4net.Config;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Configure log4net
var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();
builder.Logging.AddLog4Net();

var mapperConfiguration = new MapperConfiguration(configuration =>
{
    configuration.AddProfile(new MappingProfile());
});

var mapper = mapperConfiguration.CreateMapper();

//services.AddSingleton(mapper);
builder.Services.AddSingleton(mapper);
// Add the IUnitOfWork as a scoped service
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>(); // Replace YourUnitOfWorkImplementation with the actual implementation class
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IVendorRepository, VendorRepository>();
builder.Services.AddScoped<ISalesRepository, SalesRepository>();
builder.Services.AddScoped<ICommissionAgentExpensesRepository, CommissionAgentExpensesRepository>();
builder.Services.AddScoped<ICommissionAgentPercentageRepository, CommissionAgentPercentageRepository>();
builder.Services.AddScoped<ICustomerPaymentReceivedRepository, CustomerPaymentReceivedRepository>();
builder.Services.AddScoped<IExpensesTypesRepository, ExpensesTypesRepository>();
builder.Services.AddScoped<IStockInRepository, StockInRepository>();
builder.Services.AddScoped<IVendorExpensesRepository, VendorExpensesRepository>();
builder.Services.AddScoped<IVendorPaymentRepository, VendorPaymentRepository>();
builder.Services.AddScoped<ICustomerBalanceCarryForwardRepository, CustomerBalanceCarryForwardRepository>();
builder.Services.AddScoped<ICommissionEarnedRepository, CommissionEarnedRepository>();
//services.AddScoped<ICommissionAgentPercentageRepository, CommissionAgentPercentageRepository>();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
//public class Startup
//{
//    public Startup(IConfiguration configuration)
//    {
//        Configuration = configuration;
//    }

//    public IConfiguration Configuration { get; }

//    public void ConfigureServices(IServiceCollection services)
//    {
//        var mapperConfiguration = new MapperConfiguration(configuration =>
//        {
//            configuration.AddProfile(new MappingProfile());
//        });

//        var mapper = mapperConfiguration.CreateMapper();

//        services.AddSingleton(mapper);
//    }
//}