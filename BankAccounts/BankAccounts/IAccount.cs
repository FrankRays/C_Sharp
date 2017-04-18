using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Dictates what functions are needed
/// </summary>
namespace BankAccounts
{
    interface IAccount
    {

        void setAccountBalance(double newBalance);

        string getLastFirstName();

        string getFullName();
        
    }
}
