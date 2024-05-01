<%@ Page Title="Reports" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Manager_Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/defaultLogin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h6 class="display-6">Reports</h6>
        <hr />
    </div>

    <div class="card-body text-dark bg-light mb-3">
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

            <tr>
                <td>
                    <div class="form-data forms-inputs col-auto mt-4">
                        <span>From Date</span>
                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="w-75" TextMode="Date" ValidationGroup="ConfirmBeforeAdd" CausesValidation="True" AutoPostBack="True" OnTextChanged="txtFromDate_TextChanged"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <div class="form-data forms-inputs col-auto mt-4">
                        <span>To Date</span>
                        <asp:TextBox ID="txtToDate" runat="server" CssClass="w-75" TextMode="Date" ValidationGroup="ConfirmBeforeAdd" CausesValidation="True" AutoPostBack="True" OnTextChanged="txtToDate_TextChanged"></asp:TextBox>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <br />

    <div class=" card-body text-dark bg-light mb-4">
        <asp:GridView ID="grdReports" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-hover" ForeColor="Black" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" EmptyDataText="Record not found" GridLines="Horizontal" AllowSorting="True" OnPageIndexChanging="grdReports_PageIndexChanging">
            <AlternatingRowStyle BackColor="Silver" />
            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="Product ID" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category Name" />
                <asp:BoundField DataField="BrandName" HeaderText="Brand Name" />
                <asp:BoundField DataField="Price" HeaderText="Selled Price" />
                <asp:BoundField DataField="Quantity" HeaderText="Selled Quantity" />
                <asp:BoundField DataField="NetAmt" HeaderText="Total Amount" />
                <asp:BoundField DataField="Dated" HeaderText="Sell Date" DataFormatString="{0:dd-MMMM-yyyy}" />
                <asp:BoundField DataField="Qty" HeaderText="Reamining Quantity" />
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
