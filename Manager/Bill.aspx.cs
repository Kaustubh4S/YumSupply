using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Manager_Bill : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Session["UserID"].ToString()) || !(Session["RoleId"].ToString() == "1"))
            Response.Redirect("~/Default.aspx");
        if (!Page.IsPostBack)
        {
            LoadCustomer();
            LoadBrands();
            LoadCategory();
            LoadProducts();
            LoadPrice();
            LoadRemQuantity();
            lblAmt.Text = "0.0";
            lblQty.Text = "0";
        }
    }

    private void LoadCustomer()
    {
        string strcmd = "SELECT CustomerID, CustomerName from Customer ORDER BY CustomerName";
        DataTable dt = SQLHelper.FillData(strcmd);
        ddlCust.DataTextField = "CustomerName";
        ddlCust.DataValueField = "CustomerID";
        ddlCust.DataSource = dt;
        ddlCust.DataBind();
        ddlCust.Items.Insert(0, new ListItem("~Select Customer~", "-1"));
    }

    private void LoadBrands()
    {
        string strcmd = "SELECT BrandID, BrandName " +
                        " FROM Brands " +
                        " ORDER BY BrandName";
        DataTable dt = SQLHelper.FillData(strcmd);
        ddlBrands.DataTextField = "BrandName";
        ddlBrands.DataValueField = "BrandID";
        ddlBrands.DataSource = dt;
        ddlBrands.DataBind();
        ddlBrands.Items.Insert(0, new ListItem("~Select Brand~", "-1"));
    }

    private void LoadCategory()
    {
        string strcmd = "SELECT DISTINCT Category.CategoryID, Category.CategoryName FROM Category INNER JOIN Product ON Category.CategoryID = Product.CategoryID";
        if (ddlBrands.SelectedValue != "-1")
            strcmd += " WHERE Product.BrandID = @0 ";
        strcmd += " ORDER BY Category.CategoryName";
        DataTable dt = SQLHelper.FillData(strcmd, ddlBrands.SelectedValue);
        ddlCategory.DataSource = dt;
        ddlCategory.DataTextField = "CategoryName";
        ddlCategory.DataValueField = "CategoryID";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("~Select Category~", "-1"));
    }

    private void LoadProducts()
    {
        string strcmd = "SELECT Product.ProductID, Product.ProductName FROM Product INNER JOIN Stocks ON Product.ProductID = Stocks.ProductID ";
        if (ddlBrands.SelectedValue != "-1")
        {
            strcmd += " WHERE Product.BrandID = @0 ";
            if (ddlCategory.SelectedValue != "-1")
                strcmd += " and Product.CategoryID=@1 ";
        }
        else if (ddlCategory.SelectedValue != "-1")
            strcmd += " where Product.CategoryID=@1 ";
        else if (ddlBrands.SelectedValue == "-1" && ddlCategory.SelectedValue == "-1")
            strcmd += " WHERE (Stocks.InQuantity > 0)";
        strcmd += " AND (Stocks.InQuantity > 0)";
        strcmd += " ORDER BY Product.ProductName";
        DataTable dt = SQLHelper.FillData(strcmd, ddlBrands.SelectedValue, ddlCategory.SelectedValue);
        ddlProduct.DataTextField = "ProductName";
        ddlProduct.DataValueField = "ProductID";
        ddlProduct.DataSource = dt;
        ddlProduct.DataBind();
        ddlProduct.Items.Insert(0, new ListItem("~Select Product~", "-1"));
    }

    private void LoadPrice()
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlProduct.SelectedValue))
            {
                string strcmd = "SELECT Price FROM Product WHERE(ProductID =@0)";
                DataTable dt = SQLHelper.FillData(strcmd, ddlProduct.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    txtPrice.Text = dt.Rows[0]["Price"].ToString();
                }
                else
                {
                    txtPrice.Text = "";
                }
            }
            else
            {
                txtPrice.Text = "";
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    private void LoadRemQuantity()
    {
        try
        {
            if (!string.IsNullOrEmpty(ddlProduct.SelectedValue))
            {
                string strcmd = "SELECT SUM(Stocks.InQuantity)-SUM(Stocks.OutQuantity) AS Qty FROM Product INNER JOIN Stocks ON Product.ProductID = Stocks.ProductID WHERE(Product.ProductID =@0)";
                DataTable dt = SQLHelper.FillData(strcmd, ddlProduct.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    txtRemQty.Text = dt.Rows[0]["Qty"].ToString();
                }
                else
                {
                    txtRemQty.Text = "";
                }
            }
            else
            {
                txtRemQty.Text = "";
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    private void Clears()
    {
        if (ddlProduct.SelectedValue == "-1")
        {
            txtQty.Text = "";
            txtPrice.Text = "";
            txtRemQty.Text = "";
        }
        else
        {
            txtQty.Text = "";
            txtPrice.Text = "";
            txtRemQty.Text = "";
            ddlBrands.SelectedValue = "-1";
            ddlCategory.SelectedValue = "-1";
            ddlProduct.SelectedValue = "-1";
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ddlCust.SelectedValue == "-1")
        {
            lblMsg.Text = "Please Select Customer!";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            ddlCust.Focus();
            return;
        }

        if (string.IsNullOrEmpty(txtDate.Text))
        {
            lblMsg.Text = "Please Select Date!";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            txtDate.Focus();
            return;
        }

        if (ddlBrands.SelectedValue == "-1")
        {
            lblMsg.Text = "Please Select Brand!";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            ddlBrands.Focus();
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

        if (string.IsNullOrEmpty(txtQty.Text))
        {
            lblMsg.Text = "Please Select Quantity!";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            txtQty.Focus();
            return;
        }

        if ((Convert.ToInt32(txtRemQty.Text) - Convert.ToInt32(txtQty.Text)) < 0)
        {
            lblMsg.Text = "Quantity Can not Exceed!";
            lblMsg.ForeColor = System.Drawing.Color.Red;
            txtQty.Focus();
            return;
        }
        try
        {
            List<BillData> lst = new List<BillData>();
            BillData billData = new BillData()
            {
                BrandID = Convert.ToInt32(ddlBrands.SelectedValue),
                BrandName = ddlBrands.SelectedItem.Text,
                CateID = Convert.ToInt32(ddlCategory.SelectedValue),
                CatName = ddlCategory.SelectedItem.Text,
                ProductID = Convert.ToInt32(ddlProduct.SelectedValue),
                ProductName = ddlProduct.SelectedItem.Text,
                Price = Convert.ToDouble(txtPrice.Text),
                Qty = Convert.ToInt32(txtQty.Text),
                NetAmout = Convert.ToDouble(txtPrice.Text) * Convert.ToInt32(txtQty.Text)
            };
            if (Session["BillData"] != null)
            {
                lst = (List<BillData>)Session["BillData"];
            }
            lst.Add(billData);
            Session["BillData"] = lst;
            grdBillView.DataSource = lst.ToList();
            grdBillView.DataBind();
            LoadNetAmtNQty();
            Clears();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id;
        if (!(ddlProduct.SelectedValue == "-1") && ddlBrands.SelectedValue == "-1" || ddlCategory.SelectedValue == "-1")
        {
            string cmd = "SELECT CategoryID from Product WHERE ProductID=@0";
            id = SQLHelper.getID(cmd, ddlProduct.SelectedValue);
            ddlCategory.SelectedValue = id.ToString();

            cmd = "SELECT BrandID from Product WHERE ProductID=@0";
            id = SQLHelper.getID(cmd, ddlProduct.SelectedValue);
            ddlBrands.SelectedValue = id.ToString();
        }
        else
        {
            if (ddlProduct.SelectedValue == "-1")
            {
                ddlCategory.SelectedValue = "-1";
                ddlBrands.SelectedValue = "-1";
            }
            else
            {
                string cmd = "SELECT CategoryID from Product WHERE ProductID=@0";
                id = SQLHelper.getID(cmd, ddlProduct.SelectedValue);
                ddlCategory.SelectedValue = id.ToString();

                cmd = "SELECT BrandID from Product WHERE ProductID=@0";
                id = SQLHelper.getID(cmd, ddlProduct.SelectedValue);
                ddlBrands.SelectedValue = id.ToString();
            }
        }
        LoadPrice();
        LoadRemQuantity();
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadProducts();
        Clears();
    }

    protected void ddlBrands_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCategory();
        LoadProducts();
        Clears();
    }

    private void LoadNetAmtNQty()
    {
        int qty = 0;
        double amt = 0.0d;
        List<BillData> lst = new List<BillData>();
        lst = (List<BillData>)Session["BillData"];
        foreach (var itm in lst)
        {
            qty += itm.Qty;
            amt += itm.NetAmout;
        }
        lblQty.Text = qty.ToString();
        lblAmt.Text = amt.ToString("#,###.00");
    }

    protected void btmSubmit_Click(object sender, EventArgs e)
    {
        if (Session["BillData"] == null)
        {
            lblMsg.Text = "Pleases Add Products!";
            return;
        }
        SqlConnection con = SQLHelper.GetConnection();
        con.Open();
        SqlTransaction tran = con.BeginTransaction();
        int InvNo = 1;
        string strcmd = "SELECT InvoiceNumber FROM InvoiceNumbers WHERE (Dated = @0)";
        try
        {
            SqlCommand cmd = new SqlCommand(strcmd, con, tran);
            cmd.Parameters.AddWithValue("@0", txtDate.Text);
            SqlDataAdapter dtadp = new SqlDataAdapter();
            dtadp.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dtadp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                InvNo = Convert.ToInt32(dt.Rows[0][0].ToString());
                InvNo++;
            }
            strcmd = "INSERT INTO InvoiceNumbers (InvoiceNumber, Dated) VALUES (@0, @1)";
            cmd = new SqlCommand(strcmd, con, tran);
            cmd.Parameters.AddWithValue("@0", InvNo);
            cmd.Parameters.AddWithValue("@1", txtDate.Text);
            cmd.ExecuteNonQuery();

            strcmd = "INSERT INTO SellParent (InvoiceNumber, CustomerID, Dated) VALUES (@0, @1, @2)";
            cmd = new SqlCommand(strcmd, con, tran);
            cmd.Parameters.AddWithValue("@0", InvNo);
            cmd.Parameters.AddWithValue("@1", ddlCust.SelectedValue);
            cmd.Parameters.AddWithValue("@2", txtDate.Text);
            cmd.ExecuteNonQuery();

            strcmd = "SELECT SellID FROM SellParent WHERE (InvoiceNumber = @0) AND (CustomerID = @1) AND (Dated = @2)";
            cmd = new SqlCommand(strcmd, con, tran);
            cmd.Parameters.AddWithValue("@0", InvNo);
            cmd.Parameters.AddWithValue("@1", ddlCust.SelectedValue);
            cmd.Parameters.AddWithValue("@2", txtDate.Text);
            dtadp = new SqlDataAdapter();
            dtadp.SelectCommand = cmd;
            dt = new DataTable();
            dtadp.Fill(dt);
            int SellID = Convert.ToInt32(dt.Rows[0][0].ToString());

            List<BillData> lst = new List<BillData>();
            lst = (List<BillData>)Session["BillData"];
            foreach (var itm in lst)
            {
                //itm.BrandID.ToString
                strcmd = "INSERT INTO SellChild (SellID, ProductID, CategoryID, BrandID, Quantity, Price) VALUES (@0, @1, @2, @3, @4, @5)";
                cmd = new SqlCommand(strcmd, con, tran);
                cmd.Parameters.AddWithValue("@0", SellID);
                cmd.Parameters.AddWithValue("@1", itm.ProductID);
                cmd.Parameters.AddWithValue("@2", itm.CateID);
                cmd.Parameters.AddWithValue("@3", itm.BrandID);
                cmd.Parameters.AddWithValue("@4", itm.Qty);
                cmd.Parameters.AddWithValue("@5", itm.Price);
                cmd.ExecuteNonQuery();

                strcmd = "SELECT OutQuantity FROM Stocks WHERE (ProductID = @0)";
                cmd = new SqlCommand(strcmd, con, tran);
                cmd.Parameters.AddWithValue("@0", itm.ProductID);
                dtadp = new SqlDataAdapter();
                dtadp.SelectCommand = cmd;
                dt = new DataTable();
                dtadp.Fill(dt);
                int outQty = 0;
                outQty = Convert.ToInt32(dt.Rows[0][0].ToString());

                strcmd = "UPDATE Stocks SET OutQuantity = @0 WHERE(ProductID = @1)";
                cmd = new SqlCommand(strcmd, con, tran);
                cmd.Parameters.AddWithValue("@0", (outQty + itm.Qty));
                cmd.Parameters.AddWithValue("@1", itm.ProductID);
                cmd.ExecuteNonQuery();
            }

            tran.Commit();
            con.Close();
            Session["BillData"] = null;
            Response.Redirect("~/Manager/BillPreview.aspx?id=" + SellID, false);

        }
        catch (Exception ex)
        {
            tran.Rollback();
            throw ex;
        }
    }

    protected void grdBillView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Del")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            List<BillData> lst = new List<BillData>();
            lst = (List<BillData>)Session["BillData"];
            lst.RemoveAt(index);
            Session["BillData"] = lst;
            grdBillView.DataSource = lst.ToList();
            grdBillView.DataBind();
            LoadNetAmtNQty();
            Clears();
        }
    }
}