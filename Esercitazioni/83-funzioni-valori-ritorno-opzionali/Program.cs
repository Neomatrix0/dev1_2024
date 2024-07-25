class Program
{
    static void Main()
    {
        int? risultato = Dividi(10,2);
        // controlla se il valore è presente o se è nullo
        if(risultato.HasValue){
            Console.WriteLine($"Il risultato è:{risultato.Value}");
        }else{
            Console.WriteLine("Divisione per zero");
        }         


    }

    static int? Dividi(int a, int b){
        if(b == 0){         // divisione per zero
            return null;    // valore opzionale
        }
        return a/b;         // divisione
    }

}