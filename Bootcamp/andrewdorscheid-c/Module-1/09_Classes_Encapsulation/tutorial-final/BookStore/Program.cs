using System;

namespace BookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Tech Elevator Bookstore");
            Console.WriteLine();

            // Step Three: Test the properties
            Book twoCities = new Book();
            twoCities.Title = "A Tale of Two Cities";
            twoCities.Author = "Charles Dickens";
            twoCities.Price = 14.99;
            //Console.WriteLine("Title: " + twoCities.Title + ", Author: " + twoCities.Author + ", Price: $" + twoCities.Price);
            Console.WriteLine(twoCities.BookInfo());

            // Step Five: Test the Book constructor
            Book threeMusketeers = new Book("The Three Musketeers", "Alexandre Dumas", 12.95);
            Book childhoodEnd = new Book("Childhood's End", "Arthur C. Clark", 5.99);
            //Console.WriteLine("Title: " + threeMusketeers.Title + ", Author: " + threeMusketeers.Author + ", Price: $" + threeMusketeers.Price);
            //Console.WriteLine("Title: " + childhoodEnd.Title + ", Author: " + childhoodEnd.Author + ", Price: $" + childhoodEnd.Price);
            Console.WriteLine(threeMusketeers.BookInfo());
            Console.WriteLine(childhoodEnd.BookInfo());

            // Step Nine: Test the ShoppingCart class
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.Add(twoCities);
            shoppingCart.Add(threeMusketeers);
            shoppingCart.Add(childhoodEnd);
            Console.WriteLine(shoppingCart.PrintReceipt());
        }
    }
}
