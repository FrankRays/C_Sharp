using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _01_Project
{
    
    class Program
    {
        static void Main(string[] args)
        {
            const int triangleHeightMin = 1,
                      triangleHeightMax = 15;
                  int triangleHeight    = 0,
                      triangleWidth     = 0,
                      triangleLine      = 0;
          
            Random random    = new Random(); // Used for the collection of the random number

            // Print the welcome message
            #region Welcome message
            Console.WriteLine("Hello, this program will select a random number for a triangle's height,");
            Console.WriteLine("it will then tell you if the triangle's height is even or odd,");
            Console.WriteLine("it will then show a visual representation of the triangle.");
            Console.WriteLine();
            #endregion

            // Get the random number 
            triangleHeight = random.Next(triangleHeightMin, triangleHeightMax + 1);

            // Determine if the height is even or odd and tell user
            #region Even or Odd
            if (triangleHeight % 2 == 0)
            {
                Console.WriteLine("The triangle height of " + triangleHeight + " is even.");
            }
           else
            {
                Console.WriteLine("The triangle height of " + triangleHeight + " is odd.");
            }
            Console.WriteLine();
            #endregion

            //Draw the triangle
            #region Draw visual representation
            for (triangleLine = 1 ; triangleLine <= triangleHeight; triangleLine++)
            {
                Console.Write("\t");
                for(triangleWidth = 1; triangleWidth <= triangleLine; triangleWidth++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();       
            }
            #endregion

        }
    }
}
