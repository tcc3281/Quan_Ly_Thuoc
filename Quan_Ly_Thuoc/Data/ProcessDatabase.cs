using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Thuoc.Data
{
    public class ProcessDatabase
    {
        public SqlConnection conn;
        public SqlCommand cmd;
        public SqlDataAdapter adapter;
        public DataSet dset;

        string conStr = "Data Source=.\\sqlexpress;Initial Catalog=QL_Thuoc;Integrated Security=True";
        //string conStr = "Data Source=DESKTOP-U9CQUB1;Initial Catalog=QL_Thuoc;" +
        // "Integrated Security=True";

        public ProcessDatabase()
        {
            conn = new SqlConnection();
        }

        public void Connect()
        {
            if(conn.State != System.Data.ConnectionState.Open)
            {
                conn.ConnectionString = conStr;
                conn.Open();
            }
        }

        public void Disconnect()
        {
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public DataTable ReadTable(String sql)
        {
            Connect();
            
            DataTable tblData = new DataTable();
            adapter = new SqlDataAdapter(sql, conn);
            adapter.Fill(tblData);

            Disconnect();
            return tblData;
        }

        public void CreateCMD()
        {
            Connect();
            cmd = new SqlCommand(conStr, conn);
        }

        public void RunSQL(String sql)
        {
            Connect();
			cmd.CommandText = sql;
            cmd.Connection = conn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Disconnect();
        }
    }
}
