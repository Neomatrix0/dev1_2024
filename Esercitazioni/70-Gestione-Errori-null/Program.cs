string nome = null;

try{
    Console.WriteLine(nome.Length);
}

catch(Exception e){
    Console.WriteLine("Il nome non è valido");
    Console.WriteLine($"Errore non trattato: {e.Message}");
    return;
}