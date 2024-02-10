using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_Category : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Session["UserID"].ToString()))
        {
            Response.Redirect("~/Default.aspx");
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (HiddenField1.Value == "")
        {
            lblMsg.Text = "Category" + SQLHelper.Commit("SELECT CategoryID FROM Category WHERE CategoryName='" + txtCategory.Text + "';", "INSERT INTO Category(CategoryName) VALUES('" + txtCategory.Text + "');", 0);
            Clears();
        }
        else
        {
            lblMsg.Text = "Category" + SQLHelper.Commit("SELECT CategoryID FROM Category WHERE CategoryName='" + txtCategory.Text + "' and CategoryID=" + HiddenField1.Value, "update Category set CategoryName='" + txtCategory.Text + "' where CategoryID=" + HiddenField1.Value, 1);
            Clears();
        }
    }
    
    private void Clears()
    {
        txtCategory.Text = "";
        txtCategory.Focus();
        grdVCategory.DataBind();
        btnAdd.Text = "Save";
        HiddenField1.Value = "";

    }   

    protected void grdVCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "up")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            HiddenField1.Value = grdVCategory.Rows[index].Cells[0].Text;
            txtCategory.Text = grdVCategory.Rows[index].Cells[1].Text;
            btnAdd.Text = "Update";
        }
    }
}