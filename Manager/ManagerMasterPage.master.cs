using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_ManagerMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Session["UserID"].ToString()))
        {
            Response.Redirect("~/Default.aspx");
        }
        if (!Page.IsPostBack)
        {
            lblFullName.Text = Session["FullName"].ToString();
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session["UserID"] = "";
        Session["RoleID"] = "";
        Session["FullName"] = "";
        Response.Redirect("~/Default.aspx");
    }
}
