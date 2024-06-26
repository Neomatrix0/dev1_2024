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

