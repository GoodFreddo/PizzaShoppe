using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PizzaShoppe.DAL.Models;

namespace PizzaShoppe.DAL.Repositories
{
    public interface IPizzaRepository
    {
        Task<PizzaShoppe.Models.Pizza> InsertPizza(PizzaShoppe.Models.Pizza pizza);
        Task<PizzaShoppe.Models.Pizza> GetPizza(int pizzaId);
        Task<IEnumerable<PizzaShoppe.Models.Pizza>> GetAllPizzas();
        Task<PizzaShoppe.Models.Pizza> DeletePizza(PizzaShoppe.Models.Pizza pizza);
        Task<PizzaShoppe.Models.Pizza> UpdatePizza(PizzaShoppe.Models.Pizza pizza);
    }

    public class PizzaRepository : IPizzaRepository
    {
        private readonly IPizzaShoppeContext _context;
        public PizzaRepository(IPizzaShoppeContext context)
        {
            _context = context;
        }

        //TODO: Make an endpoint that can do insert
        public async Task<PizzaShoppe.Models.Pizza> InsertPizza(PizzaShoppe.Models.Pizza pizza)
        {
            var pizzaDalModel = new Pizza
            {
                Name = pizza.Name,
                Temperature = pizza.Temperature
            };
            var result = await _context.Pizzas.AddAsync(pizzaDalModel);
            await _context.SaveChangesAsync();
            return ToDtoPizza(result.Entity);
        }

        //TODO: Make an endpoint that can get this using an Id
        public async Task<PizzaShoppe.Models.Pizza> GetPizza(int pizzaId)
        {
            var result = await _context.Pizzas.FindAsync(pizzaId);
            return ToDtoPizza(result);
        }

        public async Task<IEnumerable<PizzaShoppe.Models.Pizza>> GetAllPizzas()
        {
            var result = await _context.Pizzas.ToListAsync();
            var createdShoppeModelPizzaList = new List<PizzaShoppe.Models.Pizza>();
            foreach (var pizza in result)
            {
                createdShoppeModelPizzaList.Add(ToDtoPizza(pizza));
            }

            return createdShoppeModelPizzaList;
        }

        public async Task<PizzaShoppe.Models.Pizza> DeletePizza(PizzaShoppe.Models.Pizza pizza)
        {
            var removedPizza = _context.Pizzas.Remove(ToDbPizza(pizza));
            await _context.SaveChangesAsync();
            var createdShoppeModelPizza = ToDtoPizza(removedPizza.Entity);
            return createdShoppeModelPizza;
        }

        public async Task<PizzaShoppe.Models.Pizza> UpdatePizza(PizzaShoppe.Models.Pizza pizza)
        {
            var updatedPizza = _context.Pizzas.Update(ToDbPizza(pizza));
            await _context.SaveChangesAsync();
            var createdShoppeModelPizza = ToDtoPizza(updatedPizza.Entity);
            return createdShoppeModelPizza;
        }

        private Pizza ToDbPizza(PizzaShoppe.Models.Pizza pizza)
        {
            return new Pizza()
            {
                PizzaId = pizza.PizzaId,
                Name = pizza.Name,
                Temperature = pizza.Temperature
            };
        }

        private PizzaShoppe.Models.Pizza ToDtoPizza(Pizza pizza)
        {
            return new PizzaShoppe.Models.Pizza
            {
                Name = pizza.Name,
                Temperature = pizza.Temperature,
                PizzaId = pizza.PizzaId
            };
        }
        //Special excercise for the "GetPizza(int pizzaId) call, how do you result.PizzaShoppeBranches to not be null when returned?
    }
}
