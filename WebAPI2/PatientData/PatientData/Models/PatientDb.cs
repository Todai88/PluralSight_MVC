using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientData.Models
{
    public static class PatientDb
    {
        public static IMongoCollection<Patient> Open()
        {
            var client = new MongoClient("mongodb://localhost"); 
            var db = client.GetDatabase("PatientDb");
            return db.GetCollection<Patient>("Patients");
        }

        public static void Drop()
        {
            var client = new MongoClient("mongodb://localhost");
            var db = client.GetDatabase("PatientDb");
            db.DropCollection("Patients");
        }

    }
}
