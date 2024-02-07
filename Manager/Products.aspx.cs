using System;
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
       // SaveProduct();
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
            DataTable dtProduct = SQLHelper.FillData(strCmd);
            if (dtProduct.Rows.Count > 0)
            {
                lblMsg.Text = "Product is Already Existed!";
                return;
            }
            string strCurrentDate = DateTime.Now.ToString("dd-MM-yyyy");
            string dt = DateTime.Now.ToString("dd-mmm-yyyy");
            lblMsg.Text = dt;
            strCmd = "INSERT INTO Product(ProductName, BrandID, CategoryID, Price, Date) VALUES('" + txtProductName.Text + "', " + Convert.ToInt32(ddlBrand.SelectedValue) + ", " + Convert.ToInt32(ddlCategory.SelectedValue) + ", " + Convert.ToSingle(txtPrice.Text) + ", " + Convert.ToDateTime(dt) + ");";
            SQLHelper.ExecuteNonQuery(strCmd);
            lblMsg.Text = "Product Added Sucessfully!";
            Clears();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void Clears()
    {
        txtProductName.Text = "";
        txtPrice.Text = "";
        txtProductName.Focus();
        grdProducts.DataBind();
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
            HiddenField1.Value = grdProducts.Rows[index].Cells[0].Text;
            txtProductName.Text = grdProducts.Rows[index].Cells[1].Text;
            btnAdd.Text = "Update";
        }
    }

    protected void grdVBrands_SelectedIndexChanged(object sender, EventArgs e)
    {
        string secondCellValue = grdProducts.SelectedRow.Cells[0].ToString();
        lblMsg.Text = secondCellValue;
    }

}

