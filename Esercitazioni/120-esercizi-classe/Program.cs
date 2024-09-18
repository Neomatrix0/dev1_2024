class Program{
    static void Main(string[] args){
        Dado d1 = new Dado(6);
        d1.SetFacce(2);


    int facce = d1.GetFacce();

        
         Console.WriteLine($"Numero facce : {facce}");

          d1.SetFacce(5);
          facce = d1.GetFacce();
           Console.WriteLine($"Nuovo numero facce : {facce}");
     

    }
}