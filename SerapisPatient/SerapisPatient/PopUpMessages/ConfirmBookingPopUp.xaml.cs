using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.PopUpMessages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirmBookingPopUp : ContentView
    {
        public ConfirmBookingPopUp()
        {
            InitializeComponent();
        }
       
        public delegate void ClickExpandDelegate();
        
        public ClickExpandDelegate OnExpandTapped { get; set; }
        public double FirstSectionHeight
        {
            get
            {
                return FirstSection.Height;
            }
        }
        private void FirstSection_Tapped(object sender, EventArgs e)
        {
            OnExpandTapped?.Invoke();
        }
    }
}