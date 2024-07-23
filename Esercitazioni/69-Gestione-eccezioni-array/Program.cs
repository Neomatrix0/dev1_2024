
int [] numeri = {1,2,3};

try{
    Console.WriteLine(numeri[3]);
}

catch(Exception e) {
    Console.WriteLine("indice non valido");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    return;
}
// finally si lancia lo stesso a prescindere dall'eccezione
finally{
    Console.WriteLine("Fine del programma");
}