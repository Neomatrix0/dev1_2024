using Microsoft.EntityFrameworkCore;
public class View
{
    public void ShowMainMenu()
    {
        Console.WriteLine("1. Add product");
        Console.WriteLine("2. View products");
        Console.WriteLine("3. Update product");
        Console.WriteLine("4. Delete product");
        Console.WriteLine("5. exit");
        Console.WriteLine("5. Add category");
    }

    public string GetInput()
    {
        return Console.ReadLine();
    }

    // Metodi aggiuntivi per visualizzare dati o leggere input dall'utente
}
