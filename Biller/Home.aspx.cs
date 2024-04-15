using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Biller_Home : System.Web.UI.Page
{ 
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadDetails();
    }

    private void LoadDetails()
    {
        string strcmd = "SELECT COUNT(BrandID) FROM Brands";
        DataTable dt = SQLHelper.FillData(strcmd);
        lblBrands.Text = dt.Rows[0][0].ToString();

        strcmd = "SELECT COUNT(CategoryID) FROM Category";
        dt = SQLHelper.FillData(strcmd);
        lblCategory.Text = dt.Rows[0][0].ToString();

        strcmd = "SELECT COUNT(ProductID) FROM Product";
        dt = SQLHelper.FillData(strcmd);
        lblProducts.Text = dt.Rows[0][0].ToString();
    }
}