using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Snake
{
    
    class Snake
    {
        public Point Head => _body.First();
        private List<Point> _body;
        private Direction _direction;

        public Snake(int startX, int startY)
        {
            _body = new List<Point> { new Point(startX, startY) };
            _direction = Direction.Right;
        }

        public void Move()
        {
            Point newHead = new Point(Head.X, Head.Y);

            switch (_direction)
            {
                case Direction.Up: newHead.Y--; break;
                case Direction.Down: newHead.Y++; break;
                case Direction.Left: newHead.X--; break;
                case Direction.Right: newHead.X++; break;
            }

            _body.Insert(0, newHead);
            _body.RemoveAt(_body.Count - 1);
        }

        public void Grow()
        {
            _body.Add(new Point(_body.Last().X, _body.Last().Y));
        }

        public bool HasCollided(int width, int height)
        {
            // Проверка на столкновение со стенками
            if (Head.X <= 0 || Head.X >= width - 1 || Head.Y <= 0 || Head.Y >= height - 1)
                return true;

            // Проверка на столкновение с самим собой
            for (int i = 1; i < _body.Count; i++)
            {
                if (Head.X == _body[i].X && Head.Y == _body[i].Y)
                    return true;
            }

            return false;
        }

        public void ChangeDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.W:
                    if (_direction != Direction.Down) _direction = Direction.Up;
                    break;
                case ConsoleKey.S:
                    if (_direction != Direction.Up) _direction = Direction.Down;
                    break;
                case ConsoleKey.A:
                    if (_direction != Direction.Right) _direction = Direction.Left;
                    break;
                case ConsoleKey.D:
                    if (_direction != Direction.Left) _direction = Direction.Right;
                    break;
            }
        }

        public bool IsOnSnake(int x, int y)
        {
            return _body.Any(point => point.X == x && point.Y == y);
        }
    }
}
