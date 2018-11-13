using MongoDB.Bson;
using SerapisPatient.Models.Delivery;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models.Doctor
{
    public class DoctorPrescription:Prescription
    {
        public Doctor PrescribingDoctor { get; set; }
        public ObjectId MedicationId { get; set; }
        
    }

}
