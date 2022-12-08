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

            //
            try
            {
                account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }

            //Test for negative balance:
            BankAccount invalidAccount;
            try
            {
                invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
                return;
            }
        }
    }
}


//https://www.youtube.com/watch?v=INfLHh3TDkk