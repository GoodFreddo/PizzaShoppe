using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShoppe.DAL.Models
{
    public class PizzaChain
    {
        public int PizzaChainId { get; set; }
        public string Name { get; set; }
        public List<PizzaShoppeBranch> PizzaShoppeBranches { get; set; }

    }
}
