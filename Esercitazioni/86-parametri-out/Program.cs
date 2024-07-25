
class Program
{
    static void Main()
    {
        int risultato;
        Somma(3,4,out risultato);
        Console.WriteLine($"La somma è: {risultato}");
    }

static void Somma(int a,int b, out int risultato){   //   out funziona come il return,am invece di essere dentro alla funzione è tra i parametri
    risultato = a+b;
}
}

// la funzione Somma prende 2 parametri interi a e b restituisce la loro somma con un parametro di output risultato
//Il parametro risultato deve essere dichiarato come out  al momento della chiamata per indicare che verrà restituito un valore della funzione

