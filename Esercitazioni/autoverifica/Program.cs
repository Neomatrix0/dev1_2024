// esercizi 



Random random = new Random();                           // nuovo oggetto random

int somma =0;                                           // inizializzo variabile a 0


for(int i=0; i < 10;i++){                               // cicla per 10 volte
int numeroCasuale = random.Next(1, 11);                 // genera un numero random da 1 a 10
Console.WriteLine(numeroCasuale);
somma+=numeroCasuale;                                   //aggiunge i numeri estratti a somma


}

Console.WriteLine($"La somma dei numeri estratti è {somma}");       // stampa somma





