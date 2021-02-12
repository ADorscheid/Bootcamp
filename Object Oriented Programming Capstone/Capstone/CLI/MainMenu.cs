using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.CLI
{
    public class MainMenu : ConsoleMenu
    {
        /*******************************************************************************
         * Private data:
         * Usually, a menu has to hold a reference to some type of "business objects",
         * on which all of the actions requested by the user are performed. A common 
         * technique would be to declare those private fields here, and then pass them
         * in through the constructor of the menu.
         * ****************************************************************************/

        // NOTE: This constructor could be changed to accept arguments needed by the menu

        public VendingMachine VendingMachine;
        public MainMenu(VendingMachine vendingMachine)
        {
            this.VendingMachine = vendingMachine;
            AddOption("(1) Display Vending Machine Items", DisplayVendingMachine);
            AddOption("(2) Purchase", Purchase);
            AddOption("(3) Exit", Exit);


            Configure(cfg =>
           {
               cfg.ItemForegroundColor = ConsoleColor.Cyan;
               cfg.MenuSelectionMode = MenuSelectionMode.Arrow; // KeyString: User types a key, Arrow: User selects with arrow
               cfg.KeyStringTextSeparator = ": ";
               cfg.Title = "Main Menu";
           });
        }

        private MenuOptionResult Purchase()
        {
            PurchaseMenu purchaseMenu = new PurchaseMenu(this.VendingMachine);
            purchaseMenu.Show();
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult DisplayVendingMachine()
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
            Console.WriteLine($"{"Slot",-7}{"Product Name",-25}{"QTY",4}{"Price",7:C2}");
            Console.WriteLine($"{"===========================================",-43}");
            foreach (KeyValuePair<string, Product> kvp in this.VendingMachine.GetDictionary())
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

            return MenuOptionResult.WaitAfterMenuSelection;
        }
    }
}
