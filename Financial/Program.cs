﻿using System;

namespace Financial
{
    class Program
    {
        static void Main(string[] args)
        {
            var Account = Constructor.CreateAccount("testc@test.com", "nathan", "schirle");

            Console.WriteLine($"AN: {Account.AccountNumber}, B: {Account.FirstName}, N: {Account.LastName}, em: {Account.EmailAddress}");
        }
    }
}
