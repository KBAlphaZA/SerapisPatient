using System;
using MongoDB.Bson;
using Realms;
using SerapisPatient.Models;
using SerapisPatient.Models.Patient;
using SerapisPatient.Services.Data;
using SerapisPatient.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using SerapisPatient.TemplateViews;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels.TabbedViewModel
{
    public class ProfilePageViewModel : BaseViewModel
    {

        public ProfilePageViewModel()
        {
            _realm = Realm.GetInstance();
            Profile = App.SessionCache.UserInfo;
            //Profile = App.CurrentUser;
            ProfilePageViewModelInit();
            
            LoadMoreIcons = new Command(LoadMore);
        }
        public async void ProfilePageViewModelInit()
        {
           
            //(Patient)App.SessionCache.CacheData[CacheKeys.SessionUser.ToString()];

            //var userDb = new RealmDBService<PatientDao>();
            //var dbuser = await userDb.RetrieveDocumentAsync();
            //var sessionDataExist = App.SessionCache.CacheData.ContainsKey(CacheKeys.SessionUser.ToString());
            /*if (!sessionDataExist || App.SessionCache.CacheData[CacheKeys.SessionUser.ToString()] == null )
            {
                
                var response = await CustomerAccountService.RetrieveUserInformationAsync(dbuser.id);
                Debug.WriteLine(response.data.ToJson());
                App.SessionCache.CacheData.Add(CacheKeys.SessionUser.ToString(), response.data);
                //SessionUser = response.data;

            }*/

            Debug.WriteLine("DB USER =>" + profile.ToJson());
            FirstName = profile.PatientFirstName;
            MyAge = (profile.PatientAge);
            //MyAge = dbuser.PatientBloodType;
            GenerateList();
        }

        private void GenerateList()
        {
            PatientCondtions = new ObservableCollection<ProfileModel>()
            {
                new ProfileModel{Icon="MyAge.png", SubTitle="Age", Title="22" },
                new ProfileModel{Icon="MyMedicalAid.png", SubTitle="Medical Aid", Title="Bonits" },
                new ProfileModel{Icon="MyGender.png", SubTitle="Gender", Title="Male" },
                new ProfileModel{Icon="MyBloodType.png", SubTitle="Blood type", Title="A+" }
            };
        }

        public async Task OnAppearing()
        {
            try
            {

                //var task = await base.getLocalUserAsync();

                DefaultLoadingView popUp = new DefaultLoadingView();

                if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                {
                    popUp.IsLightDismissEnabled = false;
                }

                if (App.SessionCache.UserInfo != null)
                {
                    return;
                }
                
                if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                    App.Current.MainPage?.Navigation.ShowPopup(popUp);
                var sessionDataExist = App.SessionCache.UserInfo;
                //var sessionDataExist = App.SessionCache.CacheData.ContainsKey(CacheKeys.SessionUser.ToString());
                if (sessionDataExist is null)
                {
                    var response = await CustomerAccountService.RetrieveUserInformationAsync(null);

                    Debug.WriteLine("MainViewModel: " + response.data.ToJson());

                    if (response?.data != null)
                    {
                        //App.SessionCache.CacheData.Add(CacheKeys.SessionUser.ToString(), response.data);
                        App.SessionCache.UserInfo = response.data;
                    }
                    else
                    {
                        //App.Current.MainPage.
                        App.Current.MainPage.Navigation.PopAsync();

                    }


                }

                if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
                    popUp.Dismiss(null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
        }
        private void LoadMore()
        {
            ProfileModel allergies = new ProfileModel()
            {
                Icon = "MyAllergies.png",
                Title = "Allergies"
            };
        }

        #region Properties

        public ObservableCollection<ProfileModel> PatientCondtions { get; set; }
        public Command LoadMoreIcons { get; set; }
        public Realm _realm;
        
        private Patient profile;

        public Patient Profile
        {
            get { return profile; }
            set { profile = value; }
        } 
            
        private string firstname;

        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; }
        }

        private int myage;

        public int MyAge
        {
            get { return myage; }
            set { myage = value; }
        }

        #endregion

    }
}