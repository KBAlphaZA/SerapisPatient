using System.Threading.Tasks;

namespace SerapisPatient.Services.DB
{
    public interface IDBService<T>
    {
        T RetrieveDocument();
        Task<T> RetrieveDocumentAsync();
        Task<bool> SaveDocumentAsync(T doc);
        bool DeleteDocument(T doc);
        Task<bool> UpdateDocumentAsync(T doc);

        void ClearDatabase();
    }
}
