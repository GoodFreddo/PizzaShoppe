using System.Threading.Tasks;
using PizzaShoppe.DAL.Models;

namespace PizzaShoppe.DAL.Repositories
{
   public interface IPizzaRepository
   {
      Task<PizzaShoppe.Models.Pizza> InsertPizza(PizzaShoppe.Models.Pizza pizza);
      Task<PizzaShoppe.Models.Pizza> GetPizza(int pizzaId);
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

         var createdShoppeModelPizza = new PizzaShoppe.Models.Pizza()
         {
            Name = result.Entity.Name,
            Temperature = result.Entity.Temperature,
            PizzaId = result.Entity.PizzaId //TODO: DId this give me the right Id from the DB back
         };

         return createdShoppeModelPizza;
      }

      //TODO: Make an endpoint that can get this using an Id
      public async Task<PizzaShoppe.Models.Pizza> GetPizza(int pizzaId)
      {
         var result = await _context.Pizzas.FindAsync(pizzaId);
         var createdShoppeModelPizza = new PizzaShoppe.Models.Pizza
         {
            Name = result.Name,
            Temperature = result.Temperature,
            PizzaId = result.PizzaId
         };

         return createdShoppeModelPizza;
      }

      //TODO: Do GetAll
      //TODO: Do delete
      //TODO: Do update
      //Special excercise for the "GetPizza(int pizzaId) call, how do you result.PizzaShoppeBranches to not be null when returned?
   }
}
