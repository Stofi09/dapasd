using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using WebApplication4;

public class YourDataAccessClass
    {
        

        public YourDataAccessClass()
        {
        }

        public void BulkInsertObjects(List<ObjectDapperDTO> objects)
        {
            using (IDbConnection dbConnection = new SqlConnection("server=(localdb)\\MSSQLLocalDB; database=YourDatabaseName; Integrated Security=true"))
            {
                dbConnection.Open();

                using (var transaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        dbConnection.Insert(objects, transaction);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }

