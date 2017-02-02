using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Nicholas Baltodano 2.1.17
namespace _01_Project
{
    
    class Program
    {
        static void Main(string[] args)
        {
            const int triangleMin = 1,
                      triangleHeightMax = 15;
                  int triangleHeight    = 0,
                      triangleWidth     = 0,
                      triangleLine      = 0;
          
            Random random =    new Random(); // Used for the collection of the random number

            // Print the welcome message
            #region Welcome message
            Console.WriteLine("Hello, this program will select a random number for a triangle's height,");
            Console.WriteLine("it will then tell you if the triangle's height is even or odd,");
            Console.WriteLine("and then show a visual representation of the triangle.");
            Console.WriteLine();
            #endregion

            // Get the random number 
            triangleHeight = random.Next(triangleMin, triangleHeightMax + 1);

            // Determine if the height is even or odd and tell user
            #region Even or Odd
            Console.Write($"The triangle height of {triangleHeight} ");
            if (triangleHeight % 2 == 0)
                Console.WriteLine("is even.");            
            else            
                Console.WriteLine(" is odd.");
            Console.WriteLine();
            #endregion

            //Draw the triangle
            #region Draw visual representation
            for (triangleLine = triangleMin ; triangleLine <= triangleHeight; triangleLine++)
            {
                Console.Write("\t");
                for(triangleWidth = triangleMin; triangleWidth <= triangleLine; triangleWidth++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();       
            }
            #endregion
            Console.WriteLine();
        }
    }
}
