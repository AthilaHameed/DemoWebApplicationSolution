namespace DocumentationAssingments.Models
{
    public class Staffs
    {
       public int StaffsId { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string Phone { get; set; }
        public string Email { get; set; }
        public string Active { get; set; }
        public int Managerid { get; set; }
        public Stores stores { get; set; }

    }
}
