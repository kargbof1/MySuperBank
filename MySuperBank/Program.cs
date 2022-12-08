using System;

namespace MySuperBank
{
   public  class program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Fifi",1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}");
            account.MakeWithdrawal(120,DateTime.Now,"Hammock");
            Console.WriteLine(account.Balance);

        }
    }
}

