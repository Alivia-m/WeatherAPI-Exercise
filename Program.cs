using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace WeatherMapProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            Console.WriteLine("Welcome to OpenWeatherMap API");
            Console.WriteLine("__________________________________________");
            Console.WriteLine("To access this data please enter your API Key");

            var key = Console.ReadLine();
            while(true)
            {
                Console.WriteLine("");
                Console.WriteLine("Please enter a city");
                var city = Console.ReadLine();

                var WeatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=imperial&appid={key}";
                var response = client.GetStringAsync(WeatherURL).Result;
                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();

                Console.WriteLine($"{formattedResponse}");
            }
        }
    }
}
