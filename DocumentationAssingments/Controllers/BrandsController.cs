using DocumentationAssingments.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentationAssingments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        // dummy Data
        private static readonly List<Brand> _Brands = new List<Brand>
        {
             new Brand { BrandId = 1,BrandName="Lakme"}
            
        };
        #region GetAllProducts
        //Get Products :api/Products
        [HttpGet]
        public IEnumerable<Brand> GetProducts()
        {
            return _Brands;
        }
        #endregion
        #region Get Product By id
        //GET:api/Products/{id}
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var brands = _Brands.FirstOrDefault(p => p.BrandId == id);
            if (brands == null)
            {
                return NotFound();
            }
            return Ok(brands);
        }
        #endregion
        #region Create a Product
        //post:api/products
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Brand brands)
        {
            if (ModelState.IsValid)
            {
                brands.BrandId = _Brands.Count + 1;
                _Brands.Add(brands);
                return Ok(brands);
            }
            return BadRequest(ModelState);
        }
        #endregion
        #region Delete Patients
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var brands = _Brands.FirstOrDefault(p => p.BrandId == id);
            if (brands == null)
            {
                return NotFound();
            }

            _Brands.Remove(brands);
            return Ok(brands);
        }
        #endregion
        #region Edit Patients
        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, [FromBody] Brand updatedBrand)
        {
            var brands = _Brands.FirstOrDefault(p => p.BrandId == id);
            if (brands == null)
            {
                return NotFound();
            }
            brands.BrandName = updatedBrand.BrandName;          
            return Ok(brands);
        }
        #endregion
    }
}
