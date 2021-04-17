namespace States.Classes
{
    // TODO 01: Examine the State class which holds information about each state / province.
    class State
    {
        public string StateCode { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public string LargestCity { get; set; }

        public State(string stateCode, string name, string capital, string largestCity)
        {
            this.StateCode = stateCode;
            this.Name = name;
            this.Capital = capital;
            this.LargestCity = largestCity;
        }

    }
}
