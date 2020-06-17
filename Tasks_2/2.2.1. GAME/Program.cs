using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _2._2._1.GAME
{
    class Program
    {
       
        static void Main(string[] args)
        {
                new Game();
        }
    }
    class Game
    {
        readonly int width = 100;
        readonly int height = 30;

        static readonly Random random = new Random();

        static readonly int n = 9;
        readonly Enemy[] spider = new Enemy[n];
        readonly Barrier[] river = new Barrier[n];
        readonly Bonus[] ring = new Bonus[n];
        readonly Medicine[] medicine = new Medicine[3];
        readonly Player hobbit = new Player();
        
        public void MapBorder()
        {
            string str = new string('-', width + 1);

            Console.SetCursorPosition(0, 0);
            Console.Write(str);
            Console.SetCursorPosition(0, height);
            Console.Write(str);
            Console.SetCursorPosition(0, 2);
            Console.Write(str);
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write('|');
                Console.SetCursorPosition(width, i);
                Console.Write('|');
            }
        }
        void MotionEnemy(object obj) 
        {
            for (int i = 0; i < n; i++)
            {
                spider[i].Remove();
                spider[i].Motion();
                for (int k = 0; k < n; k++)
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

                for (int j = 0; j < 3; j++)
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

        void Meeting() //встреча игрока с другими объектами
        {
            for (int i = 0; i < n; i++)
            {
                if (hobbit.X == spider[i].X && hobbit.Y == spider[i].Y)
                {
                    hobbit.health--;
                    hobbit.Health();
                } 
                else if (hobbit.Y == river[i].Y && (hobbit.X == river[i].X || hobbit.X == river[i].X + 1 || hobbit.X == river[i].X + 2 || hobbit.X == river[i].X + 3) )
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
            for (int i = 0; i < 3; i++)
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
        public Game()
        {
            Console.SetWindowSize(width + 1, height + 1);
            Console.CursorVisible = false;

            this.MapBorder();//рамка
           
            
                //создаем хоббита
            hobbit.X = random.Next(2, width - 1);
            hobbit.Y = random.Next(3, height - 1);
            hobbit.health = 5;
            hobbit.Health();

            //наполняем карту
            for (int i = 0; i < n; i++)
            {
                spider[i] = new Enemy(random.Next(2, width - 1), random.Next(3, height - 1));
                spider[i].Draw();

                river[i] = new Barrier(random.Next(2, width - 4), random.Next(3, height - 1));
                river[i].Draw();

                ring[i] = new Bonus(random.Next(2, width - 1), random.Next(3, height - 1));
                ring[i].Draw();
            }

            for (int i = 0; i < 3; i++)
            {
                medicine[i] = new Medicine(random.Next(2, width - 1), random.Next(3, height - 1));
                medicine[i].Draw();
            }


            TimerCallback tm = new TimerCallback(this.MotionEnemy);
            Timer timer = new Timer(tm, null, 0, 1000);


            while (true)//в бесконечном цикле проверяем нажатие, встречу и рисуем
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
    }
    class GameOver
    {
        public GameOver(int code)
        {
            Console.Clear();
            if (code == 1)
            {
                Console.Write("Вы выиграли!");
            }
            else
            {
                Console.Write("Вы проиграли!");
            }
            
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
    }
    abstract class GameObject //родительский клас. у всех объектов есть отрисовка и координаты
    {
       
        public int X { get; set; }
        public int Y { get; set; }

        public abstract void Draw();
       
    }

    class Player : GameObject //главный герой (Фродо)
    {
        public int oldX;
        public int oldY;
        public int health;
        public int bonus = 0;
        char playerChar = 'X';
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
        public void GetBonus ()
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
        public override void Draw()
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
    
    class Enemy : GameObject //противник (паук)
    {
        public int oldX;
        public int oldY;
        readonly Random random = new Random();
        public Enemy(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override void Draw()
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
            if (X <= 1)
            {
                X = 2;
            }
            else if (X >= 100)
            {
                X = 99;
            }

            if (Y <= 2)
            {
                Y = 3;
            }
            else if (Y >= 30)
            {
                Y = 29;
            }
        }
        
    }
    class Barrier : GameObject //припятствие (река)
    {
        public override void Draw()
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

    class Bonus : GameObject //бонусы (кольца)
    {
        public override void Draw()
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
    class Medicine : GameObject //аптечка (эльфийский хлеб)
    {
        public override void Draw()
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
