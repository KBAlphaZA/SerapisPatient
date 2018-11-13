using SerapisPatient.Models;
using SerapisPatient.Models.Doctor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;
using SerapisPatient.PopUpMessages;
using SerapisPatient.Utils;

namespace SerapisPatient.ViewModels
{
    public class DoctorPrescriptionViewModel
    {
        
        private DeliveryPopUp PopUp;

        private PharmacyPopUp PharmacyPopUp;

        public DoctorPrescriptionViewModel()
        {
            //DeliveryTapped = new Command<DoctorPrescription>(InitiateDeliveryProcess);
            DeliveryTapped = new Command(InitiateDeliveryProcess);
            PharmacyTapped = new Command(RemoveThePrescription);

            PopUp = new DeliveryPopUp();

            PharmacyPopUp = new PharmacyPopUp();

            DummyPrescriptionList();
        }

        #region Properties
        public Command DeliveryTapped { get; set; }

        public Command PharmacyTapped { get; set; }

        public ObservableCollection<DoctorPrescription> PrescriptionMeds { get; set; }
        #endregion
   

        private void ScanPrescriptionList()
        {
            foreach (var item in PrescriptionMeds)
            {
               
            }
        }

        public ObservableCollection<DoctorPrescription> DummyPrescriptionList()
        {
            PrescriptionMeds = new ObservableCollection<DoctorPrescription>()
            {
                new DoctorPrescription
                {
                     DatePrescribed=DateTime.Today.ToShortDateString(),
                     MedicationAddedNotes="Take it easy",
                     MedicationDosage="23gh/h",
                     MedicationName="Oxycon",
                     MedicationInstructions="Take 3 times a day",
                     MedicationType=TypeOfMedication.pill,
                     TimePrescribed="13h00"
                }
            };


            return PrescriptionMeds;
        }

        //private async void InitiateDeliveryProcess(DoctorPrescription doctorPrescription)
        private async void InitiateDeliveryProcess()
        {
            MessagingCenter.Send(this, MessagingKeys.SendOrder, PrescriptionMeds);
            //MessagingCenter.Send<DoctorPrescriptionViewModel,DoctorPrescription>(this, MessagingKeys.SendOrder, doctorPrescription);
            await PopupNavigation.Instance.PushAsync(PopUp);
        }

        private async void RemoveThePrescription()
        {
            //Just remove the prescription
            await PopupNavigation.Instance.PushAsync(PharmacyPopUp);
        }

    
    }
}
