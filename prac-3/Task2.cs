using System;

static class Task2
{
    public static void Run()
    {
        Console.Write("m = ");
        string? inputM = Console.ReadLine();
        if (!int.TryParse(inputM, out int m))
        {
            Console.WriteLine("Некорректный ввод числа m");
            return;
        }

        Console.Write("n = ");
        string? inputN = Console.ReadLine();
        if (!int.TryParse(inputN, out int n))
        {
            Console.WriteLine("Некорректный ввод числа n");
            return;
        }

        long result = Ackermann(m, n);
        Console.WriteLine($"A({m}, {n}) = {result}");
    }

    // Рекурсивная функция Аккермана
    static long Ackermann(int m, int n)
    {
        if (m == 0)
            return n + 1;

        if (m > 0 && n == 0)
            return Ackermann(m - 1, 1);

        // m > 0 и n > 0
        return Ackermann(m - 1, (int)Ackermann(m, n - 1));
    }
}