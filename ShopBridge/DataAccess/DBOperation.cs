using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using System.Configuration;
using System.Web.Hosting;

namespace ShopBridge.DataAccess
{
    public class DBOperation
    {
        //string connString1 = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+HostingEnvironment.MapPath(@"~/App_Data/Database1.mdf")+ ";Integrated Security=True";
        public List<T> GetData<T>(string query)
        {
            List<T> list = new List<T>();
            DataTable temp = GetDataTable(query);
            foreach (DataRow row in temp.Rows)
            {
                T item = GetItem<T>(row);
                list.Add(item);
            }
            return list;
        }

        public DataTable GetDataTable(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(connString)) { 
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn)) {
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    conn.Close();
                }
            }
            return dataTable;
        }

       

        public int ExecuteQuery(string query)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 30;
                    result = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            return result;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

    }
}