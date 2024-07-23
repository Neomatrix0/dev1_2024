

try{

    int numero = int.Parse("1000000000000");

}catch(Exception e)
{
    Console.WriteLine("Il numero è troppo alto");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    Console.WriteLine($"CODICE ERRORE: {e.HResult}");
    return;
}
