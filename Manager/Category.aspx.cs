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
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string cmdCheck, cmdInsertOrUpdate;
        int ID;

        if (HiddenField1.Value == "")
        {
            cmdCheck = "SELECT CategoryID FROM Category WHERE CategoryName=@0;";
            ID = SQLHelper.getID(cmdCheck, txtCategory.Text.Trim());
            cmdInsertOrUpdate = "INSERT INTO Category(CategoryName) VALUES(@0)";
            lblMsg.Text = "Category " + SQLHelper.Commit(ID, cmdInsertOrUpdate, 0, txtCategory.Text.Trim());
            Clears();
        }
        else
        {
            cmdCheck = "SELECT CategoryID FROM Category WHERE (CategoryName=@0);";
            ID = SQLHelper.getID(cmdCheck, txtCategory.Text.Trim(), HiddenField1.Value);
            cmdInsertOrUpdate = "update Category set CategoryName=@0 where CategoryID=@1";
            lblMsg.Text = "Category " + SQLHelper.Commit(ID, cmdInsertOrUpdate, 1, txtCategory.Text.Trim(), HiddenField1.Value);
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