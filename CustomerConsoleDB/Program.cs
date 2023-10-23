using CustomerConsoleDB;
using CustomerConsoleDB.Repository;
using CustomerConsoleDB.Repository.IRepository;
using Microsoft.Extensions.DependencyInjection;

var builder = new ServiceCollection()
    .AddSingleton<ICustomerDataProvider, FileCustomerDataProvider>()
    .AddSingleton<App>()
    .BuildServiceProvider();

App customerApp = builder.GetRequiredService<App>();

customerApp.SaveCustomerList();

customerApp.GetCustomerList();