public class Mansione{
    public int Id{ get; set; }
    public string Titolo{ get; set; }

    public double Stipendio{ get; set; }

    public Mansione(int id, string titolo,double stipendio){
        Id = id;
        Titolo = titolo;
        Stipendio = stipendio;
    }

     // Costruttore che accetta solo titolo e stipendio
    public Mansione(string titolo, double stipendio)
    {
        Titolo = titolo;
        Stipendio = stipendio;
    }

    // Sovrascrivi il metodo ToString per rappresentare l'oggetto come stringa
    public override string ToString()
    {
        return $"ID: {Id}, Mansione: {Titolo}, Stipendio: {Stipendio}";
    }
}