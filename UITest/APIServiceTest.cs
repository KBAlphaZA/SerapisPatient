using NUnit.Framework;
using SerapisPatient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerapisPatient.Services.Data;
using System.Diagnostics;
using System.Reflection;
using SerapisPatient.Enum;
using SerapisPatient.Services.SymptomChecker;
using SerapisPatient.Models.SymptomsChecker;
using SerapisPatient.Models.SymptomsChecker.Diagnosis;
using SerapisPatient.Utils;
using SerapisPatient.ViewModels.SymptomsCheckerViewModel;

namespace UITest
{
    public class APIServiceTest
    {
        public APIServiceTest()
        {

        }
        [Test]
        public async Task WelcomeTextIsDisplayed()
        {
            SymptomCheckerService symptomChecker = new SymptomCheckerService();
            Dictionary<String, object> CacheData = new Dictionary<string, object>();
            List<DiagnosisResponse> listOfDiagnosis = new List<DiagnosisResponse>();
                
                listOfDiagnosis.AddRange((IEnumerable<DiagnosisResponse>)await symptomChecker.GetProposedSymptomsMock("80"));
                
            
           // var output = ViewModelHelper.HandleCachingListObject(CacheData,CacheKeys.SelectedSymptomsData.ToString(),item);
            //Debug.WriteLine(output);
        }
        [Test]
        public async Task SymptomsTestAsync()
        {
           /* //ARANGE
            GoogleUser googleUser = new GoogleUser();
            googleUser.Id = "1292910";
            googleUser.Name = "Bonga";
            googleUser.FamilyName = "Ngcobo";

            //ACT

            var result = ;//await AuthenticationService.GoogleLogin(googleUser, "");

            //ASSERT
            Assert.AreEqual(result, result);
*/
        }

        [Test]
        public async Task SearchTest()
        {
            //ARANGE
            string queryText = "Ble";
            SymptomCheckerService symptomChecker = new SymptomCheckerService();
            Debug.WriteLine("Query string:   " + queryText);
            //ACT
            List<Symptoms> templist = new List<Symptoms>();
            List <Symptoms> ListOfSymptoms = symptomChecker.GetAllSymptomsMock();
            Debug.WriteLine("List length :  " + ListOfSymptoms.Count);
            Stopwatch timer = new Stopwatch();
            timer.Start();
            foreach(var symptom in ListOfSymptoms)
            {
                if (symptom.Name.ToLower().Contains(queryText.ToLower()))
                {
                    Debug.WriteLine("This text " + symptom.Name + "contains  " + queryText);
                    templist.Add(symptom);
                }
            }
            timer.Stop();
            Debug.WriteLine("Final Time: "+timer.ElapsedMilliseconds+"ms");
            foreach (var k in templist)
            {
                Debug.WriteLine("Final list:  "+k.Name);
            }            
            
            //ASSERT
            Assert.AreEqual("", "");

        }

    }
}
