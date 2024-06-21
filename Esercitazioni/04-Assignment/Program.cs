// Scrivere un programma che chieda un input all'utente e stampi il valore dell'input

//richiesta del nome

Console.WriteLine("Buongiorno,inserisca il proprio nome:");

//assegnare variabile stringa nome al metodo Readline per ricevere l'input

string? nome = Console.ReadLine();

//Richiesta codice id da inserire

Console.WriteLine("Buongiorno,inserisca il proprio codice identificativo:");

//assegna una variabile nome di tipo stringa  al metodo Readline per ricevere l'input

string? numero = Console.ReadLine();

//concatenazione di stringhe per mostrare risultato

Console.WriteLine(nome +  " - " + numero);


//Console.WriteLine($"{nome} - {numero}");
