using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class VendingMachine
    {
        private double Balance { get; set; }
        private Dictionary<string, Product> CurrentProductStock { get; set; }  
        private Dictionary<string, int> SalesReport = new Dictionary<string, int>();
        private double TotalSales;
        public string ReadPath { get; set; }
        public string PurchaseLogPath { get; set; }
        public string SalesReportPath { get; set; }
        public VendingMachine(double balance)
        {
            this.Balance = balance;
            CurrentProductStock = new Dictionary<string, Product>();
        }

        public VendingMachine(double balance, string readPath, string purchaseLogPath, string salesReportPath)
        {
            this.Balance = balance;
            CurrentProductStock = new Dictionary<string, Product>();
            this.ReadPath = readPath;
            this.PurchaseLogPath = purchaseLogPath;
            this.SalesReportPath = salesReportPath;
        }

        public void Restock()
        {
            try
            {
                using (StreamReader sr = new StreamReader(this.ReadPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] lineArray = line.Split("|");
                        Product product = new Product(lineArray[1], double.Parse(lineArray[2]), lineArray[3]);
                        CurrentProductStock.Add(lineArray[0], product);
                        SalesReport.Add(product.Name, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public double FeedMoney(int deposit)
        {
            double balanceBefore = this.Balance;
            this.Balance += deposit;
            this.PurchaseLog("FEED MONEY:", "", balanceBefore);
            return this.Balance;
        }

        public double GetBalance()
        {
            return this.Balance;
        }

        public void GetInventory()
        {
            foreach (KeyValuePair<string, Product> kvp in this.CurrentProductStock)
            {
                string quantity = "";
                if (kvp.Value.Quantity == 0)
                {
                    quantity = "SOLD OUT";
                }
                else
                {
                    quantity = kvp.Value.Quantity.ToString();
                }
                Console.WriteLine($"{kvp.Key,-4}{kvp.Value.Name,-25}{quantity,4}{kvp.Value.Price,7:C2}");
            }
        }

        public void Dispense(string key)
        {
            if (this.Balance >= this.CurrentProductStock[key].Price)
            {
                // balance before the dispense
                double balanceBefore = this.Balance;

                Console.WriteLine("\n*Clunk Clunk*");
                // update quantity for dispensing
                this.CurrentProductStock[key].Quantity -= 1;

                // display consumption message
                Console.WriteLine(this.CurrentProductStock[key].ConsumptionMessage);

                // update balance
                this.Balance -= this.CurrentProductStock[key].Price;

                // add the dispense into the log
                this.PurchaseLog(this.CurrentProductStock[key].Name, key, balanceBefore);

                // update sales report.  increment the counter
                SalesReport[this.CurrentProductStock[key].Name]++;
                TotalSales += this.CurrentProductStock[key].Price;

            }
            else
            {
                throw new MoneyException("Money Exception", key);
            }
        }

        public int[] FinishTransaction()
        {
            int[] change = new int[3];
            double quarter = 0.25;
            int quarters = 0;
            double nickel = 0.05;
            int nickels = 0;
            double dime = 0.10;
            int dimes = 0;
            decimal finishBalance = (decimal)this.Balance;

            double balanceBefore = this.Balance;

            if (finishBalance !=0 )
            {
                quarters = (int)(finishBalance / (decimal)quarter);
                finishBalance -= (decimal)(quarters*quarter);
                dimes = (int)(finishBalance / (decimal)dime);
                finishBalance -= (decimal)(dimes*dime);
                nickels = (int)(finishBalance / (decimal)nickel);
                finishBalance -= (decimal)(nickels*nickel);
                this.Balance = 0;

                change[0] = quarters;
                change[1] = dimes;
                change[2] = nickels;

                // log the give change
                this.PurchaseLog("GIVE CHANGE:","", balanceBefore);

                decimal sum = (decimal)(quarters * quarter + dimes * dime + nickels * nickel);
                //Console.WriteLine($"Your Change is: {quarters} quarters, {dimes} dimes, {nickels} nickels, or {sum:C2}");
                
            }
                return change;
        }

        public void PurchaseLog(string method, string identifer, double balanceBefore)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(this.PurchaseLogPath,true))
                {
                    DateTime now = DateTime.Now;
                    sw.WriteLine($"{now} {method} {identifer} {balanceBefore:C2} {this.Balance:C2}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void WriteSalesReport()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(this.SalesReportPath))
                {
                    foreach (KeyValuePair<string,int> kvp in SalesReport)
                    {
                        sw.WriteLine($"{kvp.Key}|{kvp.Value}");
                    }
                    sw.WriteLine($"\nTOTAL: {this.TotalSales:C2}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void VerifyKey(string key)
        {
            if (this.CurrentProductStock.ContainsKey(key))
            {
                if (this.CurrentProductStock[key].Quantity != 0)
                {
                    this.Dispense(key);
                }
                else
                {
                    throw new QuantityException("Quantity Exception", key, this.CurrentProductStock[key].Name);
                }
            }
            else 
            {
                throw new IdentifierException("Identifier Exception", key);
            }
            
        }

        public Dictionary<string,Product> GetDictionary()
        {
            //protecting the original dictionary
            return new Dictionary<string, Product>(this.CurrentProductStock);
            //return this.CurrentProductStock;
        }
    }   
}
