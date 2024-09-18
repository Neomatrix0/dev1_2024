public class Animale{
    public string Nome{ get; set; }
    public int Eta{ get; set; }
    public string Verso{ get; set; }

    public virtual void FaiVerso(){
        Console.WriteLine($"{Nome} fa: {Verso}");
    }

    public virtual void AzioneSpecifica(){
        // implementazione di default o vuota
    }
}

// Classe Mucca che estende Animale
public class Mucca : Animale{
    public double QuantitaLatte{ get; set; }  // in litri

    public override void AzioneSpecifica()
    {
        Mungi();
    }

    public void Mungi(){
        Console.WriteLine($"{Nome} è stata munta e ha prodotto {QuantitaLatte} litri di latte.");
    }
}

// Classe Maiale che estende Animale
public class Maiale : Animale {
    public double Peso{ get; set; } // in kg

    public override void AzioneSpecifica()
    {
        Mangia();
    }

    public void Mangia(){
        Console.WriteLine($"{Nome} sta mangiando e pesa ora {Peso} kg.");
    }
}

class Program{
    static void Main(string[] args) {
        // Creazione di una lista di animali
        List<Animale> animali = new List<Animale>();

        // Aggiunta di una mucca
        Mucca mucca = new Mucca{
            Nome = "Mucca",
            Eta = 5,
            Verso = "Muuu",
            QuantitaLatte = 10
        };
        animali.Add(mucca);

        // Aggiunta di un maiale
        Maiale maiale = new Maiale{
            Nome = "Maiale",
            Eta = 10,
            Verso = "Oink",
            Peso = 100
        };
        animali.Add(maiale);

        // Esecuzione del polimorfismo
        foreach (var animale in animali){
            // Esegui il verso dell'animale
            animale.FaiVerso();

            // Azioni specifiche per ogni animale
            animale.AzioneSpecifica();
        }
    }
}
