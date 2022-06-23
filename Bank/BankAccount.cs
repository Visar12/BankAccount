using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class BankAccount
    {
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

        private static int accountNumberSeed = 080803;


        private List<Transaction> allTransactions= new List<Transaction>();

        public BankAccount(string name,decimal initalBalance)
        {
            Owner = name;
            MakeDeposit(initalBalance, DateTime.Now, "initual balance");
            Number =accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            //hvis  amount er midnre end 0 hvis jeg prøver at sæte negative penge  
            if (amount <= 0)
            {

                // throw new Arguments- Arguemt er (decimal amount, DateTime date, string note)
                // Så den sørger for at amount  skal være højre  eller  lige med 0 
                //hvis den er mindre end 0 så er den negative og vi throw  exception  så exeption stopper programet
                // ligesom hvis du vil gerne hæve   -10 kr   fra en hæveautomat så vil  der ske en fejl   så  der er  hvad man kalder en exeptional situation
                throw new ArgumentException(nameof(amount), "Amount of deposit must be positive");
                    }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }


        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {  
           
            if (amount <= 0)
            {
           
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive ");

            }
            // hvis beløbet du hæver vil gør at din saldo vil være 0 
            if (Balance - amount < 0)
            {
                //hvis du  laver en throw så ville programet stop det 
                throw new InvalidOperationException("Not sufficient funds for this withdrawal ");
            }
            // så nu alle funktioner ville stop så vi ikke forlader bare  if statment  og fordi den der throw er der  den ville gør at vi forlade programmet 
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }
        public string GetAccountHistory()
        {
            var report = new StringBuilder();
            report.AppendLine("Date\tAmmount\t Note");
            foreach (var item in allTransactions)
            {
                report.AppendLine($"{item.Date}\t{item.Amount}\t{item.Notes}");
            }
            return report.ToString();
        }
    }
}

