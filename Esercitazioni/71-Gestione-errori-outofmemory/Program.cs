
try{
    int [] numeri = new int[int.MaxValue];  // int.MaxValue è il valore massimo che può contenere un int perciò poi il programma si blocca
    //arriva fino a 2147483647...
}
catch(Exception e){
    Console.WriteLine("Memoria insufficiente");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    return;
}