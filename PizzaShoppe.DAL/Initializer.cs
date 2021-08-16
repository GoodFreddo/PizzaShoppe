using Microsoft.EntityFrameworkCore;
using PizzaShoppe.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PizzaShoppe.DAL
{
   public static class Initializer
   {
      public static void Initialize(PizzaShoppeContext pizzaShoppeContext)
      {
         //Crush and create my db
         pizzaShoppeContext.Database.EnsureDeleted();
         pizzaShoppeContext.Database.EnsureCreated();

         //Make my base level entities
         var tunaPizza = new Pizza() { Name = "Tuna", Temperature = 12 };
         var pizzas = new List<Pizza>() { tunaPizza, new Pizza() { Name = "Cheese", Temperature = 200 }, new Pizza() { Name = "Bob's Special", Temperature = 123 } };

         var pizzaChain = new PizzaChain() { Name = "Big Bob's Pizza", PizzaShoppeBranches = new List<PizzaShoppeBranch>() };
         var newStreetBranch = new PizzaShoppeBranch() { Address = "420 New Street" };

         //Add entities to entities
         var pizzaToPizzaShopBranch = new PizzaToPizzaShopBranch()
         {
            Pizza = tunaPizza,
            PizzaId = tunaPizza.PizzaId,
            PizzaShoppeBranch = newStreetBranch,
            PizzaShoppeBranchId = newStreetBranch.PizzaShoppeBranchId
         };

         pizzaChain.PizzaShoppeBranches.AddRange(new[] {
                new PizzaShoppeBranch() { Address = "123 Fake St."  },
                new PizzaShoppeBranch() { Address = "667 Satan Drive" },
                new PizzaShoppeBranch() { Address = "200 Nowhere Blvd." },
                newStreetBranch
            });

         //Add my entities to the context
         pizzaShoppeContext.PizzaChains.Add(pizzaChain);
         pizzaShoppeContext.Pizzas.AddRange(pizzas);
         pizzaShoppeContext.PizzaToPizzaShopBranches.Add(pizzaToPizzaShopBranch);

         //Finally save to the db
         pizzaShoppeContext.SaveChanges();
      }
   }
}
