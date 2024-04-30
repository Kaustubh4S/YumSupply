using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Manager_Products : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string cmdCheck, cmdInsertOrUpdate;
        int PID;

        if (ddlBrand.SelectedValue == "-1")
        {
            lblMsg.Text = "Please Select Brand!";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            ddlBrand.Focus();
            return;
        }

        if (ddlCategory.SelectedValue == "-1")
        {
            lblMsg.Text = "Please Select Category!";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            ddlCategory.Focus();
            return;
        }

        if (HiddenField1.Value == "")
        {
            //save
            cmdCheck = "SELECT ProductID FROM Product WHERE (ProductName=@0 AND BrandID=@1 and CategoryID=@2 and Price=@3);";
            PID = SQLHelper.getID(cmdCheck, txtProductName.Text.Trim(), ddlBrand.SelectedValue, ddlCategory.SelectedValue, txtPrice.Text.Trim());
            cmdInsertOrUpdate = "INSERT INTO Product (ProductName, BrandID, CategoryID, Price, Date) VALUES (@0, @1, @2, @3, @4)";
            lblMsg.Text = "Product " + SQLHelper.Commit(PID, cmdInsertOrUpdate, 0, txtProductName.Text.Trim(), ddlBrand.SelectedValue, ddlCategory.SelectedValue, txtPrice.Text, DateTime.Now);
            Clears();
        }
        else
        {
            //update
            cmdCheck = "SELECT ProductID FROM Product WHERE ProductName=@0 and BrandID=@1 and CategoryID=@2 and Price=@3 and ProductID=@4";
            PID = SQLHelper.getID(cmdCheck, txtProductName.Text.Trim(), ddlBrand.SelectedValue, ddlCategory.SelectedValue, txtPrice.Text.Trim(), HiddenField1.Value);
            cmdInsertOrUpdate = "update Product set ProductName=@0, BrandID=@1, CategoryID=@2, Price=@3 where ProductID=@4";
            lblMsg.Text = "Product" + SQLHelper.Commit(PID, cmdInsertOrUpdate, 1, txtProductName.Text.Trim(), ddlBrand.SelectedValue, ddlCategory.SelectedValue, txtPrice.Text.Trim(), HiddenField1.Value);
            Clears();
        }
    }

    private void Clears()
    {
        txtProductName.Text = "";
        txtProductName.Focus();
        txtPrice.Text = "";
        ddlBrand.SelectedIndex = -1;
        ddlCategory.SelectedIndex = -1;
        grdProducts.DataBind();
        btnAdd.Text = "Add";
        HiddenField1.Value = "";
    }

    protected void grdProducts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "up")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            HiddenField1.Value = grdProducts.Rows[index].Cells[0].Text;
            txtProductName.Text = grdProducts.Rows[index].Cells[1].Text;
            ddlCategory.SelectedValue = ddlCategory.Items.FindByText(grdProducts.Rows[index].Cells[2].Text).Value;
            ddlBrand.SelectedValue = ddlBrand.Items.FindByText(grdProducts.Rows[index].Cells[3].Text).Value;
            txtPrice.Text = grdProducts.Rows[index].Cells[4].Text;
            txtPrice.Text = grdProducts.Rows[index].Cells[4].Text;
            btnAdd.Text = "Update";
        }
    }
}

