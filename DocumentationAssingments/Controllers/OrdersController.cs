using DocumentationAssingments.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentationAssingments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private static readonly List<Order> _orders = new List<Order>
        {
            new Order
            {
                Orderid=1,
                customer= new Customer
                {
                    CustomerId =1,
                FirstName ="Athila",
                LastName="Hameed",
                Phone="9629367479",
                Email="adhilaazeeza23@gmail.com",
                Street="Pon street",
                City="Nagercoil",
                State="TamilNadu",
                zipcode=629002
                },
                Order_status="Pending",
                Order_date="23/08/2024",
                Required_data="29/08/2024",
                Shipped_date="13/08/2024",
                stores= new Stores
                {
                    StoreId =1,
                StoreName="MGK",
                Phone="8056603485",
                Email="beni24@gmail.com",
                Street="ISED",
                City="Nagercoil",
                State="TamilNadu",
                ZipCode=629003
                },
                staffs=new Staffs
                {
                     StaffsId=1,
                FirstName ="Beni",
                LastName="Josh",
                Phone ="9898877898",
                Email="beni25@gmail.com",
                Active="True",
                Managerid=2,                
                stores= new Stores
                {
                    StoreId =1,
                StoreName="MGK",
                Phone="8056603485",
                Email="beni24@gmail.com",
                Street="ISED",
                City="Nagercoil",
                State="TamilNadu",
                ZipCode=629003
                }
                }
            }
        };


    }
}
