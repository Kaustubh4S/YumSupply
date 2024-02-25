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

    public static DataTable FillData(string strCmd, params object[] values)
    {
        try
        {
            SqlConnection connection = GetConnection();
            SqlCommand cmd = new SqlCommand(strCmd, connection);
            for (int i = 0; i < values.Length; i++)
                cmd.Parameters.AddWithValue("@" + i, values[i]);
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

    public static string Commit(int ID, string cmdSaveOrUpdate, int Save0OrUpdate1, params object[] value)
    {
        try
        {
            if ((ID != 0 && Save0OrUpdate1 == 0) || (ID != 0 && Save0OrUpdate1 != 0))
            {
                return " is Already Existed!";
            }
            else
            {
                if (Save0OrUpdate1 == 0)
                {
                    //save
                    ExecuteQuery(cmdSaveOrUpdate, value);
                    return " is Added Sucessfully!";
                }
                else
                {
                    //update
                    ExecuteQuery(cmdSaveOrUpdate, value);
                    return " is Updated Sucessfully!";
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static int getID(string cmd, params object[] values)
    {
        DataTable dt = FillData(cmd, values);
        if (dt.Rows.Count > 0)
            return Convert.ToInt32(dt.Rows[0][0].ToString());
        else
            return 0;
    }

    //params keyword allows to pass variable number of arguments to function
    public static void ExecuteQuery(string strCmd, params object[] values)
    {
        SqlConnection connection = GetConnection();
        SqlCommand cmd = new SqlCommand(strCmd, connection);
        for (int i = 0; i < values.Length; i++)
            cmd.Parameters.AddWithValue("@" + i, values[i]);
        try
        {
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
    }

}