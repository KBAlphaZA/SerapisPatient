using System;

namespace SerapisPatient.Models
{
    public class NotificationModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Type { get; set; }
    }

    public partial class NotificationDetailModel
    {
        public string Status { get; set; }
        public string DeliveryMode { get; set; }
        public DateTime Time { get; set; }
    }

   

   


}
