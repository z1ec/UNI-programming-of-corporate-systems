using System;

public class Task6
{
    public static void Run()
    {
        Console.WriteLine("=== Задание 6 ===");

        Console.Write("Введите количество бактерий: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введите количество антибиотика: ");
        int x = int.Parse(Console.ReadLine());

        int hour = 1;
        while (n > 0 && x > 0)
        {
            n *= 2; // размножение
            n -= Math.Max(0, 11 - hour); // действие антибиотика
            if (n <= 0) break;

            Console.WriteLine($"После {hour} часа бактерий осталось {n}");
            hour++;
            x--;
        }
    }
}
