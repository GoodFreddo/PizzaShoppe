using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShoppe.DAL.Models
{
    public class PizzaShoppeBranch
    {
        public int PizzaShoppeBranchId { get; set; }
        public string Address { get; set; }
        public PizzaChain PizzaChain { get; set; }
        public List<Pizza> Pizzas { get; set; }
        //TODO: Could have a "DateAdopted"
    }
}
