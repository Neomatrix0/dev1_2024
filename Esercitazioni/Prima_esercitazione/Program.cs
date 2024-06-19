// See https://aka.ms/new-console-template for more information


/*Console.Write("Inserisci nome");
Console.WriteLine(" Hello, Dani!");
Console.Write("Inserisci nome");
Console.Write("\nHello, Dani!\n");      //il carattere \n  serve ad andare a capo
Console.Write("Hello, Max!\t"); 
Console.Write("Hello, Lorenzo!\t");     //il carattere \t  serve per fare tab */

//questo è un commento

/*  questo è un commento
    multilinea

    Console.WriteLine("Hello, World!");

*/  

///Questo è un commento per la documentazione

Console.WriteLine("Premi un tasto per terminare ...");

//Console.ReadKey();                        //attende la pressione di un tasto da parte dell'utente
//string? nome = Console.ReadLine();        // legge una stringa da tastiera e la memorizza nella variabile nome
string nome = Console.ReadLine()!;         // legge una stringa da tastiera e la memorizza nella variabile nome
string cognome= "Musci";

Console.WriteLine("Ciao," + nome + "!");   // concatenazione elementare stringhe
Console.WriteLine($"Ciao,{nome} {cognome}!!!");      //interpolazione stringa metodo consigliato