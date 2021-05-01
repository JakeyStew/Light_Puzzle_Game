using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LightsPuzzleGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Member Variables
        /// <summary>
        /// Holds the current results of cells in the acitve game
        /// </summary>
        private MarkType[] mResults;
        /// <summary>
        /// True if the game has ended
        /// </summary>
        private bool mGameEnded;
        /// <summary>
        /// Random number generator
        /// </summary>
        private Random randNum = new Random();
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        #endregion

        /// <summary>
        /// Starts a new game and clears all values to default
        /// </summary>
        private void NewGame()
        {
            //Create a new blank array
            mResults = new MarkType[25];

            //Get a random number between specified numbers
            int randomArraySize = randNum.Next(4, 6);
            //Set the Array size to be a random size, gives us a random amount of turned on lights
            int[] cellIndexToUse = new int[randomArraySize];

            //Get 5 random indexes in the mResults array
            for (var i = 0; i < cellIndexToUse.Length; i++)
            {
                //Get random cellIndex from 0-25
                int randomIndex = randNum.Next(0, 25);
                while (true)
                {
                    //Confirm if the random value already exists in array, if false add to array
                    if (!Contains(cellIndexToUse, randomIndex)) break;
                }
                //Add random index to array
                cellIndexToUse[i] = randomIndex;
            }

            //Set every value to be inactive
            for (var i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.inactive;
                //Set a specified amount of them to be active
                for (var j = 0; j < cellIndexToUse.Length; j++)
                {
                    int number = cellIndexToUse[j];
                    if (i == number)
                    {
                        mResults[i] = MarkType.active;
                    }
                }
            }

            #region Win Test Code
            //TESTING WIN CONDITION
            /******************************************************/
            //List<int> test = new List<int>(3);
            //test.Add(0);
            //test.Add(1);
            //test.Add(5);

            //int[] cellIndexToUse = test.ToArray();

            ////Set every value to be inactive
            //for (var i = 0; i < mResults.Length; i++)
            //{
            //    mResults[i] = MarkType.inactive;
            //    //Set a specified amount of them to be active
            //    for (var j = 0; j < cellIndexToUse.Length; j++)
            //    {
            //        int number = cellIndexToUse[j];
            //        if (i == number)
            //        {
            //            mResults[i] = MarkType.active;
            //        }
            //    }
            //}
            /******************************************************/
            #endregion

            // Iterate every button on the grid (Container)
            Container.Children.Cast<Button>().ToList().ForEach(button => 
            {
                //Change content and background to default
                button.Content = string.Empty;
                button.Background = Brushes.Green;

                var column = Grid.GetColumn(button);
                var row = Grid.GetRow(button);
                var index = column + (row * 5);

                if(mResults[index] == MarkType.active)
                {
                    button.Background = Brushes.Yellow;
                }
            });

            //Set the game to be not finished
            mGameEnded = false;
        }

        #region Array Duplicate Checker
        /// <summary>
        /// Checks the array for duplicate values
        /// </summary>
        /// <param name="array"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool Contains(int[] array, int value)
        {
            //Loop through our array
            for (int i = 0; i < array.Length; i++)
            {
                //If value is in the array, we need to run again
                if (array[i] == value) return true;
            }
            return false;
        }
        #endregion

        /// <summary>
        /// Handles button click event
        /// </summary>
        /// <param name="sender">The button that was clicked</param>
        /// <param name="e">The events of the click</param>
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            //Start a new game on the click after it finished
            if(mGameEnded)
            {
                NewGame();
                return;
            }

            //Cast the sender to a button
            var button = (Button)sender;

            //Find the buttons position in the array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            //Get the index location in the array mResults
            var index = column + (row * 5);

            //Set the colour change
            if(mResults[index] == MarkType.inactive)
            {
                button.Background = Brushes.Yellow;
                mResults[index] = MarkType.active;
                //Check Neighbouring Cells
                CheckNeighbourss(column, row);
            } 
            else
            {
                button.Background = Brushes.Green;
                mResults[index] = MarkType.inactive;
                //Check Neighbouring Cells
                CheckNeighbourss(column, row);
            }

            CheckForWin();
        }

        /// <summary>
        /// Checks the neighbouring cells of the selected button
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        private void CheckNeighbourss(int column, int row)
        {
            for (int colNum = column - 1; colNum <= (column + 1); colNum += 1)
            {
                for (int rowNum = row - 1; rowNum <= (row + 1); rowNum += 1)
                {
                    //if not the center cell 
                    if (!((colNum == column) && (rowNum == row)))
                    {
                        //make sure it is within  grid
                        if (withinGrid(colNum, rowNum))
                        {
                            //Console.WriteLine("Neighbor of " + column + " " + row + " - " + colNum + " " + rowNum); //Used for debugging the neighbouring cells
                            var neighbourIndex = colNum + (rowNum * 5);
                            //Will get the Button object using the column and row number obtained from the loops above
                            Button nearButton = Container.Children.Cast<Button>().First(e => Grid.GetRow(e) == rowNum && Grid.GetColumn(e) == colNum);
                            //Only want the NORTH, SOUTH, EAST and WEST buttons, so ignores the diagonals
                            if (rowNum == row || colNum == column)
                            {
                                if (mResults[neighbourIndex] == MarkType.active)
                                {
                                    nearButton.Background = Brushes.Green;
                                    mResults[neighbourIndex] = MarkType.inactive;

                                }
                                else
                                {
                                    nearButton.Background = Brushes.Yellow;
                                    mResults[neighbourIndex] = MarkType.active;
                                }
                            }
                        }
                    }
                }
            }
        }

        #region Cells Within Grid
        /// <summary>
        /// Define if a cell is within the grid.
        /// </summary>
        /// <param name="colNum"></param>
        /// <param name="rowNum"></param>
        /// <returns></returns>
        private bool withinGrid(int colNum, int rowNum)
        {
            if ((colNum < 0) || (rowNum < 0))
            {
                //false if row or col are negative
                return false;
            }
            if ((colNum >= 5) || (rowNum >= 5))
            {
                //false if row or col are > 5
                return false;
            }
            return true;
        }
        #endregion

        /// <summary>
        /// Check for the win condition and restart the game
        /// </summary>
        private void CheckForWin()
        {
            int inactiveCount = 0;
            for(var i = 0; i < mResults.Length; i++)
            {
                if(mResults[i] == MarkType.inactive)
                {
                    inactiveCount++;
                }
            }

            //Check that we have turned off all 25 cells
            if(inactiveCount >= 25)
            {
                //End the game, causes restart
                mGameEnded = true;
            }
        }
    }
}
