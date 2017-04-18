using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    abstract public class constants
    {
        public const float  maxInterest = 10f;
        public const float  minInterest = 0.00f;
        public const double minWithdrawal = 0.0;
        public const double minDeposit = 0.0;
        public const int maxCharacters = 25;
        public const double minStartingBalance = 100.00;
        public const float startingInterest = .05f;
        public const double minAccountNumber = 1000000;
        public const double maxAccountNumber = 9999999;
    }

    enum AccountType { Checking, Savings};
}
