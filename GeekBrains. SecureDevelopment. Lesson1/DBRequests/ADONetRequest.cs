using GeekBrains._SecureDevelopment._Lesson1.Interfaces;
using GeekBrains._SecureDevelopment._Lesson1.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GeekBrains._SecureDevelopment._Lesson1.DBRequests
{
    public class ADONetRequest : IDBRequest, IDisposable
    {

        public async Task InsertRows(Bankcard models)
        {
            string connString = "Host=host.docker.internal;Port=5432;Database=postgrdb;Username=user;Password=123";
            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();

            try
            {
                await using (var cmd = new NpgsqlCommand("INSERT INTO public.listbankcard VALUES (@a, @b, @c, @d)", conn))
                {
                    cmd.Parameters.AddWithValue("a", models.Id);
                    cmd.Parameters.AddWithValue("b", models.Credit);
                    cmd.Parameters.AddWithValue("c", models.ValidDate);
                    cmd.Parameters.AddWithValue("d", models.SecreteCode);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
           
            Dispose();
        }

        public async Task<List<Bankcard>> SelectRows()
        {

            string connString = "Host=host.docker.internal;Username=user;Password=123;Database=postgrdb";
            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();
            // Retrieve all rows
            NpgsqlDataReader reader;
            List<Bankcard> FinalList = new List<Bankcard>();
            await using (var cmd = new NpgsqlCommand("SELECT * FROM public.listbankcard", conn))
            await using (reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var Id = await reader.GetFieldValueAsync<string>(0);
                    var Credit = await reader.GetFieldValueAsync<bool>(1);
                    var ValidDate = await reader.GetFieldValueAsync<DateTime>(2);
                    var SecreteCode = await reader.GetFieldValueAsync<int>(3);

                    FinalList.Add(new Bankcard()
                    {
                        Id = Convert.ToInt32(Id),
                        Credit = Credit,
                        ValidDate = ValidDate,
                        SecreteCode = SecreteCode
                    });
                }

            }

            Dispose();

            return new List<Bankcard>();


        }

        public Task UpdateRows(Bankcard models)
        {
            throw new System.NotImplementedException();
        }
        public void Dispose()
        {
            conn.Close();
             conn.Dispose();
        }


    }
}
