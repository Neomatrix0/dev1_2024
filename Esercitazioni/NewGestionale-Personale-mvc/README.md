# Applicazione mvc che ricalca il funzionamento del programma  Gestionale del personale 

- Conversione da programmazione funzionale ad oggetti del programma Gestionale dipendenti
- Lo scopo è quello di gestire i dati e gli indicatori relativi al personale con l'inserimento o la rimozione dei dati nel database (operazioni CRUD)
- L'applicazione segue il patter MVC per renderla più strutturata e modulare
- Il programma si basa sulla programmazione ad oggetti per mantenere  il codice ordinato generico e riutilizzabile
- Per la gestione del database utilizzeremo SQLite
- Implementazione di Spectre Console per la visione dei dati su console

# Tecnologie utilizzate
- C# (OOP): Implementazione ad oggetti per migliorare modularità e riusabilità.
- SQLite: Per la gestione del database locale che memorizza dipendenti, mansioni e indicatori.
- Spectre.Console: Per la visualizzazione dei dati in tabelle nella console.

## Strutturazione del database

- Il database è suddiviso in tre tabelle:

    - Dipendente: Memorizza le informazioni anagrafiche e collega il dipendente a una mansione e a degli indicatori di performance.
    - Mansione: Contiene le informazioni relative al titolo della mansione e allo stipendio.
    - Indicatori: Memorizza i valori di fatturato e presenze del dipendente.

<details>

<summary>Visualizza il codice sqlite</summary>

```sql

CREATE TABLE IF NOT EXISTS dipendente (id INTEGER PRIMARY KEY, nome TEXT, cognome TEXT, dataDiNascita DATE, mail TEXT,  mansioneId INTEGER,indicatoriId INTEGER,  FOREIGN KEY(mansioneId) REFERENCES mansione(id),FOREIGN KEY(indicatoriId) REFERENCES indicatori(id)) ;

CREATE TABLE IF NOT EXISTS mansione (id INTEGER PRIMARY KEY AUTOINCREMENT, titolo TEXT UNIQUE,stipendio REAL);

CREATE TABLE IF NOT EXISTS indicatori (id INTEGER PRIMARY KEY AUTOINCREMENT, fatturato DOUBLE,presenze INTEGER);



```

</details>

# MODELLO MVC E STRUTTURAZIONE CLASSI

- Classe Database -> gestisce creazione e operazioni direttamente sul database

- Classe View -> gestisce visione del menu principale

- Classe Controller -> Gestisce la logica del programma e funge da collegamento tra View e Database

- Classe Persona -> dati anagrafici

- Classe Dipendente -> eredita da classe Persona i dati anagrafici e aggiunge i campi  mansione, mail

<details>

<summary>Visualizza il codice class Dipendente</summary>

```c#

public class Dipendente : Persona
{
    public int Id { get; set; }
    public Mansione Mansione { get; set; }  // connette Dipendente a Mansione
    public string Mail { get; set; }
    public Statistiche Statistiche { get; set; } // connette Dipendente a Statistiche

    public Dipendente(int id,string nome, string cognome, string dataDiNascita, string mail, Mansione mansione, Statistiche statistiche = null)
        : base(nome, cognome, dataDiNascita) // Fa riferimento alla proprietà 'DataDiNascita' della classe base 'Persona'
    {
        this.Id =id;
        this.Mansione = mansione;
        this.Mail = mail;
        this.Statistiche = statistiche ?? new Statistiche(0, 0); // Imposta le statistiche
    }
}
```
</details>

- Classe Mansione -> include i campi titolo(della mansione) e stipendio

<details>

```c#

public class Mansione
{
    public int Id { get; set; }  // L'Id sarà gestito dal database
    public string Titolo { get; set; }
    public double Stipendio { get; set; }

    // Costruttore che accetta solo titolo e stipendio
    public Mansione(string titolo, double stipendio)
    {
        Titolo = titolo;
        Stipendio = stipendio;
    }
}



```

</details>

- Classe Statistiche -> include i campi fatturato e presenze

<details>

```c#

public class Statistiche{
   // public int Id{ get; set; }
    public int Performance{ get; set; }

    public double Assenze{ get; set; }

    public Statistiche(int performance,int assenze){
        
        Performance = performance;
        Assenze = assenze;
    }
}

    ```

</details>

##IMPLEMENTAZIONE FUNZIONALITà

- Operazioni CRUD relative al dipendente

- Aggiungi dipendente
    
<details>


```c#

  private void AggiungiDipendente()
    {
        Console.WriteLine("Inserisci il nome:"); // Richiesta del nome dell'utente
        var nome = _view.GetInput(); // Lettura del nome dell'utente
         Console.WriteLine("Inserisci il cognome:"); 
        var cognome = _view.GetInput();
        Console.WriteLine("Inserisci la data di nascita DD/MM/YYYY:"); 
        var dataDiNascitaString = _view.GetInput();
         Console.WriteLine("Inserisci la mail aziendale:");
        var mail = _view.GetInput();

        var mansioni = _db.MostraMansioni();
    foreach (var mansione in mansioni)
    {
        // Stampa ogni mansione con il suo ID e altri dettagli
        Console.WriteLine($"ID: {mansione.Id}, Titolo: {mansione.Titolo}, Stipendio: {mansione.Stipendio}");
    }

         Console.WriteLine("Scegli tra le mansioni disponibili per id:");
        var mansioneInput = _view.GetInput();
         if (int.TryParse(mansioneInput, out int mansioneId))
    {
        var mansioneid = Console.ReadLine();

        if (DateTime.TryParseExact(dataDiNascitaString, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dataDiNascita))
    {
        _db.AggiungiDipendente(nome, cognome, dataDiNascita,mail,mansioneId);
        Console.WriteLine("Dipendente aggiunto con successo."); // Aggiunta del dipendente al database
    }
    else
    {
        Console.WriteLine("Formato data di nascita non valido. Riprova.");
    }
   
    }else{
        Console.WriteLine("ID mansione non valido. Riprova.");
    }
    }


```
</details>
    - Mostra dipendenti

<details>

```c#
    private void MostraDipendenti()
    {
        var dipendenti = _db.GetUsers(); // Lettura degli utenti dal database
        var table = new Table();
         // Aggiungere le colonne alla tabella
    table.AddColumn("Nome");
    table.AddColumn("Cognome");
    table.AddColumn("Data di Nascita");
    table.AddColumn("Mansione");
    table.AddColumn("Stipendio annuale");
    table.AddColumn("Fatturato");
    table.AddColumn("Presenze");
    table.AddColumn("Email aziendale");
      //  _view.MostraDipendenti(dipendenti); // Visualizzazione degli utenti
      foreach (var dipendente in dipendenti)
    {
        table.AddRow(
            dipendente.Nome,
            dipendente.Cognome,
            dipendente.DataDiNascita,
            dipendente.Mansione.Titolo,
            $"{dipendente.Stipendio}",
            $"{dipendente.Statistiche.Fatturato}",
            $"{dipendente.Statistiche.Presenze}",
            dipendente.Mail
        );
    }

    // Visualizzare la tabella
    AnsiConsole.Write(table);
}

```

</details>

- Cerca dipendente

<details>

```c#

private void CercaDipendente(){
     Console.WriteLine("Cerca il dipendente usando la sua mail aziendale:");
      var cercaMail = _view.GetInput();
      var dipendente= _db.CercaDipendentePerMail(cercaMail);
      if(dipendente != null){

           var table = new Table();
        table.AddColumn("Nome");
        table.AddColumn("Cognome");
        table.AddColumn("Data di Nascita");
        table.AddColumn("Mansione");
        table.AddColumn("Stipendio");
        table.AddColumn("Fatturato");
        table.AddColumn("Presenze");
        table.AddColumn("Email");

        // Aggiungi i dati del dipendente nella tabella
        table.AddRow(
            dipendente.Nome,
            dipendente.Cognome,
            dipendente.DataDiNascita,
            dipendente.Mansione.Titolo,
            dipendente.Stipendio.ToString(),
            dipendente.Statistiche.Fatturato.ToString(),
            dipendente.Statistiche.Presenze.ToString(),
            dipendente.Mail
        );

        // Mostra la tabella
        AnsiConsole.Write(table);
       // Console.WriteLine("Dettagli del dipendente:");
       // Console.WriteLine(dipendente.ToString());
      }else{
        // Messaggio se il dipendente non viene trovato
        Console.WriteLine("Dipendente non trovato con questa email.");
      }

}


 ```


</details>

- Modifica Dipendente

   <details> 

   ```c#




   ```


   </details>
    
- Operazioni di calcolo e visualizzazione statistiche
    - Ordina Stipendi
    - Aggiungi indicatori
    - Tasso di presenza
    - Valutazione per fatturato
    - Incidenza percentuale



