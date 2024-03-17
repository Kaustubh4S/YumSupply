using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class Manager_BillPreview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id=getSellId();
        if (id == 0)
            return;
        LoadCustomer();
        LoadInvoiceDetails();
        LoadItems();
        LoadFinal();
    }

    private int getSellId()
    {
        return Convert.ToInt32(Request.QueryString["id"]);
    }

    private void LoadInvoiceDetails()
    {
        int SID = getSellId();
        string cmd = "SELECT InvoiceNumber, Dated FROM SellParent WHERE(SellID = @0)";
        DataTable dt = SQLHelper.FillData(cmd, SID);
        if (dt.Rows.Count > 0)
        {
            lblInv.Text = dt.Rows[0]["InvoiceNumber"].ToString();
            lblDate.Text = dt.Rows[0]["Dated"].ToString();
            lblBiller.Text = Session["FullName"].ToString();
        }
    }

    static void LoadPdf(string website, string destinationFile)
    {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = "~/Bin/wkhtmltopdf/bin/wkhtmltopdf.exe";
        startInfo.Arguments = website + " " + destinationFile;
        Process.Start(startInfo);
    }

    private void LoadCustomer()
    {
        int SID = getSellId();
        string cmd = "SELECT CustomerID FROM SellParent WHERE(SellID = @0)";
        int CID = SQLHelper.getID(cmd, SID);

        cmd = "SELECT CustomerName, Discount, AddressLine1, AddressLine2, StateName, DistrictName, TalukaName, MobileNumber FROM Customer WHERE(CustomerID = @0)";
        DataTable dt = SQLHelper.FillData(cmd, CID);
        if (dt.Rows.Count > 0)
        {
            lblCustName.Text = dt.Rows[0]["CustomerName"].ToString();
            lblAdd.Text = dt.Rows[0]["AddressLine1"].ToString();
            lblAdd.Text += " " + dt.Rows[0]["AddressLine2"].ToString();
            lblMob.Text = dt.Rows[0]["MobileNumber"].ToString();
            lblState.Text = dt.Rows[0]["TalukaName"].ToString();
            lblState.Text += ", " + dt.Rows[0]["DistrictName"].ToString();
            lblState.Text += ", " + dt.Rows[0]["StateName"].ToString();
        }
    }

    private void LoadItems()
    {
        string strcmd = "SELECT SellChild.Quantity, SellChild.Price, Product.ProductName, (SellChild.Quantity * SellChild.Price) AS Amount FROM SellChild INNER JOIN Product ON SellChild.ProductID = Product.ProductID WHERE(SellChild.SellID = @0) ORDER BY Product.ProductName ";
        DataTable dt = SQLHelper.FillData(strcmd, getSellId());
        RepeatInformation.DataSource = dt;
        RepeatInformation.DataBind();
    }
     
    private void LoadFinal()
    {
        string strcmd = "SELECT SUM(Quantity) As NetQty FROM SellChild WHERE(SellID = @0)";
        DataTable dt = SQLHelper.FillData(strcmd, getSellId());
        lblQty.Text = dt.Rows[0]["NetQty"].ToString();

        strcmd = "SELECT SUM(Quantity * Price) AS NetAmount FROM SellChild WHERE(SellID = @0) ";
        dt = SQLHelper.FillData(strcmd, getSellId());
        lblAmt.Text = dt.Rows[0]["NetAmount"].ToString();
        double netAmt = Convert.ToDouble(dt.Rows[0]["NetAmount"].ToString());

        strcmd = "SELECT CustomerID FROM SellParent WHERE(SellID = @0)";
        int CID = SQLHelper.getID(strcmd, getSellId());
        strcmd = "SELECT Discount FROM Customer WHERE(CustomerID = @0)";
        dt = SQLHelper.FillData(strcmd, CID);
        lblDisc.Text = dt.Rows[0]["Discount"].ToString() + "%";
        double disc = Convert.ToDouble(dt.Rows[0]["Discount"].ToString());

        lblTotal.Text = (netAmt - ((netAmt) * (disc / 100))).ToString();
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Panel.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        Panel1.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }
}