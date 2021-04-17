using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;

namespace API_Get
{
    public class WeatherAPI
    {

        string API_URL = "http://api.openweathermap.org/data/2.5";
        string API_KEY = "b49555ced86dc4c82f40c75e15906a2e";

        public CurrentWeather GetCurrentWeather(string zip)
        {
            //"/weather?zip=44286&appid=api-key"

            RestClient client = new RestClient(API_URL);
            client.Authenticator = new SimpleAuthenticator("appid", API_KEY, "x", "x");

            RestRequest request = new RestRequest($"weather?zip={zip}&units=imperial&appid={API_KEY}", DataFormat.Json);

            //IRestResponse response = client.Get(request);

            IRestResponse<CurrentWeather> weatherResponse = client.Get<CurrentWeather>(request);

            return weatherResponse.Data;
        }

    }
}
