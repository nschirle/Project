using System;

namespace Financial
{
    class Program
    {
        static void Main(string[] args)
        {
            var Account = new Account("nathan");

            Console.WriteLine($"AN: {Account.AccountNumber}, B: {Account.FirstName}");

            var Account2 = new Account("test");

            Console.WriteLine($"AN: {Account2.AccountNumber}, B: {Account2.FirstName}");
        }
    }
}
