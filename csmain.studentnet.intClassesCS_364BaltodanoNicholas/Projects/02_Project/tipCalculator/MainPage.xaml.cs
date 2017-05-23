*/***********************************************************************************
 * Nicholas Baltodano 2.14.2017                                                     *
 * This program calculates the tip for any restaurant bill.                         *
 * The user has the ability to enter their own tip or select from a percentage bar. *
 ************************************************************************************/
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



namespace tipCalculator
{
    
    public sealed partial class MainPage : Page
    {
        // Constants
        int   MINIMUM_RANGE = 0,
              DECIMAL_PLACE = 2;     // The max amount of decimal places for display of money
        float PERCENTAGE    =  .01f;  // Used to find the percent number decimal value of a number

        // Global Variables Defaults
        float basePrice          = 0.0f,  // The base bill total
              tipAmount          = 0.0f, 
              tipPercentageValue = 1;



        //Main 
        #region Main
        public MainPage()
        {
            this.InitializeComponent();
        }
        #endregion

        // Change tip value when slider is moved
        #region Slider
        private void percentageSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            tipPercentageValue = (int)percentageSlider.Value;

            Math.Round(tipPercentageValue, 2);

            tipPercentage.Text = tipPercentageValue.ToString();
            calculateTip();
        }
        #endregion

        // Update Tip percentage amount
        #region tipPercentage_TextChanged
        private void tipPercentage_TextChanged(object sender, TextChangedEventArgs e)
        {

           float.TryParse(tipPercentage.Text, out tipPercentageValue);
            try
            {
                if (tipPercentageValue < MINIMUM_RANGE)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    warning_message.Visibility = Visibility.Collapsed;
                    calculateTip();
                    calculateTotal();
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                warning_message.Visibility = Visibility.Visible;
            }
        }
        #endregion


        // Calculate the Tip amount
        #region CalculateTip
        private void calculateTip()
        { 
            tipAmount = ((tipPercentageValue * PERCENTAGE) * basePrice);

            Math.Round(tipAmount, 2);
            tipTotal.Text = tipAmount.ToString();

            // Update Total 
            calculateTotal();
        }
        #endregion

        //Update Bill and Tip amount
        #region textBox_TextChanged
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            float.TryParse(subTotal.Text, out basePrice);
            float.TryParse(tipTotal.Text, out tipAmount);
            try
            {
                if (basePrice < MINIMUM_RANGE || tipAmount < MINIMUM_RANGE)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    warning_message.Visibility = Visibility.Collapsed;
                    calculateTotal();
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                warning_message.Text = "The total and tip must be non-negative";
                warning_message.Visibility = Visibility.Visible;

            }
        }
        #endregion

        // Calculate the final total
        #region CalculateTotal()
        private void calculateTotal()
        {
            float totalPrice = basePrice + tipAmount;

            Math.Round(totalPrice, DECIMAL_PLACE);
            finalTotal.Text = totalPrice.ToString("c2");         
        }
        #endregion

        #region textBlock_SelectionChanged
        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
        #endregion
    }
}
