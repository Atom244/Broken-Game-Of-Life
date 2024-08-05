using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 15;
            Console.WindowWidth = 45;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\nBroken Game Of Life\n\n");
            Console.ResetColor();


            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.Write("Type the height of simulation window: ");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.Write("Type the width of simulation window: ");
            int width = Convert.ToInt32(Console.ReadLine());
            Console.Write("Type the delay of simulation(ms): ");
            int delay = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();

            int[,] board = new int[height, width];
            Console.WindowHeight = board.GetLength(0);
            Console.WindowWidth = board.GetLength(1)*2;

            while (true) 
            {

                for (int i = 1; i < board.GetLength(0); i++)
                {
                    for (int j = 1; j < board.GetLength(1); j++)
                    {
                        if (board[i, j] == 1)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(board[i, j] + " ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(board[i, j] + " ");
                            Console.ResetColor();
                        }

                        board[i, j] = 0;
                        board[10, 10] = 1;
                        board[11, 11] = 1;
                        board[11, 10] = 1;
                        board[10, 12] = 1;
                        // Logistic
                        if (i + 1 < board.GetLength(0) && j + 1 < board.GetLength(1) && i - 1 > 0 && j - 1 > 0)
                        {
                            int zeroCount = 0;
                            int sector1 = board[i - 1, j - 1];
                            if (sector1 == 1) {zeroCount += 1;}                                                             
                            int sector2 = board[i, j - 1];
                            if (sector2 == 1) { zeroCount += 1; }
                            int sector3 = board[i + 1, j - 1];
                            if (sector3 == 1) { zeroCount += 1; }
                            int sector4 = board[i - 1, j];
                            if (sector4 == 1) { zeroCount += 1; }
                            int sector5 = board[i + 1, j];
                            if (sector5 == 1) { zeroCount += 1; }
                            int sector6 = board[i - 1, j + 1];
                            if (sector6 == 1) { zeroCount += 1; }
                            int sector7 = board[i, j + 1];
                            if (sector7 == 1) { zeroCount += 1; }
                            int sector8 = board[i + 1, j + 1];
                            if (sector8 == 1) { zeroCount += 1; }

                            if (zeroCount == 3 || zeroCount == 2) 
                            { 
                                board[i, j] = 1; 
                            }
                            else 
                            {
                                board[i, j] = 0;
                            }

                        }

                        
                    }
                    Console.WriteLine();

                    
                }
                //Console.ReadKey();
                System.Threading.Thread.Sleep(delay);
                Console.Clear();
            }

            
            
        }
    }
}
