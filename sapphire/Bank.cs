using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sapphire
{
    public static class Bank
    {
       public static Account CreateAccount(string accountname,string emailAddress, TypeOfAccounts accountType)
        {            
            using (var db = new AccountDB())
            {
                var account = new Account();
                account.EmailAddress = emailAddress;
                account.AccountType = accountType;
                account.AccountName = accountname;
                db.Accounts.Add(account);
                db.SaveChanges();
                return account;
            }
        }
       
        public static IQueryable<Account> GetAllAccounts(string emailaddress)
        {

            var db = new AccountDB();
            
                return db.Accounts.Where(a => a.EmailAddress == emailaddress);
                
            
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

        public static Account UpdtaeAccount(string accountname, string emailaddress, TypeOfAccounts accounttype, int accno)
        {
            using (var db = new AccountDB())
            {
                var account = db.Accounts.Find(accno);
                account.AccountType = accounttype;
                account.AccountName = accountname;
                account.EmailAddress = emailaddress;
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return account;
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
