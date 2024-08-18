using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Snake
{
    class Food
    {
        public static Point Generate(int width, int height, Snake snake)
        {
            Random random = new Random();
            Point food;

            do
            {
                food = new Point(random.Next(1, width - 1), random.Next(1, height - 1));
            } while (snake.IsOnSnake(food.X, food.Y));

            return food;
        }
    }
}
