using System.Threading.Tasks;

namespace SerapisPatient.Models
{
    public class PatientActions
    {
        public int ID { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Task NavigationDeepLink { get; set; }
        public bool IsEnabled { get; set; }
        public string LowestVersionEnabled { get; set; }
    }
}