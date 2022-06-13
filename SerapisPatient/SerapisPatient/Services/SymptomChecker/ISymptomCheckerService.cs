using SerapisPatient.Models.SymptomsChecker;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerapisPatient.Services.SymptomChecker
{
    public interface ISymptomCheckerService
    {
        Task<List<Symptoms>> GetAllSymptoms();
        List<Symptoms> GetAllSymptomsMock();
        Task<List<Symptoms>> GetProposedSymptoms(string ids, string year, string gender);
    }
}
