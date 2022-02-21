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
        public async Task InsertRows(Bankcard models)
        {
 
            if (models != null)
            {
                db.Add(models);
                await db.SaveChangesAsync();
            }
 
        }

        public async Task<List<Bankcard>> SelectRows()
        {
            var Result = await db.listbankcard.ToListAsync();
            return Result;
        }

        public async Task UpdateRows(Bankcard models)
        {
            var result = db.listbankcard.SingleOrDefault(b => b.Id == models.Id);
            if (result != null)
            {
                result.Credit = models.Credit;
                result.ValidDate = models.ValidDate;
                result.SecreteCode = models.SecreteCode;
                await db.SaveChangesAsync();
            }
        }
    }
}
