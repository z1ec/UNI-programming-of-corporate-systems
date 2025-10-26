using System;

public class Task5
{
    public static void Run()
    {
        Console.WriteLine("=== Задание 5 ===");

        Console.Write("Введите количество воды в мл: ");
        int water = int.Parse(Console.ReadLine());
        Console.Write("Введите количество молока в мл: ");
        int milk = int.Parse(Console.ReadLine());

        int americanoCount = 0, latteCount = 0;

        while (true)
        {
            Console.Write("Выберите напиток (1 — американо, 2 — латте): ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                if (water >= 300)
                {
                    water -= 300;
                    americanoCount++;
                    Console.WriteLine("Ваш напиток готов.");
                }
                else
                {
                    Console.WriteLine("Не хватает воды.");
                }
            }
            else if (choice == 2)
            {
                if (water >= 30 && milk >= 270)
                {
                    water -= 30;
                    milk -= 270;
                    latteCount++;
                    Console.WriteLine("Ваш напиток готов.");
                }
                else if (water < 30) Console.WriteLine("Не хватает воды.");
                else Console.WriteLine("Не хватает молока.");
            }

            if ((water < 300 && (water < 30 || milk < 270)))
            {
                Console.WriteLine("*Отчёт*");
                Console.WriteLine($"Ингредиентов осталось:\nВода: {water} мл\nМолоко: {milk} мл");
                Console.WriteLine($"Кружек американо приготовлено: {americanoCount}");
                Console.WriteLine($"Кружек латте приготовлено: {latteCount}");
                Console.WriteLine($"Итого: {americanoCount * 150 + latteCount * 170} рублей.");
                break;
            }
        }
    }
}
