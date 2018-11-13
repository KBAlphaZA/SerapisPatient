using MongoDB.Bson;
using SerapisPatient.Models.Doctor;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models.Delivery
{
    public class ChatBotPrescription:Prescription
    {
         public ObjectId Id { get; set; }
    }
}
