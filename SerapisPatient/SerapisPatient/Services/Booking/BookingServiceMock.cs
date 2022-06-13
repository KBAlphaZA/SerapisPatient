using SerapisPatient.Models.Doctor;
using System.Collections.ObjectModel;

namespace SerapisPatient.Services.Booking
{
    public class BookingServiceMock
    {
        private ObservableCollection<Doctor> GetDoctorListMock()
        {
            var Doctor = new ObservableCollection<Doctor>
            {
                //new Doctor{ LastName = "Zulu ", University="MBchB(Ukzn)",ProfileImageUrl="userplaceholder.png", FirstName="Bonga", Id=" ", practices=new List<object>(){" ", " " }, Qualifications=new List<Qualification>(){ new Qualification { Abbr=" ", Degree=" ", Graduated=12, Specilization="Gp", Specilizationabbr="GP", University="UKZN"}},  Time="9:00", YearsOfExp="20"},
                //new Doctor{ LastName = "Duma ", University="MBchB(UWC),FC Orth(SA),Mmed Ortho(Natal)",ProfileImageUrl="userplaceholder.png", FirstName="Zama", Id="", practices=new List<object>(){ }, Qualifications=new List<Qualification>(){ new Qualification { } },  Time="9:00", YearsOfExp="20"},
                //new Doctor{ LastName = "Moody ", University="MBchB(Wits)",ProfileImageUrl="userplaceholder.png", FirstName="John", Id="", practices=new List<object>(){ }, Qualifications=new List<Qualification>(){ new Qualification {} },  Time="9:00", YearsOfExp="30"},
                //new Doctor{ LastName = "McGhee ", University="MBchB(Stellenbosch)",ProfileImageUrl="userplaceholder.png", FirstName="Andiswa", Id="", practices=new List<object>(){ }, Qualifications=new List<Qualification>(){ new Qualification { } },  Time="9:00", YearsOfExp="13"}
                //new Doctor{ LastName = "Naidoo", University="MBchB(Ukzn)",ProfileImageUrl="userplaceholder.png"},
                //new Doctor{ LastName = "Ngwenya ", University="MBchB(UFS)",ProfileImageUrl="userplaceholder.png"},
                //new Doctor{ LastName = "Miller", University="MBchB(UWC),FC Orth(SA),Mmed Ortho(Natal)",ProfileImageUrl="userplaceholder.png"},
                //new Doctor{ LastName = "Ronaldo ", University="MBchB(Wits)",ProfileImageUrl="userplaceholder.png"},
                //new Doctor{ LastName = "Buthelezi ", University="MBchB(Stellenbosch)",ProfileImageUrl="userplaceholder.png"},
                //new Doctor{ LastName = "Moodley", University="MBchB(Ukzn)",ProfileImageUrl="userplaceholder.png"},
                //new Doctor{ LastName = "Matsoso ", University="MBchB(UP)",ProfileImageUrl="userplaceholder.png"},
                //new Doctor{ LastName = "Ngcobo ", University="MBchB(Stellenbosch)",ProfileImageUrl="userplaceholder.png"},
                //new Doctor{ LastName = "Muller", University="MBchB(UWC),FC Orth(SA),Mmed Ortho(Natal)",ProfileImageUrl="userplaceholder.png"},

            };

            return Doctor;
        }
         public void LoadDummyData()
         {
            /*
             InitalizeList(PatientCoordinates.Latitude, PatientCoordinates.Longitude, Convert.ToDouble(Settings.MaximumDistance));

             selectedItem = new Command<MedicalBuildingModel>(args => 
             {
                 _MedicalBuildingData = args;
                 HandleNavigation(_MedicalBuildingData);
             });


             PracticesList = new ObservableCollection<PracticeDto>()
             {
                new PracticeDto
                  {
                      DistanceFromPractice=7.8,
                      ContactPractice = new PracticeContact
                      {
                          PracticeTelephoneNumber = "031 701 456 43"
                      },
                      //Id=ObjectId.Parse("5bc9bd861c9d4400001badf1"),
                      NumOfPatientsInPractice=5,
                      PracticeName="Grey's Hospital",
                      PracticePicture="MedicrossPinetown.jpg",
                      OperatingTime="08h00-17h00"
                  },
                  new PracticeDto
                  {
                      DistanceFromPractice=7,
                      ContactPractice = new PracticeContact
                      {
                          PracticeTelephoneNumber = "031 701 456 43"
                      },
                      //Id=ObjectId.Parse("5bc9bde81c9d4400001badf2"),
                      NumOfPatientsInPractice=10,
                      PracticeName="Crompton Hospital",
                      PracticePicture="MedicrossPinetown.jpg",
                      OperatingTime="08h00-17h00"
                  },
                  new PracticeDto
                  {
                      DistanceFromPractice=6,

                      ContactPractice = new PracticeContact
                      {
                          PracticeTelephoneNumber = "031 701 456 43"
                      },
                      //Id=ObjectId.Parse("5bc9bd741c9d4400001badf0"),
                      NumOfPatientsInPractice=10,
                      PracticeName="Groote Schuur Hospital",
                      PracticePicture="MedicrossPinetown.jpg",
                      OperatingTime="08h00-17h00"
                  }
             };
        */
        }
    }
}
