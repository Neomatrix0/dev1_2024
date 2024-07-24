// Confronto tra date

DateTime date1 = DateTime.Today;
DateTime date2 = new DateTime(2024, 12, 31);

int result = DateTime.Compare(date1,date2);
if(result < 0){
    Console.WriteLine("La prima data è prima della seconda");

}else if(result == 0){
Console.WriteLine("Le date sono uguali");}

else{
Console.WriteLine("La prima data è dopo la seconda");
}



