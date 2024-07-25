class Program
{
    static void Main()
    {
        int valore = 10;
        incrementa(ref valore);
        Console.WriteLine($"Il valore è: {valore} ");


    }

    static void Incrementa(ref int valore){         // rispetto ad out prende in esame un parametro che verrà aggiornato
        valore++;
    }

}