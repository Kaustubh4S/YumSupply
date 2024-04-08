<%@ Page Title="Customers" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="Customers.aspx.cs" Inherits="Manager_Customers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Content/defaultLogin.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h6 class="display-6">Manage Customers</h6>
        <hr />
    </div>

    <div class=" card-body text-dark bg-light mb-4">
        <table class="w-100">
            <tr class="m-5">
                <td>
                    <div class="form-data forms-inputs col-auto mt-2">
                        <span>Customer Full Name</span>
                        <asp:TextBox ID="txtCustName" runat="server" CssClass="w-75" TextMode="SingleLine" MaxLength="100"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="txtCustName_FilteredTextBoxExtender" runat="server" BehaviorID="txtCustName_FilteredTextBoxExtender" TargetControlID="txtCustName" ValidChars="QWERTYUIOPLKJHGFDSAZXCVBNM qwertyuioplkjhgfdsazxcvbnm" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCustName" Display="Dynamic" ErrorMessage="Customer Name can not be Empty" Font-Bold="True" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </td>

                <td>
                    <div class="form-data forms-inputs col-auto mt-2">
                        <span>Mobile Number</span>
                        <asp:TextBox ID="txtMobile" runat="server" CssClass="w-75" TextMode="Number" MaxLength="10"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="txtMobile_FilteredTextBoxExtender" runat="server" BehaviorID="txtMobile_FilteredTextBoxExtender" TargetControlID="txtMobile" ValidChars="0123456789" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMobile" Display="Dynamic" ErrorMessage="Mobile Number can not be Empty" Font-Bold="True" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </td>
                
                <td>
                    <div class="form-data forms-inputs col-auto mt-2">
                        <span>Discount</span>
                        <asp:TextBox ID="txtDisc" runat="server" CssClass="w-75" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDisc" Display="Dynamic" ErrorMessage="Discount Number can not be Empty" Font-Bold="True" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </td>
            </tr>

            <tr class="m-5">
                <td colspan="2">
                    <div class="form-data forms-inputs col-auto mt-4">
                        <span>Address Line1</span>
                        <asp:TextBox ID="txtAddress1" runat="server" CssClass="w-75" TextMode="MultiLine" MaxLength="50"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="txtAddress1_FilteredTextBoxExtender" runat="server" BehaviorID="txtAddress1_FilteredTextBoxExtender" TargetControlID="txtAddress1" ValidChars="QWERTYUIOPLKJHGFDSAZXCVBNM qwertyuioplkjhgfdsazxcvbnm,.'" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAddress1" Display="Dynamic" ErrorMessage="Address can not be Empty" Font-Bold="True" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </td>

                <td>
                    <div class="form-data forms-inputs col-auto mt-4">
                        <span>Address Line2</span>
                        <asp:TextBox ID="txtAddress2" runat="server" CssClass="w-75" TextMode="MultiLine" MaxLength="50"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="txtAddress2_FilteredTextBoxExtender" runat="server" BehaviorID="txtAddress2_FilteredTextBoxExtender" TargetControlID="txtAddress2" ValidChars="QWERTYUIOPLKJHGFDSAZXCVBNM qwertyuioplkjhgfdsazxcvbnm,.'" />
                    </div>
                </td>
            </tr>

            <tr class="m-5">
                <td>
                    <div class="form-data forms-inputs col-auto mt-4">
                        <span>State</span>
                        <asp:TextBox ID="txtState" runat="server" CssClass="w-75" TextMode="SingleLine" MaxLength="25"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="txtState_FilteredTextBoxExtender" runat="server" BehaviorID="txtState_FilteredTextBoxExtender" TargetControlID="txtState" ValidChars="QWERTYUIOPLKJHGFDSAZXCVBNMqwertyuioplkjhgfdsazxcvbnm" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtState" Display="Dynamic" ErrorMessage="State can not be Empty" Font-Bold="True" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </td>
                
                <td>
                    <div class="form-data forms-inputs col-auto mt-4">
                        <span>City</span>
                        <asp:TextBox ID="txtCity" runat="server" CssClass="w-75" TextMode="SingleLine" MaxLength="25"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="txtCity_FilteredTextBoxExtender" runat="server" BehaviorID="txtCity_FilteredTextBoxExtender" TargetControlID="txtCity" ValidChars="QWERTYUIOPLKJHGFDSAZXCVBNMqwertyuioplkjhgfdsazxcvbnm" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCity" Display="Dynamic" ErrorMessage="City can not be Empty" Font-Bold="True" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </td>

                <td>
                    <div class="form-data forms-inputs col-auto mt-4">
                        <span>Taluka</span>
                        <asp:TextBox ID="txtTaluka" runat="server" CssClass="w-75" TextMode="SingleLine" MaxLength="25"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="txtTaluka_FilteredTextBoxExtender" runat="server" BehaviorID="txtTaluka_FilteredTextBoxExtender" TargetControlID="txtTaluka" ValidChars="QWERTYUIOPLKJHGFDSAZXCVBNMqwertyuioplkjhgfdsazxcvbnm" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTaluka" Display="Dynamic" ErrorMessage="Taluka can not be Empty" Font-Bold="True" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </td>
            </tr>

            <tr>
                <td colspan="3">
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

    <div class=" card-body text-dark bg-light mb-4">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyCon %>" SelectCommand="SELECT DISTINCT * FROM [Customer] ORDER BY [CustomerName]"></asp:SqlDataSource>
        <asp:GridView ID="grdCustomers" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table table-hover" DataKeyNames="CustomerID" DataSourceID="SqlDataSource1" ForeColor="Black" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" GridLines="Horizontal" OnRowCommand="grdCustomers_RowCommand" AllowSorting="True">
            <AlternatingRowStyle BackColor="Silver" />
            <Columns>
                <asp:BoundField DataField="CustomerID" HeaderText="Customer ID" InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" />
                <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" SortExpression="CustomerName" />
                <asp:BoundField DataField="AddressLine1" HeaderText="Address Line1" SortExpression="AddressLine1" />
                <asp:BoundField DataField="AddressLine2" HeaderText="Address Line2" SortExpression="AddressLine2" />
                <asp:BoundField DataField="StateName" HeaderText="State" SortExpression="StateName" />
                <asp:BoundField DataField="DistrictName" HeaderText="City" SortExpression="DistrictName" />
                <asp:BoundField DataField="TalukaName" HeaderText="Taluka" SortExpression="TalukaName" />
                <asp:BoundField DataField="MobileNumber" HeaderText="Mobile Number" SortExpression="MobileNumber" />
                <asp:BoundField DataField="Discount" HeaderText="Discount" SortExpression="Discount" />
                <asp:ButtonField CommandName="Up" HeaderText="Update" ShowHeader="True" Text="Update" />
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

