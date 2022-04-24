using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Realms;
using SerapisPatient.Models.Patient;

namespace SerapisPatient.Services.DB
{
    public class RealmDBService<T> : IDisposable ,IDBService<T> where T: RealmObject
    {
        protected Realm RealmInstance;
        public RealmDBService()
        {
            RealmInstance = Realm.GetInstance();
        }

        public async Task<T> RetrieveDocumentAsync()
        {
            return await Task.FromResult(RealmInstance.All<T>().FirstOrDefault());
        }
        public T RetrieveDocument()
        {
             return RealmInstance.All<T>().FirstOrDefault();
        }
        public async Task<List<T>> RetrieveAllDocumentsAsync(T doc)
        {
            try
            {
                return await Task.FromResult(
                    RealmInstance.All<T>().ToList()
                    );

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);
                return new List<T>();
            }

        }

        public async Task<bool> SaveDocumentAsync(T doc)
        {
            try
            {
                RealmInstance.Write(() => 
                {
                    RealmInstance.Add<T>(doc);
                });

                return await Task.FromResult(true);
            }catch(Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
           
        }

        public bool UpdateDocument(T doc)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDocument(T doc)
        {
            throw new NotImplementedException();
        }

        public void ClearDatabase()
        {
            RealmInstance.Write(() =>
            {
                // Remove the instance from the realm.
                RealmInstance.RemoveAll();
                // Discard the reference.
            });
        }
        public void Dispose()
        {
            RealmInstance = null;
            GC.SuppressFinalize(this);
        }
    }
}
