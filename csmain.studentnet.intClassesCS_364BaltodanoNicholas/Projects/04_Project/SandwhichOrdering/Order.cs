using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SandwichOrdering.MainPage;
using System.Diagnostics;

// This page contains the Order and Constants class, as well as sandwich related enumerations.  
// It contains lists of sandwiches and number of drinks and sodas.
// Nicholas Baltodano 3.9.2017

namespace SandwichOrdering
{
    // Enumerations
    public enum sandwichType { BLT, potroast, turkey, ham};
    public enum condiments   { ketchup = 1, mustard, onions, relish, mayonnaise, mushrooms};

    static class Constants
    {
        public const int    MIN_SANDWICHES = 0;
        public const int    MIN_SODAS      = 0;
        public const int    MIN_FRIES      = 0;
        public const int    NONE           = 0;
        public const double FRY_COST       = 1.25;
        public const double SODA_COST      = 1.00;
        public const double SANDWICH_COST  = 5.00;
        public const double TAX            =  .10;
        public const string errorWarning = "There has been a warning, please restart the program.";    
    }
    
    class Order
    {
        private List<Sandwich> sandwichList;
        private static int fryCount;
        private static int drinkCount;

        #region Property Accessors
        public int FryCount
        {
            get
            {
                return fryCount;
            }
            set
            {
                if (value >= Constants.MIN_FRIES)
                    fryCount = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public int DrinkCount
        {
            get
            {
                return drinkCount;
            }
            set
            {
                if (value >= Constants.MIN_SODAS)
                    drinkCount = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        #endregion

        public Order(int fryCount = 0, int drinkCount = 0)
        {
            this.FryCount = fryCount;
            this.DrinkCount = drinkCount;
            this.sandwichList = new List<Sandwich>();
        }


    
        #region Public Methods
        // Add a drink to the order
        public void addDrink()
        {
            this.DrinkCount++;
        }

        // Remove a drink from the order
        public void removeDrink()
        {
            if (this.DrinkCount > Constants.NONE)
                this.DrinkCount--;
        }

        // Add a fry to the order
        public void addFry()
        {
            this.FryCount++;
        }

        // Remove a fry from the order
        public void removeFry()
        {
            if (this.FryCount > Constants.NONE)
                this.FryCount--;
        }

        // Add Sandwhich to the order
        public void addSandwich(Sandwich newSandwhich)
        {
                this.sandwichList.Add(newSandwhich);          
        }

        // Get the total price of what's in the cart
        public double totalCart()
        {
            Double total = 0.0;

            foreach (Sandwich sandwhich in sandwichList)
            {
                total += Constants.SANDWICH_COST;
            }

            total += (DrinkCount * Constants.SODA_COST);
            total += (FryCount * Constants.FRY_COST);
            return total;
        }

        #endregion
    }
}
