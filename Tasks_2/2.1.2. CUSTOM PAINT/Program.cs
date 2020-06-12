using System;
using System.Collections.Generic;

namespace _2._1._2.CUSTOM_PAINT
{
   class Figure
    {
        public double x;
        public double y;

        public bool InputPoints()
        {
            Console.Write("Введите координату центра фигуры по х: ");
            if (Double.TryParse(Console.ReadLine(), out x))
            {
                Console.Write("Введите координату центра фигуры по у: ");
                if (Double.TryParse(Console.ReadLine(), out y))
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

        public bool InputRadius()
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

        public string InfoFigure()
        {
            return $"Площадь = {this.GetArea()}. Периметр = {this.GetPerimeter()}";
        }
        public bool InputA()
        {
            Console.Write("Введите сторону а: ");
            if (Double.TryParse(Console.ReadLine(), out width) && width > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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
        public double c;
        public override double GetArea()
        {
            return 0.5 * width * height;
        }

        public override double GetPerimeter()
        {
            return width + height + c;
        }
    }
    class Line : Figure
    {
        public double x1;
        public double y1;
        public double x2;
        public double y2;

        public string GetLineLength ()
        {
            double lineLength = Math.Sqrt((x1-x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
            return $"Длина линии {lineLength}";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string> figure = new List<string>();
            string name = "unknown";
            while (true)
            {
                
                double radius;

                string Salute()
                {
                    Console.Write("Представьтесь, пожалуйста. ");
                    name = Console.ReadLine();
                    return name;
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
                if (name == "unknown" || name == "")
                {
                    Salute();
                }
                
                Console.WriteLine($"{name}, выберите действие:");
                    Console.WriteLine("     1: Добавить фигуру");
                    Console.WriteLine("     2: Вывести фигуры");
                    Console.WriteLine("     3: Очистить холст");
                    Console.WriteLine("     4: Сменить пользователя");
                    Console.WriteLine("     5: Выход");

                    if (int.TryParse(Console.ReadLine(), out int action_new))
                    {

                        switch (action_new)
                        {
                            case 1:

                                Console.WriteLine($"{ name}, выберите фигуру:");
                                Console.WriteLine("     1: Cricle (окружность)");
                                Console.WriteLine("     2: Round (круг)");
                                Console.WriteLine("     3: Ring (кольцо)");
                                Console.WriteLine("     4: Rectangle (прямоугольгик)");
                                Console.WriteLine("     5: Square (квадрат)");
                                Console.WriteLine("     6: Triangle (треугольник)");
                                Console.WriteLine("     7: Line (линия)");

                                if (int.TryParse(Console.ReadLine(), out int figure_new))
                                {
                                    switch (figure_new)
                                    {
                                        case 1:
                                            Circle circle = new Circle();
                                            if (circle.InputPoints() && circle.InputRadius())
                                            {
                                                Console.WriteLine("Рисуем окружноть...");
                                                Console.WriteLine(circle.GetInfoPoint());
                                                Console.WriteLine(circle.GetInfoFigure());
                                                figure.Add($"Окружность. {circle.GetInfoPoint()} {circle.GetInfoFigure()}");

                                            }
                                            else
                                            {
                                                Console.WriteLine(WrongInput(1));
                                            }

                                            break;

                                        case 2:
                                        Round round = new Round();
                                            if (round.InputPoints() && round.InputRadius())
                                            {

                                                Console.WriteLine("Рисуем круг...");
                                                Console.WriteLine(round.GetInfoPoint());
                                                Console.WriteLine(round.GetInfoFigure());

                                                figure.Add($"Круг. {round.GetInfoPoint()} {round.GetInfoFigure()}");
                                            }
                                            else
                                            {
                                                Console.WriteLine(WrongInput(1));
                                            }

                                            break;

                                        case 3:
                                            Ring ring = new Ring();
                                           
                                            if (ring.InputPoints() && ring.InputRadius())
                                            {
                                                radius = ring.radius;

                                                Console.Write("Введите малый радиус: ");
                                                if (Double.TryParse(Console.ReadLine(), out double smallRadius) && radius > smallRadius && smallRadius > 0)
                                                {
                                                    ring.smallRadius = smallRadius;
                                                    
                                                    Console.WriteLine("Рисуем кольцо...");
                                                    Console.WriteLine(ring.GetInfoPoint());
                                                    Console.WriteLine(ring.GetInfoFigure());
                                                    figure.Add($"Кольцо. {ring.GetInfoPoint()} {ring.GetInfoFigure()}");

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
                                            Rectangle rectangle = new Rectangle();
                                            if (rectangle.InputPoints() && rectangle.InputA())
                                            {
                                                
                                                    Console.Write("Введите высоту: ");
                                                    if (Double.TryParse(Console.ReadLine(), out double b) && b > 0)
                                                    {
                                                        rectangle.height = b;
                                                      
                                                        Console.WriteLine("Рисуем прямоугольник...");
                                                        Console.WriteLine(rectangle.GetInfoPoint());
                                                        Console.WriteLine(rectangle.InfoFigure());

                                                        figure.Add($"Прямоугольник. {rectangle.GetInfoPoint()} {rectangle.InfoFigure()}");
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
                                            Square square = new Square();
                                            if (square.InputPoints() && square.InputA())
                                            {
                                                    Console.WriteLine("Рисуем квадрат...");
                                                    Console.WriteLine(square.GetInfoPoint());
                                                    Console.WriteLine(square.InfoFigure());

                                                    figure.Add($"Квадрат. {square.GetInfoPoint()} {square.InfoFigure()}");
                                            }
                                            else
                                            {
                                                Console.WriteLine(WrongInput(1));
                                            }
                                            break;

                                        case 6:
                                            Triangle triangle = new Triangle();
                                            if (triangle.InputPoints() && triangle.InputA())
                                            {
                                                
                                                    Console.Write("Введите сторону b: ");
                                                    if (Double.TryParse(Console.ReadLine(), out double b) && b > 0)
                                                    {

                                                        Console.Write("Введите сторону c: ");
                                                        if (Double.TryParse(Console.ReadLine(), out double c) && c > 0)
                                                        {
                                                            triangle.height = b;
                                                            triangle.c = c;

                                                            Console.WriteLine("Рисуем треугольник...");
                                                            Console.WriteLine(triangle.GetInfoPoint());
                                                            Console.WriteLine(triangle.InfoFigure());

                                                            figure.Add($"Треугольник. {triangle.GetInfoPoint()} {triangle.InfoFigure()}");
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

                                        case 7:
                                                Console.Write("Введите координату х1: ");
                                                if (Double.TryParse(Console.ReadLine(), out double x1))
                                                {

                                                    Console.Write("Введите координату y1: ");
                                                    if (Double.TryParse(Console.ReadLine(), out double y1))
                                                    {

                                                        Console.Write("Введите координату х2: ");
                                                        if (Double.TryParse(Console.ReadLine(), out double x2))
                                                        {

                                                            Console.Write("Введите координату y2: ");
                                                            if (Double.TryParse(Console.ReadLine(), out double y2))
                                                            {
                                                                Line line = new Line
                                                                {
                                                                    x = (x1 + x2) / 2,
                                                                    y = (y1 + y2) / 2,
                                                                    x1 = x1,
                                                                    y1 = y1,
                                                                    x2 = x2,
                                                                    y2 = y2,
                                                                };

                                                                Console.WriteLine("Рисуем линию...");
                                                                Console.WriteLine(line.GetInfoPoint());
                                                                Console.WriteLine(line.GetLineLength());

                                                                figure.Add($"Линия. {line.GetInfoPoint()} {line.GetLineLength()}");
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
                                }
                                else
                                {
                                    Console.WriteLine(WrongInput(1));
                                }
                                break;

                            case 2:
                                if (figure.Count == 0)
                                {
                                    Console.WriteLine("На холсте пусто");
                                }
                                else
                                {
                                    foreach (string i in figure)
                                    {
                                        Console.WriteLine(i);
                                    }
                                }
                                break;

                            case 3:
                                figure.Clear();
                                Console.WriteLine("Холст очищен");
                                break;

                            case 4:
                                Console.WriteLine($"Пока, { name}");
                                name = "unknown";
                                figure.Clear();
                                break;

                            case 5:
                                Environment.Exit(0);
                                break;

                            default:
                                Console.WriteLine(WrongInput(0));
                                break;
                        }
                    }
                Console.ReadLine();
            }
        }
    }
}
