using System;

public class Task1
{
    public static void Run()
    {
        Console.WriteLine("=== Задание 1 ===");

        Console.Write("Введите номер дня недели, с которого начинается месяц (1-пн, ..., 7-вс): ");
        int firstDayOfWeek = int.Parse(Console.ReadLine());

        Console.Write("Введите день месяца: ");
        int dayOfMonth = int.Parse(Console.ReadLine());

        bool isHoliday = (dayOfMonth >= 1 && dayOfMonth <= 5) || (dayOfMonth >= 8 && dayOfMonth <= 10);

    
        int dayOfWeek = (firstDayOfWeek + dayOfMonth - 1) % 7;
        if (dayOfWeek == 0) dayOfWeek = 7;

        bool isWeekend = (dayOfWeek == 6) || (dayOfWeek == 7);
        if (isHoliday || isWeekend)
        {
            Console.WriteLine("Выходной день");
        }
        else
        {
            Console.WriteLine("Рабочий день");
        }

    }
}