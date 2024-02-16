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
<<<<<<< Updated upstream
            //save
            SaveProduct();
        }
        else
        {
            //update
            UpdateProduct();
=======
            lblMsg.Text = "Product" + SQLHelper.Commit("SELECT ProductID FROM Product WHERE (ProductName='" + txtProductName.Text + "' AND BrandID=" + ddlBrand.SelectedValue + ");",
                "INSERT INTO Product(ProductName, BrandID, CategoryID, Price, Date) VALUES('" + txtProductName.Text + "', " + Convert.ToInt32(ddlBrand.SelectedValue) + ", " + Convert.ToInt32(ddlCategory.SelectedValue) + ", " + Convert.ToSingle(txtPrice.Text) + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');", 0);

            /*
             * cmd.CommandText = "INSERT INTO Product (ProductID, CategoryID, BrandID, ProductName, Price, Date) OUTPUT inserted.ProductID, inserted.CategoryID, inserted.BrandID, @Quantity INTO AddStocks VALUES (@ProductID, @CategoryID, @BrandID, @ProductName, @Price, @Date)";
// add the parameters to the command object
cmd.Parameters.AddWithValue ("@ProductID", ProductID);
cmd.Parameters.AddWithValue ("@CategoryID", CategoryID);
cmd.Parameters.AddWithValue ("@BrandID", BrandID);
cmd.Parameters.AddWithValue ("@ProductName", ProductName);
cmd.Parameters.AddWithValue ("@Price", Price);
cmd.Parameters.AddWithValue ("@Date", Date);
cmd.Parameters.AddWithValue ("@Quantity", Quantity);*/

            int PID = Convert.ToInt32(getID("SELECT ProductID FROM Product WHERE (ProductName='" + txtProductName.Text + "' AND BrandID=" + ddlBrand.SelectedValue + ");"));

            if (PID != 0)
                SQLHelper.Commit("SELECT AddStockID FROM AddStocks WHERE (ProductID=" + PID + ");",
                    "INSERT INTO AddStocks(ProductID, CategoryID, BrandID, Quantity) VALUES(" + PID + "," + Convert.ToInt32(ddlCategory.SelectedValue) + ", " + Convert.ToInt32(ddlBrand.SelectedValue) + ", " + Convert.ToInt32(txtQuantity.Text) + ");", 0);
            Clears();
        }
        else
        {
            lblMsg.Text = "Product" + SQLHelper.Commit("SELECT ProductID FROM Product WHERE ProductName='" + txtProductName.Text + "' and ProductID=" + HiddenField1.Value,
                "update Product set ProductName='" + txtProductName.Text + "', BrandID=" + ddlBrand.SelectedValue + ", CategoryID=" + ddlCategory.SelectedValue + ",Price =" + Convert.ToSingle(txtPrice.Text) + " where ProductID=" + HiddenField1.Value, 1);
            Clears();
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======
        txtPrice.Text = "";
        txtPrice.Text = "";
        txtQuantity.Text = "";
        txtQuantity.ReadOnly = false;
        ddlBrand.SelectedIndex = -1;
        ddlCategory.SelectedIndex = -1;
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            HiddenField1.Value = GridView1.Rows[index].Cells[0].Text;
            txtProductName.Text = GridView1.Rows[index].Cells[1].Text;
=======
            HiddenField1.Value = grdProducts.Rows[index].Cells[0].Text;
            txtProductName.Text = grdProducts.Rows[index].Cells[1].Text;
            ddlBrand.SelectedValue = ddlBrand.Items.FindByText(grdProducts.Rows[index].Cells[2].Text).Value;
            ddlCategory.SelectedValue = ddlCategory.Items.FindByText(grdProducts.Rows[index].Cells[3].Text).Value;
            //ddlBrand.SelectedValue = getID("SELECT BrandID FROM Brands WHERE BrandName='" + grdProducts.Rows[index].Cells[2].Text + "';");
            //ddlCategory.SelectedValue = getID("SELECT CategoryID FROM Category WHERE CategoryName='" + grdProducts.Rows[index].Cells[3].Text + "';");
            txtPrice.Text = grdProducts.Rows[index].Cells[4].Text;
            txtQuantity.Text = grdProducts.Rows[index].Cells[5].Text;
            txtQuantity.ReadOnly = true;
>>>>>>> Stashed changes
            btnAdd.Text = "Update";
        }
    }

    protected void grdVBrands_SelectedIndexChanged(object sender, EventArgs e)
    {
        string secondCellValue = GridView1.SelectedRow.Cells[0].ToString();
        lblMsg.Text = secondCellValue;
    }
    
}

