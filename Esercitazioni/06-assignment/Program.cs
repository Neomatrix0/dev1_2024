// See https://aka.ms/new-console-template for more information

Console.WriteLine("Inserisci il numero corrispondente al giorno della settimana corrente:");

int giorno = Convert.ToInt32(Console.ReadLine());  //converte il valore di input in intero altrimenti si può usare int giorno = int.Parse(Console.ReadLine())

//la differenza tra Convert.ToInt32 e il Parse è che il primo restituisce 0 se il valore inserito non è numero ,mentre il secondo restituisce un eccezione

switch (giorno)
{
    case 1:
    Console.WriteLine("Lunedì");
    break;          //serve per uscire dallo switch

    case 2:
    Console.WriteLine("Martedì");
    break;  

    case 3:
    Console.WriteLine("Mercoledì");
    break;  

    case 4:
    Console.WriteLine("Giovedì");
    break;  

    case 5:
    Console.WriteLine("Venerdì");
    break;  

    case 6:
    Console.WriteLine("Sabato");
    break;  

    case 7:
    Console.WriteLine("Domenica");
    break;
default: 

    Console.WriteLine("Il numero non corrisponde a nessun giorno della settimana");
    break;  
}
