// See https://aka.ms/new-console-template for more information
string path = @"test.txt";
string path2 = @"test2.txt";

// Check if the files exist before reading and creating them
if (!File.Exists(path) && !File.Exists(path2))
{
    File.Create(path).Close();
    File.Create(path2).Close();
}
Random random = new Random();
string[] lines = File.ReadAllLines(path);
string[] nomi = new string[5];
Console.WriteLine("Inserisci 5 nomi divisi da ','");
string input = Console.ReadLine();
nomi = input.Split(",");


foreach (string nome in nomi)
{
    if (File.Exists(path))
    {


        File.AppendAllText(path, $"{nome}\n");
    }
    //Console.WriteLine(nome);
}

int indice = random.Next(nomi.Length);
string nomeRandom = nomi[indice];
string ultimoNome = nomi[nomi.Length-1];
string nomeMediano = nomi[nomi.Length-3];

if (File.Exists(path2))
{


    File.AppendAllText(path2, $"{nomeRandom}\n{ultimoNome}\n{nomeMediano}");
}
//prendi stringa -1 dall'array  e lo aggiungi a test2