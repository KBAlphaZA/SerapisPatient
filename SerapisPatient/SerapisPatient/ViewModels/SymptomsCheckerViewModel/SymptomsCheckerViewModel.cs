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
using System.Windows.Input;
using CarouselView.FormsPlugin.Abstractions;
using SerapisPatient.Utils;
using Xamarin.Forms;
using Xamarin.Forms.BehaviorsPack;

namespace SerapisPatient.ViewModels.SymptomsCheckerViewModel
{
    public class SymptomsCheckerViewModel : BaseViewModel
    {
        #region Properties

        private Symptoms Symptom { get; set; }

        private List<Symptoms> _listOfSymptoms;
        private ObservableCollection<Symptoms> _listOfSelectedSymptoms;
        private ObservableCollection<ViewSymptoms> _groupedListOfSymptoms;
        private ObservableCollection<ViewSymptoms> _selectedListOfSymptoms;
        
        public ObservableCollection<Symptoms> ListOfSelectedSymptoms
        {
            get { return _listOfSelectedSymptoms; }
            set
            {
                _listOfSelectedSymptoms = value;
                OnPropertyChanged("ListOfSelectedSymptoms");
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
        
        public ObservableCollection<ViewSymptoms> SelectedListOfSymptoms
        {
            get { return _selectedListOfSymptoms; }
            set
            {
                _selectedListOfSymptoms = value;
                OnPropertyChanged("SelectedListOfSymptoms");
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
        public NotificationRequest NavigateNextPageRequest { get; } = new NotificationRequest();
        public Command<object>  SelectSymptomCommand{ get; }
        SymptomCheckerService symptomChecker = new SymptomCheckerService();
        private SessionContext _context; 

        #endregion

        public SymptomsCheckerViewModel()
        {
            _context = base.SessionCache;
            ShowUI = false;
            ListOfSelectedSymptoms = new ObservableCollection<Symptoms>();
            MainListOfSymptoms = symptomChecker.GetAllSymptomsMock();
            GroupedListOfSymptoms = GenerateCarouselViewData(MainListOfSymptoms);
            SelectSymptomCommand = new Command<object>( ExecuteSelectSymptomCommand );
        }

        private void ExecuteSelectSymptomCommand( object obj )
        {
            //Parent: Frame
            //Text
            var labelObj = (Label) obj;
            var frameObj = (Frame) labelObj.Parent;
            var title = labelObj.Text;
            Debug.WriteLine("Label Element " + title );
            Debug.WriteLine("List Count:  " + MainListOfSymptoms.Count );
            ListOfSelectedSymptoms.Add(SearchUtil.FindSymptomByName(MainListOfSymptoms,title));
            Debug.WriteLine("Frame Element " + frameObj );
            
        }
        public ICommand SymptomSelectCommand => new Command<Symptoms>(selectedSymptoms =>
        {
            SymptomsListData listData = new SymptomsListData();
            NavigateNextPageRequest.Raise(new SelectedItemEvent {SelectedSymptoms = selectedSymptoms});
            Symptom = selectedSymptoms;
            
 
            if (_context.CacheData.ContainsKey("selectedSymptoms"))
            {
                _listOfSymptoms = (List<Symptoms>) _context.CacheData["selectedSymptoms"];
                Debug.WriteLine("Number Symptoms already selected [" + _listOfSymptoms.Count + "]");
                Debug.WriteLine("Adding new Symptom[" + Symptom.Name + "]" + " to the cache list");
                _listOfSymptoms.Add(Symptom);
                _context.CacheData["selectedSymptoms"] = _listOfSymptoms;
            }
            else
            {
                _listOfSymptoms.Add(Symptom);
                _context.CacheData.Add("selectedSymptoms", _listOfSymptoms);
            }
            // Navigate to the next page
            //SelectSymptomAsync(symptom); <--- TODO: Need to create a new NEXT button on toolbar
        });

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

        private async void SelectSymptomAsync(Symptoms symptom)
        {

            //Clean symptom data before navigating
            _listOfSymptoms = (List<Symptoms>) _context.CacheData["selectedSymptoms"];
            var symptomsList = _listOfSymptoms.Where(x => x.IsChecked == true).ToList();
            _context.CacheData["selectedSymptoms"] = _listOfSymptoms;

            await App.Current.MainPage.Navigation.PushAsync(null, true);
        }


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
            var groupedSymptomData = GroupSymptoms(unGroupedList);
            var  carouselViewList = new ObservableCollection<ViewSymptoms>();
            carouselViewList.Add(groupedSymptomData.Item1);
            carouselViewList.Add(groupedSymptomData.Item2);
            carouselViewList.Add(groupedSymptomData.Item3);
            carouselViewList.Add(groupedSymptomData.Item4);
            carouselViewList.Add(groupedSymptomData.Item5);
            
            return carouselViewList;
        }
        private static SymptomsListData GroupSymptoms(List<Symptoms> unGroupedList)
            {

                // Want to group Symptoms by 5 and make it its own list
                SymptomsListData groupedList = new SymptomsListData();
                ViewSymptoms viewSymptoms = new ViewSymptoms();
                var dictionary = new Dictionary<string, List<Symptoms>>();
                int k = 1;
                int j = 1;
                int counter = 0;
                for (int x = 0; x < 5; ++x)
                {
                    ViewSymptoms symptoms = new ViewSymptoms();
                    for (int i = 0; i < 5; ++i)
                    {
                        string key = "Item" + k;
                        Debug.WriteLine("We are now storing Symptom name:  " +unGroupedList[counter].Name);
                        viewSymptoms.GetType().GetProperty(key)?.SetValue(symptoms , unGroupedList[counter].Name);
                        ++k;
                        counter++;
                    }
                
                    k = 1;
                    string key2 = "Item" + j;
                    groupedList.GetType().GetProperty(key2)?.SetValue(groupedList, symptoms);
                    ++j;
                }

                return groupedList;
            }
    }
}