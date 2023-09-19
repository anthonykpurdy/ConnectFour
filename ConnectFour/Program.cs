using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    internal class Program
    {
        public const int EMPTY = 0;

        public const int YELLOW = 1;

        public const int RED = 2;
        

        static void Main(string[] args)

        {
            
            
            Player player = new Player();
            
            Referee referee = new Referee();

            int round = 0;
            int redwins = 0;
            int yellowwins = 0;
            int gamesPlayed = 0;
            int[] rounds = new int[100];
            for (gamesPlayed = 0; gamesPlayed < 100; gamesPlayed++)
            {
                round = 0;
                Board board = new Board();
                
                while (true)
                {
                    player.MakeMove(board, YELLOW);
                    board.Draw();
                    if (referee.DetectWin(board, YELLOW, "Improved computer won"))
                    {
                        yellowwins++;
                        break;
                    }

                    player.MakeMove2(board, RED);
                    board.Draw();
                    if (referee.DetectWin(board, RED, "Computer"))
                    {
                        redwins++;
                        break;
                    }



                    round++;
                    if (round == 42)
                    {
                        Console.WriteLine("It's a Tie!");
                        break;
                    }

                }
                rounds[gamesPlayed] = round;

                
            }
            float winPerc = ((float)redwins  / (float)gamesPlayed) * 100;
            float winPercyellow = ((float)yellowwins / (float)gamesPlayed) * 100;
            Console.WriteLine($"Average rounds {rounds.Average()}");
            Console.WriteLine($"Improved AI won {winPerc}%");
            Console.WriteLine($"Random won {winPercyellow}%");
            
            Console.ReadLine();


        }
    }
}
