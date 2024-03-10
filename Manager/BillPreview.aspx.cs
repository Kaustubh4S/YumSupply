using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_BillPreview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // LoadPdf(Request.Url.ToString(), "Temp");
        LoadCustomer();
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
        string id =Request.QueryString["id"];
        //lblInv.Text = id.ToString("00#");
    }
}