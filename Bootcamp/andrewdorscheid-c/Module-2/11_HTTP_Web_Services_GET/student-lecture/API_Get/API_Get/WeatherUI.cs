using System;
using System.Collections.Generic;
using System.Text;

namespace API_Get
{
    public class WeatherUI
    {
        public void Run()
        {
            WeatherAPI api = new WeatherAPI();
            while (true)
            {
                Console.Write("Enter ZIP Code: ");
                string zip = Console.ReadLine();
                if (zip.Trim().Length == 0)
                {
                    break;
                }
                CurrentWeather weather = api.GetCurrentWeather(zip);
                if (weather.cod != 200)
                {
                    Console.WriteLine($"No weather information found for '{zip}'");
                    continue;
                }
                Console.Clear();
                Console.WriteLine(@$"
Current weather in {weather.name} (ZIP: {zip}): 
    Temperature: {weather.main.temp}F ({weather.main.temp_max}/{weather.main.temp_min})
    Humidity: {weather.main.humidity}%
    Feels like: {weather.main.feels_like}F
"
                    );
            }
        }

    }
}
