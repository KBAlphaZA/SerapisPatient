
using CarouselView.FormsPlugin.Abstractions;
using MongoDB.Bson;
using SerapisPatient.Helpers;
using SerapisPatient.Models;
using SerapisPatient.Models.Appointments;
using SerapisPatient.Models.Patient;
using SerapisPatient.Models.Practices;
using SerapisPatient.Services;
using SerapisPatient.Services.LocationServices;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views.AppointmentFolder.Booking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.BehaviorsPack;

namespace SerapisPatient.ViewModels.AppointmentViewModels
{

    public class MedicalBuildingViewModel : BaseViewModel
    {

        #region Properties
        private readonly APIServices _apiServices = new APIServices();
        //MockData List
        
        public MedicalBuildingModel _MedicalBuildingData;
        public NotificationRequest NavigateNextPageRequest { get; } = new NotificationRequest();
        public Command NavigateToHomePageCommand { get; set; }
        public ICommand ItemSelected { get; set; }

        private List<MedicalBuildingModel> _practices;

        public MedicalBuildingModel SelectedItem
        {
            get { return GetValue<MedicalBuildingModel>(); }
            set { SetValue(value); }
        }

     
        private string title;
        public string Title 
        {
            get
            {
                return title;
            }
            set
            {
                title = value;

                RaisePropertyChanged(nameof(Title));
            }
        }

        private string icon;
        public string Icon
        {
            get
            {
                return icon;
            }
            set
            {
                icon = value;

                RaisePropertyChanged(nameof(Icon));
            }

        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;

                RaisePropertyChanged(nameof(Description));
            }

        }

        #region Khanyisani carousel code

        public Command selectedItem {get; set; }

        private int myPostion;

        public int MyPostion
        {
            get
            {
                return myPostion;
            }
            set
            {
                myPostion = value;
                OnPropertyChanged("MyPostion");
                myPostion = value;
            }
        }

        private ObservableCollection<PracticeDto> practiceList;

        public ObservableCollection<PracticeDto> PracticesList
        {
            get
            {
                return practiceList;
            }
            set
            {
                practiceList = value;
            }
        }

        private void MedicalBuildingViewInit(SpecilizationModel _specilizationData)
        {
            var myCarsoul = new CarouselViewControl();

            Title = _specilizationData.Title;

            Icon = _specilizationData.Icon;

            Description = _specilizationData.Description;

            myCarsoul.ItemsSource = PracticesList;
            myCarsoul.Position = 0;
            
        }

        #endregion

        #endregion

        public MedicalBuildingViewModel(SpecilizationModel _specilizationData)
        {

            InitalizeList(PatientCoordinates.Latitude, PatientCoordinates.Longitude, Convert.ToDouble(Settings.MaximumDistance));

            selectedItem = new Command<MedicalBuildingModel>(args => 
            {
                _MedicalBuildingData = args;
                HandleNavigation(_MedicalBuildingData);
            });

            PracticesList = new ObservableCollection<PracticeDto>()
            {
               new PracticeDto
                 {
                     Distance=7.8,
                     ContactNumber="031 701 456 43",
                     PracticeID=ObjectId.Parse("5bc9bd861c9d4400001badf1"),
                     NumberOfPatientsAtPractice=5,
                     PracticeName="Grey's Hospital",
                     PracticePicture="MedicrossPinetown.jpg",
                     OperatingTimes="08h00-17h00"
                 },
                 new PracticeDto
                 {
                     Distance=7,
                     ContactNumber="031 701 456 43",
                     PracticeID=ObjectId.Parse("5bc9bde81c9d4400001badf2"),
                     NumberOfPatientsAtPractice=10,
                     PracticeName="Crompton Hospital",
                     PracticePicture="MedicrossPinetown.jpg",
                     OperatingTimes="08h00-17h00"
                 },
                 new PracticeDto
                 {
                     Distance=6,
                     ContactNumber="031 701 456 43",
                     PracticeID=ObjectId.Parse("5bc9bd741c9d4400001badf0"),
                     NumberOfPatientsAtPractice=10,
                     PracticeName="Groote Schuur Hospital",
                     PracticePicture="MedicrossPinetown.jpg",
                     OperatingTimes="08h00-17h00"
                 }
            };

            MedicalBuildingViewInit(_specilizationData);
        }

        private async void InitalizeList(double lat, double lon, double radius)
        {
            await _apiServices.GetAllMedicalBuildingsAsync(lat, lon, radius);
        }

        #region Bonga
        //BONG'S Constructor//

        //public MedicalBuildingViewModel(SpecilizationModel _specilizationData)
        //{
        //    GenerateMedicalBuildingModel();
        //    //GetAllPracticesAsync().Start();
        //    //Bindings
        //    Title = _specilizationData.Title;
        //    Icon = _specilizationData.Icon;
        //    Description = _specilizationData.Description;


        //   // GenerateMedicalBuildingModel();

        //    ItemSelected = new Command<MedicalBuildingModel>(args =>
        //    {
        //        _MedicalBuildingData = args;
        //        HandleNavigation(_MedicalBuildingData);
        //    });
        //}
        #endregion

        public MedicalBuildingViewModel()
        {
            
        }

        public void HandleNavigation(MedicalBuildingModel _MedicalBuildingData)
        {
            App.Current.MainPage.Navigation.PushAsync(new SelectBooking(_MedicalBuildingData), true);
        }

       public async Task<ObservableCollection<PracticeDto>> GetAllPracticesAsync()
       {
            // Practices = await _apiServices.GetAllMedicalBuildingsAsync();
            PracticesList = new ObservableCollection<PracticeDto>();

            var Practices=await _apiServices.GetAllMedicalBuildingsAsync();

            foreach (var _practice in Practices)
            {
                PracticesList.Add(_practice);
            }

            return PracticesList;
       }


        public void ItemSelected_ExecuteCommand(object state)
        {
            SelectedItem = state as MedicalBuildingModel;
        }

        #region Bonga
        //public async Task<List<MedicalBuildingModel>> GetMedicalBuildingsBySpecializationAsync()
        //{
        //    //if (IsBusy)
        //     //   return;
        //    IsBusy = true;
        //    try
        //    {
        //        //var filter = Builders<MedicalBuildingModel>
        //         //.Filter
        //         //
        //         //.Eq(medicalbuilding, FieldsSpecilized);
        //        //adds filter to the query
        //        var result = await _mongodb.MedicalBuildingCollection
        //            .AsQueryable().Where(t => t.PracticeName.Equals("Grey's Hospital") )
        //            .ToListAsync();

        //        return result;
        //    }
        //    catch(Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //    //filter function, this will filter by Medical building and specialization
        //    return null;
        //}
        #endregion
    }
}
