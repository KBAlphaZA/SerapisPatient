using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Models
{
    public class ErrorLog
    {
        public DateTime LogDateAndTime { get; set; }

        public uint LevelOfSeverity { get; set; }

        public ObjectId UserLoggingId { get; set; }

        public string Tag { get; set; }

        public string Message { get; set; }
    }
}
