
using MongoDB.Bson;
using SerapisPatient.Models;
using SerapisPatient.Models.Entities;
using SerapisPatient.Services.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SerapisPatient.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        SessionContext _sessionContext = new SessionContext();
        public BaseViewModel()
        {
            _sessionContext.CacheData = new Dictionary<string, object>();
        }

        #region Propertychanged events

        public event PropertyChangedEventHandler PropertyChanged;

        public async Task<PatientDao> getLocalUserAsync()
        {
            RealmDBService<PatientDao> userDb = new RealmDBService<PatientDao>();
            var LocalUser = await userDb.RetrieveDocumentAsync();
            if (LocalUser != null)
            {
                Debug.WriteLine("DB user =>" + LocalUser.ToJson());
                FirstName = "Hi " + LocalUser.PatientFirstName;
                //ProfilePicture = (LocalUser.PatientProfilePicture == null) ? new Uri("user1") : new Uri(LocalUser.PatientProfilePicture);
                    //new Uri(LocalUser.PatientProfilePicture ) ?? new Uri("user1");
                    ProfilePicture ="user1.png";
                return LocalUser;
            }
            //TODO: Need to remove this session cache( after Alpha release)
            /*var sessionUser = App.SessionCache.CacheData[CacheKeys.SessionUser.ToString()] as PatientAuthResponse;
            var patient = sessionUser.PatientData;
            return new PatientDao() { PatientFirstName = $"Hi {patient.PatientFirstName}" };*/
            return new PatientDao(){ PatientFirstName = "Hi User"};
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));

            }
        }

        #region Horizontalscroll code
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion


        #endregion


        public SessionContext SessionCache
        {
            get { return _sessionContext; }
            set { SetProperty(ref _sessionContext, value); }
        }

        private string profilePicture;

        public string ProfilePicture
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

        private bool isBusy;
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
                isBusy = value;
            }
        }
        // ShowUI is for the xamrin IsEnabled feature
        private bool showUI;
        public bool ShowUI
        {
            get
            {
                return showUI;
            }
            set
            {
                showUI = value;
                OnPropertyChanged("ShowUI");
                showUI = value;
            }
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
                OnPropertyChanged("Title");
                title = value;
            }
        }

        //Use this one for changing strings
        public void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
