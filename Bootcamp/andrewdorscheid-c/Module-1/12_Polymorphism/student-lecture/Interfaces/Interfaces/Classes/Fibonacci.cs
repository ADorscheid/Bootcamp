using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Classes
{
    public class Fibonacci : IEnumerable
    {
        public int MaxNumber { get; }
        public Fibonacci(int maxNumber)
        {
            this.MaxNumber = maxNumber;
        }
        public IEnumerator GetEnumerator()
        {
            return new FibonacciEnumerator(this.MaxNumber);
        }

        private class FibonacciEnumerator : IEnumerator
        {
            public FibonacciEnumerator(int maxNumber)
            {
                this.maxNumber = maxNumber;
            }
            private int maxNumber;
            private int lastNumber = 0;
            private int currentNumber = 0;
            public object Current
            {
                get
                {
                    return currentNumber;
                }
            }

            public bool MoveNext()
            {
                if (this.lastNumber == 0 && this.currentNumber == 0)
                {
                    // This is the first in the sequence (1).
                    this.currentNumber = 1;
                }
                else
                {
                    // "cascade" the next and last numbers to keep moving down the sequence
                    int current = this.currentNumber;
                    this.currentNumber = this.lastNumber + current;
                    this.lastNumber = current;
                }
                return (this.currentNumber <= this.maxNumber);
            }

            public void Reset()
            {
                this.lastNumber = 0;
                this.currentNumber = 0;
            }
        }
    }

}
