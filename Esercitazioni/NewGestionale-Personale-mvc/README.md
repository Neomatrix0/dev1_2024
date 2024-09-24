# Applicazione mvc che ricalca il funzionamento del programma  Gestionale del personale 
- Conversione da programmazione funzionale ad oggetti del programma Gestionale dipendenti

- Lo scopo è quello di gestire i dati e gli indicatori relativi al personale con l'inserimento o la rimozione dei dati nel database
- L'applicazione segue il patter MVC per renderla più strutturata e modulare
- Il programma si basa sulla programmazione ad oggetti per mantenere  il codice ordinato generico e riutilizzabile
- Per la gestione del database utilizzeremo SQLite
- Implementazione di Spectre Console per la visione dei dati su console

## Strutturazione del database

- Il database consiste in 3 tabelle una dipendente,una mansione e una indicatori

- Tutte le tabelle sono collegate a Dipendente

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
public class Dipendente : Persona{
     public Mansione Mansione{get;set;}  // connette Dipendente a Mnasione

     public string Mail{get;set;}

     public double Stipendio{get;set;}
      public Statistiche Statistiche { get; set; } // connette le due classi Dipendente Statistiche

public Dipendente(string nome,string cognome,string dataNascita,string mail,Mansione mansione Statistiche statistiche): base (nome,cognome,dataNascita)
{
    
    this.Mansione = mansione;
    this.Mail = mail;
    this.Statistiche = statistiche;  //assegna le statistiche al dipendente
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