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
        if (string.IsNullOrEmpty(Session["UserID"].ToString()) || !(Session["RoleId"].ToString() == "1"))
            Response.Redirect("~/Default.aspx");
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
                    DataTable dt = SQLHelper.FillData("SELECT Password FROM Users WHERE UserID=" + Session["UserID"].ToString() + ";");
                    if (txtPassword1.Text == dt.Rows[0]["Password"].ToString())
                    {
                        ShowErrors("Password can not be Same as Old!");
                        txtPassword1.Focus();
                    }
                    else
                    {
                        SQLHelper.ExecuteNonQuery("UPDATE Users SET Password = '" + txtPassword1.Text + "' WHERE UserID=" + Session["UserID"].ToString() + ";");
                        DataTable dt0 = SQLHelper.FillData("SELECT Password FROM Users WHERE UserID=" + Session["UserID"].ToString() + ";");

                        if (dt0.Rows[0]["Password"].ToString() == txtPassword1.Text)
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