using System;
using System.Collections.Generic;
using System.Diagnostics;
using SerapisPatient.Enum;
using SerapisPatient.Models.SymptomsChecker.Diagnosis;
using SerapisPatient.ViewModels.Base;

namespace SerapisPatient.ViewModels.SymptomsCheckerViewModel
{
    public class DiagnosisViewModel : BaseViewModel
    {
        private List<Specialisation> _listOfSpecialisations;
        public List<Specialisation> ListOfSpecialisations
        {
            get { return _listOfSpecialisations; }
            set
            {
                _listOfSpecialisations = value;
                OnPropertyChanged("ListOfSpecialisations");
            }
        }
        
        private List<Issue> _listOfIssues;
        public List<Issue> ListOfIssues
        {
            get { return _listOfIssues; }
            set
            {
                _listOfIssues = value;
                OnPropertyChanged("ListOfIssues");
            }
        }

        public List<DiagnosisResponse> DiagnosisResponseList;
        
        public DiagnosisViewModel()
        {
            Init();
            
        }

        public void Init()
        {
            DiagnosisResponseList = App.SessionCache.CacheData.ContainsKey(CacheKeys.SelectedSymptomsData.ToString())
                ? (List<DiagnosisResponse>) App.SessionCache.CacheData[
                    CacheKeys.SelectedSymptomsData.ToString()] : new List<DiagnosisResponse>();
            ListOfSpecialisations = GetSpecialisations();
            ListOfIssues = GetSymptomsUserHadSelected();
        }
        private List<Specialisation> GetSpecialisations()
        {
            List<Specialisation> collection = new List<Specialisation>();
            try
            {
                
                if (!App.SessionCache.CacheData.ContainsKey(CacheKeys.SelectedSymptomsData.ToString()))
                    return collection;

                foreach (var item in DiagnosisResponseList )
                {
                    collection.AddRange(item.Specialisation);
                }
            }catch(Exception ex)
            {
                Debug.WriteLine("Error "+ex);
            }


            return collection;
        }

        private List<Issue> GetSymptomsUserHadSelected()
        {
            List<Issue> issues = new List<Issue>();
            foreach (var item in DiagnosisResponseList)
            {
                issues.Add(item.Issue);
            }
            
            return issues;
        }

        public void OnDisappearing()
        {
            Debug.WriteLine("Clearing ListOfSpecialisations: "+ListOfSpecialisations.Count);
            ListOfSpecialisations.Clear();
        }
    }
}