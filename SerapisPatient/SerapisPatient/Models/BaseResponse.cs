using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models
{
    public class BaseResponse<TObject> where TObject : class
    {
        public bool status { get; set; }
        public string message { get; set; }
        public TObject data { get; set; }
        public string StatusCode { get; set; }
    }
}
