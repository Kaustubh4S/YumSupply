using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Biller_BillerMasterPage : System.Web.UI.MasterPage
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["RoleId"].ToString() == "2")
            this.MasterPageFile = "~/Biller/BillerMasterPage.master";
        if (Session["RoleId"].ToString() == "1")
            this.MasterPageFile = "~/Manager/ManagerMasterPage.master";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!(Session["Active"].ToString() == "True"))
        //    Response.Redirect("../Default.aspx");
        if (!Page.IsPostBack)
            lblFullName.Text = Session["FullName"].ToString();
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session["UserID"] = "";
        Session["RoleId"] = "";
        Session["FullName"] = "";
        Session["Password"] = "";
        Session["Active"] = "";
        Session["BillData"] = null;
        Response.Redirect("../Default.aspx");
    }
}
