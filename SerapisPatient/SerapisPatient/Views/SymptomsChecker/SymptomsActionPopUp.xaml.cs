using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.SymptomsChecker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SymptomsActionPopUp : ContentView
    {
        public delegate void ClickExpandDelegate();

        public ClickExpandDelegate OnExpandTapped { get; set; }
        
        public SymptomsActionPopUp()
        {
            InitializeComponent();
        }
        
        public double FirstSectionHeight => FirstSection.Height;

        private void FirstSection_Tapped(object sender, EventArgs e)
        {
            OnExpandTapped?.Invoke();
        }
    }
}