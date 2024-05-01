using DocumentationAssingments.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentationAssingments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        //dummy Data
        // dummy Data
        private static readonly List<Catogaries> _catagories = new List<Catogaries>
        {
             new  Catogaries{ Category_id = 1,Category_name="Beauty"}

        };
        #region GetAllProducts
        //Get Products :api/Products
        [HttpGet]
        public IEnumerable<Catogaries> GetProducts()
        {
            return _catagories;
        }
        #endregion
        #region Get Product By id
        //GET:api/Products/{id}
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var catogories = _catagories.FirstOrDefault(p => p.Category_id == id);
            if (catogories == null)
            {
                return NotFound();
            }
            return Ok(catogories);
        }
        #endregion
        #region Create a Product
        //post:api/products
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Catogaries catogaries)
        {
            if (ModelState.IsValid)
            {
                catogaries.Category_id = _catagories.Count + 1;
                _catagories.Add(catogaries);
                return Ok(catogaries);
            }
            return BadRequest(ModelState);
        }
        #endregion
        #region Delete Patients
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var catogaries = _catagories.FirstOrDefault(p => p.Category_id == id);
            if (catogaries == null)
            {
                return NotFound();
            }

            _catagories.Remove(catogaries);
            return Ok(catogaries);
        }
        #endregion
        #region Edit Patients
        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, [FromBody] Catogaries updatedCatogaries)
        {
            var catogaries = _catagories.FirstOrDefault(p => p.Category_id == id);
            if (catogaries == null)
            {
                return NotFound();
            }
            catogaries.Category_name = updatedCatogaries.Category_name;
            
            return Ok(catogaries);
        }
        #endregion
    }
}
