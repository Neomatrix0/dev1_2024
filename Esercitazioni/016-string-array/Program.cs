// array structure 

string[] nomi = new string[3];

nomi[0] = "Mario";
nomi[1] = "Luigi";
nomi[2] = "Giovanni";


Console.WriteLine($"Ciao {nomi[0]},{nomi[1]},{nomi[2]}.");

// ciclo for

for (int i = 0; i < nomi.Length; i++)
{
    Console.WriteLine("Arrivederci " + nomi[i]);
}

// oppure con foreach

foreach (string nome in nomi)
{
    Console.WriteLine(nome);
}




