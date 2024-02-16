<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="Stocks.aspx.cs" Inherits="Manager_Stocks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/defaultLogin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h6 class="display-6">Stocks</h6>
        <hr />
    </div>

    <div class=" card-body text-dark bg-light mb-3">
        <table class="w-100 mt-3" border="1">
            <tr class="w-25">
                <td>
                    <div class="form-data justify-content-center col-auto">
                        <asp:DropDownList ID="ddlBrand" runat="server" DataSourceID="SqlDataSource1" DataTextField="BrandName" DataValueField="BrandID" CssClass="btn btn-secondary dropdown-toggle w-75" AppendDataBoundItems="True" AutoPostBack="True">
                            <asp:ListItem Selected="True" Value="-1">~Select Brand Name~</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT [BrandID], [BrandName] FROM [Brands] ORDER BY [BrandName]"></asp:SqlDataSource>
                    </div>
                </td>

                <td>
                    <div class="form-data justify-content-center col-auto">
                        <asp:DropDownList ID="ddlCategoryName" runat="server" DataSourceID="SqlDataSource2" DataTextField="CategoryName" DataValueField="CategoryID" CssClass="btn btn-secondary dropdown-toggle w-75" AutoPostBack="True" OnDataBinding="ddlCategoryName_DataBinding">
                            <asp:ListItem Selected="True" Value="-1">~Select Category Name~</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT Brands.BrandID, Category.CategoryID, Category.CategoryName FROM Brands CROSS JOIN Category WHERE ([BrandID] = @BrandID) ORDER BY Category.CategoryName ">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlBrand" Name="BrandID" PropertyName="SelectedValue" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </td>
                <td rowspan="3">
                    <div class="form-data justify-content-center col-auto">
                        <asp:DropDownList ID="ddlProductName" runat="server" DataSourceID="SqlDataSource3" DataTextField="ProductName" DataValueField="ProductID" CssClass="btn btn-secondary dropdown-toggle w-75" AppendDataBoundItems="True">
                            <asp:ListItem Selected="True" Value="-1">~Select Product Name~</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT [ProductID], [ProductName] FROM [Product] WHERE (([BrandID] = @BrandID) AND ([CategoryID] = @CategoryID)) ORDER BY [ProductName]">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ddlBrand" Name="BrandID" PropertyName="SelectedValue" Type="Int32" />
                                <asp:ControlParameter ControlID="ddlCategoryName" Name="CategoryID" PropertyName="SelectedValue" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
