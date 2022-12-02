using System;
using System.Diagnostics;
using System.Xml.Linq;
using static System.Console;

namespace SnakeConsole
{
    class Program
    {
        private const int Width = 30;
        private const int Height = 20;

        private const int ScreenWidth = Width * 2;
        private const int ScreenHeight = Height * 2;

        private const int FrameMs = 200;

        private const ConsoleColor BoarderColor = ConsoleColor.DarkGray;

        private const ConsoleColor HeadColor = ConsoleColor.Green;
        private const ConsoleColor BodyColor = ConsoleColor.Blue;
        private const ConsoleColor FoodColor = ConsoleColor.Red;

        private static readonly Random Random = new Random();

        static void Main(string[] args)
        {
            SetWindowSize(ScreenWidth, ScreenHeight);
            SetBufferSize(ScreenWidth, ScreenHeight);

            CursorVisible = false;

            while (true)
            {
                StartGame();

                Thread.Sleep(1000);
                ReadKey();
            }
        }

        static void StartGame()
        {
            Clear();

            DrowBoard();

            var snake = new Snake(10, 5, HeadColor, BodyColor);

            Direction currentMovement = Direction.Right;

            Pixel food = GenFood(snake);
            food.Drow();

            Stopwatch sw = new Stopwatch();

            int _score = 0;

            while (true)
            {
                sw.Restart();

                Direction oldMovement = currentMovement;
                while (sw.ElapsedMilliseconds < FrameMs)
                {
                    if (oldMovement == currentMovement)
                        currentMovement = ReadMove(currentMovement);
                }

                if (snake.Head.X == food.X && snake.Head.Y == food.Y)
                {
                    snake.Move(currentMovement, true);

                    food = GenFood(snake);
                    food.Drow();

                    _score++;

                    Task.Run(() => Beep(400, 200));
                }
                else
                {
                    snake.Move(currentMovement);
                }

                
                if (snake.Head.X == Width - 1
                    || snake.Head.X == 0
                    || snake.Head.Y == Height - 1
                    || snake.Head.Y == 0
                    || snake.Body.Any(b => b.X == snake.Head.X && b.Y == snake.Head.Y))
                    break;

            }

            snake.Clear();
            food.Clear();

            SetCursorPosition(ScreenWidth / 3 + 2, ScreenHeight / 2 - 2);
            WriteLine($"GameOver, score: {_score}");

            Task.Run(() => Beep(200, 500));
        }

        static Pixel GenFood(Snake snake)
        {
            Pixel food;

            do
            {
                food = new Pixel(Random.Next(1, Width - 2), Random.Next(1, Height - 2), FoodColor);
            } while (snake.Head.X == food.X && snake.Head.Y == food.Y
            || snake.Body.Any(b => b.X == food.X && b.Y == food.Y));

            return food;
        }

        static Direction ReadMove(Direction currentDiraction)
        {
            if(!KeyAvailable)
                return currentDiraction;
            ConsoleKey key = ReadKey(true).Key;

            currentDiraction = key switch
            {
                ConsoleKey.UpArrow when currentDiraction != Direction.Down => Direction.Up,
                ConsoleKey.DownArrow when currentDiraction != Direction.Up => Direction.Down,
                ConsoleKey.LeftArrow when currentDiraction != Direction.Right => Direction.Left,
                ConsoleKey.RightArrow when currentDiraction != Direction.Left => Direction.Right,
                _ => currentDiraction
            };

            return currentDiraction;
        }

        static void DrowBoard()
        {
            for (int i = 0; i < Width; i++)
            {
                new Pixel(i, 0, BoarderColor).Drow();
                new Pixel(i, Height - 1, BoarderColor).Drow();
            }
            for (int i = 0; i < Height; i++)
            {
                new Pixel(0, i, BoarderColor).Drow();
                new Pixel(Width - 1, i, BoarderColor).Drow();
            }

        }
    }
}