using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.PopUpMessages.NotificationsPopUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckUpPopUp : ContentView
    {
        public delegate void ClickExpandDelegate();

        public ClickExpandDelegate OnExpandTapped { get; set; }

        public CheckUpPopUp()
        {
            InitializeComponent();
        }
        public double FirstSectionHeight
        {
            get
            {
                return FirstSection.Height;
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            OnExpandTapped?.Invoke();
        }
    }
}