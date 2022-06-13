using SerapisPatient.ViewModels;
using SerapisPatient.Views.DeliveryFolder;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChatBot : ContentPage
	{
		public ChatBot ()
		{
			InitializeComponent ();
            this.BindingContext = new ChatBotViewModel();
            
        }
        public void ScrollTap(object sender, System.EventArgs e)
        {
            lock (new object())
            {
                if (BindingContext != null)
                {
                    var vm = BindingContext as ChatBotViewModel;

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        while (vm.DelayedMessages.Count > 0)
                        {
                            vm.Messages.Insert(0, vm.DelayedMessages.Dequeue());
                        }
                        vm.ShowScrollTap = false;
                        vm.LastMessageVisible = true;
                        vm.PendingMessageCount = 0;
                        ChatList?.ScrollToFirst();
                    });


                }

            }
        }
        public void OnListTapped(object sender, ItemTappedEventArgs e)
        {
            chatInput.UnFocusEntry();
        }

        private void MenuItem1_Clicked(object sender, EventArgs e)
        {
           
                Navigation.PushAsync(new MedicationCart());
            
        }
    }
}