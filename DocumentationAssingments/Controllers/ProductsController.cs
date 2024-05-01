using DocumentationAssingments.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentationAssingments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Products> _products = new List<Products>
        {
            new Products
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

            }
        };
        #region GetAllProducts
        //Get Products :api/Products
        [HttpGet]
        public IEnumerable<Products> GetProducts()
        {
            return _products;
        }
        #endregion
        #region Get Product By id
        //GET:api/Products/{id}
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        #endregion
        #region Create a Product
        //post:api/products
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Products products)
        {
            if (ModelState.IsValid)
            {
                products.ProductId = _products.Count + 1;
                _products.Add(products);
                return Ok(products);
            }
            return BadRequest(ModelState);
        }
        #endregion
        #region Delete Patients
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var products = _products.FirstOrDefault(p => p.ProductId == id);
            if (products == null)
            {
                return NotFound();
            }

            _products.Remove(products);
            return Ok(products);
        }
        #endregion
        #region Edit Patients
        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, [FromBody] Products updatedProducts)
        {
            var products = _products.FirstOrDefault(p => p.ProductId == id);
            if (products == null)
            {
                return NotFound();
            }
            products.ProductName = updatedProducts.ProductName;
            products.brand = updatedProducts.brand;
            products.Catogary = updatedProducts.Catogary;
            products.ModelYear = updatedProducts.ModelYear;
            products.ListPrice = updatedProducts.ListPrice;
            return Ok(products);
        }
        #endregion
    }
}
