using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (txtPassword1.Text == txtPassword2.Text)
        {
            if (txtPassword1.Text.Length <= 8)
            {
                ShowErrors("Password Must be Greater than 8 Characters");
            }
            else
            {
                try
                {
                    if (txtPassword1.Text == Session["Password"].ToString())
                    {
                        ShowErrors("Password can not be Same as Old!");
                        txtPassword1.Focus();
                    }
                    else
                    {
                        string strCmd = "UPDATE Users SET Password = @0 WHERE UserID=@1";
                        SQLHelper.ExecuteQuery(strCmd, txtPassword1.Text, Session["UserID"].ToString());
                        Session["Password"] = txtPassword1.Text;

                        strCmd = "SELECT Password FROM Users WHERE UserID=@0";
                        DataTable dt = SQLHelper.FillData(strCmd, Session["UserID"].ToString());
                        if (dt.Rows[0]["Password"].ToString() == Session["Password"].ToString())
                        {
                            lblSucess.Text = "Sucessfully Updated";
                            divSucess.Visible = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        else
        {
            ShowErrors("Passwords are Different!!!");
            txtPassword1.Focus();
        }
    }

    private void ShowErrors(string strError)
    {
        lblError.Text = strError;
        divError.Visible = true;
    }
}