using DocumentationAssingments.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentationAssingments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Order_itemsController : ControllerBase
    {
        // dummy Data
        private static readonly List<Order_Item> _order_items = new List<Order_Item>
        {
            new Order_Item
            {
                ItemId=1,
                products = new Products
                {
                    ProductId=1,
                    ProductName ="Sunscreen",
                brand = new Brand
                {
                    BrandId =1,
                    BrandName ="Lakme"
                },
                Catogary =new Catogaries
                {
                    Category_id=1,
                    Category_name="Cosmetics"
                },
                ModelYear ="2022",
                ListPrice =250

                },
                Quantity =12,
                ListPrice=56,
                Discount=12,
                order= new Order
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
                

            }
        };
        #region GetAllProducts
        //Get Products :api/Products
        [HttpGet]
        public IEnumerable<Order_Item> GetProducts()
        {
            return _order_items;
        }
        #endregion
        #region Get Product By id
        //GET:api/Products/{id}
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var orederitem = _order_items.FirstOrDefault(p => p.ItemId == id);
            if (orederitem == null)
            {
                return NotFound();
            }
            return Ok(orederitem);
        }
        #endregion
        #region Create a Product
        //post:api/products
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Order_Item orderitem)
        {
            if (ModelState.IsValid)
            {
                orderitem.ItemId = _order_items.Count + 1;
                _order_items.Add(orderitem);
                return Ok(orderitem);
            }
            return BadRequest(ModelState);
        }
        #endregion
        #region Delete Patients
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var orderitems = _order_items.FirstOrDefault(p => p.ItemId == id);
            if (orderitems == null)
            {
                return NotFound();
            }

            _order_items.Remove(orderitems);
            return Ok(orderitems);
        }
        #endregion
        #region Edit Patients
        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, [FromBody] Order_Item updatedorderitem)
        {
            var orederitem = _order_items.FirstOrDefault(p => p.ItemId == id);
            if (orederitem == null)
            {
                return NotFound();
            }
            orederitem.products = updatedorderitem.products;
            orederitem.Quantity = updatedorderitem.Quantity;
            orederitem.ListPrice = updatedorderitem.ListPrice;
            orederitem.Discount = updatedorderitem.Discount;
            orederitem.order = updatedorderitem.order;
            return Ok(orederitem);
        }
        #endregion
    }
}
