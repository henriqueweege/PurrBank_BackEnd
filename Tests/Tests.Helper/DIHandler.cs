using Microsoft.Extensions.Hosting;
using PurrBank.IoC;
namespace Tests.Helper;

public static class DIHandler
{
    private static IHost _Host { get; set; }


    static DIHandler()
    {
        _Host = Host.CreateDefaultBuilder()
             .ConfigureServices(services =>
             {
                 services.AddRepositories();
                 services.AddDbContext();
                 services.AddEntitiesLogics();
                 services.AddMediatR();
             })
             .Build();

    }
    public static T GetService<T>()
    {
        try
        {
            var service = (T)_Host.Services.GetService(typeof(T));

            if (service is not null)
            {
                return service;
            }
            else
            {
                throw new ArgumentException();
            }
        }
        catch
        {
            throw new ArgumentException();
        }

    }
}