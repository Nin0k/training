using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._1.GAME
{
    abstract class GameObject
    {

        private int _X { get; set; }
        private int _Y { get; set; }

        public int X
        {
            get
            {
                return _X;
            }

            set
            {
                _X = value;
            }
        }
        public int Y
        {
            get
            {
                return _Y;
            }

            set
            {
                _Y = value;
            }
        }
        internal abstract void Draw();

    }

    class Player : GameObject
    {
        public int oldX;
        public int oldY;
        public int health;
        public int bonus = 0;
        char playerChar = 'X';

       
        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Health()
        {
            Console.SetCursorPosition(1, 1);
            if (health != 0)
            {
                if (health >= 4)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (health < 4 && health > 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (health <= 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write("Здоровье:");
                Console.Write(health);
            }
            else if (health == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Здоровье:");
                Console.Write(health);
                new GameOver(0);
            }

        }
        public void GetBonus()
        {
            Console.SetCursorPosition(50, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Колец собрано:");
            Console.Write(bonus);
            if (bonus == 9)
            {
                new GameOver(1);
            }
        }
        internal override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(X, Y);
            if (playerChar == 'X')
            {
                playerChar = 'Y';
            }
            else
            {
                playerChar = 'X';
            }

            Console.Write(playerChar);
        }
        public void Remove()
        {
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(" ");
        }

    }

    class Enemy : GameObject
    {
        public int oldX;
        public int oldY;
        readonly int width = 100;
        readonly int height = 30; 

        readonly int beginWidth = 1;
        readonly int beginHeight = 2;

        readonly Random random = new Random();
        public Enemy(int x, int y)
        {
            X = x;
            Y = y;
        }
        internal override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(X, Y);

            Console.Write('Ж');

        }
        public void Remove()
        {
            Console.SetCursorPosition(X, Y);
            Console.WriteLine(" ");
        }

        public void Motion()
        {
            oldX = X;
            oldY = Y;
            X += random.Next(-1, 2);
            Y += random.Next(-1, 2);
            if (X <= beginWidth)
            {
                X = beginWidth + 1;
            }
            else if (X >= width)
            {
                X = width-1;
            }

            if (Y <= beginHeight)
            {
                Y = beginHeight + 1;
            }
            else if (Y >= height)
            {
                Y = height-1;
            }
        }

    }
    class Barrier : GameObject
    {
        internal override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(X, Y);
            Console.Write("~~~~");
        }

        public Barrier(int x, int y)
        {
            X = x;
            Y = y;
        }

    }

    class Bonus : GameObject
    {
        internal override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(X, Y);
            Console.Write("o");
        }

        public Bonus(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    class Medicine : GameObject
    {
        internal override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(X, Y);
            Console.Write("+");
        }

        public Medicine(int x, int y)
        {
            X = x;
            Y = y;
        }

    }

}
