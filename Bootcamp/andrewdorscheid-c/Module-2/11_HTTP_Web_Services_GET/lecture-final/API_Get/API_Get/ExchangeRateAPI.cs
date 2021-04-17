using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace API_Get
{
    public class ExchangeRateAPI
    {
        string API_URL = "https://api.exchangerate-api.com/v4/latest";
        public Exchange GetExchange(string currency)
        {
            // /latest/USD
            RestClient client = new RestClient(API_URL);
            RestRequest request = new RestRequest($"{currency}", DataFormat.Json);
            //IRestResponse response = client.Get(request);     // This returns json as a string only
            IRestResponse<Exchange> exchangeResponse = client.Get<Exchange>(request);   // This de-serializes json into Exchange
            return exchangeResponse.Data;
        }


    }
}
