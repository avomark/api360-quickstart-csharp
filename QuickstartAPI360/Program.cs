using System;
using RestSharp;

namespace QuickstartAPI360
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("== Quickstart API360 Avomark ==");
            Console.WriteLine("Welcome, before continuing, check that you have added your credentials in APICalss.cs");

            APICalls api = new APICalls();

            Console.WriteLine("Enter a card number : ");
            string card = Console.ReadLine();
            api.GetCardByNumber(card);

            Console.WriteLine("Enter a customer ID : ");
            int customerId = int.Parse(Console.ReadLine());
            api.GetCustomerById(customerId);
        }
    }
}
