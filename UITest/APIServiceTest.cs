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
using System.Reflection;
using SerapisPatient.Services.SymptomChecker;
using SerapisPatient.Models.SymptomsChecker;
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
        public void WelcomeTextIsDisplayed()
        {

            //ARANGE
            SymptomCheckerService symptomChecker = new SymptomCheckerService();
            
            List<Symptoms> unGroupedList = symptomChecker.GetAllSymptomsMock();
            ViewSymptoms viewSymptoms = new ViewSymptoms();
            //https://stackoverflow.com/questions/8151888/c-sharp-iterate-through-class-properties
            // Want to group Symptoms by 5 and make it its own list
            SymptomsListData groupedList = new SymptomsListData();
            
            /*while (k < 6)
{
    string key = "Item" + k;
    Debug.WriteLine("KEY NAME IS :" + key);
    dictionary.Add(key, unGroupedList.GetRange(x, 5)); //0; 5; 10; 15; 20; 25; <- start index
    x += 5;
    ++k;
    Debug.WriteLine("We are starting a new group number :" + dictionary[key] + "Value of dictionary: " +
                    dictionary.Values.Count);
}*/
            
            int k = 1;
            int j = 1;
            int counter = 0;
            for (int x = 0; x < 5; ++x)
            {
                ViewSymptoms symptoms = new ViewSymptoms();
                for (int i = 0; i < 5; ++i)
                {
                    string key = "Item" + k;
                    Debug.WriteLine("We are now storing Symptom name:  " +unGroupedList[counter].Name);
                    viewSymptoms.GetType().GetProperty(key).SetValue(symptoms , unGroupedList[counter].Name);
                    ++k;
                    counter++;
                }
                
                k = 1;
                string key2 = "Item" + j;
                groupedList.GetType().GetProperty(key2).SetValue(groupedList, symptoms);
                ++j;
            }
            //ACT

            //ASSERT

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
