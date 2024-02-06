<%@ Page Title="Brands" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="Brands.aspx.cs" Inherits="Manager_Brands" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h5 class="display-6">Brands</h5>
        <hr />
    </div>
    <div>
        <div class="card card-body text-dark bg-light mb-3">
            <table class="w-100">
                <tr>
                    <td style="text-align: right;">Enter Brands </td>
                    <td>
                        <asp:TextBox ID="txtBrandName" runat="server" MaxLength="50" Width="268px" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBrandName" Display="Dynamic" ErrorMessage="Please Enter Brand Name" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </td>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnAdd_Click" />
                        <asp:Label ID="lblMsg" runat="server" ForeColor="#3399FF"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <br />
    <div class="card card-body text-dark bg-light mb-3">

        <asp:GridView ID="grdVBrands" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-hover" DataKeyNames="BrandID" DataSourceID="SqlDataSource1" ForeColor="Black" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" GridLines="Horizontal" OnRowCommand="grdVBrands_RowCommand">
            <Columns>
                <asp:BoundField DataField="BrandID" HeaderText="Brand ID" InsertVisible="False" ReadOnly="True" SortExpression="BrandID" />
                <asp:BoundField DataField="BrandName" HeaderText="Brand Name" SortExpression="BrandName" />
                <asp:ButtonField CommandName="Ed" Text="Edit" HeaderText="Edit" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT * FROM [Brands] ORDER BY [BrandName]"></asp:SqlDataSource>

    </div>
</asp:Content>

