using Capstone.CLI;
using System;
using System.IO;

namespace Capstone
{
    class Program
    {
        /****************************************************************************************
         * Notes on this Capstone solution:
         *      This solution contains both a project for the Vending Machine program (Capstone)
         *      and a project for tests (CapstoneTests). The Test project already references the
         *      Capstone project, so all you need to do is add Test Classes and Test Methods.
         *      
         *      ConsoleMenuFramework has been added via Nuget, so the project is ready to derive
         *      new menus. There is already a sample menu in the CLI folder. You can rename this 
         *      one, or create a new one to get started.
         * 
         * *************************************************************************************/
        static void Main(string[] args)
        {
            //paths for the writing and reading of the documents
            string readingPath = @"..\..\..\..\vendingmachine.csv";
            string purchaseLogPath = @"..\..\..\..\Log.txt";

            //unique path made everytime based on datetime for the salesreport file
            DateTime time = DateTime.Now;
            string timeString = time.ToString();
            timeString = timeString.Replace(@":", ".");
            timeString = timeString.Replace("/", ".");
            string salesReportPath = @"..\..\..\..\SalesReport " + timeString + ".txt";

            // You may want to create some objects to get the whole process started here...
            VendingMachine vendingMachine = new VendingMachine(0, readingPath,purchaseLogPath,salesReportPath);

            //stock the vending machine
            vendingMachine.Restock();

            // Some objects could be passed into the menu constructor, so that the menu has something to 
            // perform its actions against....
            MainMenu mainMenu = new MainMenu(vendingMachine);

            //delete old purchase log
            string[] oldFiles = Directory.GetFiles(@"..\..\..\..\",@"*Log*");
            foreach (string file in oldFiles)
            {
                File.Delete(file);
            }

            mainMenu.Show();
        }
    }
}
