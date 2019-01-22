using Rg.Plugins.Popup.Extensions;
using SerapisPatient.PopUpMessages;
using SerapisPatient.Services;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views.MainViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        APIServices _APIServices = new APIServices();
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Message { get; set; }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {

                    await RegisterUser();
                    //consuming webservices
                    //var isSuccess = await _APIServices.RegisterAsync(Email, Password, ConfirmPassword);

                    //if (isSuccess)
                    //    Message = "Registered successfully";
                    //else
                    //{
                    //    Message = "Retry Later";
                    //}
                });
            }
        }

        private async Task RegisterUser()
        {
            try
            {
                IsBusy = true;
                var rootpage = App.Current.MainPage.Navigation.NavigationStack.FirstOrDefault();
                if(rootpage != null)
                {
                    //App.CheckLogin = true;
                    await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("S", "You Successfully Registered"));
                    App.Current.MainPage.Navigation.InsertPageBefore(new MasterView(), App.Current.MainPage.Navigation.NavigationStack.First());

                   // await Task.Delay(600);
                    await App.Current.MainPage.Navigation.PopToRootAsync();
                }
                //App.Current.MainPage = null;
                //App.Current.MainPage.Navigation.RemovePage
                
                //App.Current.MainPage = new MasterView();
            }
            catch(Exception e)
            {

            }
            finally
            {
                IsBusy = false;
            }

            
        }
    }
}
