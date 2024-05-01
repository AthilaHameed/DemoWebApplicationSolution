namespace DocumentationAssingments.Models
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ModelYear { get; set; }
        public decimal ListPrice {  get; set; }
        public Catogaries Catogary { get; set; }
        public Brand brand { get; set; }
    }
}
