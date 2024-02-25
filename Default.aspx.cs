using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            string strCmd = "SELECT  UserID, Password, RoleId, FullName FROM Users WHERE(UserName=@0)";
            DataTable dt = SQLHelper.FillData(strCmd, txtUserName.Text);
            if (dt.Rows.Count > 0)
            {
                string strPassword = dt.Rows[0]["Password"].ToString();
                if (strPassword == txtPassword.Text)
                {
                    Session["UserID"] = dt.Rows[0]["UserID"].ToString();
                    Session["RoleId"] = dt.Rows[0]["RoleId"].ToString();
                    Session["FullName"] = dt.Rows[0]["FullName"].ToString();
                    Session["Password"] = dt.Rows[0]["Password"].ToString();
                    if (Session["RoleId"].ToString() == "1")
                        Response.Redirect("~/Manager/Home.aspx");
                    if (Session["RoleId"].ToString() == "2")
                        Response.Redirect("~/Biller/Home.aspx");
                }
                else
                {
                    ShowErrors("Invalid Password");
                    txtPassword.Focus();
                }
            }
            else
            {
                ShowErrors("Invalid UserName");
                txtUserName.Focus();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ShowErrors(string strError)
    {
        lblMsg.Text = strError;
        divError.Visible = true;
    }
}
