using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._2.CUSTOM_PAINT
{
    class Input
    {
        internal List<string> figure = new List<string>();

        double valueInput;
        internal string WrongInput(int code)
        {
            if (code == 1)
            {
                return "Вы ввели некорректные данные";
            }
            else
            {
                return "Неверная команда";
            }
        }

        internal bool InputValue(string parameter)
        {
            Console.Write($"Введите {parameter}: ");
            if (Double.TryParse(Console.ReadLine(), out valueInput) && valueInput > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine(WrongInput(1));
                return false;
            }
        }
        internal bool InputСoordinate(string axis)
        {
            Console.Write($"Введите координату {axis}: ");
            if (Double.TryParse(Console.ReadLine(), out valueInput))
            {
                return true;
            }
            else
            {
                Console.WriteLine(WrongInput(1));
                return false;
            }
        }

        internal void InputCircle()
        {
            RoundShape circle = new RoundShape();
            if (InputСoordinate("центра фигуры по х"))
            {
                circle.x = valueInput;
                if (InputСoordinate("центра фигуры по y"))
                {
                    circle.y = valueInput;

                    if (InputValue("радиус"))
                    {
                        circle.radius = valueInput;
                        Console.WriteLine("Рисуем окружноть...");
                        Console.WriteLine(circle.GetInfoPoint());
                        Console.WriteLine(circle.GetInfoFigure());
                        figure.Add($"Окружность. \n{circle.GetInfoPoint()} {circle.GetInfoFigure()}");

                    }
                }
            }
        }
        internal void InputRound()
        {
            Round round = new Round();
            if (InputСoordinate("центра фигуры по х"))
            {
                round.x = valueInput;

                if (InputСoordinate("центра фигуры по y"))
                {
                    round.y = valueInput;

                    if (InputValue("радиус"))
                    {
                        round.radius = valueInput;
                        Console.WriteLine("Рисуем круг...");
                        Console.WriteLine(round.GetInfoPoint());
                        Console.WriteLine(round.GetInfoFigure());

                        figure.Add($"Круг. \n{round.GetInfoPoint()} {round.GetInfoFigure()}");
                    }
                }
            }
        }
        internal void InputRing()
        {
            Ring ring = new Ring();

            if (InputСoordinate("центра фигуры по х"))
            {
                ring.x = valueInput;

                if (InputСoordinate("центра фигуры по y"))
                {
                    ring.y = valueInput;

                    if (InputValue("радиус"))
                    {
                        ring.radius = valueInput;

                        if (InputValue("малый радиус"))
                        {
                            if (ring.radius > valueInput)
                            {
                                ring.smallRadius = valueInput;

                                Console.WriteLine("Рисуем кольцо...");
                                Console.WriteLine(ring.GetInfoPoint());
                                Console.WriteLine(ring.GetInfoFigure());
                                figure.Add($"Кольцо. \n{ring.GetInfoPoint()} {ring.GetInfoFigure()}");
                            }
                            else
                            {
                                Console.WriteLine(WrongInput(1));
                            }
                        }
                    }
                }
            }
        }

        internal void InputRectangle()
        {
            Rectangle rectangle = new Rectangle();
            if (InputСoordinate("центра фигуры по х"))
            {
                rectangle.x = valueInput;

                if (InputСoordinate("центра фигуры по y"))
                {
                    rectangle.y = valueInput;

                    if (InputValue("ширину"))
                    {
                        rectangle.width = valueInput;

                        if (InputValue("высоту"))
                        {
                            rectangle.height = valueInput;

                            Console.WriteLine("Рисуем прямоугольник...");
                            Console.WriteLine(rectangle.GetInfoPoint());
                            Console.WriteLine(rectangle.InfoFigure());

                            figure.Add($"Прямоугольник. \n{rectangle.GetInfoPoint()} {rectangle.InfoFigure()}");
                        }
                    }
                }
            }
        }

        internal void InputSquare()
        {
            Square square = new Square();
            if (InputСoordinate("центра фигуры по х"))
            {
                square.x = valueInput;

                if (InputСoordinate("центра фигуры по y"))
                {
                    square.y = valueInput;
                    if (InputValue("сторону"))
                    {
                        square.width = valueInput;
                        Console.WriteLine("Рисуем квадрат...");
                        Console.WriteLine(square.GetInfoPoint());
                        Console.WriteLine(square.InfoFigure());

                        figure.Add($"Квадрат. \n{square.GetInfoPoint()} {square.InfoFigure()}");
                    }
                }
            }

        }

        internal void InputTriangle()
        {
            Triangle triangle = new Triangle();
            if (InputСoordinate("центра фигуры по х"))
            {
                triangle.x = valueInput;

                if (InputСoordinate("центра фигуры по y"))
                {
                    triangle.y = valueInput;

                    if (InputValue("сторону a"))
                    {
                        triangle.width = valueInput;

                        if (InputValue("сторону b"))
                        {
                            triangle.height = valueInput;

                            if (InputValue("сторону c"))
                            {
                                triangle.c = valueInput;

                                Console.WriteLine("Рисуем треугольник...");
                                Console.WriteLine(triangle.GetInfoPoint());
                                Console.WriteLine(triangle.InfoFigure());

                                figure.Add($"Треугольник. \n{triangle.GetInfoPoint()} {triangle.InfoFigure()}");
                            }
                        }
                    }
                }
            }
        }

        internal void InputLine()
        {
            Line line = new Line();
            if (InputСoordinate("х1"))
            {
                line.x1 = valueInput;
                if (InputСoordinate("y1"))
                {
                    line.y1 = valueInput;
                    if (InputСoordinate("х2"))
                    {
                        line.x2 = valueInput;
                        if (InputСoordinate("y2"))
                        {
                            line.y2 = valueInput;


                            Console.WriteLine("Рисуем линию...");
                            Console.WriteLine(line.GetInfoPoint());
                            Console.WriteLine(line.GetLineLength());

                            figure.Add($"Линия. \n{line.GetInfoPoint()} {line.GetLineLength()}");
                        }

                    }

                }

            }

        }
    }
}
