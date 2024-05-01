namespace DocumentationAssingments.Models
{
    public class Order_Item
    {
        public int ItemId { get; set; }
       
        public int Quantity { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Discount {  get; set; }
        public Products products { get; set; }
        public Order order { get; set; }

    }
}
