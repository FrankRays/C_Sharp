using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SandwichOrdering.MainPage;

namespace SandwichOrdering
{
    // Enumerations
    public enum sandwichType { BLT, potroast, turkey, ham};
    public enum condiments   { ketchup = 1, mustard, onions, relish, mayonnaise, mushroom};

    static class Constants
    {
        public const int    MIN_SANDWICHES = 0;
        public const int    MIN_SODAS      = 0;
        public const int    MIN_FRIES      = 0;
        public const int    NONE           = 0;
        public const double FRY_COST       = 1.25;
        public const double SODA_COST      = 1.00;
        public const double SANDWICH_COST  = 5.00;        
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

        public void addDrink()
        {
            this.DrinkCount++;
        }

        public void removeDrink()
        {
            if (this.DrinkCount > 0)
                this.DrinkCount--;
        }

        public void addFry()
        {
            this.FryCount++;
        }

        public void removeFry()
        {
            if (this.FryCount > 0)
                this.FryCount--;
        }

        public void addSandwich(Sandwich newSandwhich)
        {
            this.sandwichList.Add(newSandwhich);
        }
    }
}
