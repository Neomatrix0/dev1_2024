try{
    int zero =0;
    int numero = 1/zero;


}

catch(Exception e){
    Console.WriteLine("Divisione per zero");
    Console.WriteLine($"Errore non trattato: {e.Message}");     // messaggio eccezione
    Console.WriteLine($"CODICE ERRORE:{e.HResult}");    //codice numerico eccezione
    Console.WriteLine(e.Data); // dati aggiuntivi dell'eccezione
    return;
}
finally{
    Console.WriteLine("Fine programma");
}