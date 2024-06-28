# Indovina pari e dispari

il pc sorteggia un numero a caso da 1 a 100 e chiede all'utente di indovinare se  sarà pari o dispari.
 Se ci sarà una corrispondenza tra la nostra scelta e quella che verrà sorteggiata verrà restituito un messaggio 

bool pari = somma % 2 == 0;


```mermaid
    flowchart TD
    A[Start] --> B[Inizializza Random] 
    B --> C[/Scegli Pari o Dispari/] 
    C --> D[/Inserisci un numero/] 
    D --> E[Genera numero random]
    E --> F[Somma numero utente e numero random]
    F --> G[Variabile bool isPari  somma % 2 == 0]
    G --> H{isPari}
    H -- Vero --> I{Scelta == P}
    H -- Falso --> J{Scelta == D}
    I -- Sì --> K[Vittoria] --> M[End]
    I -- No --> L[Sconfitta] --> M[End]
    J -- Sì --> K
    J -- No --> L


```



