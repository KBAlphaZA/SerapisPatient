using Plugin.Settings;
using Plugin.Settings.Abstractions;
using SerapisPatient.Services;
using System.Collections.Generic;

namespace SerapisPatient.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }


        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault;


        //PERSONAL SETTINGS
        public static string ProfilePicture
        {
            get
            {
                return AppSettings.GetValueOrDefault(nameof(ProfilePicture), string.Empty);
            }
            set
            {
                AppSettings.AddOrUpdateValue(nameof(ProfilePicture), value);
            }
        }


        public static string FirstName 
        {
            get 
            { 
                return AppSettings.GetValueOrDefault(nameof(FirstName), string.Empty); 
            }
            set 
            {
                AppSettings.AddOrUpdateValue(nameof(FirstName), value);
            }
        }

        public static string LastName 
        {
            get 
            { 
                return AppSettings.GetValueOrDefault(nameof(LastName), string.Empty); 
            }
            set 
            {
                AppSettings.AddOrUpdateValue(nameof(LastName), value);
            }
        }

        public static string Cellphone 
        {
            get 
            {
                return AppSettings.GetValueOrDefault(nameof(Cellphone), string.Empty);
            }
            set 
            {
                AppSettings.AddOrUpdateValue(nameof(Cellphone), value);
            }
        }

        public static string AltPhoneNumber 
        {
            get 
            {
                return AppSettings.GetValueOrDefault(nameof(AltPhoneNumber), string.Empty);
            }
            set 
            {
                AppSettings.AddOrUpdateValue(nameof(AltPhoneNumber), value);
            }
        }

        public static string Email 
        {
            get 
            {
                return AppSettings.GetValueOrDefault(nameof(Email), string.Empty);
            }
            set 
            {
                AppSettings.AddOrUpdateValue(nameof(Email), value);
            }
        }

        //public Gender Gender{get; set;}

        public static string DateOfBirth
        {
            get 
            { 
                return AppSettings.GetValueOrDefault(nameof(DateOfBirth), string.Empty); 
            }
            set
            {
                AppSettings.AddOrUpdateValue(nameof(DateOfBirth), value);
            }
        }

        public static List<string> ListOfNextOfKins { get; set; }

        //APPOINTMENT SEETINGS
        public static string MaximumDistance 
        {
            get 
            { 
                return AppSettings.GetValueOrDefault(nameof(MaximumDistance), string.Empty); 
            }
            set 
            {
                AppSettings.AddOrUpdateValue(nameof(MaximumDistance), value);
            } 
        }

        public static string UberRideRequestEnabled 
        {
            get 
            {
                return AppSettings.GetValueOrDefault(nameof(UberRideRequestEnabled), "Disabled");
            }
            set
            {
                AppSettings.AddOrUpdateValue(nameof(UberRideRequestEnabled), value);
            }
        }

        //DELIVERY SETTINGS


        //NOTIFICATIONS SETTINGS

        public static string GeneralSettings
        {
            get 
            { 
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault); 
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }



    }

}
