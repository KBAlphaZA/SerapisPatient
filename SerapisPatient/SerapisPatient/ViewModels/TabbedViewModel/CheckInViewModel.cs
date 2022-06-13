using SerapisPatient.Models.CheckIn;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SerapisPatient.ViewModels.TabbedViewModel
{
   
    public class CheckInViewModel : MvvmHelpers.BaseViewModel
    {
        public IList<TimeInfo> Locations { get; }

        public CheckInViewModel()
        {
            Locations = new ObservableCollection<TimeInfo>();

            Locations.Add(new TimeInfo() { UserName = "Dr Duma", CurrentTime = "10:49", Location = "@Medicross:Pinetown", TimeZoneId = "Appointment", TimeInfoType = TimeInfo.TimeInfoTypeEnum.Person });
            Locations.Add(new TimeInfo() { UserName = "Dr Ngcobo", CurrentTime = "14:49", Location = "@Medicross:Malvern", TimeZoneId = "Appointment", TimeInfoType = TimeInfo.TimeInfoTypeEnum.Person });
            Locations.Add(new TimeInfo() { UserName = "Dr Duma", CurrentTime = "23:00", Location = "Grey's Hospital", TimeZoneId = "Check Up", TimeInfoType = TimeInfo.TimeInfoTypeEnum.Person });
 
        }
            

    }
}
