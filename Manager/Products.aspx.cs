﻿using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Manager_Products : System.Web.UI.Page
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
        if (ddlBrand.SelectedValue == "-1")
        {
            lblMsg.Text = "Please Select Brand!";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }
        if (ddlCategory.SelectedValue == "-1")
        {
            lblMsg.Text = "Please Select Category!";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }

        if (HiddenField1.Value == "")
        {
            lblMsg.Text = "Product" + SQLHelper.Commit("SELECT ProductID FROM Product WHERE (ProductName='" + txtProductName.Text + "' AND BrandID=" + ddlBrand.SelectedValue + ");", 
                "INSERT INTO Product(ProductName, BrandID, CategoryID, Price, Date) VALUES('" + txtProductName.Text + "', " + Convert.ToInt32(ddlBrand.SelectedValue) + ", " + Convert.ToInt32(ddlCategory.SelectedValue) + ", " + Convert.ToSingle(txtPrice.Text) + ", '" + DateTime.Now + "');", 0);
            Clears();
        }
        else
        {
            lblMsg.Text = "Product" + SQLHelper.Commit("SELECT ProductID FROM Product WHERE ProductName='" + txtProductName.Text + "' and ProductID=" + HiddenField1.Value, 
                "update Product set ProductName='" + txtProductName.Text + "', BrandID=" + ddlBrand.SelectedValue + ", CategoryID=" + ddlCategory.SelectedValue + ",Price =" + Convert.ToSingle(txtPrice.Text) + " where ProductID=" + HiddenField1.Value, 1);
            Clears();
        }

    }

    private void Clears()
    {
        txtProductName.Text = "";
        txtPrice.Text = "";
        txtPrice.Text = "";
        ddlBrand.SelectedIndex = -1;
        ddlCategory.SelectedIndex = -1;
        txtProductName.Focus();
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
            ddlBrand.SelectedValue = getID("SELECT BrandID FROM Brands WHERE BrandName='" + grdProducts.Rows[index].Cells[2].Text + "';");
            ddlCategory.SelectedValue = getID("SELECT CategoryID FROM Category WHERE CategoryName='" + grdProducts.Rows[index].Cells[3].Text + "';");
            txtPrice.Text = grdProducts.Rows[index].Cells[4].Text;
            btnAdd.Text = "Update";
        }
    }

    private string getID(string cmd)
    {
        DataTable dt = SQLHelper.FillData(cmd);
        if (dt.Rows.Count > 0)
            return dt.Rows[0][0].ToString();
        else
            return null;
    }
}

