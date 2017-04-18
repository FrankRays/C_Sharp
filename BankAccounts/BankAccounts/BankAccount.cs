using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

/// <summary>
/// Provides most functionality for a bank account.
/// Holds and stores the primary banking information
/// Nicholas Baltodano
/// </summary>
namespace BankAccounts
{
     abstract class BankAccount : IAccount
     {
        private double accountNumber;
        private string firstName;
        private string lastName;
        private float yearlyInterestRate;
        private double balance;


        public double AccountNumber
        {
            get
            {
                return accountNumber;
            }
            set
            {
                if (value < constants.maxAccountNumber || value > constants.minAccountNumber)
                    accountNumber = value;
                else
                    throw new ArgumentOutOfRangeException("", "Account Number not in range");
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {

                foreach (char c in value.ToCharArray())
                {
                    if (!Char.IsLetter(c))
                        throw new ArgumentOutOfRangeException("", "First name must only have character Values");
                }
                if (value.ToCharArray().Length == 0)
                    throw new ArgumentOutOfRangeException("", "First name must be filled");
                else
                    firstName = value;           
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                foreach (char c in value.ToCharArray())
                {
                    if (!Char.IsLetter(c))
                        throw new ArgumentOutOfRangeException("", "Last name must only have character Values");
                }
                if(value.ToCharArray().Length == 0)
                    throw new ArgumentOutOfRangeException("", "Last name must be filled");
                else
                    lastName = value;              
            }
        }


        public float YearlyInterestRate
        {
            get
            {
                return yearlyInterestRate;
            }
            set
            {
                if (value < constants.minInterest)
                    throw new ArgumentOutOfRangeException("", $"Interest is too low, Min is {constants.minInterest}");
                else if(value > constants.maxInterest)
                    throw new ArgumentOutOfRangeException("", $"Interest is too high, MAX is {constants.maxInterest}");
                else
                    yearlyInterestRate = value;
            }
        }

        public double Balance
        {
            get
            {
                return balance;
            }
            set
            {
                
                this.setAccountBalance(value);
            }
        }

        public void setAccountBalance(double newBalance)
        {     
            this.balance = newBalance;
        }

        public string getLastFirstName()
        {
            return lastName + ", " + firstName;
        }

        public string getFullName()
        {
            return firstName + " " + lastName;
        }

        public override string ToString()
        {
            string accountInfo = $"Account Number: {AccountNumber} \n";
            accountInfo       += "Full Name: " + getFullName() + "\n";
            accountInfo       += $"Balance: $ {Balance} \n";
            accountInfo       += $"Interest: {yearlyInterestRate} %";
            return accountInfo;
        }
     
        public void withdraw (double withdrawalAmount)
        {
            if (withdrawalAmount < Balance)
            {
                if (withdrawalAmount >= constants.minWithdrawal)
                    Balance -= withdrawalAmount;
                else
                    throw new ArgumentOutOfRangeException("", "Withdrawal ammount cannot be negative");
            }
           else
                throw new ArgumentOutOfRangeException("", "Insufficient Funds");
            
        }

        public void deposit(double depositAmount)
        {
            if (depositAmount > constants.minDeposit)
                Balance += depositAmount;
            else
                throw new ArgumentOutOfRangeException("", "You cannnot deposit negative ammounts");    
        }

        public float calculateMonthlyInterest()
        {
            return YearlyInterestRate / 12; 
        }
    }
}
