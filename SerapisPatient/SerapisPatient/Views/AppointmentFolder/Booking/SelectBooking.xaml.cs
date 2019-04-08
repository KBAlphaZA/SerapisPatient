using SerapisPatient.Models;
using SerapisPatient.Models.Appointments;
using SerapisPatient.ViewModels.AppointmentViewModels.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.AppointmentFolder.Booking
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectBooking : ContentPage
	{
        SelectBookingViewModel viewModel;
        public string DateSelected;
		public SelectBooking(MedicalBuildingModel _MedicalBuildingData)
		{
			InitializeComponent ();

            BindingContext = new SelectBookingViewModel(_MedicalBuildingData);
            MessagingCenter.Subscribe<SelectBookingViewModel, SelectedMonths>(this, "ItemSelected", (obj, item) =>
            {
                DisplayAlert("Alert", "You've choosen the date " + item.MonthValue, "cancel");
                DateSelected = item.MonthValue.ToString();
            });

        }

        //private async void ViewCell_Disappearing(object sender, EventArgs e)
        //{

        //    var viewCell = (ViewCell)sender;
        //    await viewCell.View.TranslateTo(300, 0, 500, Easing.BounceOut);
        //    ViewExtensions.CancelAnimations(viewCell.View);
        //}
        //protected override void OnDisappearing()
        //{
        //    InitializeComponent();
        //    base.OnDisappearing();
        //}
        
    }
}