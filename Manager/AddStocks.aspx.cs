using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_AddStocks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadBrand();
            LoadCategory();
            LoadProduct();
            LoadgrdAddStocks();
        }
    }

    private void LoadBrand()
    {
        string strcmd = "Select BrandID, BrandName from Brands order by BrandName";
        DataTable dt = SQLHelper.FillData(strcmd);
        ddlBrand.DataTextField = "BrandName";
        ddlBrand.DataValueField = "BrandID";
        ddlBrand.DataSource = dt;
        ddlBrand.DataBind();
        ddlBrand.Items.Insert(0, new ListItem("~Select Brand~", "-1"));
    }

    private void LoadCategory()
    {
        string strcmd = "SELECT DISTINCT Category.CategoryID, Category.CategoryName FROM Category INNER JOIN Product ON Category.CategoryID = Product.CategoryID";
        if (ddlBrand.SelectedValue != "-1")
            strcmd += " WHERE Product.BrandID = @0 ";
        strcmd += " ORDER BY Category.CategoryName";
        DataTable dt = SQLHelper.FillData(strcmd, ddlBrand.SelectedValue);
        ddlCategory.DataSource = dt;
        ddlCategory.DataTextField = "CategoryName";
        ddlCategory.DataValueField = "CategoryID";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("~Select Category~", "-1"));
    }

    private void LoadProduct()
    {
        string strcmd = "SELECT ProductID, ProductName FROM Product ";
        if (ddlBrand.SelectedValue != "-1")
        {
            strcmd += " WHERE BrandID = @0 ";
            if (ddlCategory.SelectedValue != "-1")
                strcmd += " and CategoryID=@1 ";
        }
        else if (ddlCategory.SelectedValue != "-1")
            strcmd += " where CategoryID=@1 ";
        strcmd += " ORDER BY ProductName";
        DataTable dt = SQLHelper.FillData(strcmd, ddlBrand.SelectedValue, ddlCategory.SelectedValue);
        ddlProduct.DataTextField = "ProductName";
        ddlProduct.DataValueField = "ProductID";
        ddlProduct.DataSource = dt;
        ddlProduct.DataBind();
        ddlProduct.Items.Insert(0, new ListItem("~Select Product~", "-1"));
    }

    private void LoadgrdAddStocks()
    {
        string strcmd = "SELECT Product.ProductID, Product.ProductName, Category.CategoryName, Brands.BrandName, " +
            " SUM(Stocks.InQuantity) AS InQty, SUM(Stocks.OutQuantity) AS OutQty , SUM(Stocks.InQuantity)-SUM(Stocks.OutQuantity) AS Qty" +
        " FROM Product INNER JOIN " +
        "                  Stocks ON Product.ProductID = Stocks.ProductID INNER JOIN " +
        "                  Category ON Stocks.CategoryID = Category.CategoryID INNER JOIN " +
        "                  Brands ON Stocks.BrandID = Brands.BrandID where 1=1";
        if (ddlBrand.SelectedValue != "-1")
        {
            strcmd += " and Stocks.BrandID= @0 ";
        }
        if (ddlCategory.SelectedValue != "-1")
        {
            strcmd += " and Stocks.CategoryID= @1 ";
        }
        if (ddlProduct.SelectedValue != "-1")
        {
            strcmd += " and Stocks.ProductID= @2";
        }
        strcmd += " GROUP BY Product.ProductID, Product.ProductName, Category.CategoryName, Brands.BrandName ";
        strcmd += " ORDER BY Product.ProductName";
        DataTable dt = SQLHelper.FillData(strcmd, ddlBrand.SelectedValue, ddlCategory.SelectedValue, ddlProduct.SelectedValue);
        grdAddStocks.DataSource = dt;
        grdAddStocks.DataBind();
    }

    protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCategory();
        LoadProduct();
        LoadgrdAddStocks();
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadProduct();
        LoadgrdAddStocks();
    }

    protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id;
        if (!(ddlProduct.SelectedValue == "-1") && ddlBrand.SelectedValue == "-1" || ddlCategory.SelectedValue == "-1")
        {
            string cmd = "SELECT CategoryID from Product WHERE ProductID=@0";
            id = SQLHelper.getID(cmd, ddlProduct.SelectedValue);
            ddlCategory.SelectedValue = id.ToString();

            cmd = "SELECT BrandID from Product WHERE ProductID=@0";
            id = SQLHelper.getID(cmd, ddlProduct.SelectedValue);
            ddlBrand.SelectedValue = id.ToString();
        }
        else
        {
            if (ddlProduct.SelectedValue == "-1")
            {
                ddlCategory.SelectedValue = "-1";
                ddlBrand.SelectedValue = "-1";
            }
            else
            {
                string cmd = "SELECT CategoryID from Product WHERE ProductID=@0";
                id = SQLHelper.getID(cmd, ddlProduct.SelectedValue);
                ddlCategory.SelectedValue = id.ToString();

                cmd = "SELECT BrandID from Product WHERE ProductID=@0";
                id = SQLHelper.getID(cmd, ddlProduct.SelectedValue);
                ddlBrand.SelectedValue = id.ToString();
            }
        }
        LoadgrdAddStocks();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
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

        if (ddlProduct.SelectedValue == "-1")
        {
            lblMsg.Text = "Please Select Product!";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            ddlProduct.Focus();
            return;
        }

        if (txtQuantity.Text == "0")
        {
            lblMsg.Text = "Insert Valid Quantity!";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            txtQuantity.Text = "";
            txtQuantity.Focus();
            return;
        }
        string cmd = "SELECT InQuantity FROM Stocks WHERE (ProductID = @0)";
        int inQty = SQLHelper.getID(cmd, ddlProduct.SelectedValue);
        if (inQty > 0)
        {
            cmd = "UPDATE Stocks SET InQuantity = @0 WHERE (ProductID = @1)";
            SQLHelper.ExecuteQuery(cmd, (inQty + Convert.ToInt32(txtQuantity.Text)), ddlProduct.SelectedValue);
        }
        else
        {
            cmd = "INSERT INTO Stocks (ProductID, BrandID, CategoryID, InQuantity, OutQuantity) VALUES (@0, @1, @2, @3, @4)";
            SQLHelper.ExecuteQuery(cmd, ddlProduct.SelectedValue, ddlBrand.SelectedValue, ddlCategory.SelectedValue, txtQuantity.Text, 0);
        }
        lblMsg.Text = "Quantity Added Sucessfully!";
        Clears();
    }

    private void Clears()
    {
        ddlBrand.SelectedValue = "-1";
        ddlCategory.SelectedValue = "-1";
        ddlProduct.SelectedValue = "-1";
        txtQuantity.Text = "";
        LoadgrdAddStocks();
    }
}