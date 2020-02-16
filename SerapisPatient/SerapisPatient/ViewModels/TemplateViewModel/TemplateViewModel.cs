using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.BehaviorsPack;

namespace SerapisPatient.ViewModels.TemplateViewModel
{
    public class TemplateViewModel
    {
        #region Properties
        public Command TestCommand { get; set; }
        #endregion

        #region Constructor
        public TemplateViewModel()
        {
            TestCommand = new Command(() => TestMethod());
        }
        #endregion

        #region Methods
        private void TestMethod() 
        {
            DisplayActionSheetRequest dp=new DisplayActionSheetRequest();
            dp.Raise("Worked");
        }
        #endregion
    }
}
