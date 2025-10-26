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
            Console.WriteLine("3 - Задание 3");
            Console.WriteLine("4 - Задание 4");
            Console.WriteLine("5 - Задание 5");
            Console.WriteLine("6 - Задание 6");
            Console.WriteLine("7 - Задание 7");
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
                case "3":
                    Task3.Run();
                    break;
                case "4":
                    Task4.Run();
                    break;
                case "5":
                    Task5.Run();
                    break;
                case "6":
                    Task6.Run();
                    break;
                case "7":
                    Task7.Run();
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