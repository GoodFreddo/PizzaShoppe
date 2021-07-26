using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShoppe.DAL
{
    public static class ServiceCollectionExtensions
    {
       public static IServiceCollection AddStores(this IServiceCollection serviceCollection,
          IConfiguration configuration)
       {
          serviceCollection.AddDbContext<PizzaShoppeContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

         return serviceCollection;
       }
    }
}
