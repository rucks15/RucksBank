using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sapphire
{
    static class Bank
    {
       

        
        public static Account CreateAccount(string emailAddress, TypeOfAccounts accountType)
        {            
            using (var db = new AccountDB())
            {
                var account = new Account();
                account.EmailAddress = emailAddress;
                account.AccountType = accountType;
                db.Accounts.Add(account);
                db.SaveChanges();
                return account;
            }
        }
       
        public static void PrintAllAccounts(string emailaddress)
        {
            using (var db = new AccountDB())
            {
                foreach (var account in db.Accounts.Where(a=>a.EmailAddress==emailaddress))
                {
                    Console.WriteLine($"AccountNumber:{account.AccountNumber},Account Type:{account.AccountType},Email ID :{account.EmailAddress},Balance:{account.Balance}C");
                }
            }
        }
        
        public static Account GetAccountByAccountNumber(int accno)
        {
            var db = new AccountDB();
            return db.Accounts.Where(a => a.AccountNumber == accno).FirstOrDefault();
        }

        public static void Deposit(decimal amount,int accno)
        {
            var account = Bank.GetAccountByAccountNumber(accno);
            if (account == null)
            {
                Console.WriteLine("sorry,this account number does not exist");
            }
            else
            {
               account.Deposit(amount);
                using (var db = new AccountDB())
                {
                    var transaction = new Transactions();
                    transaction.TransactionDate = DateTime.Now;
                    transaction.TransactionType = TypeOfTransaction.Credit;
                    transaction.StartingBalance =account. Balance;
                    transaction.Amount = amount;
                    transaction.AccountNumber = account.AccountNumber;
                    db.Transactions.Add(transaction);
                    db.SaveChanges();
                }
            }
        }
        public static void withdraw(int accountnumber,decimal amount)
        {
            var account = Bank.GetAccountByAccountNumber(accountnumber);
            if (account == null)
            {
                Console.WriteLine("sorry,this account number does not exist");
                //throw new ArgumentException("Sorry, this account number does not exist");
            }
            else
            {
                account.Withdraw(amount);
                using (var db = new AccountDB())
                {
                    var transaction = new Transactions();
                    transaction.TransactionDate = DateTime.Now;
                    transaction.TransactionType = TypeOfTransaction.Debit;
                    transaction.StartingBalance = account.Balance;
                    transaction.Amount = amount;
                    transaction.AccountNumber = account.AccountNumber;
                    db.Transactions.Add(transaction);
                    db.SaveChanges();
                }
            }

        }
    }
}
