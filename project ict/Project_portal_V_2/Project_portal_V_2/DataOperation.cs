using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Project_portal_V_2
{
    public class DataOperation
    {
        public string connectstr = "Data Source=ANONYMOUS;Initial Catalog=Parent_portal_DB_V_1;Integrated Security=True";
        public int executequery(string query)
        {

            SqlConnection conn = new SqlConnection(connectstr);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch
            {
                return 0;
            }

        }
        public DataTable getData(string query)
        {
            SqlConnection conn = new SqlConnection(connectstr);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch
            {
                
            }
            return dt;
        }
        public int loginCheck(string query)
        {
            SqlConnection conn = new SqlConnection(connectstr);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                string output = cmd.ExecuteScalar().ToString();
                if (output == "1")
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
            
        }
        public SqlDataReader showLabel(string query)
        {
            SqlConnection conn = new SqlConnection(connectstr);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand(query,conn);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;

        }
    }
}