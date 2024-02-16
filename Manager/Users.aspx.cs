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
        if (string.IsNullOrEmpty(Session["UserID"].ToString()) || !(Session["RoleId"].ToString() == "1"))
            Response.Redirect("~/Default.aspx");
        if (!(Session["UserID"].ToString() == "1"))
            Response.Redirect("~/Manager/Home.aspx");//prevents from accessing throught url
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ddlRole.SelectedValue == "-1")
        {
            lblMsg.Text = "Please Select Role!";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }

        if (txtPassword1.Text == txtPassword2.Text)
        {
            if (txtPassword1.Text.Length <= 6)
            {
                ShowErrors("Password Must be Greater than 6 Characters");
            }
            else
            {
                if (HiddenField1.Value == "")
                {

                    string binary="";
                    //lblMsg.Text = "User" + SQLHelper.Commit("SELECT ProductID FROM Product WHERE (ProductName='" + txtProductName.Text + "' AND BrandID=" + ddlRole.SelectedValue + ");",
                    //    "INSERT INTO Product(ProductName, BrandID, CategoryID, Price, Date) VALUES('" + txtProductName.Text + "', " + Convert.ToInt32(ddlBrand.SelectedValue) + ", " + Convert.ToInt32(ddlCategory.SelectedValue) + ", " + Convert.ToSingle(txtPrice.Text) + ", '" + DateTime.Now + "');", 0);

                    if (chbActive.Checked)
                        binary = "True";
                    else
                        binary = "False";
                    string strcmd1 = "select UserName from Users where UserName='" + txtUserName.Text + "'";
                    string strcmd2 = "insert into Users values('" + txtUserName.Text + "', '" + txtPassword1.Text + "', " + ddlRole.SelectedValue + ", '" + txtFullName.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + binary + "');";

                    lblMsg.Text = SQLHelper.Commit(strcmd1, strcmd2, 0);
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
        txtFullName.Focus();
        grdUsers.DataBind();
        btnAdd.Text = "Add";
        HiddenField1.Value = "";
        divError.Visible = false;
    }

    protected void grdUsers_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void chbActive_CheckedChanged(object sender, EventArgs e)
    {
        if (chbActive.Checked)
            lblActive.Text = "User Active";
        else
            lblActive.Text = "User InActive";
    }
}