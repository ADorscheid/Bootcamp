using Capstone.CLI;
using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class PurchaseMenu : ConsoleMenu
    {
        public VendingMachine vendingMachine;
        public PurchaseMenu(VendingMachine vendingMachine)
        {
            this.vendingMachine = vendingMachine;
            AddOption("(1) Feed Money", FeedMoney);
            AddOption("(2) Select Product", SelectProduct);
            AddOption("(3) Finish Transaction", FinishTransaction);
            AddOption("", SalesReport);

            Configure(cfg =>
            {
                cfg.ItemForegroundColor = ConsoleColor.Yellow;
                cfg.MenuSelectionMode = MenuSelectionMode.Arrow; // KeyString: User types a key, Arrow: User selects with arrow
                cfg.KeyStringTextSeparator = ": ";
                cfg.Title = "Purchase Menu";
                cfg.SelectedItemForegroundColor = ConsoleColor.Red;
            });
        }

        protected override void OnAfterShow()
        {
            Console.WriteLine($"\nCurrent Money Provided: {vendingMachine.GetBalance():C2}");
        }

        private MenuOptionResult SalesReport()
        {
            vendingMachine.WriteSalesReport();
            Console.WriteLine("Sales Report Created");
            return MenuOptionResult.WaitAfterMenuSelection;
        }
        private MenuOptionResult FeedMoney()
        {
            bool isValidData = false;
            while (!isValidData)
            {
                try
                {
                    Console.Write("Please insert cash ($1, $2, $5, or $10)(please enter just the number (no $)): ");
                    double balanceBefore = vendingMachine.GetBalance();
                    int money = int.Parse(Console.ReadLine());
                    if (money == 1 || money == 2 || money == 5 || money == 10)
                    {
                        vendingMachine.FeedMoney(money);
                        isValidData = true;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter either $1, $2, $5, or $10");
                }
            }
            return MenuOptionResult.DoNotWaitAfterMenuSelection;

        }

        private MenuOptionResult SelectProduct()
        {
            Console.WriteLine(@" ____________________________________________");
            Console.WriteLine(@"|############################################|");
            Console.WriteLine(@"|#|                           |##############|");
            Console.WriteLine(@"|#|  =====  ..--''`  |~~``|   |##|````````|##|");
            Console.WriteLine(@"|#|  |   |  \     |  :    |   |##| Exact  |##|");
            Console.WriteLine(@"|#|  |___|   /___ |  | ___|   |##| Change |##|");
            Console.WriteLine(@"|#|  /=__\  ./.__\   |/,__\   |##| Only   |##|");
            Console.WriteLine(@"|#|  \__//   \__//    \__//   |##|________|##|");
            Console.WriteLine(@"|#|===========================|##############|");
            Console.WriteLine(@"|#|```````````````````````````|##############|");
            Console.WriteLine(@"|#| =.._      +++     //////  |##############|");
            Console.WriteLine(@"|#| \/  \     | |     \    \  |#|`````````|##|");
            Console.WriteLine(@"|#|  \___\    |_|     /___ /  |#| _______ |##|");
            Console.WriteLine(@"|#|  / __\\  /|_|\   // __\   |#| |1|2|3| |##|");
            Console.WriteLine(@"|#|  \__//-  \|_//   -\__//   |#| |4|5|6| |##|");
            Console.WriteLine(@"|#|===========================|#| |7|8|9| |##|");
            Console.WriteLine(@"|#|```````````````````````````|#| ``````` |##|");
            Console.WriteLine(@"|#| ..--    ______   .--._.   |#|[=======]|##|");
            Console.WriteLine(@"|#| \   \   |    |   |    |   |#|  _   _  |##|");
            Console.WriteLine(@"|#|  \___\  : ___:   | ___|   |#| ||| ( ) |##|");
            Console.WriteLine(@"|#|  / __\  |/ __\   // __\   |#| |||  `  |##|");
            Console.WriteLine(@"|#|  \__//   \__//  /_\__//   |#|  ~      |##|");
            Console.WriteLine(@"|#|===========================|#|_________|##|");
            Console.WriteLine(@"|#|```````````````````````````|##############|");
            Console.WriteLine(@"|############################################|");
            Console.WriteLine(@"|#|||||||||||||||||||||||||||||####```````###|");
            Console.WriteLine(@"|#||||||||||||PUSH|||||||||||||####\|||||/###|");
            Console.WriteLine(@"|############################################|");
            Console.WriteLine(@"\\\\\\\\\\\\\\\\\\\\\\///////////////////////");
            Console.WriteLine(@" |_________________________________ | LVAD |");
            Console.WriteLine("\n");

            //DISPLAY VENDING MACHINE
            Console.WriteLine($"{"Slot",-7}{"Product Name",-25}{"QTY",4}{"Price",7:C2}");
            Console.WriteLine($"{"===========================================",-43}");
            foreach (KeyValuePair<string, Product> kvp in vendingMachine.GetDictionary())
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
                Console.WriteLine($"{kvp.Key,-7}{kvp.Value.Name,-25}{quantity,4}{kvp.Value.Price,7:C2}");
            }


            try
            {
                Console.Write("\nPlease enter a slot identiefer from the list above (ex:A1): ");
                string input = Console.ReadLine().ToUpper();
                if (input.Length > 2)
                {
                    throw new IdentifierException("Identifier Exception", input);
                }
                vendingMachine.VerifyKey(input);
            }
            catch (QuantityException)
            {
                //Could refer to the code from ex.
                Console.WriteLine("Product is SOLD OUT!");
            }
            catch (IdentifierException)
            {
                Console.WriteLine("Identifier not valid");
            }
            catch (MoneyException)
            {
                Console.WriteLine("Not enough money deposited");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult FinishTransaction()
        {
            decimal sum = (decimal)vendingMachine.GetBalance();
            int[] change = vendingMachine.FinishTransaction();
            //return sum in same array
            //TODO - Actually change to get sum
            Console.WriteLine($"Your Change is: {change[0]} quarters, {change[1]} dimes, {change[2]} nickels, or {sum:C2}");
            return Exit();
        }

    }
}
