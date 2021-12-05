using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK
{
    class BankAccount
    {
        public string AccountNumber { get; }
        public string Name { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in alltransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        private List<Transaction> alltransactions = new List<Transaction>();
        public BankAccount(string accountNumber, string name, decimal initialBalance)
        {
            this.AccountNumber = accountNumber;
            this.Name = name;
            MakeDeposit(accountNumber, initialBalance, DateTime.Now, "Initial Balance");

        
            
        }

        public void MakeDeposit(string accountNumber, decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount),"Deposit must be positive");
            }
            var deposit = new Transaction(accountNumber, amount, date, note);

            alltransactions.Add(deposit);
        }
        public void MakeWidhdraw(string accountNumber, decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Widhdrawal must be positive");
            }
            if(Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds in your account!");
            }
            var widthdrawal = new Transaction(accountNumber, -amount, date, note);

            alltransactions.Add(widthdrawal);
        }
        public string getAccountHistory()
        {
            var report = new StringBuilder();

            //Header
            report.AppendLine("Date\tAmount\tnotes");
            foreach(var item in alltransactions)
            {
                //Rows
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");
            }
            return report.ToString();
        }
    }
}
