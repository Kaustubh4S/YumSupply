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
        if (string.IsNullOrEmpty(Session["UserID"].ToString()) || !(Session["RoleId"].ToString() == "1"))
            Response.Redirect("~/Default.aspx");
        if (!Page.IsPostBack)
        {
            LoadBrand();
            LoadCategory();
            LoadProduct();
            LoadgrdAddStocks(0);
        }
    }

    private void LoadBrand()
    {
        try
        {
            string strcmd = "Select BrandID, BrandName from Brands order by BrandName";
            DataTable dt = SQLHelper.FillData(strcmd);
            ddlBrand.DataTextField = "BrandName";
            ddlBrand.DataValueField = "BrandID";
            ddlBrand.DataSource = dt;
            ddlBrand.DataBind();
            ddlBrand.Items.Insert(0, new ListItem("~Select Brand~", "-1"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void LoadCategory()
    {
        try
        {
            string strcmd = "SELECT Category.CategoryID, Category.CategoryName FROM Category INNER JOIN Product ON Category.CategoryID = Product.CategoryID WHERE Product.BrandID = @0 ORDER BY Category.CategoryName";
            DataTable dt = SQLHelper.FillData(strcmd, ddlBrand.SelectedValue);
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataSource = dt;
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("~Select Category~", "-1"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void LoadProduct()
    {
        try
        {
            string strcmd = "SELECT ProductID, ProductName FROM Product WHERE BrandID = @0 or CategoryID=@1 ORDER BY ProductName";
            DataTable dt = SQLHelper.FillData(strcmd, ddlBrand.SelectedValue, ddlCategory.SelectedValue);
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataValueField = "ProductID";
            ddlProduct.DataSource = dt;
            ddlProduct.DataBind();
            ddlProduct.Items.Insert(0, new ListItem("~Select Product~", "-1"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void LoadgrdAddStocks(int Default0Brand1Category2Product3)
    {
        try
        {
            if (Default0Brand1Category2Product3 == 0)
                SqlDataSource1.SelectCommand = "SELECT Stocks.StockID, Product.ProductName, Category.CategoryName, Brands.BrandName, Stocks.InQuantity, Stocks.OutQuantity FROM Brands INNER JOIN Product ON Brands.BrandID = Product.BrandID INNER JOIN Category ON Product.CategoryID = Category.CategoryID INNER JOIN Stocks ON Brands.BrandID = Stocks.BrandID AND Product.ProductID = Stocks.ProductID AND Category.CategoryID = Stocks.CategoryID  WHERE Stocks.OutQuantity=0 ORDER BY Stocks.StockID DESC";
            if (Default0Brand1Category2Product3 == 1)
                SqlDataSource1.SelectCommand = "SELECT Stocks.StockID, Product.ProductName, Category.CategoryName, Brands.BrandName, Stocks.InQuantity, Stocks.OutQuantity FROM Brands INNER JOIN Product ON Brands.BrandID = Product.BrandID INNER JOIN Category ON Product.CategoryID = Category.CategoryID INNER JOIN Stocks ON Brands.BrandID = Stocks.BrandID AND Product.ProductID = Stocks.ProductID AND Category.CategoryID = Stocks.CategoryID WHERE Stocks.OutQuantity=0 AND Brands.BrandID=" + ddlBrand.SelectedValue + " ORDER BY Stocks.StockID DESC";
            if (Default0Brand1Category2Product3 == 2)
                SqlDataSource1.SelectCommand = "SELECT Stocks.StockID, Product.ProductName, Category.CategoryName, Brands.BrandName, Stocks.InQuantity, Stocks.OutQuantity FROM Brands INNER JOIN Product ON Brands.BrandID = Product.BrandID INNER JOIN Category ON Product.CategoryID = Category.CategoryID INNER JOIN Stocks ON Brands.BrandID = Stocks.BrandID AND Product.ProductID = Stocks.ProductID AND Category.CategoryID = Stocks.CategoryID WHERE Stocks.OutQuantity=0 AND Brands.BrandID=" + ddlBrand.SelectedValue + " OR Category.CategoryID=" + ddlCategory.SelectedValue + " ORDER BY Stocks.StockID DESC";
            if (Default0Brand1Category2Product3 == 3)
                SqlDataSource1.SelectCommand = "SELECT Stocks.StockID, Product.ProductName, Category.CategoryName, Brands.BrandName, Stocks.InQuantity, Stocks.OutQuantity FROM Brands INNER JOIN Product ON Brands.BrandID = Product.BrandID INNER JOIN Category ON Product.CategoryID = Category.CategoryID INNER JOIN Stocks ON Brands.BrandID = Stocks.BrandID AND Product.ProductID = Stocks.ProductID AND Category.CategoryID = Stocks.CategoryID WHERE WHERE Stocks.OutQuantity=0 AND Brands.BrandID=" + ddlBrand.SelectedValue + " OR Category.CategoryID=" + ddlCategory.SelectedValue + " OR Product.ProductID=" + ddlProduct.SelectedValue + " ORDER BY Stocks.StockID DESC";
            grdAddStocks.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCategory();
        LoadProduct();
        LoadgrdAddStocks(1);
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadProduct();
        LoadgrdAddStocks(2);
    }

    protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadgrdAddStocks(3);
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

        if (ddlProduct.SelectedValue == "-1")
        {
            lblMsg.Text = "Please Select Product!";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            return;
        }

        string cmd = "INSERT INTO Stocks (ProductID, BrandID, CategoryID, InQuantity, OutQuantity) VALUES (@0, @1, @2, @3, @4)";
        SQLHelper.ExecuteQuery(cmd, ddlProduct.SelectedValue, ddlBrand.SelectedValue, ddlCategory.SelectedValue, txtQuantity.Text, 0);
        lblMsg.Text = "Quantity Added Sucessfully!";
        Clears();
    }

    private void Clears()
    {
        ddlBrand.SelectedValue = "-1";
        ddlCategory.SelectedValue = "-1";
        ddlProduct.SelectedValue = "-1";
        txtQuantity.Text = "";
        LoadgrdAddStocks(0);
    }
}