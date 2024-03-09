using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BillData
/// </summary>
public class BillData
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public int BrandID { get; set; }
    public string BrandName { get; set; }
    public int CateID { get; set; }
    public string CatName { get; set; }
    public double Price { get; set; }
    public int Qty { get; set; }
    public double NetAmout { get; set; }
}