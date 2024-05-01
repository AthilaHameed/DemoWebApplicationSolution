using System.IO;
using System.Numerics;
using System.Reflection.Emit;
using DocumentationAssingments.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentationAssingments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private static readonly List<Customer> _customer = new List<Customer>
        {
            new Customer
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
            }
        };
        #region GetAllProducts
        //Get Products :api/Products
        [HttpGet]
        public IEnumerable<Customer> GetProducts()
        {
            return _customer;
        }
        #endregion
        #region Get Product By id
        //GET:api/Products/{id}
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var customer = _customer.FirstOrDefault(p => p.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        #endregion
        #region Create a Product
        //post:api/products
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.CustomerId = _customer.Count + 1;
                _customer.Add(customer);
                return Ok(customer);
            }
            return BadRequest(ModelState);
        }
        #endregion
        #region Delete Patients
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var customer = _customer.FirstOrDefault(p => p.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            _customer.Remove(customer);
            return Ok(customer);
        }
        #endregion
        #region Edit Patients
        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, [FromBody] Customer updatedCustomer)
        {
            var customer = _customer.FirstOrDefault(p => p.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }
            customer.FirstName = updatedCustomer.FirstName;
            customer.LastName = updatedCustomer.LastName;
            customer.Phone = updatedCustomer.Phone;
            customer.Email = updatedCustomer.Email;
            customer.Street = updatedCustomer.Street;
            customer.City = updatedCustomer.City;
            customer.State = updatedCustomer.State;
            customer.zipcode = updatedCustomer.zipcode;

            return Ok(customer);
        }
        #endregion
    }
}
