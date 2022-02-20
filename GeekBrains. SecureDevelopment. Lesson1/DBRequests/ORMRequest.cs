using GeekBrains._SecureDevelopment._Lesson1.Interfaces;
using GeekBrains._SecureDevelopment._Lesson1.Models;
using System.Threading.Tasks;

namespace GeekBrains._SecureDevelopment._Lesson1.DBRequests
{
    internal class ORMRequest : IDBRequest
    {
        public Task InsertRows(Bankcard models)
        {
            throw new System.NotImplementedException();
        }

        public Task<Bankcard> SelectRows(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateRows(Bankcard models)
        {
            throw new System.NotImplementedException();
        }
    }
}
