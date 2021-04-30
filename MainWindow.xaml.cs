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
        #region
        /// <summary>
        /// Holds the current results of cells in the acitve game
        /// </summary>
        private MarkType[] mResults;
        /// <summary>
        /// True if the game has ended
        /// </summary>
        private bool mGameEnded;
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

            Random randNum = new Random();
            int[] numbersToUse = new int[5];

            //Get 5 random indexes in the mResults array
            for (var i = 0; i < numbersToUse.Length; i++)
            {
                numbersToUse[i] = randNum.Next(0, 25);
            }

            //Set every value to be inactive
            for (var i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.inactive;
                //Set a specified amount of them to be active
                for(var j = 0; j < numbersToUse.Length; j++)
                {
                    int number = numbersToUse[j];
                    if(i == number)
                    {
                        mResults[i] = MarkType.active;
                    }
                }
            }

            // Iterate every button on the grid (Container)
            Container.Children.Cast<Button>().ToList().ForEach(button => 
            {
                //Change content and background to default
                //button.Content = string.Empty;
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

        /// <summary>
        /// Handles button click event
        /// </summary>
        /// <param name="sender">The button that was clicked</param>
        /// <param name="e">The events of the click</param>
        private void Button_Click(object sender, RoutedEventArgs e)
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
                CheckSurroundings(column, row);
            } 
            else
            {
                button.Background = Brushes.Green;
                mResults[index] = MarkType.inactive;
                CheckSurroundings(column, row);
            }

            CheckForWin();
        }

        /// <summary>
        /// Checks the neighbouring cells of the selected button
        /// </summary>
        /// <param name="column"></param>
        /// <param name="row"></param>
        private void CheckSurroundings(int column, int row)
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
                            Button nearButton = Container.Children.Cast<Button>().First(e => Grid.GetRow(e) == rowNum && Grid.GetColumn(e) == colNum);
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
                return false;    //false if row or col are negative
            }
            if ((colNum >= 5) || (rowNum >= 5))
            {
                return false;    //false if row or col are > 75
            }
            return true;
        }

        /// <summary>
        /// Check for the win condition and restart the game
        /// </summary>
        private void CheckForWin()
        {
            int activeCount = 0;
            for(var i = 0; i < mResults.Length; i++)
            {
                if(mResults[i] == MarkType.active)
                {
                    activeCount++;
                }
            }

            if(activeCount >= 25)
            {
                NewGame();
            }
        }
    }
}
