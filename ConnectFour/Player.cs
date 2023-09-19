using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public class Player
    {
        Random random = new Random();

        public void ChooseMove(Board board, int color)
        {
            while (true)
            {
                Console.WriteLine("Choose a column (1-7): ");
                int column = Int32.Parse(Console.ReadLine());
                if (column >= 1 || column <= 7)
                {
                    if (board.Isempty(column, color))
                    {
                        board.DropPiece(column, color);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Column is full!");
                    }
                }
                else
                {
                    Console.WriteLine("I gavew you choices, use them!");
                }


            }
        }

        public void MakeMove(Board board, int side)
        {
            int retries = 25;
            while (retries > 0) 
            {

                int randomColumn = random.Next(1,8);
                board.DropPiece(randomColumn, side);

                retries--;
                break;
            }
        }

        public void MakeMove2(Board board, int side)
        {
            Board[] futureboards =
            {
                new Board(board),
                new Board(board),
                new Board(board),
                new Board(board),
                new Board(board),
                new Board(board),
                new Board(board)

            };
            Referee referee = new Referee();

            for (int i = 0; i <7; i++)
            {
                
                futureboards[i].DropPiece(i + 1, side);
                if (referee.DetectWin(futureboards[i], side, ""))
                {
                   board.DropPiece(i + 1, side);
                   return;
                }
                
            }
            MakeMove(board, side);
        }
        

    }
}
