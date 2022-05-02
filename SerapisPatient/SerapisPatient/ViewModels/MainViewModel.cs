﻿using MongoDB.Bson;
using Rg.Plugins.Popup.Services;
using SerapisPatient.Controls;
using SerapisPatient.Enum;
using SerapisPatient.Models;
using SerapisPatient.Models.Entities;
using SerapisPatient.Services.Data;
using SerapisPatient.Services.DB;
using SerapisPatient.Services.LocationServices;
using SerapisPatient.TabbedPages;
using SerapisPatient.TemplateViews;
using SerapisPatient.Utils;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views;
using SerapisPatient.Views.NotificationViews;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
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
        public Command NavigateToDeliveryPageCommand { get; }
        public Command NavigateToCameraPageCommand { get; set; }
        public Command NavigateToCheckInPageCommand { get; set; }

        public Command OpenNotificationCard { get; set; }

        public ObservableCollection<NotificationModel> Notifications { get; private set; }

        //The instance for getting the user location
        private UserCurrentLocation usersLocation;

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

        #endregion Properties

        private NotificationModel mockUp = new NotificationModel() { Title = "MEDICATION DELIVERY" };

        public MainViewModel()
        {
            InitAsync();
            NavigateToDeliveryPageCommand = new Command(DeliveryPage);

        }
        private async Task InitAsync()
        {
            DefaultLoadingView popUp = new DefaultLoadingView();

            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                popUp.IsLightDismissEnabled = false;
            }
            var task = await getLocalUserAsync();
            /* if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                 App.Current.MainPage.Navigation.ShowPopup(popUp);

             var sessionDataExist = App.SessionCache.CacheData.ContainsKey(CacheKeys.SessionUser.ToString());
             if (!sessionDataExist)
             {
                 var response = await CustomerAccountService.RetrieveUserInformationAsync(task.id);
                 Debug.WriteLine(response.data.ToJson());
                 App.SessionCache.CacheData.Add(CacheKeys.SessionUser.ToString(), response.data);

             }*/
            FirstName = "Hi " + task.PatientFirstName;
            //ProfilePicture = new Uri("user1");
            OptionsLoader.LoadOptions();
            Notifications = OptionsLoader.Notifications;
            NavigateToProfilePageCommand = new Command(ProfilePage);
            NavigateToAppointmentPageCommand = new Command(AppointmentPage);
            NavigateToCameraPageCommand = new Command(CameraPage); //Decommisioned until feature is avaliable
            NavigateToCheckInPageCommand = new Command(CheckIn);
            OpenNotificationCard = new Command(MockMethod);
            Title = _title;

            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                popUp.Dismiss(null);

        }
        private async void MockMethod()
        {
            await PopupNavigation.Instance.PushAsync(CardExpanded);

            await App.Current.MainPage.Navigation.PushAsync(new MedicationNotificatonView());
        }

        #region Methods

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

                #endregion Getting user location code
            }
            catch (Exception ex)
            {
                Debug.Write("Failed to get user location: " + ex.Data);
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
            //await App.Current.MainPage.Navigation.PushAsync(new DeliveryPage());
            //await App.Current.MainPage.Navigation.PushAsync(new SymptomsChecker());
            await App.Current.MainPage.Navigation.PushAsync(new Page1());
        }

        private async void CheckIn()
        {
            await App.Current.MainPage.Navigation.PushAsync(new CheckIn());
        }

        private async void CameraPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new CameraPage());
        }

        private async void MedicationDelvery(NotificationModel _SelectedCard)
        {
            if (Equals(_SelectedCard.Title, " "))
            {
                //await App.Current.MainPage.Navigation.PushAsync(new  );
            }
            else if (Equals(_SelectedCard.Title, " "))
            {
                //await App.Current.MainPage.Navigation.PushAsync(new );
            }
            else if (Equals(_SelectedCard.Title, "MEDICATION DELIVERY"))
            {
                await App.Current.MainPage.Navigation.PushAsync(new MedicationNotificatonView());
            }
        }

        #endregion Methods

        public void OnAppearing(HorizontalListView noticeBoardList, Label userName,
                                    Label message, Label noticeBoardLabel,
                                    Grid appointmentButton, Grid medicationButton,
                                    Grid scanButton)
        {
            const uint AnimationSpeed = 300;

            const uint shorterAnimationDuration = 1800;

            const uint longerAnimationDuration = 2000;

            noticeBoardList.TranslationX = 2000;

            userName.Opacity = 0;

            message.Opacity = 0;

            noticeBoardLabel.Opacity = 0;

            appointmentButton.TranslationX = 2000;

            medicationButton.TranslationX = 2000;

            scanButton.TranslationX = 2000;

            userName.FadeTo(1, shorterAnimationDuration, Easing.Linear);

            message.FadeTo(1, longerAnimationDuration, Easing.Linear);

            noticeBoardLabel.FadeTo(1, shorterAnimationDuration, Easing.Linear);

            appointmentButton.TranslateTo(0, 0, 1000, Easing.SinInOut);

            medicationButton.TranslateTo(0, 0, 1200, Easing.SinInOut);

            scanButton.TranslateTo(0, 0, 1400, Easing.SinInOut);

            noticeBoardList.TranslateTo(0, 0, (longerAnimationDuration + 300), Easing.SpringOut);
        }
    }
}