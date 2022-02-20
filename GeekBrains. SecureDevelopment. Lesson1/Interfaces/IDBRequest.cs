using GeekBrains._SecureDevelopment._Lesson1.Abstraction;
using GeekBrains._SecureDevelopment._Lesson1.Models;
using System.Threading.Tasks;

namespace GeekBrains._SecureDevelopment._Lesson1.Interfaces
{
    public interface IDBRequest
    {
        Task InsertRows(Bankcard models);
        Task UpdateRows(Bankcard models);
        Task<Bankcard> SelectRows(int id);


    }
}
