
Console.WriteLine("Inserire il primo numero");

// Converti input primo numero in intero
int primoNumero =Convert.ToInt32(Console.ReadLine()); 

Console.WriteLine("Inserire il secondo numero");

// Converti input secondo numero in intero
int secondoNumero = Convert.ToInt32(Console.ReadLine()); 

//variabili contenenti le operazioni aritmetiche
int somma = primoNumero + secondoNumero;
int prodotto = primoNumero * secondoNumero;
int differenza = primoNumero - secondoNumero;
int quoziente = primoNumero / secondoNumero;

//richiede l'operatore da inserire 

Console.WriteLine("scegliere l'operazione da effettuare tra + - * /");

// input per inserire operatore
string operazione = Console.ReadLine();

//a seconda dell'operazione scelta verrà calcolato il risultato
switch(operazione)
{
    case "*":
    Console.WriteLine("Il risultato è " +  prodotto);
    break;          

    case "+":
    Console.WriteLine("Il risultato è " + somma);
    break; 


    case "-":
    Console.WriteLine("Il risultato è " + differenza);
    break;  

    case "/":
    Console.WriteLine("Il risultato è " + quoziente);
    break; 

    default: 

    Console.WriteLine("Inserisci l'operatore corretto");
    break;  
}



/*if(operazione == "/" && secondoNumero ==0){
    Console.WriteLine("Errore dividere per zero");
}  */

