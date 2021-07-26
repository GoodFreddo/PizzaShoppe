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
            if (pizzaShoppeContext.PizzaChains.Count()>0) { return; }
            pizzaShoppeContext.PizzaChains.Add(new PizzaChain() {Name="Big Bob's Pizza" });
            pizzaShoppeContext.SaveChanges();
        }
    }
}
