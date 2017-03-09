using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// NFB (2/25/17)
/// Fuel class. 
/// This is here to define what about fuel is being used in a vehicle.
/// It will throw exceptions if any negative values are given to it
/// </summary>
namespace GasMileageCalculator
{
    static class Constants
    {
        public const double MIN_GALLONS_PURCHASED = 0.0;
        public const double MIN_COST_OF_FILL_UP = MIN_GALLONS_PURCHASED;
        public const double MIN_MILES_DRIVEN = 1.0;
        public const double AVG_CAR_GAS_CAPACITY = 16.0;
        public const double MIN_CAR_COST = 0.0;
    }

    class Fuel
    {
        #region Fields & Accessors
        private double costOfFillUp;
        public double CostOfFillup
        { 
            get
            {
                return costOfFillUp;
            }
            set
            {
                if (value > Constants.MIN_COST_OF_FILL_UP)
                    totalGallonsPurchased = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }

        private double totalGallonsPurchased;
        public double TotalGallonsPurchased
        {
            get
            {
                return totalGallonsPurchased;
            }
            set
            {
               if (value > Constants.MIN_GALLONS_PURCHASED)
                    totalGallonsPurchased = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }

        private double totalMilesDriven;
        public  double TotalMilesDriven
        {
            get
            {
                return totalMilesDriven;
            }
            set
            {
                if (value > Constants.MIN_MILES_DRIVEN)
                    totalMilesDriven = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        #endregion

        #region Constructors
        public Fuel (double fillUpCost = Constants.MIN_COST_OF_FILL_UP,  double gallonsPurchased = Constants.MIN_GALLONS_PURCHASED, double totalMiles = Constants.MIN_MILES_DRIVEN)
        {
            if (fillUpCost < Constants.MIN_COST_OF_FILL_UP || gallonsPurchased < Constants.MIN_GALLONS_PURCHASED || totalMiles < Constants.MIN_MILES_DRIVEN)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                this.costOfFillUp = fillUpCost;
                this.totalGallonsPurchased = gallonsPurchased;
                this.totalMilesDriven = totalMiles;
            }
        }
        #endregion

        #region Public Methods
        public double caclulateCostPerMile(double costOfVehicle)
        {
            if (costOfVehicle < Constants.MIN_CAR_COST)
                costOfVehicle = Constants.MIN_CAR_COST;
                        
            return (costOfVehicle + ((totalGallonsPurchased / Constants.AVG_CAR_GAS_CAPACITY) * costOfFillUp)) / totalMilesDriven;
        }

        public double calculateMPG()
        {
            return totalMilesDriven / totalGallonsPurchased;
        }
        #endregion
    }
}
