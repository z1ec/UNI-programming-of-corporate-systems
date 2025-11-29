using System;
using System.Collections.Generic;

class Program
{
    static List<Table> tables = new List<Table>();
    static List<Booking> bookings = new List<Booking>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nСИСТЕМА БРОНИРОВАНИЯ");
            Console.WriteLine("1. Добавить стол");
            Console.WriteLine("2. Изменить информацию стола");
            Console.WriteLine("3. Показать информацию о столе по ID");
            Console.WriteLine("4. Создать бронирование");
            Console.WriteLine("5. Изменить бронирование");
            Console.WriteLine("6. Отменить бронирование");
            Console.WriteLine("7. Показать все бронирования");
            Console.WriteLine("8. Найти столы по фильтру (места + интервал времени)");
            Console.WriteLine("9. Поиск брони по имени и последним 4 цифрам телефона");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите пункт: ");

            string? choice = Console.ReadLine();
            if (choice is null)
            {
                Console.WriteLine("Ввод прерван.");
                return;
            }

            switch (choice)
            {
                case "1": AddTable(); break;
                case "2": EditTable(); break;
                case "3": ShowTable(); break;
                case "4": CreateBooking(); break;
                case "5": EditBooking(); break;
                case "6": CancelBooking(); break;
                case "7": ShowAllBookings(); break;
                case "8": FindAvailableTables(); break;
                case "9": SearchBooking(); break;
                case "0": return;
                default: Console.WriteLine("Неверный пункт меню"); break;
            }
        }
    }

    static Table? FindTableById(int id) => tables.Find(t => t.Id == id);

    static bool TryReadInt(string prompt, out int value)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        if (!int.TryParse(input, out value))
        {
            Console.WriteLine("Некорректный ввод числа.");
            return false;
        }

        return true;
    }

    static string? ReadRequiredString(string prompt)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Пустой ввод недопустим.");
            return null;
        }

        return input;
    }

    static void AddTable()
    {
        if (!TryReadInt("ID стола: ", out int id))
            return;

        string? location = ReadRequiredString("Расположение: ");
        if (location is null)
            return;

        if (!TryReadInt("Количество мест: ", out int seats))
            return;

        tables.Add(new Table(id, location, seats));
        Console.WriteLine("Стол добавлен.");
    }

    static void EditTable()
    {
        if (!TryReadInt("ID стола для редактирования: ", out int id))
            return;

        Table? table = FindTableById(id);
        if (table == null)
        {
            Console.WriteLine("Стол не найден.");
            return;
        }

        if (table.HasActiveBookings())
        {
            Console.WriteLine("Стол участвует в активном бронировании, редактирование запрещено.");
            return;
        }

        string? newLocation = ReadRequiredString("Новое расположение: ");
        if (newLocation is null)
            return;

        if (!TryReadInt("Новое количество мест: ", out int newSeats))
            return;

        table.UpdateInfo(newLocation, newSeats);
        Console.WriteLine("Информация стола обновлена.");
    }

    static void ShowTable()
    {
        if (!TryReadInt("ID стола: ", out int id))
            return;

        Table? table = FindTableById(id);
        if (table == null)
        {
            Console.WriteLine("Стол не найден.");
            return;
        }

        table.PrintInfo();
    }

    static void CreateBooking()
    {
        if (!TryReadInt("ID клиента: ", out int clientId))
            return;

        string? name = ReadRequiredString("Имя клиента: ");
        if (name is null)
            return;

        string? phone = ReadRequiredString("Телефон клиента: ");
        if (phone is null)
            return;

        if (!TryReadInt("ID стола: ", out int tableId))
            return;

        Table? table = FindTableById(tableId);
        if (table == null)
        {
            Console.WriteLine("Стол не найден.");
            return;
        }

        if (!TryReadInt("Время начала брони (час, например 12): ", out int startHour))
            return;

        if (!TryReadInt("Время окончания брони (час, например 14): ", out int endHour))
            return;

        if (!table.IsAvailable(startHour, endHour))
        {
            Console.WriteLine("Стол занят в указанный интервал.");
            return;
        }

        string? comment = ReadRequiredString("Комментарий: ");
        if (comment is null)
            return;

        Booking booking = new Booking(clientId, name, phone, startHour, endHour, comment, table);
        bookings.Add(booking);

        Console.WriteLine("Бронирование создано.");
    }

    static void EditBooking()
    {
        if (!TryReadInt("Введите ID клиента брони для изменения: ", out int clientId))
            return;

        Booking? booking = bookings.Find(b => b.ClientId == clientId);
        if (booking == null)
        {
            Console.WriteLine("Бронирование не найдено.");
            return;
        }

        string? name = ReadRequiredString("Новое имя клиента: ");
        if (name is null)
            return;

        string? phone = ReadRequiredString("Новый телефон: ");
        if (phone is null)
            return;

        if (!TryReadInt("Новое время начала (час): ", out int startHour))
            return;

        if (!TryReadInt("Новое время окончания (час): ", out int endHour))
            return;

        if (!booking.Table.IsAvailable(startHour, endHour))
        {
            Console.WriteLine("Стол занят в указанный интервал.");
            return;
        }

        string? comment = ReadRequiredString("Новый комментарий: ");
        if (comment is null)
            return;

        booking.Update(name, phone, startHour, endHour, comment);
        Console.WriteLine("Бронирование обновлено.");
    }

    static void CancelBooking()
    {
        if (!TryReadInt("Введите ID клиента для отмены брони: ", out int clientId))
            return;

        Booking? booking = bookings.Find(b => b.ClientId == clientId);
        if (booking == null)
        {
            Console.WriteLine("Бронирование не найдено.");
            return;
        }

        booking.Cancel();
        bookings.Remove(booking);
        Console.WriteLine("Бронирование отменено.");
    }

    static void ShowAllBookings()
    {
        if (bookings.Count == 0)
        {
            Console.WriteLine("Бронирований нет.");
            return;
        }

        foreach (var b in bookings)
        {
            Console.WriteLine(b);
        }
    }

    static void FindAvailableTables()
    {
        if (!TryReadInt("Минимальное количество мест: ", out int minSeats))
            return;

        if (!TryReadInt("Время начала (час): ", out int startHour))
            return;

        if (!TryReadInt("Время окончания (час): ", out int endHour))
            return;

        Console.WriteLine("Доступные столы:");
        foreach (var t in tables)
        {
            if (t.Seats >= minSeats && t.IsAvailable(startHour, endHour))
            {
                Console.WriteLine($"Стол ID {t.Id}, {t.Location}, мест: {t.Seats}");
            }
        }
    }

    static void SearchBooking()
    {
        string? name = ReadRequiredString("Имя клиента: ");
        if (name is null)
            return;

        string? last4 = ReadRequiredString("Последние 4 цифры телефона: ");
        if (last4 is null)
            return;

        foreach (var b in bookings)
        {
            if (b.ClientName.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                b.Phone.EndsWith(last4))
            {
                Console.WriteLine(b);
            }
        }
    }
}
