using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;



namespace BankAccounts
{
   
    /// <summary>
    /// This code handles the interactions between the controls on the page
    /// Nicholas Baltodano
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private List<BankAccount> accountList;
        double accountBalance,
               accountNumber;
        string firstName,
               lastName;
        float  interestRate;
        Random random = new Random();
  

        public MainPage()
        {
            accountList = new List<BankAccount>();
            this.InitializeComponent();
            lastNameInput.MaxLength  = constants.maxCharacters;
            firstNameInput.MaxLength = constants.maxCharacters;            
        }


        private void CreateCheckingAccountBTN_Click(object sender, RoutedEventArgs e)
        {           
            // Grab data from form ansd create checking account
            try
            {
                firstName = firstNameInput.Text;
                lastName  = lastNameInput.Text;

                double.TryParse(startingDepositInput.Text, out accountBalance);
                float.TryParse (interestRateValue.Text,    out interestRate);

                accountNumber = random.Next((int)constants.minAccountNumber, (int)constants.maxAccountNumber);

                // Create the new account and add it to a list and hide error message
                CheckingAccount newAccount = new CheckingAccount(firstName, lastName, accountNumber,  interestRate, accountBalance);
                accountList.Add(newAccount);
                updateListBox();
                errorBanner.Visibility = Visibility.Collapsed;
            }
            catch (ArgumentOutOfRangeException error)
            {
               errorBanner.Text = error.Message;
               errorBanner.Visibility = Visibility.Visible;
            }           
        }

        private void updateListBox()
        {
            AccountListBox.Items.Clear();
            foreach (BankAccount account in accountList)
            {
                AccountListBox.Items.Add(account);
            }
        }

        private void AccountListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            calculateInterestError.Visibility = Visibility.Collapsed;
            try
            {
                if (AccountListBox.SelectedItem is SavingsAccount)
                    displayAccountType.Text = (AccountListBox.SelectedItem as SavingsAccount).typeOfAccount.ToString();
                else
                    displayAccountType.Text = (AccountListBox.SelectedItem as CheckingAccount).typeOfAccount.ToString();

                displayAcccountNumber.Text = accountList[AccountListBox.SelectedIndex].AccountNumber.ToString();
                displayAccountBalance.Text = accountList[AccountListBox.SelectedIndex].Balance.ToString("c2");

            }
            catch (Exception)
            {
                AccountListBox.SelectedItem = AccountListBox.Items[0];
            }
    
        }

        private void withdrawButton_Click(object sender, RoutedEventArgs e)
        {
            double withdrawalAmount;

            withdrawError.Visibility = Visibility.Collapsed;
            displayMonthlyInterest.Text = "";

            try
            {
                double.TryParse(withdrawalAmountInput.Text, out withdrawalAmount);
                accountList[AccountListBox.SelectedIndex].withdraw(withdrawalAmount);
                displayAccountBalance.Text = accountList[AccountListBox.SelectedIndex].Balance.ToString("c2");
                updateListBox();
            }
            catch (ArgumentOutOfRangeException error)
            {
                withdrawError.Text = error.Message;
                withdrawError.Visibility = Visibility.Visible;
            }     
        }

        private void depositButton_Click(object sender, RoutedEventArgs e)
        {
            double depositAmount;

            depositError.Visibility = Visibility.Collapsed;

            try
            {
                double.TryParse(depositAmountInput.Text, out depositAmount);
                accountList[AccountListBox.SelectedIndex].deposit(depositAmount);
                displayAccountBalance.Text = accountList[AccountListBox.SelectedIndex].Balance.ToString("c2");
                updateListBox();
            }
            catch (ArgumentOutOfRangeException error)
            {
                depositError.Text = error.Message;
                depositError.Visibility = Visibility.Visible;
            }
            
        }

        private void calculateMonthlyInterest_Click(object sender, RoutedEventArgs e)
        {
            double interest;

            try
            {
                if (accountList[AccountListBox.SelectedIndex].YearlyInterestRate > constants.minInterest)
                {
                    interest = (accountList[AccountListBox.SelectedIndex].YearlyInterestRate / 100) / 12;
                    displayMonthlyInterest.Text = (accountList[AccountListBox.SelectedIndex].Balance * interest).ToString("c2");
                }
                else
                {
                    calculateInterestError.Text = "There is no interest for this account";
                    calculateInterestError.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
                calculateInterestError.Text = "There is no account selected";
            }       
        }


        private void deleteAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                accountList.RemoveAt(AccountListBox.SelectedIndex);

                if (deleteErrorBanner.Visibility == Visibility.Visible)
                   deleteErrorBanner.Visibility = Visibility.Collapsed;
            }
            catch (Exception)
            {
                deleteErrorBanner.Visibility = Visibility.Visible;
            }
            updateListBox();
        }

        private void CreateSavingsAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                firstName = firstNameInput.Text;
                lastName  = lastNameInput.Text;

                try
                {
                    
                   accountBalance = double.Parse(startingDepositInput.Text);                    
                }
                catch 
                {
                    errorBanner.Text = "Deposit not set properly, please ensure that only numbers are used";
                    errorBanner.Visibility = Visibility.Visible;
                }
                try
                {
                    interestRate = float.Parse(interestRateValue.Text);
                }
                catch
                {
                    errorBanner.Text = "Interest rate not set properly, please ensure that only numbers are used";
                    errorBanner.Visibility = Visibility.Visible;
                }
                
                    
                accountNumber = random.Next((int)constants.minAccountNumber, (int)constants.maxAccountNumber);

                // Create the new account and add it to a list and hide error message
                SavingsAccount newAccount = new SavingsAccount(firstName, lastName, accountNumber, interestRate, accountBalance);
                accountList.Add(newAccount);
                updateListBox();
                errorBanner.Visibility = Visibility.Collapsed;
      
            }
            catch (ArgumentOutOfRangeException error)
            {
                errorBanner.Text = error.Message;
                errorBanner.Visibility = Visibility.Visible;
            }
         }
    }
}
