﻿using Realms;

namespace SerapisPatient.Models
{
    public class PatientContact : RealmObject
    {
        public string CellphoneNumber { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }
    }
}
