using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sapphire
{
    static class Bank
    {
        #region Fields
        private static List<Account> accounts = new List<Account>();
        
        #endregion Fields

        
        public static Account CreateAccount(string emailAddress, TypeOfAccounts accountType)
        {
            var account = new Account();
            account.EmailAddress = emailAddress;
            account.AccountType = accountType;
            accounts.Add(account);
            return account;
        }
       
        public static void PrintAllAccounts()
        {
            foreach (var account in accounts)
            {
                Console.WriteLine($"AccountNumber:{account.AccountNumber},Account Type:{account.AccountType},Email ID :{account.EmailAddress},Balance:{account.Balance}C");
            }
        }
        


    }
}
