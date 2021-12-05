using System;

namespace BANK
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Bank";

            Console.Clear();
            Console.WriteLine("Hi Customer. Please enter your name");

            string nameCustomer = Console.ReadLine().ToUpper();

            Console.WriteLine("Please enter your Bank Account");
            string bankAccountNumber = Console.ReadLine();

            Console.WriteLine("Please enter the first deposit");

            decimal firstBalance = decimal.Parse(Console.ReadLine());
            string finalBalance = firstBalance.ToString("n");

            var account = new BankAccount(bankAccountNumber, nameCustomer, firstBalance);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\tWelcome back {nameCustomer}!!,\n\n Your account number is {bankAccountNumber}\n");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("What do you want to do?\n");
            Console.WriteLine("1. Check your Balance");
            Console.WriteLine("2. Make a Deposit");
            Console.WriteLine("3. Make a Widthdraw");
            Console.WriteLine("4. List of Last Transactions");

            string r = Console.ReadLine();

            int request = int.Parse(r);

            switch (request)
            {
                case 1:
                    Console.WriteLine($"You have balance of {account.Balance}");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Please enter your deposit amount");
                    decimal deposits = decimal.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter type of deposit(cash,cheque)");
                    string type = Console.ReadLine();
                    account.MakeDeposit(bankAccountNumber, deposits, DateTime.Now, type);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Your new balance is {account.Balance}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine($"Please enter your widthdrawal amount. Your actual balance is {account.Balance}");
                    decimal widthdraw = decimal.Parse(Console.ReadLine());
                    string note = "";
                    account.MakeWidhdraw(bankAccountNumber, widthdraw, DateTime.Now, note);
                    Console.WriteLine($"Your new balance is {account.Balance}");
                    Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine(account.getAccountHistory());
                    Console.ReadLine();
                    break;
            }

        }
    }
}
