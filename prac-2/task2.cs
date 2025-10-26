using System;

public class Task2
{
    public static void Run()
    {
        Console.WriteLine("=== Задание 2 ===");

        Console.Write("Введите номер билета (6 цифр): ");
        int ticket = int.Parse(Console.ReadLine());

        int left = ticket / 1000;
        int right = ticket % 1000;

        int sumLeft = left / 100 + (left / 10) % 10 + left % 10;
        int sumRight = right / 100 + (right / 10) % 10 + right % 10;

        Console.WriteLine(sumLeft == sumRight);
    }
}