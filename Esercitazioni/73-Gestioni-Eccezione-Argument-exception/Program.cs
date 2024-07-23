// See https://aka.ms/new-console-template for more information


try{
    int numero = int.Parse("ciao");
}
caatch(Exception e){
    Console.WriteLine("Il numero non è valido");
    Console.WriteLine($"ERRORE NON TRATTATO: e.Message");
    return;
}
