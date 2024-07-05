// See https://aka.ms/new-console-template for more information


Console.WriteLine("Lancio dei dadi");


Random random = new Random();

int score = 0;


//bool prosecuzione = true;
List<int> lanci = new List<int>();

int primoLancio = random.Next(1, 7);
int secondoLancio = random.Next(1, 7);
int terzoLancio = random.Next(1, 7);
int quartoLancio = random.Next(1, 7);
int quintoLancio = random.Next(1, 7);
int extraLancio = random.Next(1, 7);

//int [] lanci = new int[6]  {primoLancio,secondoLancio,terzoLancio,quartoLancio, quintoLancio};

lanci.Add(primoLancio);
lanci.Add(secondoLancio);
lanci.Add(terzoLancio);
lanci.Add(quartoLancio);
lanci.Add(quintoLancio);


Console.WriteLine($"Primo Lancio: {primoLancio}");
Console.WriteLine($"secondo Lancio: {secondoLancio}");
Console.WriteLine($"terzo Lancio: {terzoLancio}");
Console.WriteLine($"quarto Lancio: {quartoLancio}");
Console.WriteLine($"quinto Lancio: {quintoLancio}");

for(int i = 0;i <= lanci.Count;i++){
    if(primoLancio==secondoLancio){

        score= score+1;
    }else if(secondoLancio == terzoLancio ){
        score= score+1;
    }else if(terzoLancio == quartoLancio){
        score= score+1;
    }else if(quartoLancio == quintoLancio){
        score= score+1;
    }else{
        Console.WriteLine($"Lo score è {score}");
    } 
    Console.WriteLine($"Hai fatto {score} punti");
}
    
   /*  || secondoLancio == terzoLancio || terzoLancio == quartoLancio || quartoLancio == quintoLancio){
      score++;  

    }else if(false){
        lanci.Add(extraLancio);
        Console.Write("extralancio");
    }
    }*/






//Console.WriteLine("Quale dado vuoi rilanciare scegli tra 1-2-3-4-5?se premi 6 esci");

/*

int scelta = Convert.ToInt32(Console.ReadLine());

switch(scelta){

    case 1:
    
    primoLancio;
    break;

    case 2:

    secondoLancio;
    break;

    case 3:

    terzoLancio;
    break;

    case 4:

    quartoLancio;
    break;

    case 5:

    quintoLancio;
    break;

    case 6:
    prosecuzione = false;
    Console.WriteLine("Stai uscendo dall'app...");
    break;

    default:

    Console.WriteLine("Ritenta");
    break;


}



*/