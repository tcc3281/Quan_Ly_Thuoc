using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Thuoc.Data
{
    public class Database
    {
        public SqlConnection conn { get; set; }
        public Database()
        {
            conn = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=QL_Thuoc;User ID=sa;Password=123");
        }
        public void connect()
        {
            if (conn != null)
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
            }
            else
            {
                conn = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=QL_Thuoc;User ID=sa;Password=123");
                conn.Open();
            }
        }
        public void disconnect()
        {
            if (conn != null)
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        public void runSqlNonQuery(string sql)
        {
            SqlCommand command = new SqlCommand(sql);
            connect();
            command.Connection = conn;
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }
        public string runSqlOneValue(string sql)
        {
            SqlCommand command = new SqlCommand(sql);
            connect();
            command.Connection = conn;
            command.CommandText = sql;
            object res= command.ExecuteScalar();
            return (string)res;
        }
    }
}