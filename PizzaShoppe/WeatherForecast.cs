using System;

namespace PizzaShoppe
{

   //TODO: Make this not about the weather and about pizza.
   //TODO: Inject the IPizzaRepository into the constructor of the controller.

    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
