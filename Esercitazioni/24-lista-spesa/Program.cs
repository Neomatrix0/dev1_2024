// See https://aka.ms/new-console-template for more information


Dictionary<string, int> listaSpesa = new Dictionary<string, int>();

// aggiunge valore stringa e int 

listaSpesa.Add("pane", 1);
listaSpesa.Add("latte", 2);



// aggiungere un nuovo articolo in modo alternativo

listaSpesa["uova"] = 12;

// incrementa la quantità di un articolo già presente

listaSpesa["pane"] = listaSpesa["pane"] + 1;

foreach(KeyValuePair<string, int> articolo in listaSpesa){
    Console.WriteLine($"Articolo: {articolo.Key}, Quantità: {articolo.Value}");

}