using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sapphire
{
    enum TypeOfTransaction
    {
        Credit,
        Debit
    }
    class Transactions
    {
       
        #region Properties
        public int TransactionNumber { get; set; }

        public DateTime TransactionDate { get; set; }

        private decimal starting_balance { get; set; }

        public TypeOfTransaction TransactionType { get; set; }

        public decimal Amount { get; set; }

        private decimal balance;

        public decimal StartingBalance { get; set; }

        public decimal Balance
        {
            get
            {
                balance = StartingBalance;
                if (TransactionType == TypeOfTransaction.Credit)
                {
                    balance += Amount;
                }
                else
                {
                    if (balance >= Amount)

                    {
                        balance -= Amount;

                    }
                }

                return balance;
            }
        }



        #endregion

        #region Methods
        
        #endregion
    }

}

