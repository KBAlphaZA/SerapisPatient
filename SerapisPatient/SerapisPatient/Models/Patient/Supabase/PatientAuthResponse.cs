namespace SerapisPatient.Models.Patient.Supabase
{
    public class PatientAuthResponse
    {
        public Patient PatientData { get; set; }
        public Session SupabaseData { get; set; }
        public string Otp { get; set; }
    }
}
