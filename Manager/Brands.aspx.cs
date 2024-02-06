using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_Brands : System.Web.UI.Page
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
        if(HiddenField1.Value=="")
        {
            //save
            SaveBrand();
        }
        else
        {
            //update
            UpdateBrand();
        }
        
    }

    private void SaveBrand()
    {
        try
        {
            string strCmd = "SELECT BrandID FROM Brands WHERE BrandName='" + txtBrandName.Text + "';";
            DataTable dt = SQLHelper.FillData(strCmd);
            if (dt.Rows.Count > 0)
            {
                lblMsg.Text = "Brand is Already Existed!";
            }
            else
            {
                strCmd = "INSERT INTO Brands(BrandName) VALUES('" + txtBrandName.Text + "');";
                SQLHelper.ExecuteNonQuery(strCmd);
                lblMsg.Text = "Brand Added Sucessfully!";
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
        txtBrandName.Text = "";
        txtBrandName.Focus();
        grdVBrands.DataBind();
        btnAdd.Text = "Save";
        HiddenField1.Value = "";
       
    }

    private void UpdateBrand()
    {
        try
        {
            string strCmd = "SELECT BrandID FROM Brands WHERE BrandName='" + txtBrandName.Text + "' and BrandID<>" + HiddenField1.Value;
            DataTable dt = SQLHelper.FillData(strCmd);
            if (dt.Rows.Count > 0)
            {
                lblMsg.Text = "Brand is Already Exist";
            }
            else
            {
                strCmd = "update Brands set BrandName='"+ txtBrandName.Text +"' where BrandID=" + HiddenField1.Value;
                SQLHelper.ExecuteNonQuery(strCmd);
                lblMsg.Text = "Brand updated Sucessfully!";
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
        if(e.CommandName=="Ed")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            HiddenField1.Value = grdVBrands.Rows[index].Cells[0].Text;
            txtBrandName.Text = grdVBrands.Rows[index].Cells[1].Text;
            btnAdd.Text = "Update";
        }
    }

    protected void grdVBrands_SelectedIndexChanged(object sender, EventArgs e)
    {
        string secondCellValue = grdVBrands.SelectedRow.Cells[0].ToString();
        lblMsg.Text = secondCellValue;
    }
}