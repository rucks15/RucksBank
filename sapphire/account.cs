using System;
using System.Collections.Generic;
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
    class Account
   
    {
        #region statics
        private static int lastAccountNumber = 1;
        #endregion

        public static List<Transactions> transactions = new List<Transactions>();


        #region properties

        /// <summary>
        /// Account number of the user
        /// </summary>
        public int AccountNumber { get; private set; }
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
        

        #endregion Properties

        #region constructor
        public Account()
        {
            AccountNumber = lastAccountNumber++;
        }
        #endregion

        #region Methods

        public decimal Deposit(decimal amount)
        {
            var transaction = new Transactions();
            transaction.TransactionDate = DateTime.Now;
            transaction.TransactionType = TypeOfTransaction.Credit;
            transaction.StartingBalance = Balance;
            transaction.Amount = amount;
            transactions.Add(transaction);
            //Balance = Balance + amount;
            Balance += amount;
            return Balance;
            
        }

        public decimal Withdraw(decimal amount)
        {
            var transaction = new Transactions();
            transaction.TransactionDate = DateTime.Now;
            transaction.TransactionType = TypeOfTransaction.Debit;
            transaction.StartingBalance = Balance;
            transaction.Amount = amount;
            transactions.Add(transaction);
            if (amount <= Balance)
            {
                Balance -= amount;
                return Balance;
            }
            else
            {
                Console.WriteLine("Sorry, No sufficient funds in your account");
                return Balance;
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
