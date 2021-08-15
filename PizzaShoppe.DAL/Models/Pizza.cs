using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShoppe.DAL.Models
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public int Temperature { get; set; }
        public List<PizzaShoppeBranch> PizzaShoppeBranches { get; set; }
    }
}
