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
                        try
                        {
                            Console.Write("Email Address: ");
                            var emailAddress = Console.ReadLine();
                            var accountTypes = Enum.GetNames(typeof(TypeOfAccounts));
                            for (int i = 0; i < accountTypes.Length; i++)
                            {
                                Console.WriteLine($"{i}. {accountTypes[i]}");
                            }
                            Console.Write("Account Type: ");
                            var accountTypeOption = Convert.ToInt32(Console.ReadLine());
                            var accountType = (TypeOfAccounts)Enum.Parse(typeof(TypeOfAccounts), accountTypes[accountTypeOption]);
                            Console.Write("Initial Deposit: ");
                            var ammount = Convert.ToDecimal(Console.ReadLine());
                            var account = Bank.CreateAccount(emailAddress, accountType, ammount);
                            Console.WriteLine($"AN: {account.AccountNumber}, B: {account.Balance:C}, AT: {account.AccountType}");
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine($"invalid data, please try again. {ex.Message}");
                        }
                        catch (ArgumentNullException ax)
                        {
                            Console.WriteLine($"you must input an email address {ax.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"something went wrong {ex.Message}");
                        }
                        break;
                    case "2":
                        printAllAccounts();
                        try { 
                        Console.WriteLine("Accounts number to deposit into: ");
                        var anum = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("ammount to deposit: ");
                        var ammountToDeposit = Convert.ToInt32(Console.ReadLine());
                        Bank.Deposit(anum, ammountToDeposit);
                            }
                        catch(FormatException ex)
                        {
                            Console.WriteLine($"invalid data, please try again. {ex.Message}");
                        }
                        catch(NullReferenceException ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                        }
                        
                        Console.WriteLine("deposit was successful");
                        break;
                    case "3":
                        printAllAccounts();
                        try
                        {
                            Console.Write("Accounts number to withdraw from: ");
                            var anum = Convert.ToInt32(Console.ReadLine());
                            Console.Write("ammount to withdraw: ");
                            var ammountToDeposit = Convert.ToInt32(Console.ReadLine());
                            Bank.Withdraw(anum, ammountToDeposit);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine($"invalid data, please try again. {ex.Message}");
                        }
                        catch (NullReferenceException ex)
                        {
                            Console.WriteLine($"{ex.Message}");
                        }
                        Console.WriteLine("deposit was successful");
                        break;
                    case "4":
                        printAllAccounts();
                        break;
                    default:
                        break;
                }
            }
        }

        private static void printAllAccounts()
        {
            var accounts = Bank.getAllAccounts();
            foreach (var acnt in accounts)
            {
                Console.WriteLine($"AN: {acnt.AccountNumber}, B: {acnt.Balance:C}, AT: {acnt.AccountType}");
            }
        }
    }
}
