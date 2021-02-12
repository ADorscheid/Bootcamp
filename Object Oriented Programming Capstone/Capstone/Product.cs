using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Product
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ConsumptionMessage
        {
            get
            {
                if (this.Type == "Chip")
                {
                    return "Crunch Crunch, Yum!";
                }
                if (this.Type == "Drink")
                {
                    return "Glug Glug, Yum!";
                }
                if (this.Type == "Candy")
                {
                    return "Munch Munch, Yum!";
                }
                if (this.Type == "Gum")
                {
                    return "Chew Chew, Yum!";
                }
                return "";
            }
        }


        public Product(string name, double price, string type)
        {
            this.Name = name;
            this.Type = type;
            this.Price = price;
            this.Quantity = 5;
        }
    }
}
