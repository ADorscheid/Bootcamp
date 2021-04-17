using MenuFramework;
using States.Classes;
using System;
using System.Collections.Generic;
using System.IO;

namespace States.CLI
{
    /// <summary>
    /// MainMenu is-a Console Menu (from ConsoleMenuFramework). It is the main user interface.
    /// </summary>
    class MainMenu : ConsoleMenu
    {
        private const string US_FILE = @"..\..\..\USSSStates.txt";
        private const string CANADA_FILE = "..\\..\\..\\CanadianProvinces.txt";

        private string stateOrProvince = "state";

        // Declare and create a dictionary to hold state codes and names
        private StateDictionary stateCodes;

        /// <summary>
        /// In the constructor of a ConsoleMenu, we usually declare the options that will be on the menu,
        /// and point those options to methods which will be invoked when the user selects each option.
        /// </summary>
        public MainMenu()
        {
            // TODO 03: Examine the main menu

            // These are the menu options. the ".AddOption" syntax is called "chaining" of commands.
            AddOption("Choose Input File", SelectInputFile)
                .AddOption("Find a state", FindState)
                .AddOption("List states", ListStates)
                .AddOption("Exit", Exit);

            // Configure is how we can customize menu style, colors, etc.
            Configure(config =>
            {
                config.ItemForegroundColor = ConsoleColor.Green;                // Color of the menu items
                config.SelectedItemBackgroundColor = ConsoleColor.DarkGreen;    // Bgd color of the selected item
                config.SelectedItemForegroundColor = ConsoleColor.White;        // fgd color of the selected item
                config.Title = "State Code Lookup";                             // Menu title, displayed before the menu by default.
            });
            // We default to loading US States
            LoadStates();
        }

        private MenuOptionResult SelectInputFile()
        {
            // TODO 04: Exmine the "on-the-fly" menu that prompts the user to select a file to load

            // Using ConsoleMenu, we can also create menus "on-the-fly". We don't *need* to create
            // a subclass...instead we can create a ConsoleMenu and set all its options.
            // This menu lets the user select either States or Provinces.
            ConsoleMenu loadMenu = new ConsoleMenu()
            .AddOption("US States", LoadStates, "U")
            .AddOption("Canadian Provinces", LoadProvinces, "C")
            .AddOption("Quit", Exit, "Q")
            .Configure(config =>
            {
                config.ItemForegroundColor = ConsoleColor.Cyan;
                config.SelectedItemBackgroundColor = ConsoleColor.DarkCyan;
                config.SelectedItemForegroundColor = ConsoleColor.White;
                config.Title = "Load Input File";
                config.MenuSelectionMode = MenuSelectionMode.KeyString; // In this mode, the user types a key to select an option
                config.KeyStringTextSeparator = ": ";
            });

            // Display the menu
            loadMenu.Show();

            // Now re-draw this "Main" menu
            return MenuOptionResult.DoNotWaitAfterMenuSelection;
        }

        /// <summary>
        /// Called when the user Selects to Load the US States file
        /// </summary>
        /// <returns></returns>
        private MenuOptionResult LoadStates()
        {
            // Load the appropriate data file 
            if (LoadStateDictionary(US_FILE))
            {
                stateOrProvince = "state";
                return MenuOptionResult.CloseMenuAfterSelection;
            }
            else
            {
                return MenuOptionResult.WaitThenCloseAfterSelection;
            }
        }

        /// <summary>
        /// Called when the user Selects to Load the Canadian Provinces file
        /// </summary>
        /// <returns></returns>
        private MenuOptionResult LoadProvinces()
        {
            // Load the appropriate data file 
            if (LoadStateDictionary(CANADA_FILE))
            {
                stateOrProvince = "province";
                return MenuOptionResult.CloseMenuAfterSelection;
            }
            else
            {
                return MenuOptionResult.WaitThenCloseAfterSelection;
            }
        }

        /// <summary>
        /// This method reads a text file which contains district (state/province) information for a country
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool LoadStateDictionary(string fileName)
        {
            List<State> stateList = new List<State>();

            // TODO 12: Add exception handling so the program does not blow up with file error
            try
            {

                // TODO 11: Open the file, read each line, parse it, and load up a list of states.
                using (StreamReader reader = new StreamReader(fileName))
                {
                    while (!reader.EndOfStream)
                    {
                        // Read the next line
                        string input = reader.ReadLine();

                        // Split the line into individual fields
                        string[] fields = input.Split("|");

                        string stateName = fields[0];
                        string stateCode = fields[1];
                        string capital = fields[2];
                        string largest = fields[3];

                        State state = new State(stateCode, stateName, capital, largest);
                        stateList.Add(state);

                    }
                }

                // Now load this collection into a StateDictionary
                this.stateCodes = new StateDictionary(stateList);
                return true;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Unable to load data file {ex.FileName}. Error was {ex.Message}.");
                this.stateCodes = new StateDictionary(new List<State>());
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"File load failed with error {ex.Message}");
                this.stateCodes = new StateDictionary(new List<State>());
                return false;
            }
        }

        /// <summary>
        /// Prompt the user for a state code and look it up.
        /// </summary>
        /// <returns></returns>
        private MenuOptionResult FindState()
        {
            // TODO 05: Examine FindState to lookup a user-entered state code

            // ConsoleMenu includes a bunch of static "Helper" functions for user input, such as 
            // GetString, GetInteger, GetDate, etc.
            string stateCode = GetString($"Please enter a {stateOrProvince} code (Enter to cancel)", true);

            if (stateCode == "")
            {
                return MenuOptionResult.DoNotWaitAfterMenuSelection;
            }

            // Lookup the given state code in the State Dictionary
            if (this.stateCodes.ContainsKey(stateCode))
            {
                State state = this.stateCodes[stateCode];
                Console.WriteLine($"The name of the state with code '{stateCode}' is {state.Name}. Its capital is {state.Capital}, and the its largest city is {state.LargestCity}.");
            }
            else
            {
                Console.WriteLine($"Code '{stateCode}' was not found");
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        /// <summary>
        /// Prompt the user for a "start-with" string and look for matching states.
        /// </summary>
        /// <returns></returns>
        private MenuOptionResult ListStates()
        {
            // TODO 06: Examine ListState to find a state that start with a value.
            string startsWith = ConsoleMenu.GetString($"Find {stateOrProvince}s that start with (Enter for all)", true);

            foreach (State val in stateCodes.Values)
            {
                if (val.Name.StartsWith(startsWith, StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine($"\t{val.StateCode} {val.Name}");
                }
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }
    }
}
