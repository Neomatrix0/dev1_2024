using Microsoft.EntityFrameworkCore;

 class Product{
    public int ProductId{get; set;}
    public string Name{get;set;}
     public  Quantity Quantity{get;set;}

     public Category Category{get;set;}
     public int CategoryId { get; set; } // Chiave esterna per Category


  
}