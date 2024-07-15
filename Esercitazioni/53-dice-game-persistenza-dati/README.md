# Dice Game Spectre Console

##  Miglioramento dell'esercizio 28 implementando Spectre Console in modo da avere un interfaccia più chiara e performante

Rappresentazione del flusso di gioco e delle decisioni che vengono prese a ogni turno

- Ci sono 2 giocatori

- Ognuno lancia 2 dadi

- Entrambi i giocatori iniziano con 100 punti

- Ogni turno ciascuno lancia 2 dadi, la differenza della somme dei punteggi dei dadi viene sottratta ai punti del giocatore con il totale minore

> **Ad esempio** se il computer lancia 6 e il giocatore umano lancia 12 al computer vengono sottratti 6 punti dal punteggio di 100 aggiornato il punteggio a 94

- il primo che arriva a 0 punti o meno perde

- il gioco continua fino a quando il computer o il giocatore umano raggiungono 0 punti

> **EXTRA:**  Implementare la persistenza dei dati

- vengono scritti nel file registro tutte le giocate con relativo timestamp
- viene aggiunto al file registroVittorie  solo il punteggio più alto
- vengono presi i 3 punteggi totali più alti di ciascun giocatore e li aggiunge ad un file di testo


```mermaid

flowchart TD
   Start --> A0[Creazione path per file di testo] --> Random --> A[Giocatore1 lancia dadi] --> B[PC lancia i dadi]

   B--> D[Calcolo Somma dei rispettivi lanci] --> G{lancio giocatore1 maggiore di lancio pc?}
   G --si--> H[Sottrai punti a pc per la differenza dei punteggi] --> L0[scrive punti] 
   L{Chi perde?}
   G --no --> I[Sottrai punti a giocatore 1 per la differenza dei punteggi] --> L0[scrive punti] --> L{Chi perde?}

   L --PC == 0--> M[pc perde e vince giocatore 1] --> S[aggiunta punteggio max a file txt] --> Z[end]
   L --giocatore1 == 0 --> P[Giocatore1 perde vince pc] --> S[aggiunta punteggio max a file txt] 
   L --parità--> V[se entrambi hanno stesso punteggio = parità] --> Z[end]

   Z --> Random




   ```

  


  
  
  

  

  
  
  
  
  
  
  
  
  
  