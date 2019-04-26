using CarouselView.FormsPlugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

//Might have to delete

namespace SerapisPatient.Controls
{
    public class CarouselControl
    {
        public CarouselControl()
        {
            InitalizeCarousel();
        }

        private void InitalizeCarousel()
        {
            //For Now a set 10, but should get that number from backend
            int NumberOfwindows = 10;

            var myCarousel = new CarouselViewControl();

            myCarousel.ItemsSource = new ObservableCollection<int> { NumberOfwindows };
        }
    }
}
