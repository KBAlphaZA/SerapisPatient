using MongoDB.Bson;

namespace SerapisPatient.Models.Delivery
{
    public class ChatBotPrescription:Prescription
    {
         public ObjectId Id { get; set; }
    }
}
