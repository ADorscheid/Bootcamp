using HTTP_Web_Services_GET_lecture.Views;
using RestSharp;
using System;

namespace HTTP_Web_Services_GET_lecture
{
    class Program
    {
        static readonly string API_URL = "http://localhost:3000";

        static void Main(string[] args)
        {
            new MainMenu(API_URL).Show();
        }
    }
}
