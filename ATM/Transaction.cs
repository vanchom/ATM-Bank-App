using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK
{
    public class Transaction
    {
        private string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }

        public Transaction(string accountNumber, decimal amount,DateTime date,string notes)
        {
            AccountNumber = accountNumber;
            Amount = amount;
            Date = date;
            Notes = notes;
        }
    }
}
