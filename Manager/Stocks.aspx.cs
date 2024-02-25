using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_Stocks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Session["UserID"].ToString()) || !(Session["RoleId"].ToString() == "1"))
            Response.Redirect("~/Default.aspx");
        if (!Page.IsPostBack)
        {
            LoadBrand();
            LoadCategory(0);
            LoadProduct(0);
            LoadgrdStocks(0);
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

    private void LoadCategory(int Default0Brand1)
    {
        try
        {
            string strcmd;
            if (Default0Brand1 == 0)
            {
                strcmd = "SELECT CategoryID, CategoryName FROM Category ORDER BY CategoryName";
                DataTable dt = SQLHelper.FillData(strcmd);
                ddlCategory.DataSource = dt;
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("~Select Category~", "-1"));
                return;
            }
            if (Default0Brand1 == 1)
            {
                strcmd = "SELECT DISTINCT Category.CategoryID, Category.CategoryName FROM Category INNER JOIN Product ON Category.CategoryID = Product.CategoryID WHERE Product.BrandID = @0 ORDER BY Category.CategoryName";
                DataTable dt = SQLHelper.FillData(strcmd, ddlBrand.SelectedValue);
                ddlCategory.DataSource = dt;
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("~Select Category~", "-1"));
                return;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void LoadProduct(int Default0Brand1Category2)
    {
        try
        {
            string strcmd;
            if (Default0Brand1Category2 == 0)
            {
                strcmd = "SELECT ProductID, ProductName FROM Product ORDER BY ProductName";
                DataTable dt = SQLHelper.FillData(strcmd);
                ddlProduct.DataTextField = "ProductName";
                ddlProduct.DataValueField = "ProductID";
                ddlProduct.DataSource = dt;
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("~Select Product~", "-1"));
                return;
            }
            if (Default0Brand1Category2 == 1)
            {
                strcmd = "SELECT ProductID, ProductName FROM Product WHERE BrandID = @0 ORDER BY ProductName";
                DataTable dt = SQLHelper.FillData(strcmd, ddlBrand.SelectedValue);
                ddlProduct.DataTextField = "ProductName";
                ddlProduct.DataValueField = "ProductID";
                ddlProduct.DataSource = dt;
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("~Select Product~", "-1"));
            }
            if (Default0Brand1Category2 == 2)
            {
                strcmd = "SELECT ProductID, ProductName FROM Product WHERE CategoryID=@0 ORDER BY ProductName";
                DataTable dt = SQLHelper.FillData(strcmd, ddlCategory.SelectedValue);
                ddlProduct.DataTextField = "ProductName";
                ddlProduct.DataValueField = "ProductID";
                ddlProduct.DataSource = dt;
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("~Select Product~", "-1"));
            }
            if (Default0Brand1Category2 == 012)
            {
                strcmd = "SELECT ProductID, ProductName FROM Product WHERE BrandID = @0 OR CategoryID=@1 ORDER BY ProductName";
                DataTable dt = SQLHelper.FillData(strcmd, ddlBrand.SelectedValue, ddlCategory.SelectedValue);
                ddlProduct.DataTextField = "ProductName";
                ddlProduct.DataValueField = "ProductID";
                ddlProduct.DataSource = dt;
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("~Select Product~", "-1"));
            }
            if (Default0Brand1Category2 == 120)
            {
                strcmd = "SELECT ProductID, ProductName FROM Product WHERE BrandID = @0 AND CategoryID=@1 ORDER BY ProductName";
                DataTable dt = SQLHelper.FillData(strcmd, ddlBrand.SelectedValue, ddlCategory.SelectedValue);
                ddlProduct.DataTextField = "ProductName";
                ddlProduct.DataValueField = "ProductID";
                ddlProduct.DataSource = dt;
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("~Select Product~", "-1"));
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void LoadgrdStocks(int Default0Brand1Category2Product3)
    {
        try
        {
            if (Default0Brand1Category2Product3 == 0)
                SqlDataSource1.SelectCommand = "SELECT Stocks.StockID, Product.ProductName, Category.CategoryName, Brands.BrandName, Stocks.InQuantity, Stocks.OutQuantity FROM Brands INNER JOIN Product ON Brands.BrandID = Product.BrandID INNER JOIN Category ON Product.CategoryID = Category.CategoryID INNER JOIN Stocks ON Brands.BrandID = Stocks.BrandID AND Product.ProductID = Stocks.ProductID AND Category.CategoryID = Stocks.CategoryID ORDER BY Stocks.StockID DESC";
            if (Default0Brand1Category2Product3 == 1)
                SqlDataSource1.SelectCommand = "SELECT Stocks.StockID, Product.ProductName, Category.CategoryName, Brands.BrandName, Stocks.InQuantity, Stocks.OutQuantity FROM Brands INNER JOIN Product ON Brands.BrandID = Product.BrandID INNER JOIN Category ON Product.CategoryID = Category.CategoryID INNER JOIN Stocks ON Brands.BrandID = Stocks.BrandID AND Product.ProductID = Stocks.ProductID AND Category.CategoryID = Stocks.CategoryID WHERE Brands.BrandID=" + ddlBrand.SelectedValue + " ORDER BY Stocks.StockID DESC";
            if (Default0Brand1Category2Product3 == 2)
                SqlDataSource1.SelectCommand = "SELECT Stocks.StockID, Product.ProductName, Category.CategoryName, Brands.BrandName, Stocks.InQuantity, Stocks.OutQuantity FROM Brands INNER JOIN Product ON Brands.BrandID = Product.BrandID INNER JOIN Category ON Product.CategoryID = Category.CategoryID INNER JOIN Stocks ON Brands.BrandID = Stocks.BrandID AND Product.ProductID = Stocks.ProductID AND Category.CategoryID = Stocks.CategoryID WHERE Category.CategoryID=" + ddlCategory.SelectedValue + " ORDER BY Stocks.StockID DESC";
            if (Default0Brand1Category2Product3 == 3)
                SqlDataSource1.SelectCommand = "SELECT Stocks.StockID, Product.ProductName, Category.CategoryName, Brands.BrandName, Stocks.InQuantity, Stocks.OutQuantity FROM Brands INNER JOIN Product ON Brands.BrandID = Product.BrandID INNER JOIN Category ON Product.CategoryID = Category.CategoryID INNER JOIN Stocks ON Brands.BrandID = Stocks.BrandID AND Product.ProductID = Stocks.ProductID AND Category.CategoryID = Stocks.CategoryID WHERE Product.ProductID=" + ddlProduct.SelectedValue + " ORDER BY Stocks.StockID DESC";
            if (Default0Brand1Category2Product3 == 120)
                SqlDataSource1.SelectCommand = "SELECT Stocks.StockID, Product.ProductName, Category.CategoryName, Brands.BrandName, Stocks.InQuantity, Stocks.OutQuantity FROM Brands INNER JOIN Product ON Brands.BrandID = Product.BrandID INNER JOIN Category ON Product.CategoryID = Category.CategoryID INNER JOIN Stocks ON Brands.BrandID = Stocks.BrandID AND Product.ProductID = Stocks.ProductID AND Category.CategoryID = Stocks.CategoryID WHERE Brands.BrandID=" + ddlBrand.SelectedValue + " AND Category.CategoryID=" + ddlCategory.SelectedValue + " ORDER BY Stocks.StockID DESC";
            if (Default0Brand1Category2Product3 == 230)
                SqlDataSource1.SelectCommand = "SELECT Stocks.StockID, Product.ProductName, Category.CategoryName, Brands.BrandName, Stocks.InQuantity, Stocks.OutQuantity FROM Brands INNER JOIN Product ON Brands.BrandID = Product.BrandID INNER JOIN Category ON Product.CategoryID = Category.CategoryID INNER JOIN Stocks ON Brands.BrandID = Stocks.BrandID AND Product.ProductID = Stocks.ProductID AND Category.CategoryID = Stocks.CategoryID WHERE Category.CategoryID=" + ddlCategory.SelectedValue + " AND Product.ProductID=" + ddlProduct.SelectedValue + " ORDER BY Stocks.StockID DESC";
            if (Default0Brand1Category2Product3 == 130)
                SqlDataSource1.SelectCommand = "SELECT Stocks.StockID, Product.ProductName, Category.CategoryName, Brands.BrandName, Stocks.InQuantity, Stocks.OutQuantity FROM Brands INNER JOIN Product ON Brands.BrandID = Product.BrandID INNER JOIN Category ON Product.CategoryID = Category.CategoryID INNER JOIN Stocks ON Brands.BrandID = Stocks.BrandID AND Product.ProductID = Stocks.ProductID AND Category.CategoryID = Stocks.CategoryID WHERE Brands.BrandID=" + ddlBrand.SelectedValue + " AND Product.ProductID=" + ddlProduct.SelectedValue + " ORDER BY Stocks.StockID DESC";
            if (Default0Brand1Category2Product3 == 1230)
                SqlDataSource1.SelectCommand = "SELECT Stocks.StockID, Product.ProductName, Category.CategoryName, Brands.BrandName, Stocks.InQuantity, Stocks.OutQuantity FROM Brands INNER JOIN Product ON Brands.BrandID = Product.BrandID INNER JOIN Category ON Product.CategoryID = Category.CategoryID INNER JOIN Stocks ON Brands.BrandID = Stocks.BrandID AND Product.ProductID = Stocks.ProductID AND Category.CategoryID = Stocks.CategoryID WHERE Brands.BrandID=" + ddlBrand.SelectedValue + " AND Category.CategoryID=" + ddlCategory.SelectedValue + " AND Product.ProductID=" + ddlProduct.SelectedValue + " ORDER BY Stocks.StockID DESC";
            if (Default0Brand1Category2Product3 == 0123)
                SqlDataSource1.SelectCommand = "SELECT Stocks.StockID, Product.ProductName, Category.CategoryName, Brands.BrandName, Stocks.InQuantity, Stocks.OutQuantity FROM Brands INNER JOIN Product ON Brands.BrandID = Product.BrandID INNER JOIN Category ON Product.CategoryID = Category.CategoryID INNER JOIN Stocks ON Brands.BrandID = Stocks.BrandID AND Product.ProductID = Stocks.ProductID AND Category.CategoryID = Stocks.CategoryID WHERE Brands.BrandID=" + ddlBrand.SelectedValue + " OR Category.CategoryID=" + ddlCategory.SelectedValue + " OR Product.ProductID=" + ddlProduct.SelectedValue + " ORDER BY Stocks.StockID DESC";
            grdStocks.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBrand.SelectedValue == "-1")
        {
            LoadCategory(0);
            if (ddlCategory.SelectedValue == "-1")
            {
                LoadProduct(0);
                LoadgrdStocks(0);
                return;
            }
            else
            {
                LoadProduct(2);
                LoadgrdStocks(2);
                return;
            }
        }
        else
        {
            LoadCategory(1);
            if (ddlCategory.SelectedValue == "-1")
            {
                LoadProduct(1);
                LoadgrdStocks(1);
                return;
            }
            else
            {
                LoadProduct(120);
                LoadgrdStocks(120);
                return;
            }
        }
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategory.SelectedValue == "-1")
        {
            if (ddlBrand.SelectedValue == "-1")
            {
                LoadProduct(0);
                LoadgrdStocks(0);
                return;
            }
            else
            {
                LoadProduct(1);
                LoadgrdStocks(1);
                return;
            }
        }
        else
        {
            if (ddlBrand.SelectedValue == "-1")
            {
                LoadProduct(2);
                LoadgrdStocks(2);
                return;
            }
            else
            {
                LoadProduct(120);
                LoadgrdStocks(120);
                return;
            }
        }
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

        if (ddlProduct.SelectedValue == "-1" && ddlCategory.SelectedValue == "-1" && ddlBrand.SelectedValue == "-1")
            LoadgrdStocks(0);
        else
        {
            if (!(ddlBrand.SelectedValue == "-1"))
            {
                if (!(ddlCategory.SelectedValue == "-1"))
                {
                    if (!(ddlProduct.SelectedValue == "-1"))
                    {
                        LoadgrdStocks(1230);
                        return;
                    }
                    else
                    {
                        LoadgrdStocks(120);
                        return;
                    }
                }
                else
                {
                    if (!(ddlProduct.SelectedValue == "-1"))
                    {
                        LoadgrdStocks(130);
                        return;
                    }
                    else
                    {
                        LoadgrdStocks(1);
                        return;
                    }
                }
            }
            else
            {
                if (!(ddlCategory.SelectedValue == "-1"))
                {
                    if (!(ddlProduct.SelectedValue == "-1"))
                    {
                        LoadgrdStocks(230);
                        return;
                    }
                    else
                    {
                        LoadgrdStocks(2);
                        return;
                    }
                }
                else
                {
                    if (!(ddlProduct.SelectedValue == "-1"))
                    {
                        LoadgrdStocks(3);
                        return;
                    }
                    else
                    {
                        LoadgrdStocks(0);
                        return;
                    }
                }
            }
        }
    }
}