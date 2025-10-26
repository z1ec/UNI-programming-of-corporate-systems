using System;

public class Task7
{
    public static void Run()
    {
        Console.WriteLine("=== Задание 7 ===");

        Console.Write("Введите n: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введите a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Введите b: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Введите w: ");
        int w = int.Parse(Console.ReadLine());
        Console.Write("Введите h: ");
        int h = int.Parse(Console.ReadLine());

        int dMax = 0;
        for (int d = 1; d <= Math.Min(w, h); d++)
        {
            int cols = w / (a + 2 * d);
            int rows = h / (b + 2 * d);
            if (cols * rows >= n)
                dMax = d;
            else
                break;
        }

        Console.WriteLine($"Максимальная толщина защиты d = {dMax}");
    }
}
