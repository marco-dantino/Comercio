using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioService.DataBase
{
    internal class DataAccess
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public SqlDataReader Reader => reader;

        public DataAccess()
        {
            connection = new SqlConnection("server=.\\SQLEXPRESS;database=COMERCIO_DB;integrated security=true");
            command = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consulta;
            command.Parameters.Clear();
        }

        public void setearParametro(string nombre, object valor)
        {
            command.Parameters.AddWithValue(nombre, valor ?? DBNull.Value);
        }

        public void ejecutarLectura()
        {
            command.Connection = connection;
            connection.Open();
            reader = command.ExecuteReader();
        }

        public void ExecuteNonQuery()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
        public int ExecuteNonQueryReturn()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                return command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public object ejecutarScalar()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                return command.ExecuteScalar();
            }
            finally
            {
                connection.Close();
            }
        }

        public void cerrarConexion()
        {
            if (reader != null && !reader.IsClosed)
                reader.Close();
            if (connection.State != System.Data.ConnectionState.Closed)
                connection.Close();
        }
    }
}
