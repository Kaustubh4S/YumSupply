<%@ Page Title="Category" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Manager_Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h5 class="display-6">Category</h5>
        <hr />
    </div>
    <div>
        <div class="card card-body text-dark bg-light mb-3">
            <table class="w-100">
                <tr>
                    <td style="text-align: right;">Enter Category </td>
                    <td>
                        <asp:TextBox ID="txtCategory" runat="server" MaxLength="50" Width="268px" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCategory" Display="Dynamic" ErrorMessage="Please Enter Category Name" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
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

        <asp:GridView ID="grdVCategory" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-hover" DataKeyNames="CategoryID" DataSourceID="SqlDataSource1" ForeColor="Black" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" GridLines="Horizontal" OnRowCommand="grdVCategory_RowCommand" >
            <Columns>
                <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" InsertVisible="False" ReadOnly="True" SortExpression="CategoryID" />
                <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" SortExpression="CategoryName" />
                <asp:ButtonField CommandName="up" HeaderText="Update" ShowHeader="True" Text="Update" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT * FROM [Category] ORDER BY [CategoryName]"></asp:SqlDataSource>

    </div>
</asp:Content>

