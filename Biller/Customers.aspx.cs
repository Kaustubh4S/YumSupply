using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Biller_Customers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string cmdCheck, cmdInsertOrUpdate;
        int ID;

        if(!(txtMobile.Text.Length==10))
        {
            lblMsg.Text = "Enter Valid Mobile Number!";
            txtMobile.Focus();
            return;
        }

        if (HiddenField1.Value == "")
        {
            //save
            cmdCheck = "SELECT CustomerID FROM Customer WHERE (CustomerName=@0 and MobileNumber=@1);";
            ID = SQLHelper.getID(cmdCheck, txtCustName.Text.Trim(), txtMobile.Text.Trim());
            cmdInsertOrUpdate = "INSERT INTO Customer (CustomerName, AddressLine1, AddressLine2, StateName, DistrictName, TalukaName, MobileNumber, Discount) VALUES (@0, @1, @2, @3, @4, @5, @6, @7)";
            lblMsg.Text = "User " + SQLHelper.Commit(ID, cmdInsertOrUpdate, 0, txtCustName.Text.Trim(), txtAddress1.Text.Trim(), txtAddress2.Text.Trim(), txtState.Text.Trim(), txtCity.Text.Trim(), txtTaluka.Text.Trim(), txtMobile.Text.Trim(), txtDisc.Text.Trim());
            Clears();
        }
        else
        {
            //update
            cmdCheck = "SELECT CustomerID FROM Customer WHERE (CustomerName=@0 and MobileNumber=@1 );";
            ID = SQLHelper.getID(cmdCheck, txtCustName.Text.Trim(), txtMobile.Text.Trim());
            cmdInsertOrUpdate = "update Customer set CustomerName=@0, AddressLine1=@1, AddressLine2=@2, StateName=@3, DistrictName=@4, TalukaName=@5, MobileNumber=@6, Discount=@7 where CustomerID=@8";
            lblMsg.Text = "User " + SQLHelper.Commit(ID, cmdInsertOrUpdate, 1, txtCustName.Text.Trim(), txtAddress1.Text.Trim(), txtAddress2.Text.Trim(), txtState.Text.Trim(), txtCity.Text.Trim(), txtTaluka.Text.Trim(), txtMobile.Text.Trim(), txtDisc.Text.Trim(), HiddenField1.Value);
            Clears();
        }
    }

    private void Clears()
    {
        txtCustName.Text = "";
        txtCustName.Focus();
        txtAddress1.Text = "";
        txtAddress2.Text = "";
        txtState.Text = "";
        txtCity.Text = "";
        txtTaluka.Text = "";
        txtMobile.Text = "";
        txtDisc.Text = "";
        grdCustomers.DataBind();
        btnAdd.Text = "Add";
        HiddenField1.Value = "";
    }
    protected void grdCustomers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Up")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            HiddenField1.Value = grdCustomers.Rows[index].Cells[0].Text;
            txtCustName.Text = grdCustomers.Rows[index].Cells[1].Text;
            txtAddress1.Text = grdCustomers.Rows[index].Cells[2].Text;
            txtAddress2.Text = grdCustomers.Rows[index].Cells[3].Text;
            txtState.Text = grdCustomers.Rows[index].Cells[4].Text;
            txtCity.Text = grdCustomers.Rows[index].Cells[5].Text;
            txtTaluka.Text = grdCustomers.Rows[index].Cells[6].Text;
            txtMobile.Text = grdCustomers.Rows[index].Cells[7].Text;
            txtDisc.Text = grdCustomers.Rows[index].Cells[8].Text;
            btnAdd.Text = "Update";
        }
    }
}