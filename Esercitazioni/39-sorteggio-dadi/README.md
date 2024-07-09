# Gioco del Lancio dei Dadi

- **Obiettivo:**

Simula il lancio di più dadi e registra i risultati per calcolare statistiche.

**Descrizione:**

- Il giocatore può decidere quanti dadi lanciare (ad esempio, da 1 a 6 dadi).
- Ogni dado ha 6 facce numerate da 1 a 6.
- Dopo il lancio, il programma deve mostrare il risultato di ogni dado e il totale dei punteggi.
- Gli esiti di ogni turno vengono salvati in un array per calcolare statistiche come la media dei punteggi totali, il punteggio più frequente, ecc.

**Passaggi per l'implementazione:**

- [x] Chiedi all'utente quanti dadi vuole lanciare.
- [x] Simula il lancio dei dadi usando un generatore di numeri casuali.
- [x] Salva i risultati di ogni dado in un array.
- [x] Mostra il risultato di ogni dado e il totale.
- [x] Conserva il risultato totale di ogni turno in un altro array.
- [x] Calcolare la frequenza dei numeri usciti.
- [ ] Dopo una serie di turni, calcola e mostra statistiche basate sui risultati totali

```csharp
Console.WriteLine("Quanti dadi vuoi lanciare?");
int numDadi = int.Parse(Console.ReadLine());
int[] risultati = new int[numDadi];
Random random = new Random();

// Lancio dei dadi
int somma = 0;
for (int i = 0; i < numDadi; i++) {
    risultati[i] = random.Next(1, 7);
    somma += risultati[i];
    Console.WriteLine($"Dado {i + 1}: {risultati[i]}");
}
```