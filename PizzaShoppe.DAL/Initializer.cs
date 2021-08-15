using Microsoft.EntityFrameworkCore;
using PizzaShoppe.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaShoppe.DAL
{
    public static class Initializer
    {
        public static void Initialize(PizzaShoppeContext pizzaShoppeContext)
        {
            pizzaShoppeContext.Database.EnsureDeleted();
            pizzaShoppeContext.Database.EnsureCreated();
            var pizzaChain = new PizzaChain() { Name = "Big Bob's Pizza", PizzaShoppeBranches = new List<PizzaShoppeBranch>() };
            
            pizzaShoppeContext.PizzaChains.Add(pizzaChain);

            var tunaPizza = new Pizza() { Name = "Tuna", Temperature = 12 };
            var pizzas = new List<Pizza>() { tunaPizza, new Pizza() { Name = "Cheese", Temperature = 200 }, new Pizza() { Name = "Bob's Special", Temperature = 123 } };
            
            pizzaShoppeContext.Pizzas.AddRange(pizzas);
            pizzaChain.PizzaShoppeBranches.AddRange(new[] {
                new PizzaShoppeBranch() { Address = "123 Fake St." , Pizzas = new List<Pizza>(){ tunaPizza} },
                new PizzaShoppeBranch() { Address = "667 Satan Drive", Pizzas=pizzas },
                new PizzaShoppeBranch() { Address = "200 Nowhere Blvd." }
            });

            pizzaShoppeContext.SaveChanges();
        }
    }
}
