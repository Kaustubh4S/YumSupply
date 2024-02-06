using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
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

        /*
        if (HiddenField1.Value == "")
        {
            //save
            SaveProduct();
        }
        else
        {
            //update
            UpdateProduct();
        }
        */
    }

    private void SaveProduct()
    {
        try
        {
            string strCmd = "SELECT ProductID FROM Product WHERE ProductName='" + txtProductName.Text + "';";
            DataTable dt = SQLHelper.FillData(strCmd);
            if (dt.Rows.Count > 0)
            {
                lblMsg.Text = "Product is Already Existed!";
            }
            else
            {
                strCmd = "INSERT INTO Product(ProductName, BrandID, CategoryID, Price) VALUES('" + txtProductName.Text + "');";
                SQLHelper.ExecuteNonQuery(strCmd);
                lblMsg.Text = "Product Added Sucessfully!";
                Clears();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void Clears()
    {
        txtProductName.Text = "";
        txtProductName.Focus();
        GridView1.DataBind();
        btnAdd.Text = "Save";
        HiddenField1.Value = "";

    }

    private void UpdateProduct()
    {
        try
        {
            string strCmd = "SELECT ProductID FROM Product WHERE ProductName='" + txtProductName.Text + "' and ProductID<>" + HiddenField1.Value;
            DataTable dt = SQLHelper.FillData(strCmd);
            if (dt.Rows.Count > 0)
            {
                lblMsg.Text = "Product is Already Exist";
            }
            else
            {
                strCmd = "update Product set ProductName='" + txtProductName.Text + "' where ProductID=" + HiddenField1.Value;
                SQLHelper.ExecuteNonQuery(strCmd);
                lblMsg.Text = "Product updated Sucessfully!";
                Clears();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void grdVBrands_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ed")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            HiddenField1.Value = GridView1.Rows[index].Cells[0].Text;
            txtProductName.Text = GridView1.Rows[index].Cells[1].Text;
            btnAdd.Text = "Update";
        }
    }

    protected void grdVBrands_SelectedIndexChanged(object sender, EventArgs e)
    {
        string secondCellValue = GridView1.SelectedRow.Cells[0].ToString();
        lblMsg.Text = secondCellValue;
    }
    
}

