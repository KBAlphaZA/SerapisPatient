using SerapisPatient.Models;
using SerapisPatient.Utils;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using SerapisPatient.Services.DependencyServices;
using SerapisPatient.Views.AppointmentFolder.Booking;

namespace SerapisPatient.ViewModels
{
    public class SpecilizationViewModel:BaseViewModel
    {

        public List<SpecilizationModel> ListSpecilizations { get; private set; }

        public List<SpecilizationModel> TempList { get; set; }

        public ICommand SelectSpecilization => new Command(SelectTheSpeclizationAsync);


        public SpecilizationViewModel()
        {
            GenerateSpecilization();
        }

        private void SelectTheSpeclizationAsync()
        {
            //DependencyService.Get<ILoadingPageService>().ShowLoadingPage();
            App.Current.MainPage.Navigation.PushModalAsync(new SelectPractice());
        }
        

        private void GenerateSpecilization()
        {
            ListSpecilizations = new List<SpecilizationModel>()
            {
                new SpecilizationModel{ Title=FieldsOfExpertise.audiologist, Icon=FieldsOfExpertise.audiologyIcon},
                new SpecilizationModel{Title=FieldsOfExpertise.bioKineticist, Icon=FieldsOfExpertise.bioKineticistIcon},
                new SpecilizationModel{Title=FieldsOfExpertise.cardiologist, Icon=FieldsOfExpertise.cardioIcon},
                new SpecilizationModel{Title=FieldsOfExpertise.chiropractor, Icon=FieldsOfExpertise.chiropractorIcon},
                new SpecilizationModel{Title=FieldsOfExpertise.clicincalPsychologist, Icon=FieldsOfExpertise.clinicalIcon},
                new SpecilizationModel{Title=FieldsOfExpertise.dentalSurgeon, Icon=FieldsOfExpertise.dentalSurgeryIcon},
                new SpecilizationModel{Title=FieldsOfExpertise.dentist, Icon=FieldsOfExpertise.dentalSurgeryIcon2},
                new SpecilizationModel{Title=FieldsOfExpertise.dermatologist, Icon=FieldsOfExpertise.dermatologistIcon},
                new SpecilizationModel{Title=FieldsOfExpertise.dietician, Icon=FieldsOfExpertise.dieticianIcon},
                new SpecilizationModel{Title=FieldsOfExpertise.eNT_Specilist, Icon=FieldsOfExpertise.eNT_SpecilistIcon},
                new SpecilizationModel{Title=FieldsOfExpertise.gp, Icon=FieldsOfExpertise.gpIcon}, 
                new SpecilizationModel{Title=FieldsOfExpertise.gynaecologist, Icon=FieldsOfExpertise.gynaecologistIcon},
                new SpecilizationModel{Title=FieldsOfExpertise.haematology, Icon=FieldsOfExpertise.haematologyIcon},
                new SpecilizationModel{Title=FieldsOfExpertise.nerosurgeon, Icon=FieldsOfExpertise.neuroIcon},
                new SpecilizationModel{Title=FieldsOfExpertise.oncologist, Icon=FieldsOfExpertise.OncologyIcon},
                new SpecilizationModel{Title=FieldsOfExpertise.optometrist, Icon=FieldsOfExpertise.optomotristIcon},
                new SpecilizationModel{Title=FieldsOfExpertise.OrthopedicSurgeon, Icon=FieldsOfExpertise.OrthopaedicSurgeonIcon},
                new SpecilizationModel{Title=FieldsOfExpertise.paediatrician, Icon=FieldsOfExpertise.paediatricianIcon},
                new SpecilizationModel{Title=FieldsOfExpertise.physiotherapist, Icon=FieldsOfExpertise.physiotherapistIcon},
                new SpecilizationModel{Title=FieldsOfExpertise.plasticSurgeon, Icon=FieldsOfExpertise.plasticIcon},
                new SpecilizationModel{Title=FieldsOfExpertise.psychiatrist, Icon=FieldsOfExpertise.psychiatristIcon},
                new SpecilizationModel{Title=FieldsOfExpertise.radiologist, Icon=FieldsOfExpertise.radiologistIcon},
                new SpecilizationModel{Title=FieldsOfExpertise.urologist, Icon=FieldsOfExpertise.urologistIcon }
            };
        }


        private string searchProffesion;
        public string SearchProffesion
        {
            get
            {
                return searchProffesion;
            }
            set
            {
                searchProffesion = value;
                OnPropertyChanged("SearchProffesion");
                //an event needs to go here
                searchProffesion = value;
            }
        }

        //will go to the event handler
        private void Search()
        {
            char[] characterContainer = new char[SearchProffesion.Length];

            foreach (char character in characterContainer)
            {
                var result = from query in characterContainer
                             where query == character
                             select query;


            }
        }
        
    }
}
