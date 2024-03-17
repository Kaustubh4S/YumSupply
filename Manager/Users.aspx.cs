using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_Users : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(Session["UserID"].ToString() == "1"))
            Response.Redirect("~/Manager/Home.aspx");//prevents from accessing throught url
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ddlRole.SelectedValue == "-1")
        {
            lblMsg.Text = "Please Select Role!";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            ddlRole.Focus();
            return;
        }

        if (txtPassword1.Text == txtPassword2.Text)
        {
            string cmdCheck, cmdInsertOrUpdate;
            int ID;

            if (txtPassword1.Text.Length <= 6)
            {
                ShowErrors("Password Must be Greater than 6 Characters");
            }
            else
            {
                string binary = "";
                if (chbActive.Checked)
                    binary = "True";
                else
                    binary = "False";

                if (HiddenField1.Value == "")
                {
                    //save
                    cmdCheck = "SELECT UserID FROM Users WHERE (UserName=@0);";
                    ID = SQLHelper.getID(cmdCheck, txtUserName.Text);
                    cmdInsertOrUpdate = "INSERT INTO Users (UserName, Password, RoleId, FullName, Dated, Active) VALUES (@0, @1, @2, @3, @4, @5)";
                    lblMsg.Text = "User " + SQLHelper.Commit(ID, cmdInsertOrUpdate, 0, txtUserName.Text, txtPassword1.Text, ddlRole.SelectedValue, txtFullName.Text, DateTime.Now, binary);
                    Clears();
                }
                else
                {
                    //update
                    cmdCheck = "SELECT UserID FROM Users WHERE (UserName=@0 and UserID=@1 and RoleId=@2 and FullName=@3 and Active=@4);";
                    ID = SQLHelper.getID(cmdCheck, txtUserName.Text, HiddenField1.Value, ddlRole.SelectedValue, txtFullName.Text, binary);
                    cmdInsertOrUpdate = "update Users set UserName=@0, Password=@1, RoleId=@2, FullName=@3, Dated=@4, Active=@5 where UserID=@6";
                    lblMsg.Text = "User " + SQLHelper.Commit(ID, cmdInsertOrUpdate, 1, txtUserName.Text, txtPassword1.Text, ddlRole.SelectedValue, txtFullName.Text, DateTime.Now, binary, HiddenField1.Value);
                    Clears();
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

    private void Clears()
    {
        txtFullName.Text = "";
        txtUserName.Text = "";
        txtPassword1.Text = "";
        txtPassword2.Text = "";
        ddlRole.SelectedIndex = -1;
        chbActive.Checked = true;
        txtFullName.Focus();
        grdUsers.DataBind();
        btnAdd.Text = "Add";
        HiddenField1.Value = "";
        divError.Visible = false;
    }

    protected void grdUsers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "up")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            HiddenField1.Value = grdUsers.Rows[index].Cells[0].Text;
            txtFullName.Text = grdUsers.Rows[index].Cells[1].Text;
            txtUserName.Text = grdUsers.Rows[index].Cells[2].Text;
            txtPassword1.Text = grdUsers.Rows[index].Cells[3].Text;
            ddlRole.SelectedValue = ddlRole.Items.FindByText(grdUsers.Rows[index].Cells[4].Text).Value;
            CheckBox chk = (CheckBox)grdUsers.Rows[index].Controls[0].FindControl("CheckBox1");
            chbActive.Checked = chk.Checked;
            btnAdd.Text = "Update";
        }
    }

    protected void chbActive_CheckedChanged(object sender, EventArgs e)
    {
        if (chbActive.Checked)
            lblActive.Text = "User Active";
        else
            lblActive.Text = "User InActive";
    }
}