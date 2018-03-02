using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Common;
using Npgsql;

namespace Database
{
    public class DBHelper
    {
        [ThreadStatic]
        private static NpgsqlConnection _connection;

        private static NpgsqlConnection GetConnection()
        {
            if (_connection != null)
            {
                return _connection;
            }

            _connection = new NpgsqlConnection(ConnectionString);
            return _connection;
        }

        private static string ConnectionString = Config.ConnectionString;

        private static void Open()
        {
            NpgsqlConnection conn = GetConnection();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public static List<T> List<T>(string storedProcedureName, params object[] objs) where T : class, new()
        {
            Open();
            var cmd = new NpgsqlCommand(storedProcedureName, GetConnection());
            var reader = cmd.ExecuteReader();
            List<T> listObjects = new List<T>();
            PropertyInfo[] propertyInfos = typeof(T).GetProperties();

            try
            {
                while (reader.Read())
                {
                    T newObject = new T();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        PropertyInfo pI = propertyInfos[i];
                        string value = reader[pI.Name.ToLower()].ToString();
                        pI.SetValue(newObject, Convert.ChangeType(value, pI.PropertyType), null);
                    }

                    listObjects.Add(newObject);

                }
            }
            catch (Exception ex)
            {
                //Логирование
            }
            finally
            {
                reader.Close();
            }

            return listObjects;
        }
    }
}
