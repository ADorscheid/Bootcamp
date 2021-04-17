using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Classes
{
    /// <summary>
    /// Returns the successive digits of an integer, in any base (from 2-16), to be consumed by a foreach
    /// </summary>
    public class Digits : IEnumerable
    {
        private IEnumerator enumerator;

        /// <summary>
        /// Contructs a Digits object
        /// </summary>
        /// <param name="decimalNumber">The number to represent</param>
        /// <param name="baseNumber">The numbering system base (2-16)</param>
        public Digits(int decimalNumber, int baseNumber = 10)
        {
            if (baseNumber < 2 || baseNumber > 16)
            {
                throw new ArgumentException("Base for new Digits must be between 2 and 16");
            }
            this.enumerator = new DigitsEnumerator(decimalNumber, baseNumber);
        }

        /// <summary>
        /// Gets the enumerator for the IEnumerable interface
        /// </summary>
        /// <returns>An Enumerator</returns>
        public IEnumerator GetEnumerator()
        {
            this.enumerator.Reset();
            return this.enumerator;
        }

        private class DigitsEnumerator : IEnumerator
        {
            static char[] digitChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            private int startingNumber;
            private int remainingNumber;
            private int baseNumber;
            private int nextPower;
            private int currentDigit = 0;
            public DigitsEnumerator(int decimalNumber, int baseNumber)
            {
                this.startingNumber = decimalNumber;
                this.baseNumber = baseNumber;
                Reset();
            }

            public object Current
            {
                get
                {
                    return digitChars[currentDigit];
                }
            }

            public bool MoveNext()
            {
                if (nextPower == 0)
                {
                    return false;
                }
                this.currentDigit = remainingNumber / nextPower;
                this.remainingNumber = remainingNumber % nextPower;
                this.nextPower /= baseNumber;
                return true;
            }

            private int FindLargestBaseNumber()
            {
                //Find the largest power of baseNumber that fits inside remainingNumber
                int largest = 1;
                for (int i = 1; i <= this.remainingNumber; i *= baseNumber)
                {
                    largest = i;
                }
                return largest;
            }

            public void Reset()
            {
                this.remainingNumber = this.startingNumber;
                this.nextPower = FindLargestBaseNumber();
            }
        }
    }

}
