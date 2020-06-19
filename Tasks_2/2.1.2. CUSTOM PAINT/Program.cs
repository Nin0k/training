using System;
using System.Collections.Generic;

namespace _2._1._2.CUSTOM_PAINT
{
    class Program
    {
        static void Main(string[] args)
        {


            string name = "unknown";

            Input inputFigure = new Input();
            while (true)
            { 

                if (name == "unknown" || name.Length < 1)
                {
                    Salute();
                }
                else
                {

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
                                            inputFigure.InputCircle();
                                            break;

                                        case 2:
                                            inputFigure.InputRound();
                                            break;

                                        case 3:
                                            inputFigure.InputRing();
                                            break;

                                        case 4:
                                            inputFigure.InputRectangle();
                                            break;

                                        case 5:
                                            inputFigure.InputSquare();
                                            break;

                                        case 6:
                                            inputFigure.InputTriangle();
                                            break;

                                        case 7:
                                            inputFigure.InputLine();
                                            break;
                                        default:
                                            Console.WriteLine(inputFigure.WrongInput(0));
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(inputFigure.WrongInput(1));
                                }
                                break;

                            case 2:
                                if (inputFigure.figure.Count == 0)
                                {
                                    Console.WriteLine("На холсте пусто");
                                }
                                else
                                {
                                    foreach (string i in inputFigure.figure)
                                    {
                                        Console.WriteLine(i);
                                    }
                                }
                                break;

                            case 3:
                                inputFigure.figure.Clear();
                                Console.WriteLine("Холст очищен");
                                break;

                            case 4:
                                Console.WriteLine($"Пока, { name}");
                                name = "unknown";
                                inputFigure.figure.Clear();
                                break;

                            case 5:
                                Environment.Exit(0);
                                break;

                            default:
                                Console.WriteLine(inputFigure.WrongInput(0));
                                break;
                        }
                    }

                }

                Console.ReadLine();
            }
            string Salute()
            {
                Console.Write("Представьтесь, пожалуйста. ");
                name = Console.ReadLine();
                if (name == " ")
                {
                    return inputFigure.WrongInput(1);
                }
                return name;
            }
        }
    }
}
