using Spectre.Console;
/*




// mia versione


// Assignment Strutture dati
 

AnsiConsole.Clear();
List<string> nomi = new List<string>();

nomi.Add("Mattia");
nomi.Add("Serghei");
nomi.Add("Daniele");
nomi.Add("Matteo");
nomi.Add("Allison");
nomi.Add("Sharon");
nomi.Add("Silvio");
nomi.Add("Ginevra");

var table = new Table();
table.AddColumn("Nome corso");
table.AddColumn("Anno");
table.AddColumn("Partecipanti"); // aggiunto ora
table.AddRow("Corso di informatica", "2024","Lista nomi");





foreach(string nome in nomi){

table.AddRow("", "",nome);



}   

// versione 1

AnsiConsole.Write(table); 

var table5 = new Table();
table5.AddColumn("Nome");
table5.AddColumn("Cognome");

var partecipanti = new Dictionary<string, string>
{

    {"Mario","Rossi"},
    {"Luca","Verdi"},
    {"Paolo","Bianchi"}
};


foreach(var partecipante in partecipanti){
    table5.AddRow(partecipante.Key, partecipante.Value);
}

AnsiConsole.Write(table5);

*/

// versione 2

var table6 = new Table();
table6.AddColumn("Nome");
table6.AddColumn("Cognome");
table6.AddColumn("Anno di nascita");


var partecipanti2 = new Dictionary<string, (string,string)>
{
    {"Mario",("Rossi","1990") },
    {"Luca",("Verdi","1980") },
    {"Paolo",("Bianchi","1970") }
};

foreach ( var partecipante in partecipanti2){
    table6.AddRow(partecipante.Key, partecipante.Value.Item1, partecipante.Value.Item2);

}

AnsiConsole.Write(table6);




// versione 3 


var partecipanti3 = new Dictionary<string, (string,int)>
{
     {"Mario",("Rossi",1990) },
    {"Luca",("Verdi",1980) },
    {"Paolo",("Bianchi",1970) }
};


foreach ( var partecipante in partecipanti3){
    table6.AddRow(partecipante.Key, partecipante.Value.Item1, partecipante.Value.Item2.ToString());


}

AnsiConsole.Write(table6);

// versione con tuple in Key e Value

var table7 = new Table();
table7.AddColumn("Nome");
table7.AddColumn("Soprannome");
table7.AddColumn("Cognome");
table7.AddColumn("Anno di nascita");


var partecipanti4 = new Dictionary<(string,string), (string,int)>
{
     {("Mario","soprannome"),("Rossi",1990) },
    {("Luca","soprannome"),("Verdi",1980) },
    {("Paolo","soprannome"),("Bianchi",1970) }
};

// Item serve per accesso a tupla

foreach ( var partecipante in partecipanti4){
    table7.AddRow(partecipante.Key.Item1,partecipante.Key.Item2, partecipante.Value.Item1, partecipante.Value.Item2.ToString());


}

AnsiConsole.Write(table7);