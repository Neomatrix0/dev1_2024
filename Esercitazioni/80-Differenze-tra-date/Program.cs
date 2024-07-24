// differenza tra date

DateTime startDate = DateTime.Today;
DateTime endDate = new DateTime(2024, 12, 31);      //scegli una data 

TimeSpan difference = endDate -startDate;

Console.WriteLine("Differenza in giorni: " + difference.Days);
Console.WriteLine("Differenza in ore: " + difference.TotalHours);
Console.WriteLine("Differenza in minuti: " + difference.TotalMinutes);
