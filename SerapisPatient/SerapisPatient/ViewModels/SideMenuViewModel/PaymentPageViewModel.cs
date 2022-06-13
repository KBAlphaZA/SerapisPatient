using SerapisPatient.Models.PaymentModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;
using SerapisPatient.PopUpMessages;

namespace SerapisPatient.ViewModels.SideMenuViewModel
{
    public class PaymentPageViewModel
    {

        private PaymentMethodPopUp popUp;
        private PromotionCodeEntryPopUp promoPopUp;
        public PaymentPageViewModel()
        {
            GeneratePaymentOptions();
            popUp = new PaymentMethodPopUp();
            promoPopUp = new PromotionCodeEntryPopUp();
            AddMethodCommand = new Command(PopUpMessage);
            PromotionCommand = new Command(PopUpMessageEntry);
        }

        public ObservableCollection<PaymentOptions> PaymentMethods { get; set; }

        public Command AddMethodCommand { get; set; }

        public Command PromotionCommand { get; set; }

        private const string CashTitle = "Cash";

        private void GeneratePaymentOptions()
        {
            PaymentMethods = new ObservableCollection<PaymentOptions>()
            {

                new PaymentOptions
                {
                    Icon = "mastercardIcon.png",
                    Title = "****8574"
                },
                new PaymentOptions
                {
                    Icon = "cashIcon.png",
                    Title = CashTitle
                }
            };
        }

        private void PopUpMessage()
        {
            //pop up with methods of payment
            PopupNavigation.Instance.PushAsync(popUp);
        }

        private void PopUpMessageEntry()
        {
            //pop up with promotion code entry
            PopupNavigation.Instance.PushAsync(promoPopUp);
        }

    }
}
