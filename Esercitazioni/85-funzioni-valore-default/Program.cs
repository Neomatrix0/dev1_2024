class Program
{
    static void Main()
    {
        Saluta("Mondo");
        Saluta("Mondo","Ciao"); 
      
    }

    static void Saluta(string nome,string saluto = "Ciao")
    {
        Console.WriteLine($"{saluto},{nome}!");
    }
}