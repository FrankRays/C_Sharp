using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Random;

/// <summary>
/// A Savings account class, this implements IAccount as well as inherits from bankAccount. 
/// Provides a constructor.
/// Nicholas Baltodano
/// </summary>
namespace BankAccounts
{
    class SavingsAccount : BankAccount, IAccount 
    {
       private AccountType accountType = AccountType.Savings;

        public AccountType typeOfAccount
        {
            get
            {
                return accountType;
            }
        }

        public SavingsAccount(string firstName, string lastName, double accountNumber , float interestRate = constants.startingInterest, double startingBalance = constants.minStartingBalance)
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
