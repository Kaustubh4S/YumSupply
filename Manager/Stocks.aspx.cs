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
        if (!Page.IsPostBack)
        {
            LoadBrand();
            LoadCategory();
            LoadProduct();
            LoadgrdStocks();
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

    private void LoadgrdStocks()
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
        grdStocks.DataSource = dt;
        grdStocks.DataBind();
    }

    protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCategory();
        LoadProduct();
        LoadgrdStocks();
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadProduct();
        LoadgrdStocks();
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
        LoadgrdStocks();
    }

    protected void grdStocks_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdStocks.PageIndex = e.NewPageIndex;
        LoadgrdStocks();
    }
}