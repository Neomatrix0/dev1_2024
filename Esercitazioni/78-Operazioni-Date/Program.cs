

DateTime today = DateTime.Today;

DateTime futureDate = today.AddDays(100);

DateTime pastDate = today.AddDays(-75);

Console.WriteLine("100 giorni da oggi: " + futureDate.ToShortDateString());

Console.WriteLine("75 giorni prima di oggi: " + pastDate.ToShortDateString());

DateTime nextBirthday = new DateTime(today.Year,7,26); // inserisci dal del tuo compleanno

if(nextBirthday < today){
    nextBirthday = nextBirthday.AddYears(1);
}

int daysUntilBirthday = (nextBirthday - today).Days;
Console.WriteLine("Giorni fino al prossimo compleanno: " + daysUntilBirthday);


