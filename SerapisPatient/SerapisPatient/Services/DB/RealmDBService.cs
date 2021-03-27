using System;
using System.Collections.Generic;
using System.Text;
using Realms;
using SerapisPatient.Models.Patient;

namespace SerapisPatient.Services.DB
{
    public class RealmDBService<T> : IDBService<T>
    {
        protected Realm RealmInstance;
        public RealmDBService()
        {
            RealmInstance = Realm.GetInstance();
        }
        public bool DeleteDocument(T doc)
        {
            throw new NotImplementedException();
        }

        public bool SaveDocument(T doc)
        {
            try
            {
                RealmInstance.Write(() => 
                {
                    RealmInstance.Add(new Patient
                    {
                    PatientFirstName = "Lusanda"
                    });
                });
            }catch(Exception ex)
            {
                throw;
            }
            finally
            {

            }


            return true;
        }

        public bool UpdateDocument(T doc)
        {
            throw new NotImplementedException();
        }
    }
}
