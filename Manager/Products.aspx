﻿<%@ Page Title="Products" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Manager_Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/defaultLogin.css" rel="stylesheet" />
    <style type="text/css">
        .mt-3 {
            height: 97px;
            width: 1392px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h6 class="display-6">Products</h6>
        <hr />
    </div>
    <div class=" card-body text-dark bg-light mb-3">
        <table class="w-100 mt-3">
            <tr>

                <td>
                    <div class="form-data forms-inputs col-auto">
                        <span>Product Name</span>
                        <asp:TextBox ID="txtProductName" runat="server" CssClass="w-75" TextMode="SingleLine" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProductName" Display="Dynamic" ErrorMessage="Product Name can not be Empty" Font-Bold="True" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </td>
                <td>
                    <div class="form-data justify-content-center">
                        <asp:DropDownList ID="ddlBrand" runat="server" DataSourceID="SqlDataSource2" DataTextField="BrandName" DataValueField="BrandName" CssClass="btn btn-secondary dropdown-toggle w-75" AppendDataBoundItems="True">

                    <div class="form-data justify-content-center col-auto">
                        <asp:DropDownList ID="ddlBrand" runat="server" DataSourceID="SqlDataSource2" DataTextField="BrandName" DataValueField="BrandID" CssClass="btn btn-secondary dropdown-toggle w-75" AppendDataBoundItems="True">

                        <asp:DropDownList ID="ddlBrand" runat="server" DataSourceID="SqlDataSource2" DataTextField="BrandName" DataValueField="BrandID" CssClass="btn btn-secondary dropdown-toggle w-75" AppendDataBoundItems="True">

                            <asp:ListItem Selected="True" Value="-1">~Select Brand~</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT * FROM [Brands] ORDER BY [BrandName]"></asp:SqlDataSource>
                    </div>
                </td>
                <td>
                    <div class="form-data ">

                        <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="SqlDataSource3" DataTextField="CategoryName" CssClass="btn btn-secondary dropdown-toggle w-75" DataValueField="CategoryName" AppendDataBoundItems="True">

                    <div class="form-data justify-content-center col-auto">
                        <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="SqlDataSource3" DataTextField="CategoryName" CssClass="btn btn-secondary dropdown-toggle w-75" DataValueField="CategoryID" AppendDataBoundItems="True">

                        <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="SqlDataSource3" DataTextField="CategoryName" CssClass="btn btn-secondary dropdown-toggle w-75" DataValueField="CategoryID" AppendDataBoundItems="True">

                            <asp:ListItem Selected="True" Value="-1">~Select Category~</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT * FROM [Category] ORDER BY [CategoryName]"></asp:SqlDataSource>
                    </div>
                </td>
                <td>
                    <div class="form-data forms-inputs col-auto">
                        <span>Price</span>
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="w-75" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Price should not be Empty" ControlToValidate="txtPrice" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                </td>
                <td>
                    <div class="form-data forms-inputs col-auto">
                        <span>Quantity</span>
                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="w-75" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Quantity should not be Empty" ControlToValidate="txtQuantity" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </div>
                </td>
            </tr>

            <tr>
                <td colspan="5">
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <div class="form-data">
                        <center>
                            <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary mt-4" OnClick="btnAdd_Click" Text="Add" />
                            <asp:Label ID="lblMsg" runat="server" ForeColor="#3399FF"></asp:Label>
                        </center>
                    </div>
                </td>
            </tr>
        </table>
    </div>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT Product.ProductID, Product.ProductName, Brands.BrandName, Category.CategoryName, Product.Price, Product.Date FROM Brands INNER JOIN Product ON Brands.BrandID = Product.BrandID INNER JOIN Category ON Product.CategoryID = Category.CategoryID ORDER BY Product.ProductName"></asp:SqlDataSource>

        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-hover" DataKeyNames="ProductID" DataSourceID="SqlDataSource1" ForeColor="Black" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" GridLines="Horizontal">

    <div class=" card-body text-dark bg-light mb-3">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT Product.ProductID, Product.ProductName, Brands.BrandName, Category.CategoryName, Product.Price, AddStocks.Quantity, Product.Date FROM AddStocks INNER JOIN Brands ON AddStocks.BrandID = Brands.BrandID INNER JOIN Category ON AddStocks.CategoryID = Category.CategoryID INNER JOIN Product ON AddStocks.ProductID = Product.ProductID AND Brands.BrandID = Product.BrandID AND Category.CategoryID = Product.CategoryID"></asp:SqlDataSource>
        <asp:GridView ID="grdProducts" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-hover" DataKeyNames="ProductID" DataSourceID="SqlDataSource1" ForeColor="Black" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" GridLines="Horizontal" OnRowCommand="grdProducts_RowCommand" AllowSorting="True">


        <asp:GridView ID="grdProducts" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-hover" DataKeyNames="ProductID" DataSourceID="SqlDataSource1" ForeColor="Black" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" GridLines="Horizontal" OnRowCommand="grdProducts_RowCommand" AllowSorting="True">

            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="Product ID" InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                <asp:BoundField DataField="BrandName" HeaderText="Brand Name" SortExpression="BrandName" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category Name" SortExpression="CategoryName" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />


                <asp:ButtonField CommandName="up" ShowHeader="True" Text="Update" />

                <asp:ButtonField CommandName="up" HeaderText="Update" Text="Update" />


                <asp:ButtonField CommandName="up" ShowHeader="True" Text="Update" HeaderText="Update" />

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

