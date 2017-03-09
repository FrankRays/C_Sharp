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
using System.Text.RegularExpressions;
/// <summary>
/// NFB (2/25/17)
/// This page is used to control the UI events. 
/// The main player here the calculate button which creates instances of the fuel class to compare to each other. 
/// </summary>
namespace GasMileageCalculator
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        private void calculateIt_Click(object sender, RoutedEventArgs e)
        {            
            double vehicleCost1,
                   vehicleCost2,
                   MPGVehicle1,
                   CPMVehicle1, 
                   MPGVehicle2,
                   CPMVehicle2;
            try
            {
                Fuel vehicle1 = new Fuel();
                Fuel vehicle2 = new Fuel();

                // Hide error messages
                errorMessage.Visibility   = Visibility.Collapsed;
                resultBoxlLeft.Visibility = Visibility.Collapsed;
                resultBoxRight.Visibility = Visibility.Collapsed;

                #region Get the vehicle costs
                // First vehicle
                if (!double.TryParse(vehicle1Cost.Text, out vehicleCost1))
                {
                    errorMessage.Text = "Vehicle cost must be numberic";
                    errorMessage.Visibility = Visibility.Visible;
                }
                else
                {
                    if (vehicleCost1 < Constants.MIN_CAR_COST)
                    {
                        errorMessage.Text = "The first vehicle cost must be non-negative";
                        errorMessage.Visibility = Visibility.Visible;
                    }
                }
                
                // Second Vehicle
                if (!double.TryParse(vehicle2Cost.Text, out vehicleCost2))
                {
                    errorMessage.Text = "Vehicle cost must be numberic";
                    errorMessage.Visibility = Visibility.Visible;
                }
                else
                {
                    if (vehicleCost2 < Constants.MIN_CAR_COST)
                    {
                        errorMessage.Text = "The second vehicle cost must be non-negative";
                        errorMessage.Visibility = Visibility.Visible;
                    }
                }
                #endregion
   
                try
                {    
                    #region Assign Fuel values
                    // Vehicle 1 
                    vehicle1.CostOfFillup          = double.Parse(vehicle1FillUpCost.Text);
                    vehicle1.TotalGallonsPurchased = double.Parse(vehicle1GallonsPuchased.Text);
                    vehicle1.TotalMilesDriven      = double.Parse(vehicle1MilesDriven.Text);

                    // Vehicle 2
                    vehicle2.CostOfFillup          = double.Parse(vehicle2FillUpCost.Text);
                    vehicle2.TotalGallonsPurchased = double.Parse(vehicle2GallonsPuchased.Text);
                    vehicle2.TotalMilesDriven      = double.Parse(vehicle2MilesDriven.Text);
                    #endregion

                    #region Calculations and Output
                    // Get calculated values
                    MPGVehicle1 = vehicle1.calculateMPG();
                    MPGVehicle2 = vehicle2.calculateMPG();

                    CPMVehicle1 = vehicle1.caclulateCostPerMile(vehicleCost1);
                    CPMVehicle2 = vehicle2.caclulateCostPerMile(vehicleCost2);

                    // Round variable values
                    MPGVehicle1 = Math.Round(MPGVehicle1, 2);
                    MPGVehicle2 = Math.Round(MPGVehicle2, 2);
                    CPMVehicle1 = Math.Round(CPMVehicle1, 3);
                    CPMVehicle2 = Math.Round(CPMVehicle2, 3);

                   
                    // Output values
                    vehicle1CPM.Text = '$' + CPMVehicle1.ToString();
                    vehicle2CPM.Text = '$' + CPMVehicle2.ToString();                                       
                    vehicle1MPG.Text = MPGVehicle1.ToString() + " MPG";
                    vehicle2MPG.Text = MPGVehicle2.ToString() + " MPG";

                    // Show results
                    if ((CPMVehicle2 < CPMVehicle1) && (MPGVehicle2 > MPGVehicle1))
                        resultBoxRight.Text = "The second vehicle has the better CPM and MPG";
                    else if ((CPMVehicle2 < CPMVehicle1) && (MPGVehicle1 > MPGVehicle2))
                    {
                        resultBoxRight.Text = "The second vehicle has the better CPM";
                        resultBoxlLeft.Text = "The first vehicle has the better MPG";
                    }
                    else if ((CPMVehicle1 < CPMVehicle2) && (MPGVehicle2 > MPGVehicle1))
                    {
                        resultBoxRight.Text = "The seconds vehicle has the better MPG";
                        resultBoxlLeft.Text = "The first vehicle has the better CPM";
                    }
                    else if ((CPMVehicle1 < CPMVehicle2) && (MPGVehicle2 < MPGVehicle1))
                        resultBoxlLeft.Text = "The first Vehicle has the better CPM and MPG";
                    resultBoxlLeft.Visibility = Visibility.Visible;
                    resultBoxRight.Visibility = Visibility.Visible;
                    #endregion
                }
                catch (ArgumentOutOfRangeException)
                {
                    errorMessage.Text = "Please enter positive values";
                    errorMessage.Visibility = Visibility.Visible;
                }
                catch (Exception)
                {
                    errorMessage.Text = "Please enter numberic values";
                    errorMessage.Visibility = Visibility.Visible;
                }
                            
            }            
            catch(Exception)
            {
                errorMessage.Text = "There has been an error, please try again";
                errorMessage.Visibility = Visibility.Visible;
            }
        }
    }
}
