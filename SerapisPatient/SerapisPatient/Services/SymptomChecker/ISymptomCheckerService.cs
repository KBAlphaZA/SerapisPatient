using SerapisPatient.Models.SymptomsChecker;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Services.SymptomChecker
{
    public interface ISymptomCheckerService
    {
         List<Symptoms> GetAllSymptoms();
         List<Symptoms> GetAllSymptomsMock();
    }
}
