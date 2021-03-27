using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Services.DB
{
    public interface IDBService<T>
    {
        bool SaveDocument(T doc);
        bool DeleteDocument(T doc);
        bool UpdateDocument(T doc);

    }
}
