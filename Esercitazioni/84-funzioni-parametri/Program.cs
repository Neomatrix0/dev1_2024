class Program
{
    static void Main()
    {
        Saluta("Mondo");  // parametro
    }

    static void Saluta(string nome)
    {
        Console.WriteLine($"Ciao,{nome}!");
    }
}