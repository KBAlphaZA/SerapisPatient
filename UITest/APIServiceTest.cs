using NUnit.Framework;
using SerapisPatient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.GoogleClient.Shared;
using SerapisPatient.Services.Data;

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

    }
}
