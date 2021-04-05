using MvvmHelpers;
using SerapisPatient.Models.CheckIn;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SerapisPatient.ViewModels.TabbedViewModel
{
   
    public class CheckInViewModel : MvvmHelpers.BaseViewModel
    {
        public IList<TimeInfo> Locations { get; }

        public CheckInViewModel()
        {
            Locations = new ObservableCollection<TimeInfo>();

            Locations.Add(new TimeInfo() { UserName = "Kym", CurrentTime = "10:49", Location = "Medicross:Pinetown: Dr Duma", TimeZoneId = "Appointment", TimeInfoType = TimeInfo.TimeInfoTypeEnum.Person });
            Locations.Add(new TimeInfo() { UserName = "Frank", CurrentTime = "14:49", Location = "Berlin", TimeZoneId = "CST", TimeInfoType = TimeInfo.TimeInfoTypeEnum.Person });
            Locations.Add(new TimeInfo() { UserName = "Helen", CurrentTime = "23:00", Location = "Grey's Hospital: Dr Duma", TimeZoneId = "Check Up", TimeInfoType = TimeInfo.TimeInfoTypeEnum.Person });
            Locations.Add(new TimeInfo() { UserName = "You", CurrentTime = "23:00", Location = "Melborune", TimeZoneId = "AEST", TimeInfoType = TimeInfo.TimeInfoTypeEnum.You });
            Locations.Add(new TimeInfo() { UserName = "James", CurrentTime = "11:30", Location = "Seattle", TimeZoneId = "PST", TimeInfoType = TimeInfo.TimeInfoTypeEnum.Person });
        }
            

    }
}
