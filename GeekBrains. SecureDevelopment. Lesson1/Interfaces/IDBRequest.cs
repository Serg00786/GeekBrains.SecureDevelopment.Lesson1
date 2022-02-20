using GeekBrains._SecureDevelopment._Lesson1.Abstraction;
using GeekBrains._SecureDevelopment._Lesson1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeekBrains._SecureDevelopment._Lesson1.Interfaces
{
    public interface IDBRequest
    {
        void InsertRows(Bankcard models);
        Task UpdateRows(Bankcard models);
        Task<List<Bankcard>> SelectRows(int id);


    }
}
