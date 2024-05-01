using System.IO;
using System.Numerics;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using DocumentationAssingments.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentationAssingments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        //dummy data
        private static readonly List<Stores> _stores = new List<Stores>
        {
            new Stores
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
        };
        #region GetAllProducts
        //Get Products :api/Products
        [HttpGet]
        public IEnumerable<Stores> GetProducts()
        {
            return _stores;
        }
        #endregion
        #region Get Product By id
        //GET:api/Products/{id}
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var stores = _stores.FirstOrDefault(p => p.StoreId == id);
            if (stores == null)
            {
                return NotFound();
            }
            return Ok(stores);
        }
        #endregion
        #region Create a Product
        //post:api/products
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Stores stores)
        {
            if (ModelState.IsValid)
            {
                stores.StoreId = _stores.Count + 1;
                _stores.Add(stores);
                return Ok(stores);
            }
            return BadRequest(ModelState);
        }
        #endregion
        #region Delete Patients
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var stores = _stores.FirstOrDefault(p => p.StoreId == id);
            if (stores == null)
            {
                return NotFound();
            }

            _stores.Remove(stores);
            return Ok(stores);
        }
        #endregion
        #region Edit Patients
        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, [FromBody] Stores updatedStores)
        {
            var stores = _stores.FirstOrDefault(p => p.StoreId == id);
            if (stores == null)
            {
                return NotFound();
            }
            stores.StoreName = updatedStores.StoreName;
            stores.Phone = updatedStores.Phone;
            stores.Email = updatedStores.Email;
            stores.Street = updatedStores.Street;
            stores.City = updatedStores.City;
            stores.State = updatedStores.State;
            stores.ZipCode = updatedStores.ZipCode;
            return Ok(stores);
        }
        #endregion

    }
}
