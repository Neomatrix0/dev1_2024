// Quando la pila è piena


try
{
    StackOverflow();
}

catch (Exception e)
{
    Console.WriteLine("StackOverFlow");
    Console.WriteLine($"ERRORE NON TRATTATO: {e.Message}");
    return;
}



static void StackOverflow()
{
    StackOverflow();
}
