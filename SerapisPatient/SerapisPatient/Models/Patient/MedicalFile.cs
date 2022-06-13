using MongoDB.Bson;
using Realms;

namespace SerapisPatient.Models
{
    public class MedicalFile : RealmObject
    {
        public ObjectId Id { get; set; }
        public string File { get; set; }
        public string DateCreated { get; set; }
        public string TimeCreated { get; set; }
        public string TypeOfFile { get; set; }
    }
}
