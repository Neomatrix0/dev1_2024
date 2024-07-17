// lettura file json
class Program
{
     static void Main(string[] args)
    {

        string path = @"test.json";             //  in questo caso il file è nella stessa cartella del programma 
        string json = File.ReadAllText(path);  //legge file
        Console.WriteLine(json);                // stampa il file

    }
}