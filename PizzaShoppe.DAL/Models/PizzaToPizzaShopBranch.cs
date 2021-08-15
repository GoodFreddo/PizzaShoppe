using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaShoppe.DAL.Models
{
    public class PizzaToPizzaShopBranch
    {
        public int PizzaShoppeBranchId { get; set; }
        public PizzaShoppeBranch PizzaShoppeBranch { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
    }
}
