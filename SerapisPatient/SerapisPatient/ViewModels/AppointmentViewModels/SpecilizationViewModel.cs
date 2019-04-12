using SerapisPatient.Models;
using SerapisPatient.Utils;
using SerapisPatient.ViewModels.Base;
using SerapisPatient.Views;
using System;
using SerapisPatient.Utils;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using SerapisPatient.Services.DependencyServices;
using SerapisPatient.Views.AppointmentFolder.Booking;
using Xamarin.Forms.BehaviorsPack;
using SerapisPatient.behavious;

namespace SerapisPatient.ViewModels
{
    public class SpecilizationViewModel : BaseViewModel
    {
        object CopyOfList;

        #region Properties
        public SpecilizationModel _specilizationData;
        public List<SpecilizationModel> ListSpecilizations { get; set; }
        public List<SpecilizationModel> TempList { get; set; }
        public NotificationRequest NavigateNextPageRequest { get; } = new NotificationRequest();
        public SpecilizationModel sub = new SpecilizationModel();
        #endregion

        public SpecilizationViewModel()
        {
            ShowUI = true;
            GenerateSpecilization();
            
        }

        public ICommand SpecilizationSelectCommand => new Command<SpecilizationModel>(selectspecialization =>
        {
            NavigateNextPageRequest.Raise(new SelectedItemEvent { SelectedSpecilization = selectspecialization });
            _specilizationData = selectspecialization;
            
            //MessagingCenter.Send<SpecilizationModel,string>(sub, "New", _specilizationModel.Title);           
           // MessagingCenter.Send(_specilizationModel, "New");

            SelectTheSpeclizationAsync(_specilizationData);
        });
        private void SelectTheSpeclizationAsync(SpecilizationModel _specilizationData)
        {
            //DependencyService.Get<ILoadingPageService>().ShowLoadingPage();
           App.Current.MainPage.Navigation.PushAsync(new SelectPractice(_specilizationData),true);
        }
        
        //List
        
        private void GenerateSpecilization()
        {
            ListSpecilizations = new List<SpecilizationModel>()
            {
                new SpecilizationModel{ Title=FieldsOfExpertise.audiologist, Icon=FieldsOfExpertise.audiologyIcon, Description=FieldsOfExpertise.audiologist_Description },
                 new SpecilizationModel{Title=FieldsOfExpertise.bioKineticist, Icon=FieldsOfExpertise.bioKineticistIcon,Description=FieldsOfExpertise.biokineticist_Description},
                  new SpecilizationModel{Title=FieldsOfExpertise.cardiologist, Icon=FieldsOfExpertise.cardioIcon,Description=FieldsOfExpertise.cardiologist_Description},
                   new SpecilizationModel{Title=FieldsOfExpertise.chiropractor, Icon=FieldsOfExpertise.chiropractorIcon,Description=FieldsOfExpertise.chiropractor_Description},
                    new SpecilizationModel{Title=FieldsOfExpertise.clicincalPsychologist, Icon=FieldsOfExpertise.clinicalIcon,Description=FieldsOfExpertise.clicincalPsychologist_Description},
                     new SpecilizationModel{Title=FieldsOfExpertise.dentalSurgeon, Icon=FieldsOfExpertise.dentalSurgeryIcon, Description=FieldsOfExpertise.dentalSurgeon_Description},
                      new SpecilizationModel{Title=FieldsOfExpertise.dentist, Icon=FieldsOfExpertise.dentalSurgeryIcon2, Description=FieldsOfExpertise.dentist_Description},
                       new SpecilizationModel{Title=FieldsOfExpertise.dermatologist, Icon=FieldsOfExpertise.dermatologistIcon,Description=FieldsOfExpertise.dermatologist_Description},
                        new SpecilizationModel{Title=FieldsOfExpertise.dietician, Icon=FieldsOfExpertise.dieticianIcon,Description=FieldsOfExpertise.dietician_Description},
                         new SpecilizationModel{Title=FieldsOfExpertise.eNT_Specilist, Icon=FieldsOfExpertise.eNT_SpecilistIcon, Description=FieldsOfExpertise.eNT_Specilist_Description},
                          new SpecilizationModel{Title=FieldsOfExpertise.gp, Icon=FieldsOfExpertise.gpIcon,Description=FieldsOfExpertise.audiologist_Description}, 
                           new SpecilizationModel{Title=FieldsOfExpertise.gynaecologist, Icon=FieldsOfExpertise.gynaecologistIcon,Description=FieldsOfExpertise.audiologist_Description},
                            new SpecilizationModel{Title=FieldsOfExpertise.haematology, Icon=FieldsOfExpertise.haematologyIcon,Description=FieldsOfExpertise.audiologist_Description},
                             new SpecilizationModel{Title=FieldsOfExpertise.nerosurgeon, Icon=FieldsOfExpertise.neuroIcon, Description=FieldsOfExpertise.nerosurgeon_Description},
                              new SpecilizationModel{Title=FieldsOfExpertise.oncologist, Icon=FieldsOfExpertise.OncologyIcon,Description=FieldsOfExpertise.audiologist_Description},
                               new SpecilizationModel{Title=FieldsOfExpertise.optometrist, Icon=FieldsOfExpertise.optomotristIcon,Description=FieldsOfExpertise.audiologist_Description},
                                new SpecilizationModel{Title=FieldsOfExpertise.OrthopedicSurgeon, Icon=FieldsOfExpertise.OrthopaedicSurgeonIcon,Description=FieldsOfExpertise.audiologist_Description},
                                 new SpecilizationModel{Title=FieldsOfExpertise.paediatrician, Icon=FieldsOfExpertise.paediatricianIcon,Description=FieldsOfExpertise.audiologist_Description},
                                  new SpecilizationModel{Title=FieldsOfExpertise.physiotherapist, Icon=FieldsOfExpertise.physiotherapistIcon,Description=FieldsOfExpertise.audiologist_Description},
                                   new SpecilizationModel{Title=FieldsOfExpertise.plasticSurgeon, Icon=FieldsOfExpertise.plasticIcon,Description=FieldsOfExpertise.audiologist_Description},
                                    new SpecilizationModel{Title=FieldsOfExpertise.psychiatrist, Icon=FieldsOfExpertise.psychiatristIcon,Description=FieldsOfExpertise.audiologist_Description},
                                     new SpecilizationModel{Title=FieldsOfExpertise.radiologist, Icon=FieldsOfExpertise.radiologistIcon,Description=FieldsOfExpertise.radiologist_Description},
                                      new SpecilizationModel{Title=FieldsOfExpertise.urologist, Icon=FieldsOfExpertise.urologistIcon,Description=FieldsOfExpertise.audiologist_Description }
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
                Search(SearchProffesion);
            }
        }

        #region Methods
        //will go to the event handler
        private  List<SpecilizationModel> Search(string queryText)
        {
            string capdQueryText = queryText.Substring(0, 1).ToUpper() + queryText.Substring(1,queryText.Length-1);
                   
            //Run Procedural method
            Procedural();

            var arrayOfQueryString = capdQueryText.ToArray();
            
            //Add each letter of the string to the declared char array
            
                for(int i=0; i< capdQueryText.Length; i++) 
                {
                    int j = 0;
                                  
                    //charcterContainer must compare the Title string in listSpec
                   
                    //Returns A twice when i enter a second char
                    foreach(var item in TempList)
                    {
                         if(item.Title[j] == arrayOfQueryString[i])
                         {
                           //Perform a check if object exists in the list & Edit the list
                           CheckListIfExist(item);
                        
                        //Usecase: string 1 = dentist & string 2 = diet 
                            if (item.Title[j] != arrayOfQueryString[i])
                            {
                              ListSpecilizations.Remove(item);
                            }
                         }
                    }

                    j++;
                }
            return ListSpecilizations;
            
        }

        // start Method 
        private void Procedural() 
        {
            //First copy Everything To temp list
            TempList = new List<SpecilizationModel>();

            foreach(var specility in ListSpecilizations) 
            {
                TempList.Add(specility);
            }

            //Then clear ListSpec..., first check if empty or not
            if(ListSpecilizations != null) 
            {
                ListSpecilizations.Clear();
            }

        }
        
        private void CheckListIfExist(SpecilizationModel item)
        {
            //Perform a check here
            if (!ListSpecilizations.Exists(x => x.Title == item.Title))
            {            
                //add all matches to Mainlist
                ListSpecilizations.Add(item);

                //ListSpecilizations


                
            }
            
        }
        
        #endregion
    }
}
