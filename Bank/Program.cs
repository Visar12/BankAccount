using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var account =new BankAccount("kendra ",10000);
            Console.WriteLine($"Account {account.Number} was created  for {account.Owner} with {account.Balance}.");
         
            account.MakeWithdrawal(120, DateTime.Now, "Nike");
            Console.WriteLine(account.Balance);

            account.MakeDeposit(120, DateTime.Now, "stealing");
          
            account.MakeWithdrawal(50, DateTime.Now, "Sko");
            Console.WriteLine(account.Balance);

            Console.WriteLine(account.GetAccountHistory());
          
            //try
            //{
            //    account.MakeWithdrawal(120, DateTime.Now, "Attempt to make A withdrawl");
            //}
            //catch (ArgumentOutOfRangeException e)
            //{
            //    Console.WriteLine("Exception caught creating account with negative balance ");
            //    Console.WriteLine(e.ToString());
            //}
          
            Console.ReadLine();
        }
    }
}
