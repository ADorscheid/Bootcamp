using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class QuantityException : Exception
    {
        public string CodeSelection { get; set; }

        public string ProductName { get; set; }
        public QuantityException(string message, string codeSelection, string productName) : base(message)
        {
            //Keep track of the code and the product name
            this.CodeSelection = codeSelection;
            this.ProductName = productName;
            
        }
    }

    public class IdentifierException : Exception
    {
        public string CodeSelection { get; set; }
        public IdentifierException(string message, string codeSelection) : base(message)
        {
            //Keep track of the code and the product name
            this.CodeSelection = codeSelection;
        }
    }

    public class MoneyException: Exception
    {
        public string CodeSelection { get; set; }
        public MoneyException(string message, string codeSelection) : base(message)
        {
            //Keep track of the code and the product name
            this.CodeSelection = codeSelection;
        }
    }

}
