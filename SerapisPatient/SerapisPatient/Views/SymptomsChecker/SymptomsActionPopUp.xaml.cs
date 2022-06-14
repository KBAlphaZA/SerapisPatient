using System;
using SerapisPatient.ViewModels.SymptomsCheckerViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.SymptomsChecker
{
    [XamlCompilation(XamlCompilationOptions.Skip)]
    public partial class SymptomsActionPopUp : ContentView
    {
        SymptomsActionPopUpViewModel viewModel;
        public delegate void ClickExpandDelegate();
        public delegate void PageFaderDelegate();

        public ClickExpandDelegate OnExpandTapped { get; set; }
        public PageFaderDelegate CloseExpandedView { get; set; }
        
        public SymptomsActionPopUp()
        {
            InitializeComponent();
            
            viewModel = new SymptomsActionPopUpViewModel();
            BindingContext = viewModel;
        }
        
        public double FirstSectionHeight => FirstSection.Height;

        private void FirstSection_Tapped(object sender, EventArgs e)
        {
            OnExpandTapped?.Invoke();
            CloseExpandedView?.Invoke();
        }

        private async void SelectableItemsView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }
    }
}