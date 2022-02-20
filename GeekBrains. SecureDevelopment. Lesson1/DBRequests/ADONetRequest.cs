using GeekBrains._SecureDevelopment._Lesson1.Interfaces;
using GeekBrains._SecureDevelopment._Lesson1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeekBrains._SecureDevelopment._Lesson1.DBRequests
{
    internal class ADONetRequest : IDBRequest
    {
        public void InsertRows(Bankcard models)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Bankcard>> SelectRows(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateRows(Bankcard models)
        {
            throw new System.NotImplementedException();
        }
    }
}
