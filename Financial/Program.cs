using System;

namespace Financial
{
    class Program
    {
        static void Main(string[] args)
        {
            var Account = Constructor.CreateAccount("test@test.com", "nathan", "schirle");

            Console.WriteLine($"AN: {Account.AccountNumber}, B: {Account.FirstName}, N: {Account.LastName}, em: {Account.EmailAddress}, {Account.CreatedDate}");

            Constructor.CreateInvestment(40, 120000, 6, 20);

        }
    }
}
