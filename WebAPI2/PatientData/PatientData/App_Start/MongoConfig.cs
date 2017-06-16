using MongoDB.Driver;
using PatientData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientData.App_Start
{
    public static class MongoConfig
    {
        public static void Seed()
        {
            //PatientDb.Drop();
            var patients = PatientDb.Open();

            if(!patients.AsQueryable().Any(p => p.Name == "Scott"))
            {
                var data = new List<Patient>()
                {
                    new Patient {
                    Name = "Scott",
                    Ailments = new List<Ailment>() { new Ailment { Name = "Crazy" }, new Ailment { Name = "Aids" } },
                    Medications = new List<Medication>() { new Medication { Name = "Ibuprofen"} }
                    },
                    new Patient
                    {
                        Name = "Joakim",
                        Ailments = new List<Ailment>() { new Ailment { Name = "Nothing, too cool" } },
                        Medications = null
                    },
                    new Patient
                    {
                        Name = "Bethany",
                        Ailments = new List<Ailment>() { new Ailment { Name = "Tooth ache" } },
                        Medications = new List<Medication>() { new Medication { Name = "Antibiotics" } }
                    }
                };
                patients.InsertMany(data);
            }
        }
    }
}
