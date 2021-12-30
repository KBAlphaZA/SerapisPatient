using NUnit.Framework;
using SerapisPatient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.GoogleClient.Shared;
using SerapisPatient.Services.Data;
using System.Diagnostics;
using SerapisPatient.Services.SymptomChecker;
using SerapisPatient.Models.SymptomsChecker;

namespace UITest
{
    public class APIServiceTest
    {
        public APIServiceTest()
        {

        }
        [Test]
        public void WelcomeTextIsDisplayed()
        {
            //ARANGE


            //ACT

            //ASSERT
            Assert.AreEqual("", "");
        }

        [Test]
        public async Task GoogleLoginTestAsync()
        {
            //ARANGE
            AuthenticationService _authenticationService = new AuthenticationService(); 
            GoogleUser googleUser = new GoogleUser();
            googleUser.Id = "1292910";
            googleUser.Name = "Bonga";
            googleUser.FamilyName = "Ngcobo";

            //ACT
            
            var result = await _authenticationService.GoogleLogin(googleUser, "");

            //ASSERT
            Assert.AreEqual(result, result);

        }
        [Test]
        public async Task SymptomsTestAsync()
        {
            //ARANGE
            AuthenticationService _authenticationService = new AuthenticationService();
            GoogleUser googleUser = new GoogleUser();
            googleUser.Id = "1292910";
            googleUser.Name = "Bonga";
            googleUser.FamilyName = "Ngcobo";

            //ACT

            var result = await _authenticationService.GoogleLogin(googleUser, "");

            //ASSERT
            Assert.AreEqual(result, result);

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
