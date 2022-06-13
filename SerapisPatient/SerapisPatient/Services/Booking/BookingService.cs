using SerapisPatient.Models.Doctor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerapisPatient.Services.Booking
{
    public class BookingService : IBookingService
    {
        private readonly APIServices _apiServices = new APIServices();
        public async Task<List<Doctor>> GetDoctors()
        {

            var DoctorAvaliable = await _apiServices.GetDoctorsAsync();

            return DoctorAvaliable;

        }
    }
}
