using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// A Checking account class, this implements IAccount as well as inherits from bankAccount. 
/// Provides a constructor.
/// Nicholas Baltodano
/// </summary>
namespace BankAccounts
{
    class CheckingAccount : BankAccount, IAccount
    {
        private AccountType accountType = AccountType.Checking;

        public AccountType typeOfAccount
        {
            get
            {
                return accountType;
            }
        }

        public CheckingAccount(string firstName, string lastName, double accountNumber, float interestRate, double startingBalance) 
        {
            FirstName = firstName;
            LastName = lastName;
            YearlyInterestRate = interestRate;
            Balance = startingBalance;
            AccountNumber = accountNumber;
        }

        
        public override string ToString()
        {
            return $"{accountType.ToString()} \n" + base.ToString();
        }
    }


  
}
