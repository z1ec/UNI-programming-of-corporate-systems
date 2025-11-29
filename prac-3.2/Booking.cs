using System;

public class Booking
{
    public int ClientId { get; private set; }
    public string ClientName { get; private set; }
    public string Phone { get; private set; }
    public int StartHour { get; private set; }
    public int EndHour { get; private set; }
    public string Comment { get; private set; }

    public Table Table { get; private set; }

    // Создание брони
    public Booking(int clientId,
                   string clientName,
                   string phone,
                   int startHour,
                   int endHour,
                   string comment,
                   Table table)
    {
        ClientId = clientId;
        ClientName = clientName;
        Phone = phone;
        StartHour = startHour;
        EndHour = endHour;
        Comment = comment;
        Table = table;

        // Вносим изменения в объект стола
        Table.AddBookingToSchedule(this);
    }

    // Изменение брони
    public void Update(string newName, string newPhone, int newStartHour, int newEndHour, string newComment)
    {
        // Удаляем старое расписание
        Table.RemoveBookingFromSchedule(this);

        ClientName = newName;
        Phone = newPhone;
        StartHour = newStartHour;
        EndHour = newEndHour;
        Comment = newComment;

        // Добавляем в расписание с новыми параметрами
        Table.AddBookingToSchedule(this);
    }

    // Отмена брони
    public void Cancel()
    {
        Table.RemoveBookingFromSchedule(this);
    }

    public override string ToString()
    {
        return $"Клиент ID {ClientId}, {ClientName}, {Phone}, " +
               $"Стол {Table.Id}, {StartHour:00}:00-{EndHour:00}:00, Комментарий: {Comment}";
    }
}
