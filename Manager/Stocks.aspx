<%@ Page Title="Stocks" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="Stocks.aspx.cs" Inherits="Manager_Stocks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/defaultLogin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h6 class="display-6">Stocks</h6>
        <hr />
    </div>

    <div class=" card-body text-dark bg-light mb-3">
        <table class="w-100 mt-3">
            <tr class="w-25">
                <td>
                    <div class="form-data justify-content-center col-auto">
                        <asp:DropDownList ID="ddlBrand" runat="server" CssClass="btn btn-secondary dropdown-toggle w-100" AutoPostBack="True" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </td>

                <td>
                    <div class="form-data justify-content-center col-auto">
                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="btn btn-secondary dropdown-toggle w-100" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </td>
                <td>
                    <div class="form-data justify-content-center col-auto">
                        <asp:DropDownList ID="ddlProduct" runat="server" CssClass="btn btn-secondary dropdown-toggle w-100" AutoPostBack="True" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div class=" card-body text-dark bg-light mb-4">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT Stocks.StockID, Product.ProductName, Category.CategoryName, Brands.BrandName, Stocks.InQuantity, Stocks.OutQuantity FROM Brands INNER JOIN Product ON Brands.BrandID = Product.BrandID INNER JOIN Category ON Product.CategoryID = Category.CategoryID INNER JOIN Stocks ON Brands.BrandID = Stocks.BrandID AND Product.ProductID = Stocks.ProductID AND Category.CategoryID = Stocks.CategoryID ORDER BY Stocks.StockID DESC"></asp:SqlDataSource>
        <asp:GridView ID="grdStocks" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-hover" DataKeyNames="StockID" ForeColor="Black" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" GridLines="Horizontal" AllowSorting="True" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="StockID" HeaderText="Stock ID" InsertVisible="False" ReadOnly="True" SortExpression="StockID" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category Name" SortExpression="CategoryName" />
                <asp:BoundField DataField="BrandName" HeaderText="Brand Name" SortExpression="BrandName" />
                <asp:BoundField DataField="InQuantity" HeaderText="In Quantity" SortExpression="InQuantity" />
                <asp:BoundField DataField="OutQuantity" HeaderText="Out Quantity" SortExpression="OutQuantity" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    </div>
</asp:Content>
