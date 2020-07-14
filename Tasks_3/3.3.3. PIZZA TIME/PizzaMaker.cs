using System;
using System.Threading;

namespace _3._3._3.PIZZA_TIME
{
    public class PizzaMaker
    {
        public PizzaType pizza;
        public event Action<PizzaMaker> OnFinishCooking = delegate { };
        public void BeginCookPizza(Pizzeria pizzeria)
        {
            pizzeria.OnGiveOrderPizzaMaker += CookPizza;
        }

        public void CookPizza(Pizzeria pizzeria)
        {
            pizza = pizzeria.pizza;
            Console.WriteLine($"PizzaMaker: Готовлю пиццу {pizza}");

            pizzeria.OnGiveOrderPizzaMaker -= CookPizza;
            Thread.Sleep(1000);
            FinishCooking(pizzeria);
        }
        public void FinishCooking(Pizzeria pizzeria)
        {
            Console.WriteLine($"PizzaMaker: Пицца {pizzeria.pizza} готова!");
            OnFinishCooking?.Invoke(this);
        }
    }
}
