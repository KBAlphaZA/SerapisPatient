using System;
using SerapisPatient.behavious;
using SerapisPatient.Models;
using SerapisPatient.Models.SymptomsChecker;
using SerapisPatient.Services.SymptomChecker;
using SerapisPatient.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using CarouselView.FormsPlugin.Abstractions;
using MongoDB.Bson;
using Rg.Plugins.Popup.Extensions;
using SerapisPatient.Enum;
using SerapisPatient.Models.SymptomsChecker.Diagnosis;
using SerapisPatient.PopUpMessages;
using SerapisPatient.Utils;
using Xamarin.Forms;
using Xamarin.Forms.BehaviorsPack;
using SerapisPatient.Views.SymptomsChecker;

namespace SerapisPatient.ViewModels.SymptomsCheckerViewModel
{
    public class SymptomsCheckerViewModel : BaseViewModel
    {
        #region Properties

        public Command NavigateToNextPageCommand { get; }
        private Symptoms Symptom { get; set; }

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

        public SymptomsCheckerViewModel()
        {
           // _context = base._sessionContext;
                //base.SessionCache;
            ShowUI = false;
            ListOfSelectedSymptoms = new ObservableCollection<Symptoms>();
            ListOfProposedSymptoms = new ObservableCollection<Issue>();
            MainListOfSymptoms = symptomChecker.GetAllSymptomsMock();
            GroupedListOfSymptoms = GenerateCarouselViewData(MainListOfSymptoms);
            NavigateToNextPageCommand = new Command(SelectedSymptom);
            SelectSymptomCommand = new Command<object>(ExecuteSelectSymptomCommand);
            Title = "Symptoms";
        }

        private async void SelectedSymptom()
        {
            //await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("E", "Error!, We couldn't complete your booking. Please Try Again"));
            
            await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("S", "You Successfully completed your booking"));

            await Task.Delay(100);
            await App.Current.MainPage.Navigation.PushAsync(new DiagnosisView());
        }

        private async void ExecuteSelectSymptomCommand( object obj )
        {
            var labelObj = (Label) obj;
            var frameObj = (Frame) labelObj.Parent;
            var title = labelObj.Text;
            Debug.WriteLine("Label Element " + title );
            Debug.WriteLine("List Count:  " + MainListOfSymptoms.Count );
            
            var symptomByName = SearchUtil.FindSymptomByName(MainListOfSymptoms,title);
            // Call API for proposed Symptoms
            var item = await symptomChecker.GetProposedSymptomsMock(symptomByName.ID);
            ListOfSelectedSymptoms.Add(symptomByName);
            ListOfProposedSymptoms.Add(item.Issue);
            App.SessionCache.CacheData = ViewModelHelper.HandleCachingListObject<DiagnosisResponse>(App.SessionCache.CacheData, CacheKeys.SelectedSymptomsData.ToString(),item);
            ProgressBarValue = NumberUtil.ToSingle(item.Issue.Accuracy);
            ProgressBarColor = ViewModelHelper.DetermineProgressBarColorByValue(item.Issue.Accuracy);
            
            Debug.WriteLine("progressBarValue: {0} progressBarColor: {1}", progressBarValue, progressBarColor);
            //await progressBar.ProgressTo(0.75, 500, Easing.Linear);
        }

        public ICommand PerformSearch => new Command<string>((string query) =>
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                ShowUI = false;
                //ListOfSymptoms = SearchUtil.SearchForSymptoms(query,MainListOfSymptoms);
                ListOfSymptoms = Search(query);
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

        private ObservableCollection<ViewSymptoms> GenerateCarouselViewData(List<Symptoms> unGroupedList)
        {
            var groupedSymptomData = ViewModelHelper.GroupSymptoms(unGroupedList);
            var  carouselViewList = new ObservableCollection<ViewSymptoms>();
            carouselViewList.Add(groupedSymptomData.Item1);
            carouselViewList.Add(groupedSymptomData.Item2);
            carouselViewList.Add(groupedSymptomData.Item3);
            carouselViewList.Add(groupedSymptomData.Item4);
            carouselViewList.Add(groupedSymptomData.Item5);
            
            return carouselViewList;
        }
    }
}