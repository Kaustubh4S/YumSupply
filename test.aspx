<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.6.1.min.js"></script>
    <script src="../Scripts/bootstrap.bundle.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--Select Brand:--%><%--<asp:DropDownList ID="ddlBrand" runat="server"  AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="BrandName" DataValueField="BrandID">
            <asp:ListItem Value="-1">Select</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT [BrandID], [BrandName] FROM [Brands] ORDER BY [BrandName]"></asp:SqlDataSource>--%>            <%-- <br />
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
        </asp:SqlDataSource>--%>            <%--<div class="form-group row">
                <label for="name" class="col-4 col-form-label">Employee Name</label>
                <div class="col-8">
                    <asp:DropDownList ID="ddlBrand" runat="server" class="form-control here"></asp:DropDownList>
                </div>
            </div>--%>
            <%--            <select class="js-example-basic-single" name="state">
  <option value="AL">Alabama</option>
  <option value="WY">Wyoming</option>--%><%--</select>--%>

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <ajaxToolkit:ComboBox ID="ddlBrand" runat="server" AutoCompleteMode="SuggestAppend" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle w-75" DropDownStyle="DropDownList">
                    </ajaxToolkit:ComboBox>
                    <asp:DropDownList ID="ddlBrands" runat="server" AutoPostBack="True" CssClass="btn btn-secondary dropdown-toggle w-75" OnSelectedIndexChanged="ddlBrands_SelectedIndexChanged">
                    </asp:DropDownList>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
    <%-- <script>
        $(document).ready(function () {
            $("#<%= ddlBrand.ClientID %>").select2({
            placeholder: "Select an option",
            allowClear: true
        });
    });
    </script>--%>
    <script>
        //$(document).ready(function () {
        //    $("#ddlBrand").select2();
        //});

        //$(document).ready(function () {
        //    $('.js-example-basic-single').select2();
        //});
    </script>
</body>
</html>
