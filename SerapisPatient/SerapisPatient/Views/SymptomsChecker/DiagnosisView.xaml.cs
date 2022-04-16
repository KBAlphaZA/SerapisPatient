using SerapisPatient.ViewModels.SymptomsCheckerViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.SymptomsChecker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiagnosisView : ContentPage
    {
        DiagnosisViewModel viewModel;
        public DiagnosisView()
        {
            InitializeComponent();

            viewModel = new DiagnosisViewModel();
            BindingContext = viewModel;
            //OnDisappearing();
        }
        
        const uint AnimationSpeed = 300;
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            SymptomsActionPopUp.OnExpandTapped += ExpandPopup;
            SymptomsActionPopUp.CloseExpandedView += PageFader_Tapped;
        }

        protected sealed override void OnDisappearing()
        {
            base.OnDisappearing();
            SymptomsActionPopUp.OnExpandTapped -= ExpandPopup;
            SymptomsActionPopUp.CloseExpandedView -= PageFader_Tapped;
            viewModel.OnDisappearing();
        }
    
        private void SelectableItemsView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pageHeight = Height;
            var firstSection = SymptomsActionPopUp.FirstSectionHeight;
            PageFader.IsVisible = true;
            PageFader.FadeTo(1, AnimationSpeed, Easing.SinInOut);
            SymptomsActionPopUp.TranslateTo(0, pageHeight-firstSection, AnimationSpeed, Easing.SinInOut);
        }
        
        private void ExpandPopup()
        {
            var height = SymptomsActionPopUp.Height;

            SymptomsActionPopUp.TranslateTo(0, this.Height - height, AnimationSpeed, Easing.SinInOut);
        }

        private async void PageFader_Tapped()
        {
            await SymptomsActionPopUp.TranslateTo(0, Height, AnimationSpeed, Easing.SinInOut);
            await PageFader.FadeTo(0, AnimationSpeed, Easing.SinInOut);
            PageFader.IsVisible = false;
        }
    }
}