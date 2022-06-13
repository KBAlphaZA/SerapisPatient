namespace SerapisPatient.Services.DependencyServices
{
    public interface IMedicationReminder
    {
        void SetReminder(string medicationInstructions, string medicationDosage);
    }
}
