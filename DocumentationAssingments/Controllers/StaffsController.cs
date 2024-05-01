using System;
using System.Numerics;
using DocumentationAssingments.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentationAssingments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        //dummy data 
        private static readonly List<Staffs> _staff = new List<Staffs>
        {
            new Staffs
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
        };
        #region GetAllProducts
        //Get Products :api/Products
        [HttpGet]
        public IEnumerable<Staffs> GetProducts()
        {
            return _staff;
        }
        #endregion
        #region Get Product By id
        //GET:api/Products/{id}
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var staffs = _staff.FirstOrDefault(p => p.StaffsId == id);
            if (staffs == null)
            {
                return NotFound();
            }
            return Ok(staffs);
        }
        #endregion
        #region Create a Product
        //post:api/products
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Staffs staff)
        {
            if (ModelState.IsValid)
            {
                staff.StaffsId = _staff.Count + 1;
                _staff.Add(staff);
                return Ok(staff);
            }
            return BadRequest(ModelState);
        }
        #endregion
        #region Delete Patients
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var staff = _staff.FirstOrDefault(p => p.StaffsId == id);
            if (staff == null)
            {
                return NotFound();
            }

            _staff.Remove(staff);
            return Ok(staff);
        }
        #endregion
        #region Edit Patients
        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, [FromBody] Staffs updatedstaff)
        {
            var staff = _staff.FirstOrDefault(p => p.StaffsId == id);
            if (staff == null)
            {
                return NotFound();
            }
            staff.FirstName = updatedstaff.FirstName;
            staff.LastName = updatedstaff.LastName;
            staff.Phone = updatedstaff.Phone;
            staff.Email = updatedstaff.Email;
            staff.Active = updatedstaff.Active;
            staff.staffs = updatedstaff.staffs;
            staff.stores = updatedstaff.stores;
            return Ok(staff);
        }
        #endregion
    }
}
