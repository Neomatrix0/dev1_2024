// Un blocco di codice è compreso tra parentesi graffe{} e può contenere uno o più statement
// Le condizioni sono utilizzate per eseguire un blocco di codice solo se una condizione è vera

/*

Le condizioni possono essere:

if
if-else
if-else if-else
switch

*/

// pulire terminale

//Console.Clear();


//if - se il numero è uguale a 10 stampa il numero

int numero = 30;

if (numero == 10)               //utilizzo l'operatore di confronto ==

{
    Console.WriteLine("Il numero è 10");

}


//if -else  se il numero è 10 stampa il primo messaggio alttrimenti il secondo


if( numero == 10)
{
    Console.WriteLine("Il numero è 10");
}

else{
    Console.WriteLine("Il numero non è 10");
}

// alternativa

int verifica = 10;

if( numero == verifica)
{
    Console.WriteLine("Il numero è 10");
}

else{
    Console.WriteLine("Il numero non è 10");
}

//if else if else



if( numero == 10)
{
    Console.WriteLine("Il numero è 10");
}

else if (numero > 10){
    Console.WriteLine("Il numero è maggiore 10");
}
else{

    Console.WriteLine("Il numero è minore 10");
}

// prova
int eta = 30;

if( numero == eta ){
    Console.WriteLine("Il numero corrisponde all'età");
}else{
    Console.WriteLine("Il numero non corrisponde all'età");
}

// switch

int giorno = 5;

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