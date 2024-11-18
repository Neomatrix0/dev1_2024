
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace Docker
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tentativi.json");
            Random random = new Random();
           // Random random = random.Shared;
            int numero = random.Next(1, 101);
            int tentativi = 0;
            int tentativo = 0;

            Console.WriteLine("Indovina il numero tra 1 e 100");
            if(File.Exists(filePath)){
                try{
                    string tentativiString = File.ReadAllText(filePath);
                    if(!string.IsNullOrWhiteSpace(tentativiString)){
                        tentativi = JsonConvert.DeserializeObject<int>(tentativiString);
                    }
                }
                catch(Exception ex){
                    Console.WriteLine($"Errore nella lettura del file: {ex.Message}");

                }
            }

            do
            {
                Console.Write("Inserisci un numero: ");
                string? input = Console.ReadLine();

                tentativo = int.TryParse(input, out int result) ? result : 0;

                if (tentativo < numero)
                {
                    Console.WriteLine("Troppo basso");
                }
                else if (tentativo > numero)
                {
                    Console.WriteLine("Troppo alto");
                }

                tentativi++;

                try{
                    File.WriteAllText(filePath, JsonConvert.SerializeObject(tentativi));
                }catch(Exception ex){
                    Console.WriteLine($"Errore nella scrittura del file: {ex.Message}");
                }
            } while (tentativo != numero);

            Console.WriteLine($"Hai indovinato in {tentativi} tentativi");
        }
    }
}
