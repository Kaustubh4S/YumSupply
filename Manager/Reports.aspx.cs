using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_Reports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadBrand();
            LoadCategory();
            LoadProduct();
            LoadgrdReports();
        }
    }

    private void LoadgrdReports()
    {
        string strCmd = "SELECT Product.ProductID, Product.ProductName, Category.CategoryName, Brands.BrandName, SellChild.Price, SellChild.Quantity, SellParent.Dated, (SellChild.Price * SellChild.Quantity) AS NetAmt, SUM(Stocks.InQuantity) - SUM(Stocks.OutQuantity) AS Qty" +
            " FROM Product INNER JOIN Category ON Product.CategoryID = Category.CategoryID " +
            " INNER JOIN Brands ON Product.BrandID = Brands.BrandID " +
            " INNER JOIN SellChild ON Product.ProductID = SellChild.ProductID " +
            " INNER JOIN SellParent ON SellChild.SellID = SellParent.SellID " +
            " INNER JOIN Stocks ON Product.ProductID = Stocks.ProductID AND Category.CategoryID = Stocks.CategoryID AND Brands.BrandID = Stocks.BrandID " +
            " WHERE(1 = 1) ";
        if (ddlBrand.SelectedValue != "-1")
            strCmd += " and Stocks.BrandID= @0 ";
        if (ddlCategory.SelectedValue != "-1")
            strCmd += " and Stocks.CategoryID= @1 ";
        if (ddlProduct.SelectedValue != "-1")
            strCmd += " and Stocks.ProductID= @2";
        if (!(string.IsNullOrEmpty(txtFromDate.Text)))
            strCmd += " and SellParent.Dated>=@3 ";
        if (!(string.IsNullOrEmpty(txtToDate.Text)))
            strCmd += " and SellParent.Dated<=@4 ";
        strCmd += " GROUP BY Product.ProductID, Product.ProductName, Category.CategoryName, Brands.BrandName,SellChild.Price, SellChild.Quantity, SellParent.Dated " +
            " ORDER BY Product.ProductName";
        DataTable dt = SQLHelper.FillData(strCmd, ddlBrand.SelectedValue, ddlCategory.SelectedValue, ddlProduct.SelectedValue, txtFromDate.Text.Trim(), txtToDate.Text.Trim());
        grdReports.DataSource = dt;
        grdReports.DataBind();
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


    protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCategory();
        LoadProduct();
        LoadgrdReports();
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadProduct();
        LoadgrdReports();
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
        LoadgrdReports();
    }

    protected void txtFromDate_TextChanged(object sender, EventArgs e)
    {
        LoadgrdReports();
    }

    protected void txtToDate_TextChanged(object sender, EventArgs e)
    {
        LoadgrdReports();
    }
}