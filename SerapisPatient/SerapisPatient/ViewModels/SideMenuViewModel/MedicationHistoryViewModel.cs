using Rg.Plugins.Popup.Services;
using SerapisPatient.Models;
using SerapisPatient.Models.Delivery;
using SerapisPatient.PopUpMessages;
using SerapisPatient.Utils;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.ViewModels.PopUpViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels.SideMenuViewModel
{
    public class MedicationHistoryViewModel:BaseViewModel
    {
        private FilterSelectionPopUp popUp;

        

        private Filtration localFiltration;
        public Filtration LocalFilter
        {
            get
            {
                return localFiltration;
            }
            set
            {
                localFiltration = value;
            }
        }

        //all copy from this list, do not alter
        public ObservableCollection<Prescription> AllMedicationHistory { get; set; }

        //temp storage for filtering, destroy with destructor after use
        public ObservableCollection<Prescription> TempStorage{ get; set; }

        public Command FilterCommand { get; set; } 

        Location deliveryLocation = new Location()
        {
            address = "Home"
        };

        #region Default Constructor
        public MedicationHistoryViewModel()
        {

            LocalFilter = Filtration.none;

            //Dummy Data
            AllMedicationHistory = new ObservableCollection<Prescription>()
            {
                 new Prescription
                 {
                     DatePrescribed ="23/03/19",
                     TimePrescribed ="13h00",
                     IsDoctorPrescription =false,
                     MedicationName ="Pando",
                     MedicationDosage ="23gh/l",
                     MedicationType =Models.Doctor.TypeOfMedication.pill,
                     Issuer ="Dr Viser",
                     PlaceDelivered =deliveryLocation
                 },

                new Prescription
                {
                    DatePrescribed ="23/03/19",
                    TimePrescribed ="13h00",
                    IsDoctorPrescription =false,
                    MedicationName ="Pando",
                    MedicationDosage ="23gh/l",
                    MedicationType =Models.Doctor.TypeOfMedication.pill,
                    Issuer ="Self"
                }
            };

            InitalizeList();
            popUp = new FilterSelectionPopUp();
            FilterCommand = new Command(PopUpFilterSelector);
        }
        #endregion

        #region Methods
        private void InitalizeList()
        {

            switch (LocalFilter)
            {

                case Filtration.DateRange:
                    break;

                case Filtration.PrescribedMedication:
                    FilterByPrecribedMedication();
                    break;

                case Filtration.SelfPrescribed:
                    FilterBySelfPrescription();
                    break;

                case Filtration.none:
                     NoFilter();
                    break;

                default:
                    NoFilter();
                    break;
            }
        }

        private void FilterByDate()
        {
            var result = from datefilter in AllMedicationHistory
                         where datefilter.DateDelivered == "some queried date" //should between two dates
                         select datefilter;
        }

        private ObservableCollection<Prescription> FilterByPrecribedMedication()
        {
            //intialize the property
            TempStorage = new ObservableCollection<Prescription>();

            //clear to make sure no items exiest 
            TempStorage.Clear();

            var result = from prescribedMedsfilter in AllMedicationHistory
                        where prescribedMedsfilter.IsDoctorPrescription == true
                        select prescribedMedsfilter;

            //then return all of them.
            foreach (Prescription items in result)
            {
                TempStorage.Add(items);
            }
      
            return TempStorage;
        }

        private void FilterBySelfPrescription()
        {
          var result=from selfPrescribedMedsFilter in AllMedicationHistory
                     where selfPrescribedMedsFilter.IsDoctorPrescription == false
                     select selfPrescribedMedsFilter;
        }

        private ObservableCollection<Prescription> NoFilter()
        {

            TempStorage = new ObservableCollection<Prescription>();
            TempStorage.Clear();

            TempStorage = AllMedicationHistory;

            return TempStorage;

        }

        private void RaisEvent()
        {
            //Raise the even when the filtration is changed
        }

        //Method to create the custom pop up
        private void PopUpFilterSelector()
        {
            PopupNavigation.Instance.PushAsync(popUp);
        }
        #endregion

    }
}
