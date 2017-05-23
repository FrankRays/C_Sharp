using System;



    public class checker
    {
        public bool Kingship { get; set; }
        int locationX, locationY;
        checkerType color;

        public const int Y_MAX = 3;
        public const int X_MAX = 7;
        public const int COORD_MIN = 0;


        double victorychance;



        public enum checkerType { Red, Black };


        #region constructors
        public checker(int locationX, int locationY, checkerType colorParam)
        {
            kingship = false;
            victorychance = 100.00;
            LocationX = locationX;
            locationY = locationY;
            color = colorParam;
        }

        public checker()
        {
        }

        #endregion
        #region Public accessors
        public int LocationX
        {
            get { return locationX; }

            set
            {
                if (value > X_MAX || value < COORD_MIN)
                    throw new ArgumentOutOfRangeException();
                else
                    locationX = value;
            }
        }

        public int LocationY
        {
            get;

            set
            {
                if (value > Y_MAX || value < COORD_MIN)
                    throw new ArgumentOutOfRangeException();
                else
                    locationX = value;
            }
        }
        #endregion


        #region Methods
        public void findMoves()
        {
            int X, Y;


            if (isKing() == false)
            {
                // Make sure to check for end of board TODO on all code here
                #region Right Diagonal
                //Check the right diagonal
                X = LocationX + 1;
                Y = LocationY + 1;
                // if there is a checker, see if you can jump
                if (isChecker(X, Y))
                {

                    if (isChecker(++X, ++Y) == false)
                    {
                        //Set the square as a highlighted jump location
                    }
                    else
                    {
                        // User cannnot jump
                    }

                }
                else
                {
                    // Set location X++ and Y++ highlighted
                }
                #endregion

                #region Left Diagonal
                X = LocationX - 1;
                Y = LocationY + 1;
                if (isChecker(X, Y))
                {

                    if (isChecker(--X, ++Y) == false)
                    {
                        //Set the square as a highlighted jump location
                    }
                    else
                    {
                        // User cannnot jump
                    }

                }
                else
                {
                    // Set location X-- and Y++ highlighted
                    //user can jump
                }



                #endregion




            }
        }

        public void makeKing()
        {
            kingship = true;
        }

        #endregion
    }

