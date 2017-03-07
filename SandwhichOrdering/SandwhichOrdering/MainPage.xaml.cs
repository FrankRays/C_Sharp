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


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SandwichOrdering
{
    
    public sealed partial class MainPage : Page
    {
        private Order customerOrder;

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
                    if (value == condiments.mushroom || value == Constants.NONE)
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
                    if (WMushrooms == condiments.mushroom)
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
            customerOrder = new Order();
            
        }

        private void addSoda_Click(object sender, RoutedEventArgs e)
        {
            customerOrder.addDrink();
            sodaCount.Text = customerOrder.DrinkCount.ToString();
        }

        private void minusSoda_Click(object sender, RoutedEventArgs e)
        {
            customerOrder.removeDrink();
            sodaCount.Text = customerOrder.DrinkCount.ToString();
        }
      
        private void addFries_Click(object sender, RoutedEventArgs e)
        {
            customerOrder.addFry();
            fryCount.Text = customerOrder.FryCount.ToString();
        }

        private void minusFries_Click(object sender, RoutedEventArgs e)
        {
            customerOrder.removeFry();
            fryCount.Text = customerOrder.FryCount.ToString();
        }

    }
}
