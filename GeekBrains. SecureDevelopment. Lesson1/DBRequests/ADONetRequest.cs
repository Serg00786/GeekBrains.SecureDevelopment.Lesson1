using GeekBrains._SecureDevelopment._Lesson1.Interfaces;
using GeekBrains._SecureDevelopment._Lesson1.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GeekBrains._SecureDevelopment._Lesson1.DBRequests
{
    public class ADONetRequest : IDBRequest
    {
        NpgsqlConnection conn;
        public ADONetRequest()
        {
            string connString = "Host=host.docker.internal;Port=5432;Database=postgrdb;Username=user;Password=123";
            conn = new NpgsqlConnection(connString);
        }

        public async Task InsertRows(Bankcard models)
        {
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
            finally
            {
                conn.Close();
            }
           
        }

        public async Task<List<Bankcard>> SelectRows()
        {

            await conn.OpenAsync();
            // Retrieve all rows
            NpgsqlDataReader reader;
            List<Bankcard> FinalList = new List<Bankcard>();
            try
            {


                await using (var cmd = new NpgsqlCommand("SELECT * FROM public.listbankcard", conn))
                await using (reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        FinalList.Add(new Bankcard()
                        {
                            Id = await reader.GetFieldValueAsync<int>(0),
                            Credit = await reader.GetFieldValueAsync<bool>(1),
                            ValidDate = await reader.GetFieldValueAsync<DateTime>(2),
                            SecreteCode = await reader.GetFieldValueAsync<int>(3)
                        });
                    }

                }
            }
            catch(Exception ex)
            {
                throw new Exception (ex.ToString());
            }
            finally { conn.Close(); }



            return FinalList;


        }

        public Task UpdateRows(Bankcard models)
        {
            throw new System.NotImplementedException();
        }
    }
}
