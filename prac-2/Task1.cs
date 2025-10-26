using System;

public class Task1
{
    public static void Run()
    {
        Console.WriteLine("=== Задание 1 ===");

        Console.Write("Введите x: ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Введите точность e (e < 0.01): ");
        double e = double.Parse(Console.ReadLine());

        double sum = 1;
        double term = 1;
        int n = 1;

        do
        {
            term *= x / n;
            sum += term;
            n++;
        } while (Math.Abs(term) >= e);

        Console.WriteLine($"Приближенное значение: {sum}");
        Console.WriteLine($"Точное значение: {Math.Exp(x)}");

        // Вычисление n-го члена
        Console.Write("Введите n для вычисления n-го члена: ");
        int nTerm = int.Parse(Console.ReadLine());
        double nthTerm = Math.Pow(x, nTerm) / Factorial(nTerm);
        Console.WriteLine($"{nTerm}-й член ряда: {nthTerm}");
    }

    static double Factorial(int k)
    {
        double result = 1;
        for (int i = 2; i <= k; i++) result *= i;
        return result;
    }
}