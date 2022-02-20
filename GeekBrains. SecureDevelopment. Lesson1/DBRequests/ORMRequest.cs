using GeekBrains._SecureDevelopment._Lesson1.Interfaces;
using GeekBrains._SecureDevelopment._Lesson1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBrains._SecureDevelopment._Lesson1.DBRequests
{
    internal class ORMRequest : IDBRequest
    {
        AppDbContext db = new AppDbContext();
        public void InsertRows(Bankcard models)
        {
 
            db.Add(models);
            db.SaveChanges();

        }

        public async Task<List<Bankcard>> SelectRows(int id)
        {
            var Result = await db.listbankcard.ToListAsync();
            return Result;
        }

        public Task UpdateRows(Bankcard models)
        {
            throw new System.NotImplementedException();
        }
    }
}
