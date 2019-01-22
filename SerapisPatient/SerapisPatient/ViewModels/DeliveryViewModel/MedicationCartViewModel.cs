using SerapisPatient.Models.Delivery;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SerapisPatient.ViewModels.DeliveryViewModel
{
    public class MedicationCartViewModel
    {
        public ObservableCollection<Prescription> Basket { get; private set; }

        public MedicationCartViewModel()
        {
            GenerateMedicalBuildingModel();
        }

        private void GenerateMedicalBuildingModel()
        {
            Basket = new ObservableCollection<Prescription>
            {
                new Prescription{ MedicationName ="CoughSyrup", Price=25},
                new Prescription{ MedicationName ="Painkillers", Price=35},
                new Prescription{ MedicationName ="CoughSyrup", Price=25},
                new Prescription{ MedicationName ="Painkillers", Price=65},

            };


        }
    }
}
