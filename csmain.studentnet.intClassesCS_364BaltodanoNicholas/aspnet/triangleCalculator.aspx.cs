using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Nicholas Baltodano
/// This page controls the triangle
/// Most functions are controlling the validity of the user input values
/// as well making sure there is a right triangle that could be created
/// </summary>
public partial class triangleCalculator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {          
            if(RequiredFieldValidatorA.IsValid == true && RequiredFieldValidatorB.IsValid == true)
            {
                if (triangleValueValidator.IsValid == true && triangleValueValidatorB.IsValid == true)
                {
                    double lengthA = Convert.ToDouble(sideA.Text);
                    double lengthB = Convert.ToDouble(sideB.Text);
                    calculateTriangle(lengthA, lengthB);
                }
            }
        }
        catch (Exception)
        {

        }
        
    }

    // Make sure the triangle is a right triangle and calculate it
    private void calculateTriangle(double lengthA, double lengthB)
    {
        var lengthC = Math.Sqrt((lengthA * lengthA) + (lengthB * lengthB));

        if ((lengthA* lengthA) + (lengthB*lengthB) == (lengthC*lengthC))
        {
            TriangleConfirmation.Text = "These values make a triangle";
            perimeterText.Text = "Perimeter " + (lengthA + lengthB + lengthC).ToString(".##");
            sideCText.Text = "Side C: " + lengthC.ToString(".##");
            areaText.Text = "Area: " + ((lengthA * lengthB) / 2).ToString(".##");

        }
        else
        {
            TriangleConfirmation.Text = "These values do not make a right triangle";
            sideCText.Text = "Side C: ";
            areaText.Text = "Area: ";
            perimeterText.Text = "Perimeter: ";
        }           
    }
}