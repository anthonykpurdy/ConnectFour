using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public class Board
    {
        
        public int[,] Spaces = new int[7,6];

        public Board() 
        { 
            for(int i = 0; i < Spaces.GetLength(0); i++)
            {
                for(int j = 0; j < Spaces.GetLength(1); j++)
                {
                    Spaces[i, j] = Program.EMPTY;
                }
            }
        }
        public Board(Board prevBoard)
        {
            for (int i = 0; i < Spaces.GetLength(0); i++)
            {
                for (int j = 0; j < Spaces.GetLength(1); j++)
                {
                    Spaces[i, j] = prevBoard.Spaces[i,j];
                }
            }
        }

        public void Draw()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            for(int row = 0; row < Spaces.GetLength(1); row++)
            {
                for(int col = 0; col < Spaces.GetLength(0); col++)
                {
                    PrintState(Spaces[col, row]);
                    if(col < Spaces.GetLength(0)-1)
                        Console.Write($" | ");
                }

                Console.WriteLine("\n--------------------------");
            }
        }
        static void PrintState(int state)

        {

            if (state == Program.EMPTY)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(" ");
            }

                

            else if (state == Program.RED)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("O");
                Console.ForegroundColor = ConsoleColor.Blue;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("O");
                Console.ForegroundColor = ConsoleColor.Blue;

            }

        }

        public bool Isempty(int column, int color)
        {
            bool returnvalue = false;
            column = column - 1;

            for (int row = 5; row >= 0; row--)
            {
                if (Spaces[column, row] == Program.EMPTY)
                { 
                    returnvalue = true;
                    break;
                }
            }

            return returnvalue;
        }

        public bool DropPiece(int column, int color)
        {
           
            bool returnvalue = false;
            column = column - 1;

                for (int row = 5; row >= 0; row--)
                {
                    if (Spaces[column, row] == Program.EMPTY)
                    {
                        Spaces[column, row] = color;
                        returnvalue = true;
                        break;
                    }
                }
            
            return returnvalue;
        }
    }
}
