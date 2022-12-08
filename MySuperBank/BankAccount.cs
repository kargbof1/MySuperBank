using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySuperBank
{
    public class BankAccount
    {
        //Properties:
        //Bank Account Number
        //Bank Account Owner
        //Bank Account Balance
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;


                }

                return balance;
            }
        }
        private static int accountNumberSeed = 123456789;
        private List<Transaction> allTransactions=new List<Transaction>();

        //Construct creates an individual 
        //Construct a bank account
        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            MakeDeposit(initialBalance,DateTime.Now,"Initial Balance");
            this.Number=accountNumberSeed.ToString();
            accountNumberSeed++;

        }

        //Methods and Functions:
        //Deposits
        //Withdrawals

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

    }
}
