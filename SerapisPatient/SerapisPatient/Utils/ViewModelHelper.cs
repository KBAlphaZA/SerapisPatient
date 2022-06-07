using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using Rg.Plugins.Popup.Extensions;
using SerapisPatient.Enum;
using SerapisPatient.Models.Entities;
using SerapisPatient.Models.SymptomsChecker;
using SerapisPatient.PopUpMessages;
using SerapisPatient.Services.DB;
using SerapisPatient.Views;
using Xamarin.Forms;

namespace SerapisPatient.Utils
{
    public static class ViewModelHelper
    {
        
        public async static Task<SymptomsListData> GroupSymptoms(List<Symptoms> unGroupedList)
        {

            // Want to group Symptoms by 5 and make it its own list
            SymptomsListData groupedList = new SymptomsListData();
            ViewSymptoms viewSymptoms = new ViewSymptoms();
            int k = 1;
            int j = 1;
            int counter = 0;
            for (int x = 0; x < 5; ++x)
            {
                ViewSymptoms symptoms = new ViewSymptoms();
                for (int i = 0; i < 5; ++i)
                {
                    string key = "Item" + k;
                    Debug.WriteLine("We are now storing Symptom name:  " +unGroupedList[counter].Name);
                    viewSymptoms.GetType().GetProperty(key)?.SetValue(symptoms , unGroupedList[counter].Name);
                    ++k;
                    counter++;
                }
                
                k = 1;
                string key2 = "Item" + j;
                groupedList.GetType().GetProperty(key2)?.SetValue(groupedList, symptoms);
                ++j;
            }

            return groupedList;
        }

        public static Color DetermineProgressBarColorByValue(double percentage)
        {
            if (percentage > 0.75)
            {
                return Color.Red;
            }
            if (0.75 > percentage && percentage > 0.35)
            {
                return Color.Orange;
            }
            return Color.Green;
        }

        public static Dictionary<String, object> HandleCachingListObject<T>(Dictionary<String, object> CacheData,string Cachekey ,T data)
        {
            List<T> list = new List<T>();
            if (CacheData.ContainsKey(Cachekey))
            {
                var listObj = (List<T>) CacheData[Cachekey];
                Debug.WriteLine("Number Symptoms already selected [" + listObj.Count + "]");
                Debug.WriteLine("Adding new Symptom[" + data.ToJson() + "]" + " to the cache list");
                listObj.Add(data);
                CacheData[Cachekey] = listObj;
                return CacheData;
            }
            
            list.Add(data);
            CacheData.Add(Cachekey,list);
            return CacheData;
        }
        
        public static Dictionary<String, object> HandleCachingObject(Dictionary<String, object> CacheData,string Cachekey ,object data)
        {
            object obj = new object();
            if (CacheData.ContainsKey(Cachekey))
            {
                obj = CacheData[Cachekey];
                Debug.WriteLine("Adding new item [" + data.ToJson() + "]" + " to the cache list");
                CacheData["selectedSymptoms"] = obj;
                return CacheData;
            }
            
            CacheData.Add(Cachekey,data);
            return CacheData;
        }

        public static async void DumpDataAndKickUserOut()
        {
            await App.Current.MainPage.Navigation.PushPopupAsync(new AlertPopup("S", "You Successfully Registered"));
            App.Current.MainPage.Navigation.InsertPageBefore(new LoginViewV2(), App.Current.MainPage.Navigation.NavigationStack.First());

            RealmDBService<PatientDao> userDb = new RealmDBService<PatientDao>();
            userDb.ClearDatabase();
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }
        
    }
}