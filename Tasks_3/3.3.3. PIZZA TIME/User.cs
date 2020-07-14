using System;


namespace _3._3._3.PIZZA_TIME
{
    public class User
    {
        readonly Pizzeria pizzeria = new Pizzeria();
        public void MakeOrder(int number, PizzaType pizza)
        {
            Console.WriteLine($"User: Заказываю {pizza}.");
            pizzeria.OnGiveOrderUser += PickUpOrder;
            pizzeria.TakeOrder(number, pizza);

        }
        public void PickUpOrder(Pizzeria pizzeria)
        {
            Console.WriteLine($"User: Забираю свой заказ № {pizzeria.NumberOrder} и ем {pizzeria.pizza} пиццу");
            pizzeria.OnGiveOrderUser -= PickUpOrder;
        }
    }
}
