using Rg.Plugins.Popup.Services;
using SerapisPatient.Models;
using SerapisPatient.Models.Doctor;
using SerapisPatient.Utils;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels.PopUpViewModel
{
    public class DeliveryPopUpViewModel
    {
        //Make a list to send to the server
        private List<DoctorPrescription> PrescribedMedication { get; set; }

        public DeliveryPopUpViewModel()
        {            
            CloseCommand = new Command(async () => await CloseTheDialogBox());
            StartProcessCommand = new Command(async () => await RequestMedicationDelivery());
            GetPrescriptionList();
        }

        public Command CloseCommand { get; set; }

        public Command StartProcessCommand { get; set; }

        private Task CloseTheDialogBox()
        {
            return PopupNavigation.Instance.PopAllAsync(true);
        }

        private async Task RequestMedicationDelivery()
        {
            //First check for internet connectivity, raise an event if there is no connectivity
            CheckInternetConnection();

            SendOrderToServer();

        }

        private void CheckInternetConnection()
        {
      
        }


        private Location GetUserLocation()
        {
            Location UserLocation = new Location()
            {
                lng = 34.345443534,
                lat=4.676756756756
            };

            return UserLocation;
        }
        

        private void GetPrescriptionList()
        {
            //List to store items that are being ordered
            PrescribedMedication = new List<DoctorPrescription>();

            //Get them from the DoctorPrescriptionViewModel
            MessagingCenter.Subscribe<DoctorPrescriptionViewModel, ObservableCollection<DoctorPrescription>>(this, MessagingKeys.SendOrder,  (obj, arg) =>
            {
                // AddPrescriptionAsync(arg);
                //var list = obj.DummyPrescriptionList();
                var list = arg;
                
                foreach (DoctorPrescription item in list)
                {
                    PrescribedMedication.Add(item);
                }

            });
        }

        private void AddPrescriptionAsync(DoctorPrescription arg)
        {
            PrescribedMedication.Add(new DoctorPrescription
            {
                DatePrescribed = arg.DatePrescribed,
                MedicationAddedNotes = arg.MedicationAddedNotes,
                MedicationDosage = arg.MedicationDosage,
                MedicationName = arg.MedicationName ,
                MedicationInstructions = arg.MedicationInstructions,
                MedicationType = arg.MedicationType,
                TimePrescribed = arg.TimePrescribed
                
            });
        }

        private void SendOrderToServer()
        {
            //our api url
            const string url = "https://something.net";
            
            //send the user location for us to delivery too
            GetUserLocation();


            //get prescriptionm to be sent to server
            GetPrescriptionList();


            using (HttpClient client = new HttpClient())
            {
                
               // var post = await client.PostAsync(url);
            }

        }
    }
}
