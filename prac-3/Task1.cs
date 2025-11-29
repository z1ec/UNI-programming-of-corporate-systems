using System;

static class Task1
{
    public static void Run()
    {
        string? input = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Некорректный ввод числа");
            return;
        }

        string digits = input.TrimStart('-', '+');
        if (digits.Contains('0'))
        {
            Console.WriteLine("Число не должно содержать цифру 0");
            return;
        }

        if (!int.TryParse(input, out int n))
        {
            Console.WriteLine("Некорректный ввод числа");
            return;
        }

        int result = ReverseNumber(n);
        Console.WriteLine(result);
    }

    // Рекурсивный разворот числа без строк и циклов
    static int ReverseNumber(int n, int acc = 0)
    {
        if (n == 0)
            return acc;

        int lastDigit = n % 10;
        int rest = n / 10;

        return ReverseNumber(rest, acc * 10 + lastDigit);
    }
}
