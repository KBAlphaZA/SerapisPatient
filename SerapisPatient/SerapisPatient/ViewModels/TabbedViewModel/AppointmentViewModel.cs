using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels.TabbedPageViewModel
{
    public class AppointmentViewModel:BaseViewModel
    {
        public Command BookByDate { get; set; }

        public Command SerapisBooking { get; set; }

        //Title Of the Page
        private readonly string _title = "Set Appointment";

        public AppointmentViewModel()
        {
            BookByDate = new Command(NavigateToBookByDate);
            SerapisBooking = new Command(NavigateToSerapisBooking);

            Title = _title;
        }


        private void NavigateToBookByDate()
        {
            //App.Current.MainPage.Navigation.PushModalAsync(new Specilization());

            //Pause to allow the animation to run
             Task.Delay(4000);

             App.Current.MainPage.Navigation.PushAsync(new Specilization());
        }

        private void NavigateToSerapisBooking()
        {
            // App.Current.MainPage.Navigation.PushModalAsync(new Specilization());     

            //Pause to allow the animation to run
             Task.Delay(4000);

            App.Current.MainPage.Navigation.PushAsync(new Specilization(),true);
        }

    }
}
