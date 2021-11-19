using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace assets_management_system
{
   
    class CheckLogin
    {
        static private SqlConnection connection;
        static private SqlCommand cmd = new SqlCommand();
        static private SqlDataReader reader;


        static public void ConnectToSQL()
        {

            connection = new SqlConnection(SQLConnector.ConnectionString);
        }
        
     

        public static SqlConnection Connection { get { return connection; } }

       
        private static bool IsServerConnected()
        {
            using (SqlConnection connection = new SqlConnection(SQLConnector.ConnectionString))
            {
                try
                {
                    connection.Open();
                    connection.Close();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }




    }   
}


    

