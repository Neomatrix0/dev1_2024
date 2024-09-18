class Dado{

    // dichiarazioni variabili
    private Random rand= new Random();

    private int facce;
// metodo per settare il numero di facce del dado
    public void SetFacce(int valore) {
        if(valore < 5){
            Console.WriteLine("Opzione non eseguibile.Facce =4");
            facce=4;
        }else{
            facce= valore;
        }
    }

    public int GetFacce() {
       return facce;
    }  

// costruttore per istanziare e inizializzare un nuovo oggetto
    public Dado(int facce) {
        this.SetFacce(facce);    
    }

    public Dado(){
        facce =4;
    }
}