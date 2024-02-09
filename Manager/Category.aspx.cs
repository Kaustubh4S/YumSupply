using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_Category : System.Web.UI.Page
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
        if (HiddenField1.Value == "")
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
            string strCmd = "SELECT CategoryID FROM Category WHERE CategoryName='" + txtCategory.Text + "';";
            DataTable dt = SQLHelper.FillData(strCmd);
            if (dt.Rows.Count > 0)
            {
                lblMsg.Text = "Category is Already Existed!";
            }
            else
            {
                strCmd = "INSERT INTO Category(CategoryName) VALUES('" + txtCategory.Text + "');";
                SQLHelper.ExecuteNonQuery(strCmd);
                lblMsg.Text = "Category Added Sucessfully!";
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
        txtCategory.Text = "";
        txtCategory.Focus();
        grdVCategory.DataBind();
        btnAdd.Text = "Save";
        HiddenField1.Value = "";

    }

    private void UpdateBrand()
    {
        try
        {
            string strCmd = "SELECT CategoryID FROM Category WHERE CategoryName='" + txtCategory.Text + "' and CategoryID=" + HiddenField1.Value;
            DataTable dt = SQLHelper.FillData(strCmd);
            if (dt.Rows.Count > 0)
            {
                lblMsg.Text = "Category is Already Exist";
            }
            else
            {
                strCmd = "update Category set CategoryName='" + txtCategory.Text + "' where CategoryID=" + HiddenField1.Value;
                SQLHelper.ExecuteNonQuery(strCmd);
                lblMsg.Text = "Category updated Sucessfully!";
                Clears();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void grdVCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "up")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            HiddenField1.Value = grdVCategory.Rows[index].Cells[0].Text;
            txtCategory.Text = grdVCategory.Rows[index].Cells[1].Text;
            btnAdd.Text = "Update";
        }
    }
}