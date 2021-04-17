using System;
using System.Collections;
using System.Text;

namespace Interfaces.Classes
{
    public class Sentence : IEnumerable
    {
        private IEnumerator enumerator;

        public Sentence(string sentence)
        {
            enumerator = new SentenceEnumerator(sentence);
        }

        public IEnumerator GetEnumerator()
        {
            this.enumerator.Reset();
            return this.enumerator;
        }
    }



    public class SentenceEnumerator : IEnumerator
    {
        private string sentence;
        private string[] words;
        int index;
        public SentenceEnumerator(string sentence)
        {
            this.sentence = sentence;
            this.words = sentence.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            this.Reset();
        }

        public object Current
        {
            get
            {
                if (index < words.Length)
                {
                    return this.words[this.index];
                }
                else
                {
                    return "";
                }
            }
        }

        public bool MoveNext()
        {
            if (index < words.Length-1)
            {
                index++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            this.index = -1;
        }
    }
}
