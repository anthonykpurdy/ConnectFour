using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public class Referee
    {
        public bool DetectWin(Board board, int color, string name)
        {
            bool win = false;
            // Check Horizontal wins
            for (int i = 0; i < 6; i++)
            {
                // Check for the four possible four connected in each row
                for (int j = 0; j < 4; j++)
                {
                    if (board.Spaces[j, i] == color
                    && board.Spaces[j + 1, i] == color
                    && board.Spaces[j + 2, i] == color
                    && board.Spaces[j + 3, i] == color)
                    {
                        win = true;
                        break;
                    }
                }
            }
            // Check Vertical wins
            for (int i = 0; i < 7; i++)
            {
                // Check for the three possible four connected in each column
                for (int j = 0; j < 3; j++)
                {
                    if (board.Spaces[i, j] == color
                    && board.Spaces[i, j + 1] == color
                    && board.Spaces[i, j + 2] == color
                    && board.Spaces[i, j + 3] == color)
                    {
                        win = true;
                        break;
                    }
                }
            }
            // Check Diagonal Up wins
            // Must check the bottom three rows of the first 4 columns
            for (int i = 3; i <= 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board.Spaces[j, i] == color
                    && board.Spaces[j + 1, i - 1] == color
                    && board.Spaces[j + 2, i - 2] == color
                    && board.Spaces[j + 3, i - 3] == color)
                    {
                        win = true;
                        break;
                    }
                }
            }
            // Check Diagonal Down wins
            // Must check the top three rows of the first 4 columns
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board.Spaces[j, i] == color
                    && board.Spaces[j + 1, i + 1] == color
                    && board.Spaces[j + 2, i + 2] == color
                    && board.Spaces[j + 3, i + 3] == color)
                    {
                        win = true;
                        break;
                    }
                }
            }
            if (win)
            {
                board.Draw();
                Console.WriteLine($"\n{name} wins!");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

