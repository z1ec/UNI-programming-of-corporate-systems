using System;

public class Task3
{
    public static void Run()
    {
        Console.WriteLine("=== Задание 3 ===");

        Console.Write("Введите числитель: ");
        int m = int.Parse(Console.ReadLine());
        Console.Write("Введите знаменатель: ");
        int n = int.Parse(Console.ReadLine());

        int gcd = GCD(Math.Abs(m), Math.Abs(n));
        int num = m / gcd;
        int den = n / gcd;

        if (den < 0)
        {
            num = -num;
            den = -den;
        }

        Console.WriteLine($"Результат: {num} / {den}");
    }

    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}