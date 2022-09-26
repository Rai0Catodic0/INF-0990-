namespace proj;
using Newtonsoft.Json;
public class Serializer
{   
    public Serializer() {
       Product product = new Product();
       product.Name = "Apple";
       product.ExpiryDate = new DateTime(2008, 12, 28);
       product.Price = 3.99M;
       product.Sizes = new string[] { "Small", "Medium", "Large" };
       string output = JsonConvert.SerializeObject(product,Formatting.Indented);
       Console.WriteLine(output);
       Product? deserializedProduct = JsonConvert.DeserializeObject<Product>(output);
       Console.WriteLine("Product: "+deserializedProduct);
    }
}

class Product {
    public string? Name;
    public DateTime ExpiryDate;
    public decimal Price;
    public string[]? Sizes;

    public override string ToString() {
        string outvar = "Name: "+Name+" Expiry Date: "+ExpiryDate+" Price: "+Price+" Sizes: ";
        foreach (string s in Sizes) {
            outvar += s +" ";
        }
        return(outvar);
    }
}
class Program 
{
    static void Main(){
     Serializer s = new Serializer();
    t}
    static int FeetToInches(int Feet){
        int inches = Feet * 12;
        return inches;
    }

}