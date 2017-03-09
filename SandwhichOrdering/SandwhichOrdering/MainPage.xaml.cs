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
using System.Diagnostics;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SandwichOrdering
{
    
    public sealed partial class MainPage : Page
    {
        private Order customerOrder;
        private Sandwich customerSandwich;

        public struct Sandwich
        {
            private condiments wKetchup,
                               wMustard,
                               wOnions,
                               wRelish,
                               wMayonnaise,
                               wMushrooms;
            private sandwichType type;

            #region get and sets for variables
            public condiments WKetchup
            {
                get
                {
                    return wKetchup;
                }
                set
                {
                    if (value == condiments.ketchup || value == Constants.NONE)
                        wKetchup = value;
                    else
                        throw new ArgumentException();
                }  
            }
            public condiments WMustard
            {
                get
                {
                    return wMustard;
                }
                set
                {
                    if (value == condiments.mustard || value == Constants.NONE)
                        wMustard = value;
                    else
                        throw new ArgumentException();
                }
            }
            public condiments WOnions
            {
                get
                {
                    return wOnions;
                }
                set
                {
                    if (value == condiments.onions || value == Constants.NONE)
                        wOnions = value;
                    else
                        throw new ArgumentException();
                }
            }
            public condiments WRelish
            {
                get
                {
                    return wRelish;
                }
                set
                {
                    if (value == condiments.relish || value == Constants.NONE)
                        wRelish = value;
                    else
                        throw new ArgumentException();
                }
            }
            public condiments WMayonnaise
            {
                get
                {
                    return wMayonnaise;
                }
                set
                {
                    if (value == condiments.mayonnaise  || value == Constants.NONE)
                        wMayonnaise = value;
                    else
                        throw new ArgumentException();
                }
            }
            public condiments WMushrooms
            {
                get
                {
                    return wMushrooms;
                }
                set
                {
                    if (value == condiments.mushrooms || value == Constants.NONE)
                        wMushrooms = value;
                    else
                        throw new ArgumentException();
                }
            }
            public sandwichType Type
            {
                get
                {
                    return type;
                }
                set
                {
                    type = value;
                }
            }
            #endregion

            public override string ToString()
            {
              
                string sandwichSummary = this.Type.ToString();

                if ((WKetchup != Constants.NONE) || (WMustard != Constants.NONE) || (WOnions != Constants.NONE) ||
                    (WRelish != Constants.NONE) || (WMayonnaise != Constants.NONE) || (WMayonnaise != Constants.NONE))
                {
                    if (WKetchup == condiments.ketchup)
                        sandwichSummary += "\n with Ketchup";
                    if (WMustard == condiments.mustard)
                        sandwichSummary += "\n with Mustard";
                    if (WOnions == condiments.onions)
                        sandwichSummary += "\n with Onions";
                    if (WRelish == condiments.relish)
                        sandwichSummary += "\n with Relish";
                    if (WMayonnaise == condiments.mayonnaise)
                        sandwichSummary += "\n with Mayonnaise";
                    if (WMushrooms == condiments.mushrooms)
                        sandwichSummary += "\n with Mushrooms";
                }
                else
                {
                    sandwichSummary += " with no condiments";
                }

                return sandwichSummary;
            }
        }



        public MainPage()
        {
            this.InitializeComponent();
            try
            {
                customerOrder = new Order();  
            }
            catch (ArgumentOutOfRangeException)
            {
                error_warning.Text = Constants.errorWarning;
                error_warning.Visibility = Visibility.Visible;
            }

        }

        public void updatePrice()
        {
            double subtotal,
                   tax,
                   total;

            subtotal = customerOrder.totalCart();          
            subTotalSign.Text = subtotal.ToString("F");

            tax = Constants.TAX * subtotal;
            taxSign.Text = tax.ToString("F");
            
            total = subtotal + tax;
            totalSign.Text = total.ToString("F"); 
        }

        private void addSoda_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                customerOrder.addDrink();
                sodaCount.Text = customerOrder.DrinkCount.ToString();
                updatePrice();
            }
            catch (ArgumentOutOfRangeException)
            {
                error_warning.Text = Constants.errorWarning;
                error_warning.Visibility = Visibility.Visible;
            }


        }

        private void minusSoda_Click(object sender, RoutedEventArgs e)
        {
            try
            {           
                customerOrder.removeDrink();
                sodaCount.Text = customerOrder.DrinkCount.ToString();
                updatePrice();
            }
            catch (ArgumentOutOfRangeException)
            {
                error_warning.Text = Constants.errorWarning;
                error_warning.Visibility = Visibility.Visible;
            }
        }
      
        private void addFries_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                customerOrder.addFry();
                fryCount.Text = customerOrder.FryCount.ToString();
                updatePrice();
            }
            catch (ArgumentOutOfRangeException)
            {
                error_warning.Text = Constants.errorWarning;
                error_warning.Visibility = Visibility.Visible;
            }
        }

        private void minusFries_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                customerOrder.removeFry();
                fryCount.Text = customerOrder.FryCount.ToString();
                updatePrice();
            }
            catch (ArgumentOutOfRangeException)
            {
                error_warning.Text = Constants.errorWarning;
                error_warning.Visibility = Visibility.Visible;
            }
        }

        private void addSandwich_Click(object sender, RoutedEventArgs e)
        {
            // See what checkboxes are clicked and assign appropiate values
            // Sandwich type
            if (wantedBLT.IsChecked == true)
                customerSandwich.Type = sandwichType.BLT;
            if (wantedPotroast.IsChecked == true)
                customerSandwich.Type = sandwichType.potroast;
            if (wantedTurkey.IsChecked == true)
                customerSandwich.Type = sandwichType.turkey;
            if (wantedHam.IsChecked == true)
                customerSandwich.Type = sandwichType.ham;

            // Ketchup
            if (withKetchup.IsChecked == true)
                customerSandwich.WKetchup = condiments.ketchup;
            else
                customerSandwich.WKetchup = Constants.NONE;

            // Mustard
            if (withMustard.IsChecked == true)
                customerSandwich.WMustard = condiments.mustard;
            else
                customerSandwich.WMustard = Constants.NONE;

            // Onions
            if (withOnions.IsChecked == true)
                customerSandwich.WOnions = condiments.onions;
            else
                customerSandwich.WOnions = Constants.NONE;

            // Relish
            if (withRelish.IsChecked == true)
                customerSandwich.WRelish = condiments.relish;
            else
                customerSandwich.WRelish = Constants.NONE;

            // Mayonnaise
            if (withMayonnaise.IsChecked == true)
                customerSandwich.WMayonnaise = condiments.mayonnaise;
            else
                customerSandwich.WMayonnaise = Constants.NONE;

            // Mushrooms
            if (withMushrooms.IsChecked == true)
                customerSandwich.WMushrooms = condiments.mushrooms;
            else
                customerSandwich.WMushrooms = Constants.NONE;

            // Fries
            if (withFries.IsChecked == true)
            {
                try
                {
                    customerOrder.addFry();
                    fryCount.Text = customerOrder.FryCount.ToString();
                }
                catch (ArgumentOutOfRangeException)
                {
                    error_warning.Text = Constants.errorWarning;
                    error_warning.Visibility = Visibility.Visible;
                }
            }
            
            // Soda
            if (withSoda.IsChecked == true)
            {
                try
                {
                    customerOrder.addDrink();
                    sodaCount.Text = customerOrder.DrinkCount.ToString();
                }
                catch (ArgumentOutOfRangeException)
                {
                    error_warning.Text = Constants.errorWarning;
                    error_warning.Visibility = Visibility.Visible;
                }
              
            }
          
            // Add Sandwich
            customerOrder.addSandwich(customerSandwich);

            // Reset values for a new sandwhich
            withSoda.IsChecked       = false;
            withFries.IsChecked      = false;
            withKetchup.IsChecked    = false;
            withMustard.IsChecked    = false;
            withOnions.IsChecked     = false;
            withRelish.IsChecked     = false;
            withMayonnaise.IsChecked = false;
            withMushrooms.IsChecked  = false;
            wantedBLT.IsChecked      = true;
            
            updatePrice();
            
        }    
    }
}
