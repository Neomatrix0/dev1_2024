public class Mansione
{
    public int Id { get; set; }  // L'Id sarà gestito dal database
    public string Titolo { get; set; }
    public double Stipendio { get; set; }

    // Costruttore che accetta solo titolo e stipendio
    public Mansione(int id,string titolo, double stipendio)
    {
        Id =id;
        Titolo = titolo;
        Stipendio = stipendio;
    }
    // Costruttore che accetta solo titolo e stipendio
    public Mansione(string titolo, double stipendio)
    {
        Titolo = titolo;
        Stipendio = stipendio;
    }
}