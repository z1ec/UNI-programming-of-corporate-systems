using System;
using System.Collections.Generic;
using System.Linq;

public class Order
{
    public int Id { get; private set; }
    public int TableId { get; private set; }
    public List<Dish> Dishes { get; private set; }
    public string Comment { get; private set; } = string.Empty;
    public string StartTime { get; private set; } = string.Empty;
    public int WaiterId { get; private set; }
    public string? CloseTime { get; private set; }
    public double TotalPrice { get; private set; }
    public bool IsClosed => CloseTime != null;

    public Order(int id, int tableId, int waiterId, string comment = "")
    {
        Id = id;
        TableId = tableId;
        WaiterId = waiterId;
        Comment = comment;
        StartTime = DateTime.Now.ToString("HH:mm:ss");
        Dishes = new List<Dish>();
    }

    public void AddDish(params Dish[] dishes)
    {
        foreach (var d in dishes)
            Dishes.Add(d);
    }

    public void EditOrder(int? tableId = null, int? waiterId = null, string? comment = null)
    {
        if (tableId.HasValue) TableId = tableId.Value;
        if (waiterId.HasValue) WaiterId = waiterId.Value;
        if (comment != null) Comment = comment;
    }

    public void CloseOrder()
    {
        CloseTime = DateTime.Now.ToString("HH:mm:ss");
        TotalPrice = Dishes.Sum(d => d.Price);
    }

    public void PrintOrder()
    {
        Console.WriteLine($"Заказ #{Id}  Стол: {TableId}");
        Console.WriteLine($"Официант: {WaiterId}");
        Console.WriteLine($"Начало: {StartTime}");
        Console.WriteLine($"Комментарий: {Comment}");
        Console.WriteLine("\nСостав заказа:");

        foreach (var d in Dishes)
            Console.WriteLine($"{d.Name} — {d.Price} руб.");

        Console.WriteLine($"\nИТОГ: {(IsClosed ? TotalPrice : 0)} руб.");
        Console.WriteLine("----------------------------------");
    }

    public void PrintCheck()
    {
        if (!IsClosed)
        {
            Console.WriteLine("Нельзя вывести чек. Заказ не закрыт!");
            return;
        }

        Console.WriteLine("************* ЧЕК *************");
        Console.WriteLine($"Столик: {TableId}");
        Console.WriteLine($"Официант: {WaiterId}");
        Console.WriteLine($"Период: {StartTime} — {CloseTime}");

        var grouped = Dishes.GroupBy(d => d.Category);

        foreach (var cat in grouped)
        {
            Console.WriteLine($"\nКатегория: {cat.Key}");

            foreach (var d in cat)
                Console.WriteLine($"{d.Name} 1*{d.Price} = {d.Price}");

            Console.WriteLine($"Подитог категории: {cat.Sum(x => x.Price)}");
        }

        Console.WriteLine($"Итог счета: {TotalPrice}");
        Console.WriteLine("*******************************");
    }
}
