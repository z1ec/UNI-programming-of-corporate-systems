using System;

public class Task4
{
    public static void Run()
    {
        Console.WriteLine("=== Задание 4 ===");

        int low = 0, high = 63;
        Console.WriteLine("Загадайте число от 0 до 63.");

        for (int i = 0; i < 7; i++)
        {
            int mid = (low + high) / 2;
            Console.Write($"Ваше число больше {mid}? (1-да, 0-нет): ");
            int answer = int.Parse(Console.ReadLine());

            if (answer == 1)
                low = mid + 1;
            else
                high = mid;
        }

        Console.WriteLine($"Вы загадали число: {low}");
    }
}