<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Select Brand:<asp:DropDownList ID="ddlBrand" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="BrandName" DataValueField="BrandID">
            <asp:ListItem Value="-1">Select</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT [BrandID], [BrandName] FROM [Brands] ORDER BY [BrandName]"></asp:SqlDataSource>
        <br />
        <br />
        Select Category:<asp:DropDownList ID="ddlCategory" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="CategoryName" DataValueField="CategoryID">
            <asp:ListItem Value="-1">Select</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT [CategoryID], [CategoryName] FROM [Category] ORDER BY [CategoryName]"></asp:SqlDataSource>
        <br />
        <br />
        Select Product:<asp:DropDownList ID="ddlProduct" runat="server" DataSourceID="SqlDataSource3" DataTextField="ProductName" DataValueField="ProductID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT [ProductID], [ProductName] FROM [Product] WHERE (([BrandID] = @BrandID) AND ([CategoryID] = @CategoryID)) ORDER BY [ProductName]">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlBrand" Name="BrandID" PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="ddlCategory" Name="CategoryID" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
