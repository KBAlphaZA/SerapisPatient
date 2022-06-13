using Realms;

namespace SerapisPatient.Models.MedicalDetails
{
    public class Allergies : RealmObject
    {
        public string Id { get; set; }
        public string AllergyName { get; set; }
    }
}
