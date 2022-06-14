using System;
using SerapisPatient.Models.Appointments;
using SerapisPatient.Models.Doctor;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MongoDB.Bson;
using SerapisPatient.Enum;
using SerapisPatient.Models.Bookings;
using SerapisPatient.Models.Patient;
using SerapisPatient.Services.Data;
using SerapisPatient.TemplateViews;
using SerapisPatient.Utils;
using SerapisPatient.ViewModels.Base;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels.SideMenuViewModel
{
    public class AppointmentHistoryViewModel : BaseViewModel
    {

        public ObservableCollection<PatientBookingDto> AppointmentHistoryList { get; private set; }
        public ICommand RefreshCommand { get; set; }

        public AppointmentHistoryViewModel()
        {
            //GenerateDummy();
            RefreshCommand = new Command(() => RefreshList());
            LoadRealData();
        }

        private async void RefreshList()
        {
            IsBusy = true;
            try
            {
                var response = await CustomerAccountService.RetrievePatientBookingInformationAsync(App.SessionCache.UserInfo.id);
                AppointmentHistoryList.Clear();
                AppointmentHistoryList = response.data;
                App.SessionCache.CacheData[CacheKeys.BookingHistory.ToString()] = AppointmentHistoryList;
                
                //AppointmentHistoryList = (ObservableCollection<PatientBookingDto>)App.SessionCache.CacheData[CacheKeys.BookingHistory.ToString()];
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }


        


        private async void LoadRealData()
        {
             await OnAppearing();
            
        }

        internal async Task<ObservableCollection<PatientBookingDto>> OnAppearing()
        {

            DefaultLoadingView popUp = new DefaultLoadingView();
            try
            {
                var current = Connectivity.NetworkAccess;

                if (current != NetworkAccess.Internet)
                {
                    return new ObservableCollection<PatientBookingDto>();
                }

                if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                {
                    popUp.IsLightDismissEnabled = false;
                }

                if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                    App.Current.MainPage?.Navigation.ShowPopup(popUp);

                var sessionDataExist = App.SessionCache.CacheData.ContainsKey(CacheKeys.BookingHistory.ToString());
                if ( !sessionDataExist )
                {
                    var task = await base.getLocalUserAsync();
                    var response = await CustomerAccountService.RetrievePatientBookingInformationAsync(task.id);

                    Debug.WriteLine("AppointmentHistoryViewModel: " + response.data.ToJson());

                    if (response?.data != null)
                    {
                        App.SessionCache.CacheData.Add(CacheKeys.BookingHistory.ToString(), response.data);
                    }

                }
                
                AppointmentHistoryList = (ObservableCollection<PatientBookingDto>)App.SessionCache.CacheData[CacheKeys.BookingHistory.ToString()];

                if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                    popUp.Dismiss(null);

                return App.SessionCache.CacheData[CacheKeys.BookingHistory.ToString()] as ObservableCollection<PatientBookingDto>;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                    popUp.Dismiss(null);
                //We failed to get Booking History, clear their token and make them login again
                return new ObservableCollection<PatientBookingDto>();

            }
        }

    }
}
