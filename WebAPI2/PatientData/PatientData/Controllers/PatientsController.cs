using MongoDB.Bson;
using MongoDB.Driver;
using PatientData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PatientData.Controllers
{
    public class PatientsController : ApiController 
    { 
        IMongoCollection<Patient> _patients;

        public PatientsController()
        {
            _patients = PatientDb.Open();
        }
        public async Task<IEnumerable<Patient>> Get()
        {
            return await _patients.Find(_ => true).ToListAsync();
        }

        [Route("api/patients/{id}")]
        public IHttpActionResult Get(string id)
        {
            var filter = Builders<Patient>.Filter.Eq("_id", ObjectId.Parse(id));
            Patient patient = _patients.Find(filter).First();
            if(patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [Route("api/patients/{id}/medications")]
        public IHttpActionResult GetMedications(string id)
        {
            var filter = Builders<Patient>.Filter.Eq("_id", ObjectId.Parse(id));
            Patient patient = _patients.Find(filter).First();

            if(patient == null)
            {
                return NotFound();
            }

            return Ok(patient.Medications);
        }
    }
}
