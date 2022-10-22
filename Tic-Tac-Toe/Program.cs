using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{

    internal class Program
    {

        static void Main(string[] args)
        {
            string xPlayer;
            string oPlayer;

            int steps = 0;

            char[,] field ={
                {'_', '_', '_'},
                {'_', '_', '_'},
                {'_', '_', '_'}
            };

            Console.WriteLine("Choose game mode: ");
            Console.WriteLine("1 - 1 vs. 1");
            Console.WriteLine("2 - vs. bot");

            var answer = Console.ReadLine();

            if (answer == "1")
            {
                Console.WriteLine("Write first name:");
                var player1 = Console.ReadLine();

                Console.WriteLine("Write second name:");
                var player2 = Console.ReadLine();

                var curentPlayer = player1;

                while (true)
                {
                    //Choose player
                    char curentChar;
                    {
                        if (curentPlayer == player1)
                        {
                            curentPlayer = player2;
                            curentChar = 'X';
                        }
                        else
                        {
                            curentPlayer = player1;
                            curentChar = 'O';
                        }
                    }
                    
                    //Print field
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            Console.Write(field[i, j] + " ");
                        }
                        Console.WriteLine();
                    }

                    //Logic
                    Console.WriteLine(curentPlayer + " your step in row");
                    var stepRow = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(curentPlayer + " your step in row");
                    var stpColumn = Convert.ToInt32(Console.ReadLine());

                    if (field[stepRow, stpColumn] == '_')
                    {
                        field[stepRow, stpColumn] = curentChar;
                        steps++;
                        {
                            //Winner 'O'
                            if ((field[0, 0] == 'O' && field[1, 0] == 'O' && field[2, 0] == 'O')
                                ^ (field[0, 1] == 'O' && field[1, 1] == 'O' && field[2, 2] == 'O')
                                ^ (field[0, 2] == 'O' && field[1, 2] == 'O' && field[2, 2] == 'O'))
                            {
                                Console.WriteLine(player1 + " Winner!");
                                break;
                            }
                            else if ((field[0, 0] == 'O' && field[1, 1] == 'O' && field[2, 2] == 'O')
                                     ^ (field[0, 2] == 'O' && field[1, 1] == 'O' && field[2, 0] == 'O'))
                            {
                                Console.WriteLine(player1 + " Winner!");
                                break;
                            }
                            else if ((field[0, 0] == 'O' && field[0, 1] == 'O' && field[0, 2] == 'O')
                                     ^ (field[1, 0] == 'O' && field[1, 1] == 'O' && field[1, 2] == 'O')
                                     ^ (field[2, 0] == 'O' && field[2, 1] == 'O' && field[2, 2] == 'O'))
                            {
                                Console.WriteLine(player1 + " Winner!");
                                break;
                            }
                            else if (steps == 9)
                            {
                                Console.WriteLine("Draw!!");
                                break;
                            }

                            //Winner 'X'
                            if ((field[0, 0] == 'X' && field[1, 0] == 'X' && field[2, 0] == 'X')
                                ^ (field[0, 1] == 'X' && field[1, 1] == 'X' && field[2, 1] == 'X')
                                ^ (field[0, 2] == 'X' && field[1, 2] == 'X' && field[2, 2] == 'X'))
                            {
                                Console.WriteLine(player2 + " Winner!");
                                break;
                            }
                            else if ((field[0, 0] == 'X' && field[1, 1] == 'X' && field[2, 2] == 'X')
                                     ^ (field[0, 2] == 'X' && field[1, 1] == 'X' && field[2, 0] == 'X'))
                            {
                                Console.WriteLine(player2 + " Winner!");
                                break;
                            }
                            else if ((field[0, 0] == 'X' && field[0, 1] == 'X' && field[0, 2] == 'X')
                                     ^ (field[1, 0] == 'X' && field[1, 1] == 'X' && field[1, 2] == 'X')
                                     ^ (field[2, 0] == 'X' && field[2, 1] == 'X' && field[2, 2] == 'X'))
                            {
                                Console.WriteLine(player2 + " Winner!");
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not empty!");
                    }
                }
            }
        }
    }
}
