using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sapphire
{
    public enum TypeOfAccounts
    {
        Checking,
        Savings
    }
    /// <summary>
    /// This class describes a bank account
    /// </summary>
    public class Account
   
    {
        

        public static List<Transactions> transactions = new List<Transactions>();


        #region properties
        [Key]
        /// <summary>
        /// Account number of the user
        /// </summary>
        public int AccountNumber { get; set; }
        public string AccountName { get; set; }
       
        /// <summary>
        /// Email Address of the user
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Current balance in the user's account
        /// </summary>
        public decimal Balance { get; private set; }
        /// <summary>
        /// User's Account type
        /// </summary>
        public TypeOfAccounts AccountType { get; set; }

        public virtual ICollection<Transactions> alltransactions {get; set;}
        

        #endregion Properties

        

        #region Methods

        public decimal Deposit(decimal amount)
        {
            using (var db = new AccountDB())
            {
                var original = db.Accounts.Where(a => a.AccountNumber == this.AccountNumber).First();
                var updates = original;
                Balance = Balance + amount;
                updates.Balance += amount;
                db.Entry(original).CurrentValues.SetValues(updates);
                db.SaveChanges();
                return Balance;
            }
            
        }

        public decimal Withdraw(decimal amount)
        {
            using (var db = new AccountDB())
            {
                var original = db.Accounts.Where(a => a.AccountNumber == this.AccountNumber).First();
                var updates = original;
                if (amount <= updates.Balance)
                {
                    Balance -= amount;
                    updates.Balance -= amount;
                    db.Entry(original).CurrentValues.SetValues(updates);
                    db.SaveChanges();
                    return Balance;
                }
            else
            {
                Console.WriteLine("Sorry, No sufficient funds in your account");
                return Balance;
            }
            
            }
        }

        public void PrintTransactions()
        {

            foreach (var trans in transactions)
            {
                Console.WriteLine($"Date:{trans.TransactionDate}, Transaction Type : {trans.TransactionType}, Starting Balance:{trans.StartingBalance}, Balance : {trans.Balance}");

            }
        }
        #endregion Methods
    }
}
