# ELENCO COMPAGNI DI CORSI CON SORTEGGIO


Creare una console app con un elenco di nomi  dei partecipanti del corso.
La app sorteggia un nome e lo visualizza  

# Versione 2

Implementare il metodo RemoveAt(indice) ci permette di eliminare un nome una volta estratto


versione alternativa inserendo più nomi in contemporanea invece di uno alla volta per creare una struttura dati

```c#

// per creare un nuovo array già inizializzato
nomi.AddRange(new string[] {"Mario,Giovanni,Luigi"});

// oppure per le liste

List<string> names = new List<string> {"Mario,Giovanni,Luigi"};

```

# Versione 3

La app sorteggia un nome e lo visualizza
toglie il nome sorteggiato dalla lista e lo visualizza 
continua ad estrarre nomi finchè ci sono partecipanti dentro alla lista.
Quando la lista rimane vuota stampa un messaggio di avvertimento

# Versione 4

la app toglie dalla lista il nome sorteggiato e lo aggiunge ad una seconda lista sorteggiati

# Versione 5

l'app permette d'inserire un nuovo partecipante
1. inserisci partecipante 

    - nome partecipante:

2. visualizza partecipanti

3. esci

visualizza la lista di partecipanti

la app permette di uscire

# Versione 6

1. La app permette di ordinare la lista dei partecipanti in ordine alfabetico con il metodo partecipanti.Sort();
partecipanti.Reverse(); ordinamento inverso

# Versione 7

1.  cerca un partecipante specifico nella lista
```c#
 if(partecipanti.Contains(nome){
    Console.WriteLine($"{nome} è nell'elenco ")
 });

 ```

Dovrà dirci se il nome inserito è compreso oppure no nella lista


# Versione 8

Eliminare un partecipante dalla lista se presente usando il seguente metodo 

```c#
nomelista.Remove(nome);
```