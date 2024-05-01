namespace DocumentationAssingments.Models
{
    public class Order
    {
        public int Orderid {  get; set; }
        public string Order_status { get; set; }
        public string Order_date { get; set;}
        public string Required_data {  get; set; }
        public string Shipped_date { get; set; }
        public Staffs staffs { get; set; }
        public Stores stores { get; set; }
        public Customer customer { get; set; }

    }
}
