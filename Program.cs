// See https://aka.ms/new-console-template for more information

List<Room> rooms = [
    new(1,10),
    new(2,20),
    new(3,30)
    ];

List<Tariff> tariffs = [
    new(2024, 5, 5m),
    new(2024, 7, 8m)
    ];


foreach (var r in rooms)
{
    PrintReport(r, tariffs, new DateTime(2024, 4, 1), new DateTime(2024, 8, 1));
    Console.WriteLine();
    Console.WriteLine();
}

static void PrintReport(Room r, List<Tariff> tariffs, DateTime periodFrom, DateTime periodTo)
{
    Console.WriteLine($"Комната №{r.Number}");
    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine($"|{" Период ",-20}|{" Сальдо входящее ",-20}|{" Начислено ",-20}|{" Перерасчет ",-20}|{" Итого начислено ",-20}|{" Оплачено ",-20}|{" Сальдо исходящее ",-20}|");
    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------");

    do
    {
        var actualTariff = tariffs.OrderByDescending(t => t.StartDt).FirstOrDefault(t => t.StartDt <= periodFrom);

        if (actualTariff == null)
        {
            Console.WriteLine($"|{periodFrom,-20:MMMMyyyy}|{"-",20}|{"-",20}|{"-",20}|{"-",20}|{"-",20}|{"-",20}|");
        }
        else
        {
            Console.WriteLine($"|{periodFrom,-20:MMMMyyyy}|{"-",20}|{(actualTariff.Amount * r.Square),20}|{"-",20}|{"-",20}|{"-",20}|{"-",20}|");
        }

        periodFrom = periodFrom.AddMonths(1);
    }
    while (periodFrom <= periodTo);
    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------");
}

public class Room(uint number, decimal square)
{
    public uint Number { get; private set; } = number;
    public decimal Square { get; private set; } = square;

    public override string ToString()
    {
        return $"Номер комнаты - {Number} | Площадь комнаты - {Square}";
    }
}

public class Tariff(int year, int month, decimal amount)
{
    public string Code => StartDt.ToString("ddMMyyyy");
    public DateTime StartDt { get; private set; } = new DateTime(year, month, 1);
    public decimal Amount { get; private set; } = amount;

    public override string ToString()
    {
        return $"Код тарифа - {Code} | Дата старта тарифа - {StartDt:yyy.MM.dd}";
    }
}