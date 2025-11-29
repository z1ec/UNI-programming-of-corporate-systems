using System;
using System.Collections.Generic;

public class Table
{
    public int Id { get; private set; }
    public string Location { get; private set; }
    public int Seats { get; private set; }

    // Расписание по часам: ключ — час (например, 9, 10, 11...), значение — бронирование
    private Dictionary<int, Booking> _schedule = new Dictionary<int, Booking>();

    public const int OpenHour = 9;
    public const int CloseHour = 18; // 18:00, последний слот 17–18

    public Table(int id, string location, int seats)
    {
        Id = id;
        Location = location;
        Seats = seats;
    }

    // Изменение информации стола
    public void UpdateInfo(string newLocation, int newSeats)
    {
        Location = newLocation;
        Seats = newSeats;
    }

    // Проверка, участвует ли стол в активном бронировании
    public bool HasActiveBookings()
    {
        return _schedule.Count > 0;
    }

    // Проверка, свободен ли стол в заданном интервале [startHour; endHour)
    public bool IsAvailable(int startHour, int endHour)
    {
        for (int h = startHour; h < endHour; h++)
        {
            if (_schedule.ContainsKey(h))
                return false;
        }
        return true;
    }

    // Добавление брони в расписание
    public void AddBookingToSchedule(Booking booking)
    {
        for (int h = booking.StartHour; h < booking.EndHour; h++)
        {
            _schedule[h] = booking;
        }
    }

    // Удаление брони из расписания (при изменении или отмене)
    public void RemoveBookingFromSchedule(Booking booking)
    {
        List<int> toRemove = new List<int>();
        foreach (var kvp in _schedule)
        {
            if (kvp.Value == booking)
                toRemove.Add(kvp.Key);
        }

        foreach (int h in toRemove)
        {
            _schedule.Remove(h);
        }
    }

    // Вывод полной информации о столе
    public void PrintInfo()
    {
        Console.WriteLine("***************************************************************");
        Console.WriteLine($"ID: -----------------------------------------------------------{Id:D2}.");
        Console.WriteLine($"Расположение: ----------------------------------------------\"{Location}\".");
        Console.WriteLine($"Количество мест: --------------------------------------------{Seats}");
        Console.WriteLine("Расписание:");

        for (int h = OpenHour; h < CloseHour; h++)
        {
            Console.Write($"{h:00}:00-{h + 1:00}:00 -------------------");
            if (_schedule.TryGetValue(h, out Booking? booking))
            {
                Console.WriteLine($"ID {booking.ClientId}, {booking.ClientName}, {booking.Phone}");
            }
            else
            {
                Console.WriteLine();
            }
        }

        Console.WriteLine("***************************************************************");
    }
}
