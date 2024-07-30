// esercizio divisione con divrem

int dividendo = 10;
int divisore = 0;
int quoziente = Math.DivRem(dividendo,divisore, out int resto);
Console.WriteLine($"Quoziente: {quoziente}");
Console.WriteLine($"Resto: {resto}");