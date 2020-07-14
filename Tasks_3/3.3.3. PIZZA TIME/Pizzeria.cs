using System;


namespace _3._3._3.PIZZA_TIME
{
    public class Pizzeria
    {
        public event Action<Pizzeria> OnGiveOrderPizzaMaker = delegate { };
        public event Action<Pizzeria> OnGiveOrderUser = delegate { };

        readonly PizzaMaker pizzaMaker = new PizzaMaker();

        public int NumberOrder { get; private set; } = 0;
        public PizzaType pizza;

        public int TakeOrder(int number, PizzaType newPizza)
        {
            pizza = newPizza;
            NumberOrder = number;
            Console.WriteLine($"Pizzeria: Отдаем заказ №{NumberOrder} - {pizza} пиццайолу. ");

            pizzaMaker.BeginCookPizza(this);
            GiveOrderPizzaMaker();

            return NumberOrder;

        }
        public void GiveOrderPizzaMaker()
        {
            pizzaMaker.OnFinishCooking += GiveOrderUser;
            OnGiveOrderPizzaMaker?.Invoke(this);

        }
        public void GiveOrderUser(PizzaMaker pizzaMaker)
        {
            Console.WriteLine($"Pizzeria: Заказ №{NumberOrder} - {pizza} готов к выдаче. ");
            pizzaMaker.OnFinishCooking -= GiveOrderUser;

            OnGiveOrderUser?.Invoke(this);
        }


    }
}
