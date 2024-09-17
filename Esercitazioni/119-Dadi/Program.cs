class Dado{


private Random random= new Random();
private int facce;

// costruttore specificare il numero di facce del dado
public Dado(int facce){
    this.facce = facce;
}

// metodo lancia dadi
public int Lancia(){
    return random.Next(1,facce+1);
}
}




class Program{
    public static void Main(string[] args){

        // specifico numero di facce
        Dado d1 = new Dado(6);
        Dado d2 = new Dado(12);

       

        int n1 = d1.Lancia();
        int n2 = d2.Lancia();

        Console.WriteLine($"Dado 1 (6 facce): {n1}");
        Console.WriteLine($"Dado 2 (12 facce): {n2}");

      
    }
}

/*  versione Insegnante
class Dado{
    private Random random = new Random();
    private int facce;

    public int Facce{
        get{return facce;}
        set{facce = value;}
    }

    public Dado(int facce){
        this.facce = facce;
    }

    public int Lancia(){
        return random.Next(1,facce + 1);
    }
}

class Program{
    static void Main(string[] args){
        Dado d1 = new Dado(6);
        Dado d2 = new Dado(20);

        d1.Facce = 6;   // qquesta riga setta il numero di facce del dado da 1 a 6 come un valore di default
        d2.Facce = 20;

        int n1 = d1.Lancia();
        int n2 = d2.Lancia();
         Console.WriteLine($"Dado 1 : {n1}");
        Console.WriteLine($"Dado 2 : {n2}");

    }
}

*/