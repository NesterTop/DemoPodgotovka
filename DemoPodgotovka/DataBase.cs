using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DemoPodgotovka
{
    public class DataBase : IDisposable
    {
        private string _dataSource = @"Data Source=DESKTOP-AVGELME\STP;Initial Catalog=DataBase;Integrated Security=True";
        private SqlConnection _connection;
        public bool IsConnected { get; private set; }

        public DataBase()
        {
            _connection = new SqlConnection(_dataSource);
            OpenConnection();
        }

        private void OpenConnection()
        {
            if(_connection.State != ConnectionState.Open)
            {
                _connection.Open();
                IsConnected = true;
            }
        }
        private void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
                IsConnected = false;
            }
        }

        public DataTable ExecuteSql(string sql)
        {
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand(sql, _connection);
            var reader = command.ExecuteReader();
            dt.Load(reader);
            return dt;
        }

        public void Dispose()
        {
            CloseConnection();
        }
    }
}
