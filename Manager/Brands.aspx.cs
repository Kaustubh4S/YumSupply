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
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string cmdCheck, cmdInsertOrUpdate;
        int ID;

        if (HiddenField1.Value == "")
        {
            cmdCheck = "SELECT BrandID FROM Brands WHERE BrandName=@0;";
            ID = SQLHelper.getID(cmdCheck, txtBrandName.Text.Trim());
            cmdInsertOrUpdate = "INSERT INTO Brands(BrandName) VALUES(@0)";
            lblMsg.Text = "Brand " + SQLHelper.Commit(ID, cmdInsertOrUpdate, 0, txtBrandName.Text.Trim());
            Clears();
        }
        else
        {
            cmdCheck = "SELECT BrandID FROM Brands WHERE (BrandName=@0)";
            ID = SQLHelper.getID(cmdCheck, txtBrandName.Text.Trim(), HiddenField1.Value);
            cmdInsertOrUpdate = "update Brands set BrandName=@0 where BrandID=@1";
            lblMsg.Text = "Brand" + SQLHelper.Commit(ID, cmdInsertOrUpdate, 1, txtBrandName.Text.Trim(), HiddenField1.Value);
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
        if (e.CommandName == "Ed")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            HiddenField1.Value = grdVBrands.Rows[index].Cells[0].Text;
            txtBrandName.Text = grdVBrands.Rows[index].Cells[1].Text;
            btnAdd.Text = "Update";
        }
    }
}