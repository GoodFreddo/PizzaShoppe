using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaShoppe.DAL.Repositories;
using PizzaShoppe.Models;

namespace PizzaShoppe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {

        private IPizzaRepository _pizzaRepository;
        private readonly ILogger<PizzaController> _logger;

        public PizzaController(ILogger<PizzaController> logger, IPizzaRepository pizzaRepository)
        {
            _logger = logger;
            _pizzaRepository = pizzaRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Pizza>> GetPizzas()
        {
            return await _pizzaRepository.GetAllPizzas();
        }

        [HttpGet("{pizzaId}")]
        public async Task<Pizza> GetPizzaById(int pizzaId)
        {
            return await _pizzaRepository.GetPizza(pizzaId);
        }
    }
}
