using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_Brands : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Session["UserID"].ToString()) || !(Session["RoleId"].ToString() == "1"))
            Response.Redirect("~/Default.aspx");
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if(HiddenField1.Value=="")
        {
            lblMsg.Text= "Brand"+ SQLHelper.Commit("SELECT BrandID FROM Brands WHERE BrandName='" + txtBrandName.Text + "';", "INSERT INTO Brands(BrandName) VALUES('" + txtBrandName.Text + "');", 0);
            Clears();
        }
        else
        {
            lblMsg.Text = "Brand" + SQLHelper.Commit("SELECT BrandID FROM Brands WHERE BrandName='" + txtBrandName.Text + "' and BrandID=" + HiddenField1.Value, "update Brands set BrandName='" + txtBrandName.Text + "' where BrandID=" + HiddenField1.Value, 1);
            Clears();
        }
        
    }   

    private void Clears()
    {
        txtBrandName.Text = "";
        txtBrandName.Focus();
        grdVBrands.DataBind();
        btnAdd.Text = "Save";
        HiddenField1.Value = "";
       
    }
    
    protected void grdVBrands_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="Ed")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            HiddenField1.Value = grdVBrands.Rows[index].Cells[0].Text;
            txtBrandName.Text = grdVBrands.Rows[index].Cells[1].Text;
            btnAdd.Text = "Update";
        }
    }
}