namespace SerapisPatient.Helpers
{
    public static class ConstantValues
    {
        public static string GoogleScope = "https://www.googleapis.com/auth/userinfo.email";
        public static string GoogleAndroidRedirectUri = "com.googleusercontent.apps.660976645428-r9kcb5cera105cfd60k8cmvuk15fbdlk.apps.googleusercontent.com:/oauth2redirect";


        public static string StartSessionCode = "00";
        public static string ResumeSessionCode = "01";



        //SerapisMedical API ENDPOINTS
        public static string SerapisMedical_Heroku_BaseEndpoint = "https://serapismedicalapi.herokuapp.com/api";
        public static string SerapisMedical_Azure_BaseEndpoint = "http://serapismedicalapi.azurewebsites.net/api";
        public static string SerapisMedical_Register_User_Via_Cell_And_Password = "/v1/Auth/supabase/register";
        public static string SerapisMedical_Login_User_Via_Cell_And_Password = "/v1/Auth/supabase/login";
        

    }
}