using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;

public class SQLHelper
{
    public static SqlConnection GetConnection()
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);
        return connection;
    }

    public static void ExecuteNonQuery(string strCmd)
    {
        try
        {
            SqlConnection connection = GetConnection();
            SqlCommand cmd = new SqlCommand(strCmd, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static DataTable FillData(string strCmd)
    {
        try
        {
            SqlConnection connection = GetConnection();
            SqlCommand cmd = new SqlCommand(strCmd, connection);
            SqlDataAdapter dtadp = new SqlDataAdapter();
            dtadp.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dtadp.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}