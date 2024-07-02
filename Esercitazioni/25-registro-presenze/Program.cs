// registro presenze


Dictionary<string, bool> presenze = new Dictionary<string, bool>();

presenze["Mario Rossi"] = true;
presenze["Luca Bianchi"] = false;

foreach(KeyValuePair<string, bool> dipendente in presenze){

    if(dipendente.Value){
        Console.WriteLine($"Dipendente: {dipendente.Key}, Stato: Presente");
    }else{
        Console.WriteLine($"Dipendente: {dipendente.Key}, Stato: Assente");
    }


}