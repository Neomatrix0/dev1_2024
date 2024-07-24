//creazione e formattazione date

DateTime birthDate = new DateTime(1990, 2, 1);

Console.WriteLine("Formato lungo: " + birthDate.ToLongDateString()); // formato esteso lunedì 1 febbraio 1990
Console.WriteLine("Mese in formato testuale: " + birthDate.ToString("MMMM")); //MM da 01 il mese in termini numerici
Console.WriteLine("Formato personalizzato: " + birthDate.ToString("dd-MM-yyyy"));

