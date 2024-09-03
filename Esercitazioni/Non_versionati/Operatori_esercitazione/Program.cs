using System.Text.RegularExpressions;
/*
string pattern = @"\b[D]\w+";

Regex rg = new Regex(pattern);

string authors = "Mahesh Chand, Raj Kumar, Mike Gold, Allen O'Neill, Marshal Troll,Davide Marrone";

MatchCollection matchedAuthors = rg.Matches(authors);

for (int i = 0; i < matchedAuthors.Count; i++) {
    Console.WriteLine(matchedAuthors[i].Value);
}


// Spilt a string on alphabetic character
string azpattern = "[a-z]+";
string str = "Asd2323b0900c1234Def5678Ghi9012Jklm";
string[] result = Regex.Split(str, azpattern,
RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(500));
for (int i = 0; i < result.Length; i++)
{
    Console.Write("'{0}'", result[i]);
    if (i < result.Length - 1)
        Console.Write(", ");
}

*/


using System;
using System.Text.RegularExpressions;

class MainClass
{
    public static void Main(string[] args)
    {
        string path = @"prova.txt";
        string input = File.ReadAllText(path);
      
        string pattern = @"\bnome\b";

        // Check if the word "match" is in the input string
         bool isMatch = Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);

        Console.WriteLine(isMatch); // Output: True
        Saluta("Matteo",2);
    }


    static void Saluta(string nome,int ora){
        switch(ora){
            case 0:

            Console.WriteLine($"Buongiorno {nome}");
            break;

               case 1:

            Console.WriteLine($"Buon pomeriggio {nome}");
            break;


            case 2:

              

            Console.WriteLine($"Buona sera {nome}");
            break;


        }
    }
}