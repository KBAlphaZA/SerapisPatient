using SerapisPatient.Models.Doctor;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models.Delivery
{
    public class Prescription
    {
        public bool IsDoctorPrescription { get; set; }
        public string Issuer { get; set; }
        public string DatePrescribed { get; set; }
        public string TimePrescribed { get; set; }
        public string DeliveryTime { get; set; }
        public string DateDelivered { get; set; }
        public Location PlaceDelivered { get; set; }
        public string MedicationName { get; set; }
        public string MedicationDosage { get; set; }
        public string MedicationInstructions { get; set; }
        public string MedicationAddedNotes { get; set; }
        public TypeOfMedication MedicationType { get; set; }
        public int Price { get; internal set; }
    }
}
