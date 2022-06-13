using SerapisPatient.Models.Appointments;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerapisPatient.Services.Cloud
{
    public interface IMongoService<T>
    {
        Task<List<MedicalBuildingModel>> GetUsersBySpecialization(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<T> GetNote(string id);

        // query after multiple parameters
        Task<IEnumerable<T>> Get(string bodyText, DateTime updatedFrom, long headerSizeLimit);

        // add new note document
        Task Add(T item);

        // remove a single document / note
        Task<bool> Remove(string id);

        // update just a single document / note
        Task<bool> Update(string id, string body);

        // should be used with high cautious, only in relation with demo setup
        Task<bool> Remove();

        // creates a sample index
        Task<string> CreateIndex();
    }
}
