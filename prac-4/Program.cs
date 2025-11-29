class Program
{
    static void Main()
    {
        OrderSystem sys = new OrderSystem();

        // блюда
        Dish d1 = new Dish(1, "Борщ", "Свекла, мясо", "350/30/50", 250, DishCategory.Soups, 25, "острое");
        Dish d2 = new Dish(2, "Стейк", "Говядина", "300/20/50", 550, DishCategory.HotDishes, 40, "халяль");

        sys.AddDish(d1);
        sys.AddDish(d2);

        sys.PrintMenu();

        // заказ
        Order o1 = new Order(1, 4, 10);
        o1.AddDish(d1, d2);
        o1.CloseOrder();
        o1.PrintCheck();

        sys.AddOrder(o1);

        Console.WriteLine("Сумма закрытых заказов: " + sys.GetTotalClosed());
    }
}
