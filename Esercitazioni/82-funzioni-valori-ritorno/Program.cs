
// restituisce più valori usando una tupla

class Program
{
    static void Main()
    {
        int[] numeri = { 3, 1, 4, 1, 5, 9 };
        (int minimo, int massimo) risultato = CalcolaMinMax(numeri);
        Console.WriteLine($"Valore minimo:  {risultato.minimo}");
        Console.WriteLine($"Valore massimo:  {risultato.massimo}");
    }

    static (int, int) CalcolaMinMax(int[] numeri)
    {
        int minimo = numeri.Min();
        int massimo = numeri.Max();
        return (minimo, massimo); // tupla
    }
}

//Questa funzione CalcolaMinMax prende un array di numeri e restituisce il vaore minimo e massimo come una tupla.
//I valori restituiti vengono quindi assegnati a una variabile risutlato e stampati sulla consol.e