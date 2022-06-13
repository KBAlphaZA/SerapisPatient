using System;
using System.ComponentModel;

namespace SerapisPatient.Models
{
    public class UserProfile : INotifyPropertyChanged
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public Uri Picture { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
