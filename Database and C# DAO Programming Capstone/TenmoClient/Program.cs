using System;
using System.Collections.Generic;
using TenmoClient.DAL;
using TenmoClient.Data;
using TenmoClient.Views;

namespace TenmoClient
{
    class Program
    {
        private readonly static string API_BASE_URL = "https://localhost:44315/";
        static void Main(string[] args)
        {
            //IAccountDAO accountDao = new AccountApiDAO(API_BASE_URL);
            AuthService authService = new AuthService(API_BASE_URL);
            new LoginRegisterMenu(authService, API_BASE_URL).Show();

            Console.WriteLine("\r\nThank you for using TEnmo!!!\r\n");
        }
    }
}
