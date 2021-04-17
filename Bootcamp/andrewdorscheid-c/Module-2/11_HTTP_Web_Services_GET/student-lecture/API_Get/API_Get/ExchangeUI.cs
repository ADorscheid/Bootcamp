using System;
using System.Collections.Generic;
using System.Text;

namespace API_Get
{
    public class ExchangeUI
    {
        public void Run()
        {
            ExchangeRateAPI api = new ExchangeRateAPI();
            while (true)
            {
                Console.Write("Enter Currency Code: ");
                string currency = Console.ReadLine();
                if (currency.Trim().Length == 0)
                {
                    break;
                }
                Exchange exchange = api.GetExchange(currency);
                if (exchange.Rates == null)
                {
                    Console.WriteLine($"No currency information found for '{currency}'");
                    continue;
                }
                Console.Clear();
                Console.WriteLine(@$"Base currency: {exchange.Base}:");
                foreach (var kvp in exchange.Rates)
                {
                    Console.WriteLine($"\t{kvp.Key}{kvp.Value,14:n5}");
                }
            }
        }

    }
}
