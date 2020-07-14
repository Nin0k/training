using System;


namespace _3._3._3.PIZZA_TIME
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int number = 0;
            while (true)
            {
                User user = new User();
                Console.WriteLine("Меню:");
                Console.WriteLine("     1: Margarita");
                Console.WriteLine("     2: Carbonara");
                Console.WriteLine("     3: Cheese");
                Console.WriteLine("     4: Mexican");
                Console.WriteLine("     5: Bavarian");
                if (int.TryParse(Console.ReadLine(), out int order_new))
                {
                    PizzaType order = PizzaType.None;
                    switch (order_new)
                    {
                        case 1:
                            order = PizzaType.Margarita;
                            break;
                        case 2:
                            order = PizzaType.Carbonara;
                            break;
                        case 3:
                            order = PizzaType.Cheese;
                            break;
                        case 4:
                            order = PizzaType.Mexican;
                            break;
                        case 5:
                            order = PizzaType.Bavarian;
                            break;
                        default:
                            Console.WriteLine("К сожалению, в нашем меню нет такого пункта");
                            break;
                    }
                    if (order != PizzaType.None)
                    {
                        user.MakeOrder(++number, order);
                    }
                }

            }
         
        }
       
    }
        public enum PizzaType
    {
        Margarita,
        Carbonara,
        Cheese,
        Mexican,
        Bavarian,
        None
    }
}
