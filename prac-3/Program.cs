using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Выберите задание для запуска:");
            Console.WriteLine("1 - Задание 1");
            Console.WriteLine("2 - Задание 2");
            Console.WriteLine("0 - Выход");
            
            string? choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    Task1.Run();
                    break;
                case "2":
                    Task2.Run();
                    break;
                case "0":
                     return;
                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }
            
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}