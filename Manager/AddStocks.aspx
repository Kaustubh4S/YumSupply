<%@ Page Title="Add Stocks" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="AddStocks.aspx.cs" Inherits="Manager_AddStocks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/defaultLogin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h6 class="display-6">Add Stocks</h6>
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

                <td>
                    <div class="form-data forms-inputs col-auto">
                        <span>Quantity</span>
                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="w-75" TextMode="Number"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="txtQuantity_FilteredTextBoxExtender" runat="server" BehaviorID="txtQuantity_FilteredTextBoxExtender" TargetControlID="txtQuantity" ValidChars="0123456789" />
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
    <br />
    <div class=" card-body text-dark bg-light mb-4">
        <asp:GridView ID="grdAddStocks" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-hover" ForeColor="Black" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" GridLines="Horizontal" AllowSorting="True">
            <AlternatingRowStyle BackColor="Silver" />
            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="Product ID" InsertVisible="False" ReadOnly="True" SortExpression="StockID" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category Name" SortExpression="CategoryName" />
                <asp:BoundField DataField="BrandName" HeaderText="Brand Name" SortExpression="BrandName" />
                <asp:BoundField DataField="InQty" HeaderText="In Quantity" SortExpression="InQuantity" />
                <asp:BoundField DataField="OutQty" HeaderText="Out Quantity" SortExpression="OutQuantity" />
                <asp:BoundField DataField="Qty" HeaderText="Quantity" SortExpression="Quantity" />
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
