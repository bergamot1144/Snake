using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using _Snake;


class Program
{
    static void Main()
    {
        int width = 40;
        int height = 20;
        int score = 0;
        bool gameOver = false;
        int speed = 100;

        Snake snake = new Snake(width / 2, height / 2);
        Point food = Food.Generate(width, height, snake);

        while (!gameOver)
        {
            Console.Clear();
            snake.Move();

            if (snake.HasCollided(width, height))
            {
                gameOver = true;
            }

            if (snake.Head.X == food.X && snake.Head.Y == food.Y)
            {
                snake.Grow();
                food = Food.Generate(width, height, snake);
                score += 10;
                speed = Math.Max(20, speed - 5); // Ускоряем змейку
            }

            Draw(snake, food, width, height, score);

            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                snake.ChangeDirection(key);
            }

            Thread.Sleep(speed);
        }

        Console.Clear();
        Console.WriteLine("Игра окончена!");
        Console.WriteLine($"Ваш счёт: {score}");
    }

    static void Draw(Snake snake, Point food, int width, int height, int score)
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    Console.Write('#');
                }
                else if (x == food.X && y == food.Y)
                {
                    Console.Write('O');
                }
                else if (snake.IsOnSnake(x, y))
                {
                    Console.Write('o');
                }
                else
                {
                    Console.Write(' ');
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine($"Счёт: {score}");
    }
}


enum Direction
{
    Up,
    Down,
    Left,
    Right
}


