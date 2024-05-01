namespace DocumentationAssingments.Models
{
    public class Stock
    {
        public int Quantity {  get; set; }
        public Stores stores { get; set; }
        public Products products { get; set; }
    }
}
