using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaShoppe.DAL.Repositories;

namespace PizzaShoppe.DAL
{
    public static class ServiceCollectionExtensions
    {
       public static IServiceCollection AddStores(this IServiceCollection serviceCollection,
          IConfiguration configuration)
       {
          serviceCollection.AddDbContext<PizzaShoppeContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

          serviceCollection.AddScoped<IPizzaShoppeContext>(s => s.GetRequiredService<PizzaShoppeContext>());

          serviceCollection.AddScoped<IPizzaRepository, PizzaRepository>();

         return serviceCollection;
       }
    }
}
