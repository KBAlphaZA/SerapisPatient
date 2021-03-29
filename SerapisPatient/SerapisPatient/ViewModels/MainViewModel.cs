using MongoDB.Bson;
using Realms;
using Rg.Plugins.Popup.Services;
using SerapisPatient.Models;
using SerapisPatient.Models.Patient;
using SerapisPatient.Services;
using SerapisPatient.Services.LocationServices;
using SerapisPatient.TabbedPages;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views.NotificationViews;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Properties
        //The Title of the Page
        private readonly string _title = "Serapis Patient";

        //public ICommand SettingsCommand => new Command(async () => await SettingsAsync());


        private Uri profilePicture;

        public Uri ProfilePicture
        {
            get { return profilePicture; }
            set { profilePicture = value; }
        }

        private string firstname;

        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }

        private NotificationBoardExpanded CardExpanded;
        public ICommand RunInit { get; set; }
        public Command NavigateToProfilePageCommand { get; set; }
        public Command NavigateToAppointmentPageCommand { get; set; }
        public Command NavigateToDeliveryPageCommand { get; set; }
        public Command NavigateToCameraPageCommand { get; set; }

        public Command OpenNotificationCard { get; set; }

        public ObservableCollection<NotificationModel> Notifications { get; private set; }

        //The instance for getting the user location
        UserCurrentLocation usersLocation;

        private NotificationModel selectedCard;
        public NotificationModel SelectedCard
        {
            get => selectedCard;
            set
            {
                SetProperty(ref selectedCard, value);

                MedicationDelvery(SelectedCard);
            }
        }
        public Realm _realm;
        #endregion

        NotificationModel mockUp = new NotificationModel() {Title= "MEDICATION DELIVERY" };

        public MainViewModel()
        {
            _realm = Realm.GetInstance();
            Init();

            GenerateNotificationList();
            NavigateToProfilePageCommand = new Command(ProfilePage);
            NavigateToAppointmentPageCommand = new Command(AppointmentPage);
            NavigateToDeliveryPageCommand = new Command(DeliveryPage);
            NavigateToCameraPageCommand = new Command(CameraPage);
            OpenNotificationCard = new Command(MockMethod);
            Title = _title;

            

        }

        private async void MockMethod()
        {

            await PopupNavigation.Instance.PushAsync(CardExpanded);

            await App.Current.MainPage.Navigation.PushAsync(new MedicationNotificatonView());
        }

        #region Methods
        private void Init()
        {

            var dbuser = _realm.All<Patient>().FirstOrDefault();
            Debug.WriteLine("DB USER =>" + dbuser.ToJson());
            FirstName = "Hi " + dbuser.PatientFirstName;

            ProfilePicture = new Uri(dbuser.PatientProfilePicture);
            if (String.IsNullOrEmpty(dbuser.PatientProfilePicture))
                ProfilePicture = new Uri("user1"); 

            //Debug.WriteLine(FirstName == null ? " " : dbuser.PatientFirstName);
            Debug.WriteLine("FirstName USER =>" + FirstName);
            
        }

        //ListView
        private void GenerateNotificationList()
        {
            Notifications = new ObservableCollection<NotificationModel>
                  {
                    new NotificationModel{ Title = "FOLLOW UP", Body ="You have a follow up with Dr. Duma ", Type="FollowUp" },
                     new NotificationModel{ Title = "MEDICATION DELIVERY", Body ="Your ordered medication should be with you in a few hours ", Type="Delivery" },
                      new NotificationModel{ Title = "DELVIERED", Body =" View your reciept below" },
                  };
        }

        private async void ProfilePage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new ProfilePage());
        }

        /// <summary>
        /// <c a="AppointmentPAge"/>
        /// First Gets the user location, then
        /// Navigates to AppointmentPage(Passes Location)
        /// </summary>
        private async void AppointmentPage()
        {

            //Busy status
            IsBusy = true;

            try
            {
                #region Getting user location code

                //Get the users location before moving on to the next page
                usersLocation = new UserCurrentLocation();

                await usersLocation.GetCurrentLocationAsync();

                #endregion
            }
            catch (Exception ex)
            {
                Debug.Write("Failed to get user location: "+  ex.Data);
            }
            finally
            {
                //Navigate to the next page

                IsBusy = false;

                await App.Current.MainPage.Navigation.PushAsync(new AppointmentPage());
            }

        }
        private async void DeliveryPage()
        {
           
            await App.Current.MainPage.Navigation.PushAsync(new DeliveryPage());
        }
        private async void CameraPage()
        {
            
            await App.Current.MainPage.Navigation.PushAsync(new CameraPage());
        }

        private async void MedicationDelvery(NotificationModel _SelectedCard) 
        {
            if(bool.Equals(_SelectedCard.Title," "))
            {
                //await App.Current.MainPage.Navigation.PushAsync(new  );
            }
            else if(bool.Equals(_SelectedCard.Title, " "))
            {
                //await App.Current.MainPage.Navigation.PushAsync(new );
            }
            else if(bool.Equals(_SelectedCard.Title, "MEDICATION DELIVERY"))
            {
                await App.Current.MainPage.Navigation.PushAsync(new MedicationNotificatonView());
            }
            
        }
        #endregion
    }
}
