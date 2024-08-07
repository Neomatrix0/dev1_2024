
 # PROGETTAZIONE APPLICAZIONE GESTIONE  RISORSE UMANE

## GESTIONE PERSONALE   

Questa applicazione console permetterà la gestione del personale in un azienda,valutando performance,costi,mansioni,ore di lavoro e tasso di assenteismo.
Verranno divisi i dipendenti in 2 gruppi in base al punteggio di produttività e verranno segnalati il 15 % dei dipendenti meno performanti.
Mostra i dati relativi a stipendi e  assenze del personale calcolando in percentuale il tasso di assenteismo di ognuno

## DEFINIZIONE DEI REQUISITI E ANALISI

L'applicazione consente ad una azienda di monitorare il personale,valutarne le performance e i costi

- [ ] L'applicazione consente di inserire il nome e cognome della persona assunta,età,mansione,score di produttività da 1 a 10,stipendio,ore di assenza

- [ ] Visualizzazione dei dipendenti inseriti con i relativi dati anagrafici 

- [ ] Possibilità di visionare gli stipendi annuali di ogni dipendente

- [ ] Valutazione performance e indicazione del 15% dei dipendenti meno performanti


## PIANIFICAZIONE E DESIGN DELL'ARCHITETTURA

- [ ] Impostazione del menu generale con opzioni di scelta

- [ ] Opzione di inserimento del personale con dati inseriti in modo intervallato da virgola(Split),dettagli anagrafici,stipendio,mansione,contratto,performance,assenze e salvataggio dati nel file json

- [ ] Opzione di visualizzazione di tutto il personale con i relativi dati

- [ ] Valutazione performance i dipendenti vengono divisi in 2 gruppi in base al livello della performance e viene segnalato il 15% dei dipendenti con le performance più basse il in questo sottomenu

- [ ] Calcolo assenteismo scrivendo nome e cognome  del dipendente l'utente inserisce  le ore lavorate e viene calcolato il tasso di assenteismo(assenze/ giorni da lavorare)*100

- [ ]  Opzione sottomenu  cerca dipendente e inserisci valutazione da valutare questo aspetto

- [ ]  Modifica dati dipendente 

- [ ] rimuovi dipendente

- [ ] sorta stipendio dal più alto al più basso con mansione e dati anagrafici



## DEFINIZIONE DI STRUTTURE E CONVENZIONI

Ora che abbiamo deciso come organizzare il codice, dobbiamo definire le convenzioni di codifica e i nomi standard. In questo caso, useremo le convenzioni di codifica di C# e .NET e i nomi standard.

 - [ ]  I nomi delle classi devono essere PascalCase.
 - [ ]  I nomi dei metodi devono essere PascalCase.
 - [ ]  I nomi delle variabili devono essere camelCase.
 - [ ]  I nomi delle costanti devono essere UPPERCASE.
 - [ ]  I nomi dei file devono essere lowercase.
 - [ ]  I nomi dei progetti devono essere PascalCase.
 - [ ]  I nomi dei namespace devono essere PascalCase.


## SVILUPPO DEI COMPONENTI
Ora che abbiamo definito le convenzioni di codifica e i nomi standard, possiamo iniziare a scrivere il codice. In questo caso, creeremo un progetto console per l'applicazione e un progetto di test per i test unitari.

- [ ] Creare un progetto console per l'applicazione.
- [ ] Creare un progetto di test per i test unitari.

## TEST E DEBUGGING
Ora che abbiamo integrato i componenti dell'applicazione, dobbiamo testarli e risolvere eventuali bug. In questo caso, scriveremo test unitari per i componenti dell'applicazione.

 - [ ] Scrivere test unitari per i componenti dell'applicazione.
 - [ ] Eseguire il debugging per individuare e risolvere i bug



## DOCUMENTAZIONE

Ora che abbiamo testato e risolto i bug dell'applicazione, dobbiamo documentare il codice e l'architettura. In questo caso, documenteremo il codice e l'architettura dell'applicazione.

 - [ ] Documentare il codice e l'architettura dell'applicazione.

 - [ ] Documentare i test unitari.

 - [ ] Documentare la fase di Beta Testing.

 - [ ] Documentare la fase di post Beta Testing.


## SCHEDULE 
```mermaid

gantt
    title A Gantt Diagram
    dateFormat YYYY-MM-DD
    section Section
        Giorno 1 impostazione menu    :a1, 2024-07-22, 1d
        Giorno 2 lavoro su funzioni   :a2, 2024-07-23, 1d
        Giorno 3 Persistenza dei dati :a3, 2024-07-24, 1d
        Giorno 4 Finire funzionalità e spectre :a4, 2024-07-25, 1d
        Giorno 5 Fine                 :a5, 2024-07-26, 1d


   
```


## FLOWCHART
```mermaid



   flowchart TD
    A[Start] --> B{Menu Principale}
    B -- 1 --> C[Inserisci dipendente con i dati] --> Z
    B -- 2 --> D[visualizza dipendenti] --> Z
    B -- 3 --> E[cerca dipendente] --> Z
    B -- 4 --> F[modifica dipendente] --> Z
    B -- 5 --> G[rimuovi dipendente] --> Z
    B -- 6 --> H[tasso di assenteismo ] --> Z
    B -- 7 --> I[performance indicatore] --> O[top10] & O1[-10] --> Z
    B -- 8 --> L[sorta stipendio] --> Z
    B -- 9 --> M[salva dipende json] --> Z
    B -- 9 --> N[esci dall'applicazione] --> Z
    Z[end] --loop --> B

    
   

   
```