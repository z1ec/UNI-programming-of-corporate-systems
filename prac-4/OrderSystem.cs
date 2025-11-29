using System;
using System.Collections.Generic;
using System.Linq;

public class OrderSystem
{
    public List<Dish> Dishes { get; private set; }
    public List<Order> Orders { get; private set; }

    public OrderSystem()
    {
        Dishes = new List<Dish>();
        Orders = new List<Order>();
    }

    public void AddDish(Dish d) => Dishes.Add(d);
    public void AddOrder(Order o) => Orders.Add(o);

    // Вывод меню
    public void PrintMenu()
    {
        Console.WriteLine("\n===== МЕНЮ =====");

        var groups = Dishes.GroupBy(d => d.Category);

        foreach (var g in groups)
        {
            Console.WriteLine($"\n*** {g.Key} ***");

            foreach (var d in g)
                d.PrintDish();
        }
    }

    // Стоимость всех закрытых заказов
    public double GetTotalClosed()
    {
        return Orders.Where(o => o.IsClosed).Sum(o => o.TotalPrice);
    }

    // Количество закрытых заказов официанта
    public int GetClosedOrdersByWaiter(int waiterId)
    {
        return Orders.Count(o => o.WaiterId == waiterId && o.IsClosed);
    }

    // Сбор статистики (использование in)
    public void GetDishStatistics(in int limit, out Dictionary<string, int> result)
    {
        int limitCopy = limit;

        result = Orders
            .SelectMany(o => o.Dishes)
            .GroupBy(d => d.Name)
            .Where(g => g.Count() >= limitCopy)
            .ToDictionary(g => g.Key, g => g.Count());
    }
}
