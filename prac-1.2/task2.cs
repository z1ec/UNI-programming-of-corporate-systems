using System;

public class Task2
{
    public static void Run()
    {
        Console.WriteLine("=== Задание 2 ===");

        int[] denominations = { 5000, 2000, 1000, 500, 200, 100 };
        Console.Write("Введите сумму для снятия: ");
        int amount = int.Parse(Console.ReadLine());

        if (amount > 150000)
        {
            Console.WriteLine("Ошибка: Превышен лимит в 150 000 рублей за одну операцию.");
            return;
        }

        if (amount % 100 != 0)
        {
            Console.WriteLine("Ошибка: Сумма должна быть кратна 100 рублям.");
            return;
        }

        int remainingAmount = amount;
        bool isPossible = true;
        string result = "";

        foreach (int denom in denominations)
        {
            int count = remainingAmount / denom;

            if (count > 0)
            {
                result += $"{count} по {denom}, ";
                remainingAmount %= denom;
            }

            if (remainingAmount == 0)
            {
                break;
            }
        }

        if (remainingAmount == 0)
        {
            result = result.TrimEnd(',', ' ');
            Console.WriteLine($"Для выдачи {amount} рублей потребуются купюры: {result}.");
        }
        else
        {
            Console.WriteLine($"Невозможно выдать ровно {amount} рублей имеющимися купюрами.");
        }
    }
}
