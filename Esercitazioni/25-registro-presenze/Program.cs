// registro presenze


Dictionary<string, bool> presenze = new Dictionary<string, bool>();

presenze["Mario Rossi"] = false;
presenze["Luca Bianchi"] = true;



foreach (KeyValuePair<string, bool> dipendente in presenze)
{

    // se il valore di default è true

    if (dipendente.Value)
    {
        Console.WriteLine($"Dipendente: {dipendente.Key}, Stato: Presente");
    }
    else
    {
        Console.WriteLine($"Dipendente: {dipendente.Key}, Stato: Assente");
    }


}

// cambio stato dipendente

Console.WriteLine("Di quale dipendente vuoi cambiare lo stato?");

string nomeDipendente = Console.ReadLine();

if (presenze.ContainsKey(nomeDipendente))
{
    presenze[nomeDipendente] = !presenze[nomeDipendente];   // cambio stato dipendente
}
else
{
    Console.WriteLine("Il dipendente non è presente nella lista");
}

// stampa lista aggiornata

foreach (KeyValuePair<string, bool> dipendente in presenze)
{

    if (dipendente.Value)
    {
        Console.WriteLine($"Dipendente: {dipendente.Key}, Stato: Presente");
    }
    else
    {
        Console.WriteLine($"Dipendente: {dipendente.Key}, Stato: Assente");
    }
}



