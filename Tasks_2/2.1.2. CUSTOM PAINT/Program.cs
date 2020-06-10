using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._2.CUSTOM_PAINT
{
   class Figure
    {
        public double x;
        public double y;

        public string GetInfoPoint()
        {
            return $"Центр фигуры: x={x}, y={y}. ";
        }
        
    }
    abstract class RoundShape : Figure
    {
        public double radius;
       
        public double GetСircumference()
        {
            return 2* Math.PI * radius;
        }
        public abstract string GetInfoFigure();
       
    }
    class Circle : RoundShape
    {
        public override string GetInfoFigure()
        {
            return $"Длина описанной окружности = {this.GetСircumference()}";
        }

    }
    class Round : RoundShape
    {
        public double GetArea()
        {
            return Math.PI * radius * radius;
            
        }

        public override string GetInfoFigure()
        {
            return $"Длина описанной окружности = {this.GetСircumference()}. Площадь круга = {this.GetArea()}.";
        }
    }

    class Ring : RoundShape
    {
        public double smallRadius;

        public double GetArea()
        {
            return Math.PI * (radius * radius - smallRadius * smallRadius);
        }
        
        public double GetSumLengths()
        {
            return this.GetСircumference() + (2 * Math.PI * smallRadius);
        }

        public override string GetInfoFigure()
        {
            return $"Сумма длин внешней и внутренней окружностей = {this.GetSumLengths()}. Площадь кольца = {this.GetArea()}.";
        }

    }

    abstract class Polygons : Figure
    {
        public double width;
        public double height;
        public abstract double GetArea();
        public abstract double GetPerimeter();

        // public abstract string GetInfoFigure();
        public string InfoFigure()
        {
            return $"Площадь = {this.GetArea()}. Периметр = {this.GetPerimeter()}";
        }

    }
    class Rectangle : Polygons
    {
        public override double GetArea()
        {
            return width * height;
        }

        public override double GetPerimeter()
        {
            return 2 * (width + height);
        }
    }
   
    class Square : Polygons
    {
       
        public override double GetArea()
        {
            return width * width;
        }

        public override double GetPerimeter()
        {
            return 4 * width;
        }
    }
    class Triangle : Polygons
    {
        public double b;
        public double c;
        public override double GetArea()
        {
            return 0.5 * width * height;
        }

        public override double GetPerimeter()
        {
            return width + b + c;
        }
    }
    class Program
    {
        enum Action
        {
            None,
            Add,
            Withdraw,
            Remove,
            Exit
        }

        [Flags]
        enum Figure 
        {
             None = 0,
             Circle = 1,
             Round = 2,
             Ring = 4,
             Rectangle = 8,
             Square = 16,
             Triangle = 32,
             Line = 64
           /* None,
            Circle,
            Round,
            Ring,
            Rectangle,
            Square,
            Triangle,
            Line */

        }
      
        static void Main(string[] args)
        {
            

            var type_figure = Figure.None;
            while (true)
            {
                double point_x = 0;
                double point_y = 0;
                double radius;

                bool InputPoints()
                {
                    Console.Write("Введите координату центра по х: ");
                    //point_x = double.Parse(Console.ReadLine());
                    if (Double.TryParse(Console.ReadLine(), out point_x))
                    {
                        Console.Write("Введите координату центра по у: ");
                        if (Double.TryParse(Console.ReadLine(), out point_y))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
               
                bool InputRadius()
                {

                    Console.Write("Введите радиус: ");
                    if (Double.TryParse(Console.ReadLine(), out radius))
                    {
                        if (radius > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                        
                    }
                    else
                    {
                        return false;
                    }
                }
                string WrongInput (int i)
                {
                    if (i==1)
                    {
                        return "Вы ввели некорректные данные";
                    }
                    else
                    {
                        return "Неверная команда";
                    }
                    
                    
                }

                /*bool InputValidation ( double check)
                {
                    if(check > 0)
                }*/

                Console.WriteLine("Выберите действие:");
                Console.WriteLine("     1: Добавить фигуру");
                Console.WriteLine("     2: Вывести фигуры");
                Console.WriteLine("     3: Очистить холст");
                Console.WriteLine("     4: Выход");

                int action_new = int.Parse(Console.ReadLine());


                switch (action_new)
                {
                    case 1:
                        
                        Console.WriteLine("Введите:");
                        Console.WriteLine("     1: Cricle (окружность)");
                        Console.WriteLine("     2: Round (круг)");
                        Console.WriteLine("     3: Ring (кольцо)");
                        Console.WriteLine("     4: Rectangle (прямоугольгик)");
                        Console.WriteLine("     5: Square (квадрат)");
                        Console.WriteLine("     6: Triangle (треугольник)");
                        Console.WriteLine("     7: Line (линия)");

                        int figure_new = int.Parse(Console.ReadLine());

                        switch (figure_new)
                        {
                            case 1:
                               
                                if(InputPoints() && InputRadius())
                                {
                                       
                                            Circle circle = new Circle
                                            {
                                                x = point_x,
                                                y = point_y,
                                                radius = radius
                                            };

                                            Console.WriteLine("Рисуем окружноть...");
                                            Console.WriteLine(circle.GetInfoPoint());
                                            Console.WriteLine(circle.GetInfoFigure());

                                }
                                else
                                {
                                    Console.WriteLine(WrongInput(1));
                                }

                                break;

                            case 2:

                                if (InputPoints() && InputRadius())
                                {
                                    
                                        Round round = new Round
                                        {
                                            x = point_x,
                                            y = point_y,
                                            radius = radius
                                        };

                                        Console.WriteLine("Рисуем круг...");
                                        Console.WriteLine(round.GetInfoPoint());
                                        Console.WriteLine(round.GetInfoFigure());

                                        type_figure |= Figure.Round;
                                }
                                else
                                {
                                    Console.WriteLine(WrongInput(1));
                                }

                                
                                
                                break;

                            case 3:

                                if (InputPoints() && InputRadius())
                                {
                                        Console.Write("Введите малый радиус: ");

                                        if (Double.TryParse(Console.ReadLine(), out double smallRadius) && radius > smallRadius && smallRadius > 0)
                                        {
                                                Ring ring = new Ring
                                                {
                                                    x = point_x,
                                                    y = point_y,
                                                    radius = radius,
                                                    smallRadius = smallRadius
                                                };

                                                Console.WriteLine("Рисуем кольцо...");
                                                Console.WriteLine(ring.GetInfoPoint());
                                                Console.WriteLine(ring.GetInfoFigure());
                                                type_figure |= Figure.Ring;
                                            
                                        }
                                        else
                                        {
                                            Console.WriteLine(WrongInput(1));
                                        }
                                }
                                else
                                {
                                    Console.WriteLine(WrongInput(1));
                                }

                                break;

                            case 4:

                                if (InputPoints())
                                {
                                    Console.Write("Введите ширину: ");
                                    double a = double.Parse(Console.ReadLine());
                                    if (a > 0)
                                    {
                                         Console.Write("Введите высоту: ");
                                         double b = double.Parse(Console.ReadLine());
                                         if (b > 0)
                                         {

                                             Rectangle rectangle = new Rectangle
                                             {
                                                 x = point_x,
                                                 y = point_y,
                                                 width = a,
                                                 height = b
                                                };

                                             Console.WriteLine("Рисуем прямоугольник...");
                                             Console.WriteLine(rectangle.GetInfoPoint());
                                             Console.WriteLine(rectangle.InfoFigure());

                                            type_figure |= Figure.Rectangle;
                                         }
                                         else
                                         {
                                            Console.WriteLine(WrongInput(1));
                                         }
                                    }
                                    else
                                    {
                                        Console.WriteLine(WrongInput(1));
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(WrongInput(1));
                                }

                                break;
                            case 5:

                                if (InputPoints())
                                {
                                        Console.Write("Введите ширину: ");
                                        double a = double.Parse(Console.ReadLine());
                                        if (a > 0)
                                        { 
                                            Square square = new Square
                                            {
                                                    x = point_x,
                                                    y = point_y,
                                                    width = a,
                                                    height = a
                                            };

                                                Console.WriteLine("Рисуем квадрат...");
                                                Console.WriteLine(square.GetInfoPoint());
                                                Console.WriteLine(square.InfoFigure());

                                                type_figure |= Figure.Square;
                                        }
                                        else
                                        {
                                            Console.WriteLine(WrongInput(1));
                                        }
                                }
                                else
                                {
                                    Console.WriteLine(WrongInput(1));
                                }

                                break;
                            case 6:

                                if (InputPoints())
                                {
                                    
                                        Console.Write("Введите сторону а: ");
                                            double a = double.Parse(Console.ReadLine());

                                        Console.Write("Введите сторону b: ");
                                            double b = double.Parse(Console.ReadLine());

                                        Console.Write("Введите сторону c: ");
                                            double c = double.Parse(Console.ReadLine());

                                        Console.Write("Введите высоту: ");
                                            double h = double.Parse(Console.ReadLine());

                                        if (a > 0 && b > 0 && c > 0 && h > 0)
                                        { 
                                            
                                            Triangle triangle = new Triangle
                                            {
                                                x = point_x,
                                                y = point_y,
                                                width = a,
                                                b = b,
                                                c = c,
                                                height = h
                                                
                                            };

                                            Console.WriteLine("Рисуем треугольник...");
                                            Console.WriteLine(triangle.GetInfoPoint());
                                            Console.WriteLine(triangle.InfoFigure());

                                            type_figure |= Figure.Ring;
                                        }
                                        else
                                        {
                                            Console.WriteLine(WrongInput(1));
                                        }
                                }
                                else
                                {
                                    Console.WriteLine(WrongInput(1));
                                }

                                break;

                            default:
                                    Console.WriteLine(WrongInput(0));
                                break;


                        }
                        break;

                    case 2:
                        if (type_figure== Figure.None)
                        {
                            Console.WriteLine("На холсте пусто");
                        }
                        else
                        {
                            Console.WriteLine("Фигуры на холсте " + type_figure);
                        }
                        
                        break;

                    case 3:
                        type_figure =  Figure.None;
                        Console.WriteLine("Холст очищен");
                        break;

                    case 4:
                        Console.WriteLine("Выход");
                        break;

                    default:
                        Console.WriteLine(WrongInput(0));
                        break;
                }
                   Console.ReadLine();
            }
        }
    }
}
