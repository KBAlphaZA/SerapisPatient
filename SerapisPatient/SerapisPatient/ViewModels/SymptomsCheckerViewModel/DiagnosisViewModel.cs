using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using SerapisPatient.Enum;
using SerapisPatient.Models;
using SerapisPatient.Models.SymptomsChecker.Diagnosis;
using SerapisPatient.ViewModels.Base;

namespace SerapisPatient.ViewModels.SymptomsCheckerViewModel
{
    public class DiagnosisViewModel : BaseViewModel
    {
        private SessionContext _context; 
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
        
        public DiagnosisViewModel()
        {
            ListOfSpecialisations = GetSpecialisations();
        }
        
        private List<Specialisation> GetSpecialisations()
        {
            List<Specialisation> collection = new List<Specialisation>();
            try
            {
                
                if (!App.SessionCache.CacheData.ContainsKey(CacheKeys.SelectedSymptomsData.ToString()))
                    return collection;

                var cachelist = App.SessionCache.CacheData[CacheKeys.SelectedSymptomsData.ToString()];
                var list = (List<DiagnosisResponse>)cachelist;

                foreach (var item in list)
                {
                    collection.AddRange(item.Specialisation);
                }
            }catch(Exception ex)
            {
                Debug.WriteLine("Error "+ex);
            }


            return collection;
        }
    }
}