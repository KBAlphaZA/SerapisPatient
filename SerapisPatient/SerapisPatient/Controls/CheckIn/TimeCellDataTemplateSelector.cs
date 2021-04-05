using SerapisPatient.Models.CheckIn;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
//using TimeInfoType = UnZone.Models.TimeInfo.TimeInfoTypeEnum;
namespace SerapisPatient.Controls.CheckIn
{
    public  class TimeCellDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate PersonTemplate { get; set; }
        public DataTemplate YouTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            // have a look at the item and return the right type of cell
           // if (((TimeInfo)item).TimeInfoType == TimeInfoType.Person)
                return PersonTemplate;
            /*else
                return YouTemplate;
            return YouTemplate;*/

        }
    }
}
