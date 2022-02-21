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
        //NpgsqlConnection conn;

        public ADONetRequest()
        {
           GetConnection();
        }


        private async Task GetConnection()
        {
            //string connString = "Host=host.docker.internal;Username=user;Password=123;Database=postgrdb";
            //conn = new NpgsqlConnection(connString);
           // await conn.OpenAsync();

        }

        public async Task InsertRows(Bankcard models)
        {
            string connString = "Host=host.docker.internal;Username=user;Password=123;Database=postgrdb";
            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();


            IDbCommand command = conn.CreateCommand();
            string sql = "INSERT INTO listbankcard (Id,Credit,ValidDate,SecreteCode) VALUES (1, true, null, 123)";
            command.CommandText = sql;

            var parameter = command.CreateParameter();
            parameter.ParameterName = "FirstName";
            parameter.Value = "Test";
            command.Parameters.Add(parameter);
            command.ExecuteNonQuery();



            // Insert some data "+models.Id+","+models.Credit+","+models.ValidDate+"," +models.SecreteCode+ "
            //await using (var cmd = new NpgsqlCommand("INSERT INTO public.listbankcard ('Id','Credit','ValidDate','SecreteCode') VALUES (1, true, null, 123)", conn))
            //{
            //    cmd.Parameters.AddWithValue("a", models.Id);
            //    cmd.Parameters.AddWithValue("b", models.Credit);
            //    cmd.Parameters.AddWithValue("c", models.ValidDate);
            //    cmd.Parameters.AddWithValue("d", models.SecreteCode);
            //    cmd.ExecuteNonQuery();
            //}
            //Dispose();
        }

        public async Task<List<Bankcard>> SelectRows()
        {

            string connString = "Host=host.docker.internal;Username=user;Password=123;Database=postgrdb";
            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();
            // Retrieve all rows
            NpgsqlDataReader reader;
            List<Bankcard1> FinalList = new List<Bankcard1>();
            await using (var cmd = new NpgsqlCommand("SELECT 'Id', 'Credit', 'ValidDate', 'SecreteCode' FROM public.listbankcard", conn))
            await using (reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    FinalList.Add(new Bankcard1()
                    {
                        Id = await reader.GetFieldValueAsync<string>(0),
                        Credit = await reader.GetFieldValueAsync<string>(1),
                        ValidDate = await reader.GetFieldValueAsync<string>(2),
                        SecreteCode = await reader.GetFieldValueAsync<string>(3)
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
            //conn.Close();
           // conn.Dispose();
        }


    }
}
