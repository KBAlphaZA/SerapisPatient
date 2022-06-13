using SerapisPatient.Utils;

namespace SerapisPatient.Models.SymptomsChecker
{
    public class Symptoms
    {
        public string ID { get; set; }

        //Using this as a placeholder image
        public string Icon { get; private set; } = FieldsOfExpertise.audiologyIcon;

        public string Name { get; set; }

        public bool IsChecked { get; set; } = false;
    }
}
