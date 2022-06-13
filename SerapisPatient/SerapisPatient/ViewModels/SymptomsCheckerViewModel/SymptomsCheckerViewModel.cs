using System;
using SerapisPatient.Models;
using SerapisPatient.Models.SymptomsChecker;
using SerapisPatient.Services.SymptomChecker;
using SerapisPatient.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Rg.Plugins.Popup.Extensions;
using SerapisPatient.Enum;
using SerapisPatient.Models.Patient;
using SerapisPatient.Models.SymptomsChecker.Diagnosis;
using SerapisPatient.PopUpMessages;
using SerapisPatient.TemplateViews;
using SerapisPatient.Utils;
using Xamarin.Forms;
using Xamarin.Forms.BehaviorsPack;
using SerapisPatient.Views.SymptomsChecker;
using Xamarin.CommunityToolkit.Extensions;

namespace SerapisPatient.ViewModels.SymptomsCheckerViewModel
{
    public class SymptomsCheckerViewModel : BaseViewModel
    {
       

        public SymptomsCheckerViewModel()
        {
            Init();
            NavigateToNextPageCommand = new Command(SelectedSymptom);
            SelectSymptomCommand = new Command<object>(ExecuteSelectSymptomCommand);
            Title = "Symptoms";
        }




        
        private async Task Init()
        {
            PatientInfo = App.SessionCache.UserInfo;
            if (ListOfSelectedSymptoms is null || ListOfProposedSymptoms is null)
                App.SessionCache.CacheData.Remove(CacheKeys.SelectedSymptomsData.ToString());
            ShowUI = false;
            ListOfSelectedSymptoms = new ObservableCollection<Symptoms>();
            ListOfProposedSymptoms = new ObservableCollection<Issue>();

           
        }

        private async Task<List<Symptoms>> PopulateSymptoms()
        {
           return await symptomChecker.GetAllSymptoms();
        }
        
        

        private async void SelectedSymptom()
        {
            //await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("E", "Error!, We couldn't complete your booking. Please Try Again"));
            
            //await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("S", "You Successfully completed your booking"));

            //await Task.Delay(100);
            await App.Current.MainPage.Navigation.PushAsync(new DiagnosisView());
        }

        private async void ExecuteSelectSymptomCommand( object obj )
        {
            
            var labelObj = (Label) obj;
            var frameObj = (Frame) labelObj.Parent;
            var title = labelObj.Text;
            Debug.WriteLine("Label Element " + title );
            Debug.WriteLine("List Count:  " + MainListOfSymptoms.Count );
            try
            {
                IsBusy = true;
                var symptomByName = SearchUtil.FindSymptomByName(MainListOfSymptoms, title);
                // Call API for proposed Symptoms

                App.SessionCache.CacheData = ViewModelHelper.HandleCachingObject<string>(App.SessionCache.CacheData, CacheKeys.SelectedSymptomsIds.ToString(), symptomByName.ID);
                var userYear = (PatientInfo.PatientAge == 0 ? 30 : DateTime.Now.Year - App.SessionCache.UserInfo.PatientAge).ToString();
                var gender = (PatientInfo.Gender.ToString() ?? Genders.male.ToString());
                var ids = (string)App.SessionCache.CacheData[CacheKeys.SelectedSymptomsIds.ToString()];
                var diagnosisResponses = await symptomChecker.GetProposedDiagnosisResponse(ids, userYear, gender);
                //var year = (DateTime.Now.Year - PatientInfo.PatientAge).ToString();
                //var item = await symptomChecker.GetProposedSymptoms(symptomByName.ID,year,user.Gender.ToString());
                foreach (var diagnosisResponse in diagnosisResponses)
                {
                    ListOfSelectedSymptoms.Add(symptomByName);
                    ListOfProposedSymptoms.Add(diagnosisResponse.Issue);
                    ProgressBarValue = NumberUtil.ToSingle(diagnosisResponse.Issue.Accuracy);
                    ProgressBarColor = ViewModelHelper.DetermineProgressBarColorByValue(diagnosisResponse.Issue.Accuracy);
                }

                App.SessionCache.CacheData = ViewModelHelper.HandleCachingListObject<DiagnosisResponse>(
                    App.SessionCache.CacheData, CacheKeys.SelectedSymptomsData.ToString(), diagnosisResponses);

                Debug.WriteLine("progressBarValue: {0} progressBarColor: {1}", progressBarValue, progressBarColor);
                //await progressBar.ProgressTo(0.75, 500, Easing.Linear);
                IsBusy = false;
            }
            catch (Exception e)
            {
                IsBusy = false;
                Debug.WriteLine("Exception: " + e.Message);
            }
            
        }
        
        public ICommand PerformSearch => new Command<string>((string query) =>
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                ShowUI = false;
                //ListOfSymptoms = SearchUtil.SearchForSymptoms(query,MainListOfSymptoms);
                ListOfSymptoms = Search(query);
                MainListOfSymptoms = ListOfSymptoms;
                ShowUI = true;
            });
        });
        
        private List<Symptoms> Search(string queryText)
        {

            ListOfSymptoms = MainListOfSymptoms;

            Debug.WriteLine("Query string: [ " + queryText + " ]");

            var tempList = ListOfSymptoms
                .Where(x => x.Name.ToLower().Contains(queryText.ToLower()))
                .ToList();

                return tempList;
        }

        private async Task<ObservableCollection<ViewSymptoms>> GenerateCarouselViewData(List<Symptoms> unGroupedList)
        {
            var groupedSymptomData = await ViewModelHelper.GroupSymptoms(unGroupedList);
            var  carouselViewList = new ObservableCollection<ViewSymptoms>();
            carouselViewList.Add(groupedSymptomData.Item1);
            carouselViewList.Add(groupedSymptomData.Item2);
            carouselViewList.Add(groupedSymptomData.Item3);
            carouselViewList.Add(groupedSymptomData.Item4);
            carouselViewList.Add(groupedSymptomData.Item5);
            
            return carouselViewList;
        }

        public async Task OnAppearing()
        {
            try
            {

                DefaultLoadingView popUp = new DefaultLoadingView();
                if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                {
                    popUp.IsLightDismissEnabled = false;
                }
                
                if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                    App.Current.MainPage?.Navigation.ShowPopup(popUp);
                //Task.Delay(4000);
                if (!App.SessionCache.CacheData.ContainsKey(CacheKeys.CachedSymptomsList.ToString()))
                {
                    MainListOfSymptoms = await PopulateSymptoms();
                    App.SessionCache.CacheData.Add(CacheKeys.CachedSymptomsList.ToString(), MainListOfSymptoms);
                }
                MainListOfSymptoms = (List<Symptoms>)App.SessionCache.CacheData[CacheKeys.CachedSymptomsList.ToString()];
                GroupedListOfSymptoms = await GenerateCarouselViewData(MainListOfSymptoms);
                ShowUI = true;
                //= PopulateSymptoms().Result;
                if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                    popUp.Dismiss(null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
        }
        
         #region Properties

        public Command NavigateToNextPageCommand { get; }
        private Symptoms Symptom { get; set; }
        public Patient PatientInfo { get;  set; }

        private List<Symptoms> _listOfSymptoms;
        private ObservableCollection<Symptoms> _listOfSelectedSymptoms;
        private ObservableCollection<Issue> _listOfProposedSymptoms;
        private ObservableCollection<ViewSymptoms> _groupedListOfSymptoms;

        public ObservableCollection<Symptoms> ListOfSelectedSymptoms
        {
            get { return _listOfSelectedSymptoms; }
            set
            {
                _listOfSelectedSymptoms = value;
                OnPropertyChanged("ListOfSelectedSymptoms");
            }
        }

        public ObservableCollection<Issue> ListOfProposedSymptoms
        {
            get { return _listOfProposedSymptoms; }
            set
            {
                _listOfProposedSymptoms = value;
                OnPropertyChanged("ListOfProposedSymptoms");
            }
        }

        public List<Symptoms> ListOfSymptoms
        {
            get { return _listOfSymptoms; }
            set
            {
                _listOfSymptoms = value;
                OnPropertyChanged("ListOfSymptoms");
            }
        }

        public ObservableCollection<ViewSymptoms> GroupedListOfSymptoms
        {
            get { return _groupedListOfSymptoms; }
            set
            {
                _groupedListOfSymptoms = value;
                OnPropertyChanged("GroupedListOfSymptoms");
            }
        }

        public List<Symptoms> MainListOfSymptoms { get; set; }

        private float progressBarValue;
        private Color progressBarColor;

        public float ProgressBarValue
        {
            get { return progressBarValue; }
            set
            {
                progressBarValue = value;
                OnPropertyChanged("ProgressBarValue");
            }
        }
        private Color ProgressBarColor { 
            get { return progressBarColor; }
            set
            {
                progressBarColor = value;
                OnPropertyChanged("ProgressBarColor");
            } 
        }
        
        
        private string searchSymptoms;

        public string SearchSymptoms
        {
            get { return searchSymptoms; }
            set
            {
                searchSymptoms = value;
                OnPropertyChanged("SearchSymptoms");
            }
        }

        private NotificationRequest NavigateNextPageRequest { get; } = new NotificationRequest();
        public Command<object>  SelectSymptomCommand{ get; }
        SymptomCheckerService symptomChecker = new SymptomCheckerService();
        private SessionContext _context; 

        #endregion
        
    }
}