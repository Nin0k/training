using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _2._2._1.GAME
{
    class Game
    {
        readonly int width = 100;
        readonly int height = 30;

        static readonly Random random = new Random();

        static readonly int quantity = 10;
        static readonly int maxHealth = 5;

        readonly Enemy[] spider = new Enemy[quantity];
        readonly Barrier[] river = new Barrier[quantity];
        readonly Bonus[] ring = new Bonus[quantity];
        readonly Medicine[] medicine = new Medicine[maxHealth];
        readonly Player hobbit;


        internal Game()
        {
            Console.SetWindowSize(width + 1, height + 1);
            Console.CursorVisible = false;

            this.MapBorder();

            hobbit = new Player(random.Next(2, width - 1), random.Next(3, height - 1));
           
            hobbit.health = maxHealth;
            hobbit.Health();


            this.DrawGameObject();

            TimerCallback tm = new TimerCallback(this.MotionEnemy);
            Timer timer = new Timer(tm, null, 0, 1000);


            while (true)
            {
                this.Meeting();
                this.hobbit.Draw();
                hobbit.oldX = hobbit.X;
                hobbit.oldY = hobbit.Y;

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.RightArrow:
                        hobbit.Remove();
                        hobbit.X++;

                        if (hobbit.X >= width - 1)
                        {
                            hobbit.X = width - 2;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        hobbit.Remove();
                        hobbit.X--;

                        if (hobbit.X <= 1)
                        {
                            hobbit.X = 2;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        hobbit.Remove();
                        hobbit.Y--;

                        if (hobbit.Y <= 2)
                        {
                            hobbit.Y = 3;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        hobbit.Remove();
                        hobbit.Y++;

                        if (hobbit.Y >= height - 1)
                        {
                            hobbit.Y = height - 2;
                        }
                        break;

                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;

                }
            }
        }

        private void MapBorder()
        {
            string border = new string('-', width + 1);

            Console.SetCursorPosition(0, 0);
            Console.Write(border);
            Console.SetCursorPosition(0, height);
            Console.Write(border);
            Console.SetCursorPosition(0, 2);
            Console.Write(border);
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write('|');
                Console.SetCursorPosition(width, i);
                Console.Write('|');
            }
        }
        private void DrawGameObject()
        {
            for (int i = 0; i < maxHealth; i++)
            {
                medicine[i] = new Medicine(random.Next(2, width - 1), random.Next(3, height - 1));
                medicine[i].Draw();
            }

            for (int i = 0; i < quantity; i++)
            {
                spider[i] = new Enemy(random.Next(2, width - 1), random.Next(3, height - 1));
                spider[i].Draw();

                river[i] = new Barrier(random.Next(2, width - 4), random.Next(3, height - 1));
                river[i].Draw();

                ring[i] = new Bonus(random.Next(2, width - 1), random.Next(3, height - 1));
                ring[i].Draw();
            }
        }

        private void MotionEnemy(object obj)
        {
            for (int i = 0; i < quantity; i++)
            {
                spider[i].Remove();
                spider[i].Motion();
                for (int k = 0; k < quantity; k++)
                {
                    if (spider[i].Y == river[k].Y && (spider[i].X == river[k].X || spider[i].X == river[k].X + 1 || spider[i].X == river[k].X + 2 || spider[i].X == river[k].X + 3))
                    {
                        spider[i].X = spider[i].oldX;
                        spider[i].Y = spider[i].oldY;
                    }
                    else if (spider[i].X == ring[k].X && spider[i].Y == ring[k].Y)
                    {
                        spider[i].X = spider[i].oldX;
                        spider[i].Y = spider[i].oldY;
                    }
                }

                for (int j = 0; j < maxHealth; j++)
                {
                    if (spider[i].X == medicine[j].X && spider[i].Y == medicine[j].Y)
                    {
                        spider[i].X = spider[i].oldX;
                        spider[i].Y = spider[i].oldY;

                    }
                }
                spider[i].Draw();
            }
        }

        private void Meeting()
        {
            for (int i = 0; i < quantity; i++)
            {
                if (hobbit.X == spider[i].X && hobbit.Y == spider[i].Y)
                {
                    hobbit.health--;
                    hobbit.Health();
                }
                else if (hobbit.Y == river[i].Y && (hobbit.X == river[i].X || hobbit.X == river[i].X + 1 || hobbit.X == river[i].X + 2 || hobbit.X == river[i].X + 3))
                {
                    hobbit.X = hobbit.oldX;
                    hobbit.Y = hobbit.oldY;
                }
                else if (hobbit.X == ring[i].X && hobbit.Y == ring[i].Y)
                {
                    hobbit.bonus++;
                    hobbit.GetBonus();
                }

            }
            for (int i = 0; i < maxHealth; i++)
            {
                if (hobbit.X == medicine[i].X && hobbit.Y == medicine[i].Y)
                {
                    if (hobbit.health < 5)
                    {
                        hobbit.health++;
                        hobbit.Health();
                    }

                }
            }
        }
    }
}
