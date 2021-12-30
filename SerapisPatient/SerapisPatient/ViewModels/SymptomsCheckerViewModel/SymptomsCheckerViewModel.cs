using SerapisPatient.behavious;
using SerapisPatient.Models;
using SerapisPatient.Models.SymptomsChecker;
using SerapisPatient.Services;
using SerapisPatient.Services.SymptomChecker;
using SerapisPatient.ViewModels.Base;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.BehaviorsPack;

namespace SerapisPatient.ViewModels.SymptomsCheckerViewModel
{
    public class SymptomsCheckerViewModel : BaseViewModel
    {
        private Symptoms symptom { get; set; }

        private List<Symptoms> listOfSymptoms;
        public List<Symptoms> ListOfSymptoms
        {
            get
            {
                return listOfSymptoms;
            }
            set
            {
                listOfSymptoms = value;
                OnPropertyChanged("ListOfSymptoms");
            }
        }
        public List<Symptoms> MainListOfSymptoms { get; set; }
        public NotificationRequest NavigateNextPageRequest { get; } = new NotificationRequest();
       
        SymptomCheckerService symptomChecker = new SymptomCheckerService();
        public SessionContext context;
        public SymptomsCheckerViewModel()
        {
            context = base.SessionCache;
            // <!--Text="{Binding SearchSymptoms}" -->
            ShowUI = false;

            MainListOfSymptoms = symptomChecker.GetAllSymptomsMock();
        }

        public ICommand SpecilizationSelectCommand => new Command<Symptoms>(selectedSymptoms =>
        {
            NavigateNextPageRequest.Raise(new SelectedItemEvent { SelectedSymptoms = selectedSymptoms });
            symptom = selectedSymptoms;
            
            if (context.CacheData.ContainsKey("selectedSymptoms"))
            {
                listOfSymptoms = (List<Symptoms>) context.CacheData["selectedSymptoms"];
                Debug.WriteLine("Symptoms already selected [" + listOfSymptoms.Count+"]");
                Debug.WriteLine("Adding new Symptom[" + symptom + "]" + " to the cache list");
                listOfSymptoms.Add(symptom);
                context.CacheData["selectedSymptoms"] = listOfSymptoms;
            }
            else
            {
                listOfSymptoms.Add(symptom);
                context.CacheData.Add("selectedSymptoms", listOfSymptoms);
            }
            // Navigate to the next page
            SelectSymptomAsync(symptom);
        });

        public ICommand PerformSearch => new Command<string>((string query) =>
        {
            Device.BeginInvokeOnMainThread(() =>
            {
               ShowUI = false;
               ListOfSymptoms = Search(query);
               ShowUI = true;
            });
            
        });
        private async void SelectSymptomAsync(Symptoms symptom)
        {

            await App.Current.MainPage.Navigation.PushAsync(null, true);
        }

     
        private string searchSymptoms;
        public string SearchSymptoms
        {
            get
            {
                return searchSymptoms;
            }
            set
            {
                searchSymptoms = value;
                OnPropertyChanged("SearchSymptoms");
                //an event needs to go here
                //Search(SearchSymptoms);
            }
        }
        private List<Symptoms> Search(string queryText)
        {
            
            ListOfSymptoms = MainListOfSymptoms;

            Debug.WriteLine("Query string: [ " + queryText + " ]");

            List<Symptoms> templist = new List<Symptoms>();

            foreach (var symptom in ListOfSymptoms)
            {
                if (symptom.Name.ToLower().Contains(queryText.ToLower()))
                {
                    Debug.WriteLine("This text [" + symptom.Name + "] contains [" + queryText+"]");
                    templist.Add(symptom);
                }
            }

            //ListOfSymptoms.Clear();
            //ListOfSymptoms.AddRange(templist);

            return templist;
        }
    }
}
