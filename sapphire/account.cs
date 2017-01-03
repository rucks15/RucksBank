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
    class Account
   
    {
        #region statics
        private static int lastAccountNumber = 1;
        #endregion

        
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
            //Balance = Balance + amount;
            Balance += amount;
            return Balance;
        }

        public decimal Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return Balance;
            }
            return Balance;
        }         
        #endregion Methods
    }
}
