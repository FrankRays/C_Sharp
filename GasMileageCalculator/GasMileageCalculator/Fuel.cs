using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasMileageCalculator
{
    static class Constants
    {
        public const float MIN_GALLONS_PURCHASED = 0.0f;
        public const float MIN_COST_OF_FILL_UP = MIN_GALLONS_PURCHASED;
        public const float MIN_MILES_DRIVEN = MIN_COST_OF_FILL_UP;
        public const float AVG_CAR_GAS_CAPACITY = 16.0f;
        public const float AVG_TRUCK_GAS_CAPACITY = 23.0f;
    }

    enum carType { car, truck}

    class Fuel
    {
        // Fields
        private float costOfFillUp
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

        private float totalGallonsPurchased
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
            
        private float totalMilesDriven
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

      
        // Public Methods
        //********************************************************************

        // Cost Per Mile 
        public float caclulateCostPerMile(float costOfVehicle, carType vehicle)
        {
            float costPerMile;

            if( vehicle == carType.car)
                costPerMile = (costOfVehicle + ((totalGallonsPurchased / Constants.AVG_CAR_GAS_CAPACITY) * costOfFillUp)) / totalMilesDriven;
            else
                costPerMile = (costOfVehicle + ((totalGallonsPurchased / Constants.AVG_TRUCK_GAS_CAPACITY) * costOfFillUp)) / totalMilesDriven;
            return costPerMile;
        }

        // Calculate Miles Per Gallon
        public float calculateMPG()
        {
            return totalMilesDriven / totalGallonsPurchased;
        }
      
     }
}
