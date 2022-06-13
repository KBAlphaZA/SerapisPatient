using SerapisPatient.Models;
using SerapisPatient.ViewModels.Base;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using SerapisPatient.Services.LocationServices;
using Newtonsoft.Json;

namespace SerapisPatient.ViewModels.SideMenuViewModel.SettingsSubFolderViewModel
{
    public class DeliverySettingsViewModel:BaseViewModel
    {
 
        /*
                NEEDS A BUNCH OF WORK AND LOGIC  TO GET UP AND RUNNING NICELY,
                THIS IS JUST THE BLUPRINT OF HOW IT'S GOING TO BE USED.
        */

        public DeliverySettingsViewModel()
        {
            DummyData();
        }


        public ObservableCollection<Location> SuggestionLocations { get; set; }

        public Command AddLocationCommand { get; set; }

        public Command SuggestCommand { get; set; }

        private string suggestion;
        public string Suggestion
        {
            get
            {
                return suggestion;
            }
            set
            {
                suggestion = value;
                OnPropertyChanged("Suggestion");
                suggestion = value;
            }
        }


        private async Task<ObservableCollection<Location>> SuggestLocations(string word)
        {
            //Looks at the back end google servers for the location

            word = suggestion;

            var url = GoogleMapsService.GenerateUrl(nameOfPlace: word);

            SuggestionLocations = new ObservableCollection<Location>();

       
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Location>(json);

                SuggestionLocations = result.formattedAddress as ObservableCollection<Location>;
            }

            return SuggestionLocations;
        }

      
        private void DummyData()
        {
            /*
            SuggestionLocations = new ObservableCollection<PatientUserLocation>()
            {
                new PatientUserLocation
                {
                     AddressLine1="6 Calsi",
                     AddressLine2="6 Calsi Gardens, Pinetown, 3610, South Africa"
                }
            };
            */
        }
    }
}
