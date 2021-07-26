using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShoppe.DAL.Models
{
    public class PizzaShoppeBranch
    {
        public int Id { get; set; }
        public string Address { get; set; }

        public List<Pizza> Pizzas { get; set; }

    }
}
