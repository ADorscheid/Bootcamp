using System.Collections.Generic;

namespace BookStore
{
    public class ShoppingCart
    {
        private List<Book> booksToBuy = new List<Book>();

        public void Add(Book newBook)
        {
            booksToBuy.Add(newBook);
        }

        public double TotalPrice
        {
            get
            {
                double total = 0;
                foreach (Book book in booksToBuy)
                {
                    total += book.Price;
                }
                return total;
            }
        }


        public string PrintReceipt()
        {
            string receipt = "\nReceipt\n";
            foreach (Book book in booksToBuy)
            {
                receipt += book.BookInfo();
                receipt += "\n";
            }

            receipt += "\nTotal: $" + TotalPrice;

            return receipt;
        }
    }
}