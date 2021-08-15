using Microsoft.EntityFrameworkCore;
using PizzaShoppe.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShoppe.DAL
{
    public class PizzaShoppeContext : DbContext
    {
        public PizzaShoppeContext(DbContextOptions<PizzaShoppeContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<PizzaChain> PizzaChains { get; set; }
        public DbSet<PizzaShoppeBranch> PizzaShoppeBranches { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<PizzaToPizzaShopBranch> PizzaToPizzaShopBranches {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PizzaChain>().HasMany(pizzaChain=>pizzaChain.PizzaShoppeBranches).WithOne(pizzaShoppeBranch=>pizzaShoppeBranch.PizzaChain);
            //modelBuilder.Entity<PizzaShoppeBranch>().HasMany(pizzaShoppeBranch=>pizzaShoppeBranch.Pizzas).WithMany(pizza=>pizza.PizzaShoppeBranches);
            modelBuilder.Entity<PizzaToPizzaShopBranch>().HasKey(pizzaToPizzaShopBranch => new { pizzaToPizzaShopBranch.PizzaShoppeBranchId, pizzaToPizzaShopBranch.PizzaId });

      }
    }
}
