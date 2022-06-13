using SerapisPatient.Models.SymptomsChecker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using MongoDB.Bson;
using Newtonsoft.Json;
using SerapisPatient.Models.SymptomsChecker.Diagnosis;

namespace SerapisPatient.Services.SymptomChecker
{
    public class SymptomCheckerService : ISymptomCheckerService
    {
        //private string APIURL = "https://serapismedicalapi.herokuapp.com/api";
        //private string APIURL = App.APIURL;

        public async Task<List<Symptoms>> GetAllSymptoms()
        {
            using (HttpClient _httpClient = new HttpClient())
            {
                string api = $"{App.APIURL}/SymptomChecker/v1/symptoms";
                //Getting JSON data from the WebAPI
                var content = await _httpClient.GetStringAsync(api);
                //We deserialize the JSON data from this line
                var result = JsonConvert.DeserializeObject<List<Symptoms>>(content);
                Debug.WriteLine(" Booking Creation Response =>[" + result.ToJson() + "]");
                return result;
            }
        }

        public async Task<List<Symptoms>> GetProposedSymptoms(string ids, string year, string gender)
        {
            using (HttpClient _httpClient = new HttpClient())
            {
                string api = $"{App.APIURL}/SymptomChecker/v1/proposed-symptoms?id={ids}&age={year}&sex={gender}";
                //tring api = $"{APIURL}/SymptomChecker/v1/diagnosis-by-symptoms/{id}";
                //Getting JSON data from the WebAPI
                var content = await _httpClient.GetStringAsync(api);
                //We deserialize the JSON data from this line
                var result = JsonConvert.DeserializeObject<List<Symptoms>>(content);
                Debug.WriteLine(" Booking Creation Response =>[" + result.ToJson() + "]");
                return result;
            }
        }

        public async Task<List<DiagnosisResponse>> GetProposedDiagnosisResponse(string ids, string year, string gender)
        {
            using (HttpClient _httpClient = new HttpClient())
            {
                string api = $"{App.APIURL}/SymptomChecker/v1/proposed-symptoms?id={ids}&age={year}&sex={gender}";
                //tring api = $"{APIURL}/SymptomChecker/v1/diagnosis-by-symptoms/{id}";
                //Getting JSON data from the WebAPI
                var content = await _httpClient.GetStringAsync(api);
                //We deserialize the JSON data from this line
                var result = JsonConvert.DeserializeObject<List<DiagnosisResponse>>(content);
                Debug.WriteLine(" Booking Creation Response =>[" + result.ToJson() + "]");
                return result;
            }
        }

        public async Task<DiagnosisResponse> GetProposedSymptomsMock(string id)
        {
            var diagnosisResponses = new List<DiagnosisResponse>()
            {
                new DiagnosisResponse { Issue = new Issue(){ ID = 80,Name = "Cold", Accuracy = 90, Icd = "J00", Ranking = 1, ProfName = "Common cold", IcdName = "Acute nasopharyngitis [common cold]"},
                    Specialisation = new List<Specialisation>(){ new Specialisation() { ID = 15, Name = "General practice", SpecialistID = 3}}},
                new DiagnosisResponse { Issue = new Issue(){ ID = 11, Name = "Flu", Accuracy = 65.390625,Icd ="J10;J11", IcdName = "Influenza due to other identified influenza virus;Influenza, virus not identified", Ranking = 2,ProfName = "Influenza"},
                    Specialisation = new List<Specialisation>(){ new Specialisation() { ID = 15,Name = "General Practice",SpecialistID =3 },new Specialisation() { ID = 19, Name = "Internal medicine",SpecialistID =4 }}},
                new DiagnosisResponse { Issue = new Issue(){ID = 83,Name = "Inflammation of the brain covering membranes", Accuracy = 45.4921, Icd = "G00;G01;G02;G03", Ranking = 3, ProfName = "Meningitis", IcdName = "Bacterial meningitis, not elsewhere classified;Meningitis in bacterial diseases classified elsewhere;Meningitis in other infectious and parasitic diseases classified elsewhere;Meningitis due to other and unspecified causes"},
                    Specialisation = new List<Specialisation>(){ new Specialisation()  { ID = 15,Name = "General Practice",SpecialistID =3 }, new Specialisation() { ID = 27, Name = "Neurology",SpecialistID =45 }}},
                new DiagnosisResponse { Issue = new Issue(){ ID = 80,Name = "Cold", Accuracy = 90, Icd = "J00", Ranking = 1, ProfName = "Common cold", IcdName = "Acute nasopharyngitis [common cold]"},
                    Specialisation = new List<Specialisation>(){ new Specialisation() { ID = 15, Name = "General practice", SpecialistID = 3}}},
                new DiagnosisResponse { Issue = new Issue(){ ID = 11, Name = "Flu", Accuracy = 65.390625,Icd ="J10;J11", IcdName = "Influenza due to other identified influenza virus;Influenza, virus not identified", Ranking = 2,ProfName = "Influenza"},
                    Specialisation = new List<Specialisation>(){ new Specialisation() { ID = 15, Name = "General Practice",SpecialistID =3 },new Specialisation() { ID = 19, Name = "Internal medicine",SpecialistID =4 }}},
                new DiagnosisResponse { Issue = new Issue(){ID = 83,Name = "Inflammation of the brain covering membranes", Accuracy = 45.4921, Icd = "G00;G01;G02;G03", Ranking = 3, ProfName = "Meningitis", IcdName = "Bacterial meningitis, not elsewhere classified;Meningitis in bacterial diseases classified elsewhere;Meningitis in other infectious and parasitic diseases classified elsewhere;Meningitis due to other and unspecified causes"},
                    Specialisation = new List<Specialisation>(){ new Specialisation()  { ID = 15, Name = "General Practice",SpecialistID =3 }, new Specialisation() { ID = 27, Name = "Neurology",SpecialistID =45 }}},

                
            };
            return diagnosisResponses[new Random().Next(0, 5)];
        }

        public List<Symptoms> GetAllSymptomsMock()
        {
            List<Symptoms> symptoms;

            symptoms = new List<Symptoms>()
            {
                new Symptoms {ID = "1", Name = "Back"},
                new Symptoms {ID = "2", Name = "Flu"},
                new Symptoms {ID = "3", Name = "Headache"},
                new Symptoms {ID = "4", Name = "Leg"},
                new Symptoms {ID = "5", Name = "Spine"},
                new Symptoms {ID = "6", Name = "Brain"},
                new Symptoms {ID = "7", Name = "Nose Bleed"},
                new Symptoms {ID = "8", Name = "Chest"},
                new Symptoms {ID = "9", Name = "Pain Breathing"},
                new Symptoms {ID = "10", Name = "Backache"},
                new Symptoms {ID = "10", Name = "Internal bleeding"},
                new Symptoms {ID = "1", Name = "Back"},
                new Symptoms {ID = "2", Name = "Flu"},
                new Symptoms {ID = "3", Name = "Headache"},
                new Symptoms {ID = "4", Name = "Leg"},
                new Symptoms {ID = "5", Name = "Spine"},
                new Symptoms {ID = "6", Name = "Brain"},
                new Symptoms {ID = "7", Name = "Nose Bleed"},
                new Symptoms {ID = "8", Name = "Chest"},
                new Symptoms {ID = "9", Name = "Pain Breathing"},
                new Symptoms {ID = "10", Name = "Backache"},
                new Symptoms {ID = "1", Name = "Back"},
                new Symptoms {ID = "2", Name = "Flu"},
                new Symptoms {ID = "3", Name = "Headache"},
                new Symptoms {ID = "4", Name = "Leg"},
                new Symptoms {ID = "5", Name = "Spine"},
                new Symptoms {ID = "6", Name = "Brain"},
                new Symptoms {ID = "7", Name = "Nose Bleed"},
                new Symptoms {ID = "8", Name = "Chest"},
                new Symptoms {ID = "9", Name = "Pain Breathing"},
                new Symptoms {ID = "1", Name = "Back"},
                new Symptoms {ID = "2", Name = "Flu"},
                new Symptoms {ID = "3", Name = "Headache"},
                new Symptoms {ID = "4", Name = "Leg"},
                new Symptoms {ID = "5", Name = "Spine"},
                new Symptoms {ID = "6", Name = "Brain"},
                new Symptoms {ID = "7", Name = "Nose Bleed"},
                new Symptoms {ID = "8", Name = "Chest"},
                new Symptoms {ID = "9", Name = "Pain Breathing"},
                new Symptoms {ID = "10", Name = "Backache"},
                new Symptoms {ID = "1", Name = "Back"},
                new Symptoms {ID = "2", Name = "Flu"},
                new Symptoms {ID = "3", Name = "Headache"},
                new Symptoms {ID = "4", Name = "Leg"},
                new Symptoms {ID = "5", Name = "Spine"},
                new Symptoms {ID = "6", Name = "Brain"},
                new Symptoms {ID = "7", Name = "Nose Bleed"},
                new Symptoms {ID = "8", Name = "Chest"},
                new Symptoms {ID = "3", Name = "Headache"},
                new Symptoms {ID = "4", Name = "Leg"},
                new Symptoms {ID = "5", Name = "Spine"},
                new Symptoms {ID = "6", Name = "Brain"},
                new Symptoms {ID = "7", Name = "Nose Bleed"},
                new Symptoms {ID = "8", Name = "Chest"},
                new Symptoms {ID = "9", Name = "Pain Breathing"},
                new Symptoms {ID = "1", Name = "Back"},
                new Symptoms {ID = "2", Name = "Flu"},
                new Symptoms {ID = "3", Name = "Headache"},
                new Symptoms {ID = "4", Name = "Leg"},
                new Symptoms {ID = "5", Name = "Spine"},
                new Symptoms {ID = "6", Name = "Brain"},
                new Symptoms {ID = "7", Name = "Nose Bleed"},
                new Symptoms {ID = "8", Name = "Chest"},
                new Symptoms {ID = "9", Name = "Pain Breathing"},
                new Symptoms {ID = "10", Name = "Backache"},
                new Symptoms {ID = "1", Name = "Back"},
                new Symptoms {ID = "2", Name = "Flu"},
                new Symptoms {ID = "3", Name = "Headache"},
                new Symptoms {ID = "4", Name = "Leg"},
                new Symptoms {ID = "5", Name = "Spine"},
                new Symptoms {ID = "6", Name = "Brain"},
                new Symptoms {ID = "7", Name = "Nose Bleed"},
                new Symptoms {ID = "8", Name = "Chest"},
            };

            return symptoms;
        }
    }
}