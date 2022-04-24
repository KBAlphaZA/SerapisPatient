using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SerapisPatient.Services.DB
{
    public interface IDBService<T>
    {
        T RetrieveDocument();
        Task<T> RetrieveDocumentAsync();
        Task<bool> SaveDocumentAsync(T doc);
        bool DeleteDocument(T doc);
        bool UpdateDocument(T doc);

        void ClearDatabase();
    }
}
