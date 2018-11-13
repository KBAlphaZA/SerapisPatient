using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SerapisPatient.CustomRenderer
{
    public class DynamicEditor:Editor
    {
        public DynamicEditor()
        {
            this.TextChanged += (sender, args) => 
            {
                this.InvalidateMeasure();
            };
        }

    }
}
