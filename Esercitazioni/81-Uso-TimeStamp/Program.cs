// See https://aka.ms/new-console-template for more information



TimeSpan timeSpan = new TimeSpan(3, 5, 10, 0); // 3 giorni 5 ore 10 minuti 0 secondi  

DateTime today = DateTime.Today;
DateTime resultDate = today.Add(timeSpan);  // aggiungerà alla data corrente 3 giorni 5 ore  10 minuti restituisce stringa

Console.WriteLine("Data e ora risultante: " + resultDate);

