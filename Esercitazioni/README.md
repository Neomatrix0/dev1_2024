# ESERCITAZIONI

## 01 TIPI di DATI

<details>
    <summary>Visualizza il codice</summary>

```c#

//esempio di commento single line

/*esempio di commento 
multi line*/

// esempio di dichiarazione di variabili

int numero;     // dichiaro una variabile di tipo intero

string nome;    // dichiaro una variabile di tipo stringa

bool flag;      //dichiaro una variabile di tipo booleano


// esempio di dichiarazione ed inizializzazione di variabili

numero = 10;    //inizializzo la variabile numero con valore 10

nome = "Mario"; //inizializzo la variabile nome con il valore "Mario"

flag = true;    //inizializzo la variabile flag con il valore true 


//esempio di dichiarazione e inizializzazione

int eta = 20;   //dichiarazione e inizializzazione della variabile eta

string cognome = "Rossi";

bool isStudent = false;     //dichiarazione e inizializzazione della variabile  isStudent con valore false

//esempio di dichiarazione e inizializzazione di una costante

const double PI = 3.14159;  //dichiaro e inizializzo la costante PI con il valore 3.14159

//esempio di dichiarazione e inizializzazione di una variabile con la parola chiave var

var altezza = 1.80;     //dichiaro e inizializzo la variabile altezza con il valore 1.80

// lo svantaggio è che non è possibile dichiarare una variabile var senza inizializzarla

//REGOLA IMPORTANTE: una variabile deve essere inizializzata prima di essere utilizzata

//REGOLA IMPORTANTE: i nomi delle variabili devono essere significativi e autoesplicativi e non usare abbreviazioni

// in c# i nomi delle variabili e costanti possono essere scritti in due modi

Pascal Case // NumeroIntero
Camel Case   // numeroIntero   (la prima lettera è minuscola)



```

</details>

## 02 OPERATORI

<details>
    <summary>Visualizza il codice</summary>

```c#

/* 

Gli operatori sono utilizzati per eseguire più operazioni su uno o più operandi

Gli operatori possono essere:

operatori aritmetici
operatori di confronto
operatori logici
operatori di assegnazione


*/

//esempio di utilizzo degli operatori aritmetici

int a = 10;

int b = 20;

int somma = a + b;          // somma = 30

int differenza = a - b;     // differenza = -10

int prodotto = a * b;       // prodotto = 200

int divisione = a / b;      // divisione = 0

int modulo = a % b;         // modulo = 10 verifica divisibilità tra 2 numeri

//esempio di utilizzo degli operatori di confronto

int c = 30;                 

int c == a;                 //false

int c != a;                 // true

int c > a;                  // true

int c < a;                  // false

int c >= a;                 // true

int c <= a;                 // false


//esempio di utilizzo degli operatori logici

bool x =true;

bool y = false;

// and

bool z = x && y;        // false

//or

bool w = x || y;        // true

//not

bool v = !x;            // false

//esempio di utilizzo degli operatori di assegnazione

/*

Gli operatori di assegnazione possono essere.

assegnazione(=)
assegnazione con addizione(+=)
assegnazione con sottrazione(-=)


*/

int d= 10;

d += 5;             // d= 15

d -= 5;             // d = 5

//esempi di operatori di incremento e decremento

e++;                // e = 11
en--;               // e = 9

//esempi di operatori di concatenazione

string f = "Hello";

string g = "World";

string h = f + " " + g;     // h= "Hello World"

string i = $"{f} {g}";      // i= "Hello World"


```

</details>

## 03 TIPI di DATI ed OPERATORI

<details>
    <summary>Visualizza il codice</summary>

```c#

// pulire terminale

Console.Clear();


// Stampare il valore di una variabile

int numero;                                   // dichiaro una variabile di tipo intero

numero = 10;                                 //inizializzo variabile

Console.WriteLine(numero);                  // stampo valore della variabile

// Stampare il valore di una variabile con un messaggio


int eta = 20;                              //dichiaro e inizializzo una variabile eta con valore 20

Console.WriteLine("L'età è " + eta);       //stampo il valore della variabile con un messaggio

// oppure con interpolazione

Console.WriteLine($"L'età è {eta}");

eta++;                                      //incrementa di 1

Console.WriteLine($"L'età è {eta}");

eta+=5;                                     //incrementa di 5

Console.WriteLine($"L'età è {eta}");

eta-=5;                                     //decrementa di 5

Console.WriteLine($"L'età è {eta}");

//stampare due variabili una stringa ed una int

string nome = "Mario";

Console.WriteLine($"Il nome è {nome} e l'età è {eta}");     // stampa variabili nome ed eta con un messaggio




```

</details>

## 04 ASSIGNMENT

<details>
    <summary>Visualizza il codice</summary>

```c#

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


```

</details>

## 05 CONDIZIONI

<details>
    <summary>Visualizza il codice</summary>

```c#

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

```

</details>

## 06 ASSIGNMENT SWITCH

<details>
    <summary>Visualizza il codice</summary>

```c#

// utilizzo switch attraverso metodi di console

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


```

</details>

## 07  CALCOLATRICE

<details>
    <summary>Visualizza il codice</summary>

```c#

// Calcolatrice per eseguire le 4 operazioni aritmetiche

Console.WriteLine("Questa è una calcolatrice.Prego inserire di seguito la prima cifra");

// riceve il primo numero come  input e lo converte nel formato float

float num1 = float.Parse(Console.ReadLine());

Console.WriteLine("Prego inserire sotto la secondo cifra cifra");

// riceve il secondo  numero come  input e lo converte nel formato float

float num2 = float.Parse(Console.ReadLine());

//chiede di scegliere il tipo di operazione da svolgere

Console.WriteLine("Prego inserire il simbolo dell'operazione artimetica da svolgere.\n * Per la moltiplicazione, / per la divisione,+ per la somma, - per la sottrazione");

// riceve come input il simbolo dell'operazione scelta

string? operazione = Console.ReadLine();

// inizializza variabile risultato 

float risultato = 0;

// costrutto switch a seconda del tipo di simbolo scelto verrà eseguita la corrispondente operazione

switch (operazione)
{
    case "+":
        risultato = num1 + num2;          //somma
        break;

    case "-":
        risultato = num1 - num2;         //differenza
        break;

    case "*":
        risultato = num1 * num2;        //prodotto
        break;

    case "/":                           //quoziente

        // se il divisore è 0 la divisione è impossibile

        if (num2 == 0)
        {
            Console.WriteLine("Mi dispiace,ma non è possibile dividere un numero per 0");
            return;

        }

        // se il divisore è diverso da 0 la divisione verrà svolta

        risultato = num1 / num2;
        break;

    // in caso non venga scelto il simbolo corretto apparirà il seguente messaggio
    default:
        Console.WriteLine("L'operazione scelta non è corretta,prego riprovare.");
        break;

}

// mostra il risultato finale dell'operazione scelta

Console.WriteLine($"Il risultato è {risultato}");




```

</details>

## 08 WHILE

<details>
    <summary>Visualizza il codice</summary>

```c#

// ciclo while

// inizializzo la variabile

int numero = 10;

//iterazione finchè la variabile numero è maggiore di 0

while (numero > 0)
{
    Console.WriteLine(numero);
    numero--;                           // ad ogni iterazione il numero si riduce di 1
}



```

</details>

## 09 DO-WHILE

<details>
    <summary>Visualizza il codice</summary>

```c#

// esempio di ciclo do while


int numero = 10;

do
{
    Console.WriteLine(numero);
    numero--;
}
while (numero > 0);




```

</details>

## 10 FOR

<details>
    <summary>Visualizza il codice</summary>

```c#

// esempio di ciclo for


for (int numero = 10; numero > 0; numero--)
{
    Console.WriteLine(numero);
}

// stesso esempio ma stampa i numeri al contrario

Console.WriteLine("Esempio contrario");

int n = 10;

for (int i = 1; i <= n; i++){
    Console.WriteLine(i);
}

//oppure

Console.WriteLine("Esempio alternativo");

for(int i = 1; i <= n;){
    
    Console.WriteLine(i);
    i++;
}

```

</details>

## 11 FOR-EACH

<details>
    <summary>Visualizza il codice</summary>

```c#

// esempi di for each 

/*
int[] numeri = new int[10];

for (int i = 0; i < numeri.Length; i++)
{
    numeri[i] = i;
}

foreach (int numero in numeri)
{
    Console.WriteLine(numero);
}

*/
string scritta = "ciao";

foreach(char lettera in scritta){
    Console.WriteLine(lettera);
}



```

</details>

## 12 RANDOM

<details>
    <summary>Visualizza il codice</summary>

```c#

// metodo random che accetta l'intervallo di generazione del numero inserito tramite input

Random random = new Random();       //new è un costruttore 

Console.WriteLine("Inserisci il primo numero dell'intervallo");

// converte la stringa di input in int

int primoNumero = int.Parse(Console.ReadLine());

Console.WriteLine("Inserisci il secondo numero dell'intervallo");



int secondoNumero = int.Parse(Console.ReadLine());

// genera numero random nell'intervallo scelto

int numeroCasuale = random.Next(primoNumero, secondoNumero);

Console.WriteLine($"Il numero casuale è {numeroCasuale}");

/* versione automatica

Random random = new Random();       //new è un costruttore 

int numeroCasuale = random.Next(11);

Console.WriteLine($"Il numero casuale è {numeroCasuale}");   */


```

</details>

## 13 INDOVINA NUMERO

<details>
    <summary>Visualizza il codice</summary>

```c#

// Calcolatore numeri random con 5 tentativi

// inizializzo contatore

int conteggio = 5;


Random random = new Random();

// intervallo generazione numeri random

int numeroCasuale = random.Next(1, 101);

//ciclo while per richiedere fino a un massimo di  5 volte l'inserimento del numero 

while (conteggio > 0)
{
    conteggio--;

// inizializzo variabile per conteggiare il numero di tentativi

    int tentativi =5 - conteggio;



    Console.WriteLine("Prego inserisca un numero per indovinare quello sorteggiato");

    // converte input in intero

    int numeroScelto = Convert.ToInt32(Console.ReadLine());

    // se il numero è giusto

    if (numeroScelto == numeroCasuale)
    {

        Console.WriteLine($"Complimenti hai indovinato il numero sorteggiato {numeroCasuale} in {tentativi} tentativi");
        break;

    }
    else if (numeroScelto > numeroCasuale)                      // suggerimento se il numero scelto è più grande del numero estratto
    {
        Console.WriteLine("Il numero scelto è troppo alto");


    }
    else
    {

        Console.WriteLine("Il numero scelto è troppo basso");   // suggerimento se il numero scelto è inferiore al numero estratto
    }
}
Console.WriteLine($"Il numero sorteggiato casualmente è {numeroCasuale}");      // informa circa il valore estratto




```

</details>

## 14 INDOVINA PARI DISPARI

<details>
    <summary>Visualizza il codice</summary>

```c#



```

</details>

## 15 FIZZBUZZ

<details>
    <summary>Visualizza il codice</summary>

```c#



```

</details>

## 16 STRING ARRAY

<details>
    <summary>Visualizza il codice</summary>

```c#



```

</details>

## 17 INT ARRAY

<details>
    <summary>Visualizza il codice</summary>

```c#



```

</details>

## 18 ARRAY LENGTH

<details>
    <summary>Visualizza il codice</summary>

```c#



```

</details>

## 19 LIST STRING

<details>
    <summary>Visualizza il codice</summary>

```c#



```

</details>

## 20 INT LIST

<details>
    <summary>Visualizza il codice</summary>

```c#



```

</details>

## 21 LIST COUNT

<details>
    <summary>Visualizza il codice</summary>

```c#



```

</details>

## 22 STRUTTURE DATI

<details>
    <summary>Visualizza il codice</summary>

```c#



```

</details>


## 23 DIZIONARIO DEI COLORI

<details>
    <summary>Visualizza il codice</summary>

```c#



```

</details>

## 24 LISTA SPESA

<details>
    <summary>Visualizza il codice</summary>

```c#



```

</details>


## 25 REGISTRO PRESENZE

<details>
    <summary>Visualizza il codice</summary>

```c#



```

</details>


## 26 REGISTRO VOTI

<details>
    <summary>Visualizza il codice</summary>

```c#



```

</details>

## 27 VAR

<details>
    <summary>Visualizza il codice</summary>

```c#



```

</details>

## AUTOVERIFICA 1

<details>
    <summary>Visualizza il codice</summary>

```c#



```

</details>

## AUTOVERIFICA 2

<details>
    <summary>Visualizza il codice</summary>

```c#



```

</details>

