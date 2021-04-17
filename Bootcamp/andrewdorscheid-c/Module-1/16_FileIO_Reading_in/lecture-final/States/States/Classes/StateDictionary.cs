using System;
using System.Collections.Generic;

namespace States.Classes
{
    // TODO 02: Examine this specialized Dictionary just for holding StateCodes & State objects

    /// <summary>
    /// StateDictionary "is-a" Dictionary. We call the constructor that makes the dictionary case-insensitive
    /// </summary>
    class StateDictionary : Dictionary<string, State>
    {
        // Our constructor accepts an IEnumerable of States, which we will load into ourselves (this - a dictionary).
        // Our constructor calls the base constructor passing an argument to make it case-insensitive.
        public StateDictionary(IEnumerable<State> states) : base(StringComparer.InvariantCultureIgnoreCase)
        {
            foreach (State state in states)
            {
                this.Add(state.StateCode, state);
            }
        }
    }
}
