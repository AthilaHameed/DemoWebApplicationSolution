using System.Net;
using System.Reflection;
using DemoPatients.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoPatients.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        // dummy Data
        private static readonly List<Patients> _patients = new List<Patients>
        {
             new Patients { PatientId = 1,PatientName="Dhoni",DateOfBirth=Convert.ToDateTime("23/08/2000"),Gender="Male",PhoneNumber="9629367479",Address="Nagercoil"},
             new Patients { PatientId = 2,PatientName="Sachin",DateOfBirth=Convert.ToDateTime("24/08/2000"),Gender="Male",PhoneNumber="9629367478",Address="Kottar"}
        };
        #region GetAllProducts
        //Get Products :api/Products
        [HttpGet]
        public IEnumerable<Patients> GetProducts()
        {
            return _patients;
        }
        #endregion
        #region Get Product By id
        //GET:api/Products/{id}
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _patients.FirstOrDefault(p => p.PatientId == id);
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
        public IActionResult CreateProduct([FromBody] Patients patients)
        {
            if (ModelState.IsValid)
            {
                patients.PatientId = _patients.Count + 1;
                _patients.Add(patients);
                return Ok(patients);
            }
            return BadRequest(ModelState);
        }
        #endregion
        #region Delete Patients
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var patient = _patients.FirstOrDefault(p => p.PatientId == id);
            if (patient == null)
            {
                return NotFound();
            }

            _patients.Remove(patient);
            return Ok(patient);
        }
        #endregion
        #region Edit Patients
        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, [FromBody] Patients updatedPatient)
        {
            var patient = _patients.FirstOrDefault(p => p.PatientId == id);
            if (patient == null)
            {
                return NotFound();
            }
            patient.PatientName = updatedPatient.PatientName;
            patient.DateOfBirth = updatedPatient.DateOfBirth;
            patient.Gender = updatedPatient.Gender;
            patient.PhoneNumber = updatedPatient.PhoneNumber;
            patient.Address = updatedPatient.Address;
            return Ok(patient);
        }
        #endregion
    }

}



