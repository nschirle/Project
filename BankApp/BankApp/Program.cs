using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {


                Console.WriteLine("Welcome to the Bank of Nate!");
                Console.WriteLine("Option 0: Exit");
                Console.WriteLine("Option 1: Create an Account");
                Console.WriteLine("Option 2: Deposit Money");
                Console.WriteLine("Option 3: Withdraw Money");
                Console.WriteLine("Option 4: Print all accounts");
                Console.Write("please input an option:");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "0": return;

                    case "1":
                        Console.Write("Email Address: ");
                        var emailAddress = Console.ReadLine();
                        var accountTypes = Enum.GetNames(typeof(TypeOfAccounts));
                        for (int i = 0; i < accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. {accountTypes[i]}");
                        }
                        Console.Write("Account Type: ");
                        var accountTypeOption = Convert.ToInt32(Console.ReadLine());
                        var accountType = (TypeOfAccounts)Enum.Parse(typeof(TypeOfAccounts), accountTypes[accountTypeOption]);
                        Console.Write("Initial Deposit: ");
                        var ammount = Convert.ToDecimal(Console.ReadLine());

                        var account = Bank.CreateAccount(emailAddress, accountType, ammount);
                        Console.WriteLine($"AN: {account.AccountNumber}, B: {account.Balance:C}, AT: {account.AccountType}");
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
