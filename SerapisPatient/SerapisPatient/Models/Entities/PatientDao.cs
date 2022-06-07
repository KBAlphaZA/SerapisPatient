using Realms;
using SerapisPatient.Enum;
using System;

namespace SerapisPatient.Models.Entities
{
    public class PatientDao : RealmObject
    {
        [PrimaryKey]
        public string id { get; set; }
        public string AuthId { get; set; }
        public string PatientFirstName { get; set; }

        public string PatientLastName { get; set; }

        public bool MedicalAidPatient { get; set; }

        public string PatientBloodType { get; set; }

        public int PatientAge { get; set; }

        public string PatientProfilePicture { get; set; }

        public string Gender { get; set; } = Genders.other.ToString();
        public DateTimeOffset BirthDate { get; set; }

        public bool IsAuthenticated { get; set; }
        public string RefreshToken { get; set; }
        public string AuthenticationExpiresIn { get; set; }


    }
}
