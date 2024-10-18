using System;
using System.Net; // Necessario per IPAddress
using System.Net.Sockets; // Necessario per TcpListener, TcpClient e NetworkStream
using System.Text; // Necessario per Encoding
using System.Threading; // Necessario per Thread e ParameterizedThreadStart


public class Server {

    private TcpListener listener; //oggetto che rappresenta un server tcp

public void StartServer(int port){
    listener = new TcpListener(IPAddress.Any,port);
    listener.Start();
    Console.WriteLine("Server avviato su porta" + port);

    while(true){
        TcpClient client = listener.AcceptTcpClient();
        Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient)); // crea un nuovo thread per gestire il client connesso
        clientThread.Start(client); //Avvia il thread per gestire il client connesso in questo caso thread significa un flusso di esecuzione separato
    }
}

private void HandleClient(object obj){
    TcpClient client = (TcpClient)obj;
    NetworkStream stream = client.GetStream();
    byte[] buffer= new byte[1024];
    int byteCount;

    while((byteCount = stream.Read(buffer, 0, buffer.Length)) != 0){
        string message = Encoding.ASCII.GetString(buffer,0, byteCount);
        Console.WriteLine("Ricevuto" + message);
        Broadcast(message);
    }
    client.Close();
}
private void Broadcast(string message){
//aggiungi qui la logica
}

    public static void Main(string[] args){
    // digito ipconfig nel cmd e prendo l'indirzzo ipv4
    Server server = new Server();  // crea un istanza della classe Server 
    server.StartServer(3000); //avvia il server sulla porta 3000
}
}