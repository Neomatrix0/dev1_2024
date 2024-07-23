// See https://aka.ms/new-console-template for more information


try{
    int numero = int.Parse(null);
}
catch(Exception e){
    Console.WriteLine("Il numero non può essere null");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    return;
}