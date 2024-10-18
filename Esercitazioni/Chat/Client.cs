using System;
using System.Net.Sockets;
using System.Text;

public class Client
{
    void StartClient(string serverIP, int port)
    {
        using (var client = new TcpClient(serverIP, port))
        using (var stream = client.GetStream())
        {
            Console.WriteLine("Connesso al server");
            string messageToSend = Console.ReadLine(); 

            while (!string.IsNullOrEmpty(messageToSend)) 
            {
                byte[] buffer = Encoding.ASCII.GetBytes(messageToSend);  // converte la stringa in un array di byte
                stream.Write(buffer, 0, buffer.Length);
                messageToSend = Console.ReadLine();
            }
        } // Il blocco using assicura che lo stream sia chiuso correttamente alla fine
    }

    public static void Main(string[] args)
    {
        Client client = new Client();   
        Console.WriteLine("Inserisci l'IP del server:");
        string serverIP = Console.ReadLine();
        client.StartClient(serverIP, 3000);   // 3000 è la porta su cui il server è in ascolto
    }
}
